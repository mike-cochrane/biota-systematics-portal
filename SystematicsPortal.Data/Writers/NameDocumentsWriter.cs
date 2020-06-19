
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using SystematicsPortal.Model.Interfaces;
//using SystematicsPortal.Model.Models.Documents;
//using SystematicsPortal.Utility.Helpers;

//namespace NZOR.Publish.Publisher.Writers.Documents
//{
//    class NameDocumentsWriter
//    {
//        private readonly INamesWebRepository _namesRepository;

//        private readonly ILogger _logger;

//        public NameDocumentsWriter(INamesWebRepository namesRepository, ILogger logger)
//        {
//            _namesRepository = namesRepository;
//            _logger = logger;
//        }

//        /// <summary>
//        /// Writes name documents to the store and returns a list of names that were updated.
//        /// </summary>
//        public List<NameDocumentDto> WriteDocuments(List<NameDocumentDto> names)
//        {
//            int index = 1;
//            int consensusNameCount = names.Count();
//            var allStoreNames = _namesRepository.GetDocuments().ToDictionary(o => o.nameId);
//            var updatedNames = new List<NameDocumentDto>();

//            foreach (var name in names)
//            {
//               // _logger.Verbose("{Action} {NameFullName} (Record {Index} of {NameCount})", "Process Consensus Name Document", name.FullName, index, consensusNameCount);

//                string xml = SerializationHelper.Serialize(name);

//                if (allStoreNames.TryGetValue(name.nameId, out var storeName))
//                {
//                    var xmlComparer = DiffBuilder.Compare(Input.FromString(storeName.SerializedDocument))
//                        .WithTest(Input.FromString(xml))
//                        .WithNodeFilter(o => String.Equals(o.Name, "ModifiedDate", StringComparison.OrdinalIgnoreCase))
//                        .Build();

//                    if (xmlComparer.HasDifferences())
//                    {
//                        storeName.Version += 1;
//                        storeName.SerializedDocument = xml;

//                        _namesRepository.UpdateDocument(storeName);
//                        updatedNames.Add(name);
//                       // _logger.Verbose("{Action} {NameId} {NameFullName} {Differences}", "Update Consensus Name Document", name.NameId, name.FullName, xmlComparer.ToString());
//                    }
//                }
//                else
//                {
//                    storeName = new ConsensusNameDocument();

//                    storeName.NameId = name.NameId;
//                    storeName.Version = 1;
//                    storeName.SerializedDocument = xml;

//                    _namesRepository.ConsensusNameDocuments.InsertDocument(storeName);
//                    updatedNames.Add(name);
//                    _logger.Verbose("{Action} {NameId} {NameFullName}", "Add Consensus Name Document", name.NameId, name.FullName);
//                }

//                index++;
//            }

//            return updatedNames;
//        }
//    }
//}
