using Microsoft.EntityFrameworkCore;
using Org.XmlUnit.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using SystematicsPortal.Data.dbmodels;
using SystematicsPortal.Data.Extensions;
using SystematicsPortal.Model.Interfaces;
using SystematicsPortal.Model.Models.Documents;
using SystematicsPortal.Model.Models.DTOs;
using SystematicsPortal.Utility.Helpers;

namespace SystematicsPortal.Data
{
    public class NamesRepository : INamesWebRepository
    {
        private readonly NamesWebContext _context;


        public NamesRepository(NamesWebContext context)
        {
            _context = context;
        }

        public async Task<DocumentDto> GetDocument(Guid documentId)
        {
            DocumentDto documentDto = null;
            var documentDb = await _context.NameDocument.FirstOrDefaultAsync(doc => doc.NameId == documentId);

            if (!(documentDb is null))
            {
                documentDto = documentDb.ToDto();
            }

            return documentDto;
        }

        public IEnumerable<dbmodels.NameDocument> GetDocuments()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DocumentDto> GetDocuments(IEnumerable<Guid> documentIds)
        {
            throw new NotImplementedException();
        }

        public void InsertDocument(dbmodels.NameDocument document)
        {
            _context.NameDocument.Add(document);

            _context.SaveChanges();
        }

        public void UpdateDocument(DocumentDto document)
        {
            throw new NotImplementedException();
        }

        public void UpdateDocument(dbmodels.NameDocument document)
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
                    var storeName = new dbmodels.NameDocument();

                    storeName.NameId = Guid.Parse(name.nameId);
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

        IEnumerable<dbmodels.NameDocument> INamesWebRepository.GetDocuments(IEnumerable<Guid> documentIds)
        {
            throw new NotImplementedException();
        }
    }
}
