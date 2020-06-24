using Microsoft.EntityFrameworkCore;
using Org.XmlUnit.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using SystematicsPortal.Data.Extensions;
using SystematicsPortal.Model.Interfaces;
using SystematicsPortal.Model.Models.Documents;
using SystematicsPortal.Model.Models.DTOs;
using SystematicsPortal.Utility.Helpers;
using SystematicsPortal.Model.Models.Access;
using System.Xml.Linq;

namespace SystematicsPortal.Data
{
    public class DocumentsRepository : IDocumentsRepository
    {
        private readonly NamesWebContext _context;


        public DocumentsRepository(NamesWebContext context)
        {
            _context = context;
        }

        public async Task<Model.Models.Access.Document> GetDocument(Guid documentId)
        {
            Model.Models.Access.Document documentAccess= null;
            var documentDb = await _context.Document.FirstOrDefaultAsync(doc => doc.DocumentId == documentId);

            if (!(documentDb is null))
            {
                documentAccess.XDocument = XDocument.Parse(documentDb.SerializedDocument);
            }

            return documentAccess;
        }

        public IEnumerable<Model.Models.Access.Document> GetDocuments()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Models.Access.Document> GetDocuments(IEnumerable<Guid> documentIds)
        {
            throw new NotImplementedException();
        }

        public void InsertDocument(Model.Models.Database.Document document)
        {
            _context.Document.Add(document);

        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void UpdateDocument(Model.Models.Access.Document document)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Writes name documents to the store and returns a list of names that were updated.
        /// </summary>
        public List<Model.Models.Documents.Name.Document> WriteDocuments(Model.Models.Documents.Name.Document[] names)
        {
            int index = 1;
            int consensusNameCount = names.Count();
            // var allStoreNames = GetDocuments().ToDictionary(o => o.NameId);
            var updatedNames = new List<Model.Models.Documents.Name.Document>();

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

                    InsertDocument(storeName);
                    //updatedNames.Add(name);
                    //_logger.Verbose("{Action} {NameId} {NameFullName}", "Add Consensus Name Document", name.NameId, name.FullName);
                }

                index++;
            }

            return updatedNames;
        }
    }
}
