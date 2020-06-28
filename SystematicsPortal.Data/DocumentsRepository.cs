using Microsoft.EntityFrameworkCore;
using Org.XmlUnit.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using SystematicsPortal.Model.Interfaces;
using SystematicsPortal.Model.Models.Access;
using SystematicsPortal.Utility.Helpers;

namespace SystematicsPortal.Data
{
    public class DocumentsRepository : IDocumentsRepository
    {
        private readonly NamesWebContext _context;


        public DocumentsRepository(NamesWebContext context)
        {
            _context = context;
        }

        public async Task<Document> GetDocument(Guid documentId)
        {
            Document documentAccess = null;
            var documentDb = await _context.Document.FirstOrDefaultAsync(doc => doc.DocumentId == documentId);

            if (!(documentDb is null))
            {
                documentAccess = new Document()
                {
                    XDocument = XDocument.Parse(documentDb.SerializedDocument),
                    XmlDocument = (new XmlDocument()),
                    SDocument = documentDb.SerializedDocument
                };

                documentAccess.XmlDocument.LoadXml(documentDb.SerializedDocument);
            }

            return documentAccess;
        }

        public Task InsertDocument(Model.Models.Database.Document document)
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
        /// Writes name documents to the store and returns a list of names that were updated.
        /// </summary>
        public async Task<int> WriteSerializedDocuments(Model.Models.Documents.Name.NameDocument[] names)
        {
            int index = 1;
            int consensusNameCount = names.Count();
            // var allStoreNames = GetDocuments().ToDictionary(o => o.NameId);

            foreach (var name in names)
            {
                // _logger.Verbose("{Action} {NameFullName} (Record {Index} of {NameCount})", "Process Consensus Name Document", name.FullName, index, consensusNameCount);

                string xml = SerializationHelper.Serialize(name);

                //if (allStoreNames.TryGetValue(Guid.Parse(name.nameId), out var storeName))
                //{
                //    var xmlComparer = DiffBuilder.Compare(Input.FromString(storeName.SerializedDocument))
                //        .WithTest(Input.FromString(xml))
                //        .WithNodeFilter(o => String.Equals(o.Name, "ModifiedDate", StringComparison.OrdinalIgnoreCase))
                //        .Build();

                //    if (xmlComparer.HasDifferences())
                //    {
                //        storeName.Version += 1;
                //        storeName.SerializedDocument = xml;

                //        UpdateDocument(storeName);
                //        updatedNames.Add(name);
                //        // _logger.Verbose("{Action} {NameId} {NameFullName} {Differences}", "Update Consensus Name Document", name.NameId, name.FullName, xmlComparer.ToString());
                //    }
                //}
                //else
                {
                    var storeName = new Model.Models.Database.Document();

                    storeName.DocumentId = Guid.Parse(name.nameId);
                    storeName.Version = 1;
                    storeName.SerializedDocument = xml;

                    await InsertDocument(storeName);
                    //updatedNames.Add(name);
                    //_logger.Verbose("{Action} {NameId} {NameFullName}", "Add Consensus Name Document", name.NameId, name.FullName);
                }


                index++;
            }

            var result = await SaveChanges();
            return result;
        }

        public async Task<int> WriteDocuments(XDocument documents)
        {
            var documentsElements = documents.Element("Documents");
            var documentsList = documentsElements.Descendants("Document");
            var allStoreNames = GetDocumentsDb().ToDictionary(o => o.DocumentId);

            foreach (var document in documentsList)
            {
                // _logger.Verbose("{Action} {NameFullName} (Record {Index} of {NameCount})", "Process Consensus Name Document", name.FullName, index, consensusNameCount);
                string documentId = (string)document.Attribute("nameId");

                if (string.IsNullOrEmpty(documentId))
                {
                    documentId = (string)document.Attribute("referenceId");

                    if (string.IsNullOrEmpty(documentId))
                    {
                        documentId = (string)document.Attribute("vernacularId");
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
                    storeDocument = new Model.Models.Database.Document();

                    storeDocument.DocumentId = Guid.Parse(documentId);
                    storeDocument.Version = 1;
                    storeDocument.SerializedDocument = document.ToString();

                    await InsertDocumentDb(storeDocument);
                    //_logger.Verbose("{Action} {NameId} {NameFullName}", "Add Consensus Name Document", name.NameId, name.FullName);
                }

            }

            var result = await SaveChanges();
            return result;
        }

        public IEnumerable<Document> GetDocuments()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Model.Models.Database.Document> GetDocumentsDb()
        {
            return _context.Document;

        }

        private async Task InsertDocumentDb(Model.Models.Database.Document document)
        {
            await _context.Document.AddAsync(document);
        }


        public async Task<int> SaveChanges()
        {
            var result = await _context.SaveChangesAsync();

            return result;
        }


    }
}
