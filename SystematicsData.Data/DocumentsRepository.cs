using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Org.XmlUnit.Builder;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsData.Models.Entities.Access;
using SystematicsData.Models.Infrastructure.Exceptions;
using SystematicsData.Models.Interfaces;

namespace SystematicsData.Data
{
    public class DocumentsRepository : IDocumentsRepository
    {
        private readonly NamesWebContext _context;

        private readonly ILogger _logger;

        public DocumentsRepository(NamesWebContext context, ILogger<DocumentsRepository> logger)
        {
            _context = context;

            _logger = logger;
        }

        /// <summary>
        /// Get specific document based on document id.
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns>Document access model with document as XmlDocument property</returns>
        public async Task<Document> GetDocumentAsync(Guid documentId)
        {
            Document documentAccess = new Document();

            var documentDb = await _context.Document.FirstOrDefaultAsync(doc => doc.DocumentId == documentId);

            if (documentDb is null)
            {
                throw new NotFoundException($"Document with Id: {documentId} has not been found", null);
            }

            documentAccess.XmlDocument.LoadXml(documentDb.SerializedDocument);

            return documentAccess;
        }

        public Task InsertDocument(Models.Entities.Database.Document document)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Document> GetDocuments(IEnumerable<Guid> documentIds)
        {
            throw new NotImplementedException();
        }

        public void UpdateDocument(Document document)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes documents to the store and returns a number of documents that were updated.
        /// </summary>
        /// <param name="documents">The document contents as Xml.</param>
        public async Task<int> WriteDocuments(IEnumerable<XElement> documents)
        {
            int savedCount;

            using var transaction = await _context.Database.BeginTransactionAsync();
            {
                try
                {
                    foreach (var document in documents)
                    {
                        await SaveDocument(document);
                    }

                    savedCount = await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();

                    throw;
                }
            }

            return savedCount;
        }

        /// <summary>
        /// Saves a document to the data store if there is a change after comparing the contents.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        private async Task SaveDocument(XElement document)
        {
            string documentId = (string)document.Attribute("documentId");

            if (String.IsNullOrEmpty(documentId))
            {
                throw new InvalidInputException("DocumentId has not been found");
            }

            _logger.LogDebug("{Action} - DocumentId: {documentId} - Document: {document}", "Save Document", documentId, document);

            var storeDocument = await _context.Document.FindAsync(new Guid(documentId));

            if (storeDocument != null)
            {
                var xmlComparer = DiffBuilder.Compare(Input.FromString(storeDocument.SerializedDocument))
                    .WithTest(Input.FromString(document.ToString()))
                    .Build();

                if (xmlComparer.HasDifferences())
                {
                    storeDocument.Version += 1;
                    storeDocument.SerializedDocument = document.ToString();

                    //    _logger.LogDebug("{Action} - {DocumentId} - Number of documents saved {NumberOfDocuments}", "Update Document", documentId, result);
                }
            }
            else
            {
                storeDocument = new Models.Entities.Database.Document
                {
                    DocumentId = Guid.Parse(documentId),
                    Version = 1,
                    SerializedDocument = document.ToString()
                };

                await _context.Document.AddAsync(storeDocument);

                //     _logger.LogDebug("{Action} - {DocumentId} - Number of documents saved {NumberOfDocuments}", "Update Document", documentId, result);
            }
        }

        public IEnumerable<Document> GetDocuments()
        {
            throw new NotImplementedException();
        }
    }
}