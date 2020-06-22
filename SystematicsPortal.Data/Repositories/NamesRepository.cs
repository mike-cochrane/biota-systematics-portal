using Org.XmlUnit.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystematicsPortal.Data.dbmodels;
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

        public DocumentDto GetDocument(Guid documentId)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
        public List<DocumentDto> WriteDocuments(List<DocumentDto> names)
        {
            int index = 1;
            int consensusNameCount = names.Count();
            var allStoreNames = GetDocuments().ToDictionary(o => o.NameId);
            var updatedNames = new List<DocumentDto>();

            foreach (var name in names)
            {
                // _logger.Verbose("{Action} {NameFullName} (Record {Index} of {NameCount})", "Process Consensus Name Document", name.FullName, index, consensusNameCount);

                string xml = SerializationHelper.Serialize(name);

                if (allStoreNames.TryGetValue(Guid.Parse(name.NameId), out var storeName))
                {
                    var xmlComparer = DiffBuilder.Compare(Input.FromString(storeName.SerializedDocument))
                        .WithTest(Input.FromString(xml))
                        .WithNodeFilter(o => String.Equals(o.Name, "ModifiedDate", StringComparison.OrdinalIgnoreCase))
                        .Build();

                    if (xmlComparer.HasDifferences())
                    {
                        storeName.Version += 1;
                        storeName.SerializedDocument = xml;

                        UpdateDocument(storeName);
                        updatedNames.Add(name);
                        // _logger.Verbose("{Action} {NameId} {NameFullName} {Differences}", "Update Consensus Name Document", name.NameId, name.FullName, xmlComparer.ToString());
                    }
                }
                else
                {
                    storeName = new dbmodels.NameDocument();

                    storeName.NameId = Guid.Parse(name.NameId);
                    storeName.Version = 1;
                    storeName.SerializedDocument = xml;

                    InsertDocument(storeName);
                    updatedNames.Add(name);
                    //_logger.Verbose("{Action} {NameId} {NameFullName}", "Add Consensus Name Document", name.NameId, name.FullName);
                }

                index++;
            }

            return updatedNames;
        }

        dbmodels.NameDocument INamesWebRepository.GetDocument(Guid documentId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<dbmodels.NameDocument> INamesWebRepository.GetDocuments(IEnumerable<Guid> documentIds)
        {
            throw new NotImplementedException();
        }
    }
}
