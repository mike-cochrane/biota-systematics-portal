using Microsoft.EntityFrameworkCore;
using Org.XmlUnit.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsPortal.Models.Entities.Access;
using SystematicsPortal.Models.Infrastructure.Exceptions;
using SystematicsPortal.Models.Interfaces;

namespace SystematicsPortal.Data
{
    public class DocumentsRepository : IDocumentsRepository
    {
        private readonly NamesWebContext _context;


        public DocumentsRepository(NamesWebContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get specific document based on document id.
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns>Document access model with docuemnt as XmlDocument property</returns>
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
        public async Task<int> WriteDocuments(XDocument documents)
        {
            var documentsElements = documents.Element("Documents");
            var documentsList = documentsElements.Descendants("Document");
            var allStoreNames = GetDocumentsDb().ToDictionary(o => o.DocumentId);

            foreach (var document in documentsList)
            {
                // _logger.Verbose("{Action} {NameFullName} (Record {Index} of {NameCount})", "Process Consensus Name Document", name.FullName, index, consensusNameCount);
                string documentId = (string)document.Attribute("documentId");

                if (String.IsNullOrEmpty(documentId))
                {
                    documentId = (string)document.Attribute("nameId");

                    if (String.IsNullOrEmpty(documentId))
                    {
                        documentId = (string)document.Attribute("referenceId");

                        if (String.IsNullOrEmpty(documentId))
                        {
                            documentId = (string)document.Attribute("vernacularId");
                        }
                    }
                }

                if (allStoreNames.TryGetValue(Guid.Parse(documentId), out var storeDocument))
                {
                    var xmlComparer = DiffBuilder.Compare(Input.FromString(storeDocument.SerializedDocument))
                        .WithTest(Input.FromString(document.ToString()))
                        .WithNodeFilter(o => String.Equals(o.Name, "ModifiedDate", StringComparison.OrdinalIgnoreCase))
                        .Build();

                    if (xmlComparer.HasDifferences())
                    {
                        storeDocument.Version += 1;
                        storeDocument.SerializedDocument = document.ToString();

                        // _logger.Verbose("{Action} {NameId} {NameFullName} {Differences}", "Update Consensus Name Document", name.NameId, name.FullName, xmlComparer.ToString());
                    }
                }
                else
                {
                    storeDocument = new Models.Entities.Database.Document();

                    storeDocument.DocumentId = Guid.Parse(documentId);
                    storeDocument.Version = 1;
                    storeDocument.SerializedDocument = document.ToString();

                    await InsertDocumentDbAsync(storeDocument);
                    //_logger.Verbose("{Action} {NameId} {NameFullName}", "Add Consensus Name Document", name.NameId, name.FullName);
                }

            }

            var result = await SaveChangesAsync();

            return result;
        }

        public IEnumerable<Document> GetDocuments()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Models.Entities.Database.Document> GetDocumentsDb()
        {
            return _context.Document;

        }

        private async Task InsertDocumentDbAsync(Models.Entities.Database.Document document)
        {
            await _context.Document.AddAsync(document);
        }


        public async Task<int> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();

            return result;
        }
    }
}
