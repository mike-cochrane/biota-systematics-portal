using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsData.Harvester.Service.Clients;
using SystematicsData.Models.Configuration;
using SystematicsData.Models.Entities.Annotations;
using SystematicsData.Models.Interfaces;
using SystematicsData.Utility.Helpers;

namespace SystematicsData.Harvester.Service.Strategies
{
    public class FieldConfigurationStrategy : IHarvesterActionStrategy
    {
        private readonly IDocumentsRepository _repository;

        public readonly AnnotationsClient _client;
        private readonly ILogger _logger;

        public FieldConfigurationStrategy(IDocumentsRepository repository, AnnotationsClient client, ILogger logger)
        {
            _repository = repository;
            _client = client;
            _logger = logger;
        }

        public async Task<int> ApplyStrategyAsync(XElement document)
        {
            _logger.LogInformation("{Action} - document: {document}", "Applying stategy FieldConfigurationStrategy", document);

            var documents = await GetDocumentsAsync(document);

            var results = await _repository.WriteDocuments(documents);

            return results;
        }

        private async Task<IEnumerable<XElement>> GetDocumentsAsync(XElement itemXml)
        {
            var item = SerializationHelper.Deserialize<Item>(itemXml.ToString());

            var configuredField = new Field()
            {
                Description = item.Notes.FirstOrDefault(n => n.NoteTypeId == "dd7e0148-fb46-4b6f-856e-cf6bc3aa75b9").Content,
                DocumentId = item.ItemId,
                Labels = item.Notes.Where(n => n.NoteTypeId == "ddf07fb9-edde-41f8-97b3-893c0d1c903f").Select(note => new Label()
                {
                    Title = note.Content,
                    Language = "TO BE DEFINED 2",
                }).ToList()
            };

            var xField = XElement.Parse(SerializationHelper.Serialize(configuredField));

            return new List<XElement>() { xField};
        }
    }
}