using Annotations.Messaging.Contracts.Items;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystematicsPortal.Models.Interfaces;

namespace SystematicsPortal.Data.Harvester.Consumers
{
    class ItemUpdatedConsumer : IConsumer<IItemUpdated>
    {
        private readonly IDictionary<string, IHarvesterActionStrategy> _strategies;

        public ItemUpdatedConsumer(IDictionary<string, IHarvesterActionStrategy> strategies)
        {
            _strategies = strategies;
        }

        public async Task Consume(ConsumeContext<IItemUpdated> context)
        {
            await Task.Run(() => Console.WriteLine("Item Updated: " + context.Message.ItemId + " - " + context.Message.ResourceId));

            // Find the stratgey
            // Do the strategy

            // TODO: Listen for a message

            //var resourceId = "C7EA0FE3-40A4-453A-BBB8-9F1AAF6673D7";
            //var itemTypeId = "299B3954-6119-4265-AD5E-799CB7F53DE6";
            //// var itemId = "8F766C02-BD56-4B9A-BB35-27ED8F2E1826";
            //var itemId = "";

            //var selector = $"{resourceId}|{itemTypeId}";

           // var documentsToSave = await _strategies[selector].GetDocumentsAsync(resourceId, itemTypeId, itemId);

            //switch (resourceId)
            //{
            //    case "C7EA0FE3-40A4-453A-BBB8-9F1AAF6673D7":
            //        if (itemId == "8F766C02-BD56-4B9A-BB35-27ED8F2E1826")
            //        {
            //            var fieldReceiver = new FieldConfigurationStrategy(_client, null);

            //            documentsToSave = await fieldReceiver.GetDocumentsAsync(resourceId, itemTypeId, itemId);
            //        }
            //        if (itemTypeId == "299B3954-6119-4265-AD5E-799CB7F53DE6")
            //        {
            //            var contentReceiver = new StaticContentStrategy(_client, null);

            //            documentsToSave = await contentReceiver.GetDocumentsAsync(resourceId, itemTypeId, itemId);
            //        }
            //        break;

            //    default:
            //        break;
            //}

            //await _repository.WriteDocuments(documentsToSave);
        }
    }
}

namespace Annotations.Messaging.Contracts.Items
{
    public interface IItemUpdated
    {
        public string ItemId { get; set; }

        public string ResourceId { get; set; }
    }
}
