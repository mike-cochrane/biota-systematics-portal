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

namespace SystematicsPortal.Data.Harvester.Services
{
    public class HarvesterService
    {
        public readonly AnnotationsClient _client;
        private readonly ILogger<HarvesterService> _logger;
        private readonly IDocumentsRepository _repository;

        public HarvesterService(IDocumentsRepository repository, AnnotationsClient client, ILogger<HarvesterService> logger)
        {
            _repository = repository;
            _client = client;
            _logger = logger;
        }

        public async Task StartAsync()
        {
            var documents = new List<string>();
            // TODO: Listen for a message

            var resourceId = "C7EA0FE3-40A4-453A-BBB8-9F1AAF6673D7";
            var itemTypeId = "299B3954-6119-4265-AD5E-799CB7F53DE6";
            var itemId = "8F766C02-BD56-4B9A-BB35-27ED8F2E1826";

            var fields = await GetFieldsConfigurationAsync(resourceId, itemTypeId, itemId);

            await _repository.WriteDocuments(fields);
            //foreach (var item in fields)
            //{
            //    item.DocumentId = item.ItemId;
            //    var serializedItem = SerializationHelper.Serialize<Item>(item);

            //    await _repository.WriteDocument(serializedItem);
            //    //documents.Add(serializedItem);
            //}
        }

        public void Stop()
        {
            // write code here that runs when the Windows Service stops.
        }

        private async Task<List<XElement>> GetFieldsConfigurationAsync(string resourceId, string itemTypeId, string itemId)
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