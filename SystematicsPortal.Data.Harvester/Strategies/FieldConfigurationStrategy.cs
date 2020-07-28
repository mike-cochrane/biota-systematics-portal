using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsPortal.Data.Harvester.Clients;
using SystematicsPortal.Models.Configuration;
using SystematicsPortal.Models.Interfaces;
using SystematicsPortal.Utility.Helpers;

namespace SystematicsPortal.Data.Harvester.Classes
{
    public class FieldConfigurationStrategy : IHarvesterActionStrategy
    {
        private readonly IDocumentsRepository _repository;

        public readonly AnnotationsClient _client;
        private readonly ILogger<FieldConfigurationStrategy> _logger;

        public FieldConfigurationStrategy(IDocumentsRepository repository, AnnotationsClient client, ILogger<FieldConfigurationStrategy> logger)
        {
            _repository = repository;
            _client = client;
            _logger = logger;
        }

        public async Task<int> ApplyStrategyAsync(string resourceId, string itemTypeId, string itemId)
        {
            var documents = await GetDocumentsAsync(resourceId, itemTypeId, itemId);

            var results = await _repository.WriteDocuments(documents);

            return results;
        }

        private async Task<IEnumerable<XElement>> GetDocumentsAsync(string resourceId, string itemTypeId, string itemId)
        {
            List<XElement> xFields = new List<XElement>();

            var items = await _client.GetItemsByIds(new List<string>() { itemId });

            var foundItem = items.ItemsList[0];

            if (foundItem == null)
            {
                throw new Exception($"Item {itemId} has not been found");
            }

            var relatedItemsIds = foundItem.relatedItems.Select(x => x.RelatedItemId).ToList();

            var relatedItems = await _client.GetItemsByIds(relatedItemsIds);

            var configuredFields = relatedItems.ItemsList.Select(i => new Field()
            {
                Description = i.Notes.FirstOrDefault(n => n.NoteTypeId == "dd7e0148-fb46-4b6f-856e-cf6bc3aa75b9").Content,
                DocumentId = i.ItemId,
                Labels = i.Notes.Where(n => n.NoteTypeId == "ddf07fb9-edde-41f8-97b3-893c0d1c903f").Select(note => new Label()
                {
                    Title = note.Content,
                    Language = "TO BE DEFINED 2",
                }).ToList()
            }).ToList();

            xFields = configuredFields.Select(field => XElement.Parse(SerializationHelper.Serialize(field))).ToList();

            return xFields;
        }
    }
}