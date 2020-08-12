using Annotations.Messaging.Contracts.Items;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsData.Harvester.Service.Clients;
using SystematicsData.Harvester.Service.Strategies.Interfaces;

namespace SystematicsData.Harvester.Service.Consumers
{
    internal class ItemUpdatedConsumer : IConsumer<IItemUpdated>
    {
        private readonly IHarvesterStrategies _harvesterStrategies;
        private readonly AnnotationsClient _client;
        private readonly ILogger<ItemUpdatedConsumer> _logger;


        public ItemUpdatedConsumer(IHarvesterStrategies harvesterStrategies, AnnotationsClient client, ILogger<ItemUpdatedConsumer> logger)
        {
            _harvesterStrategies = harvesterStrategies;
            _client = client;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<IItemUpdated> context)
        {
            try
            {
                await Task.Run(() => Console.WriteLine("Item Updated: " + context.Message.ItemId + " - " + context.Message.ResourceId));

                _logger.LogDebug($"SystematicsData.Harvester.Service - Message received: Item updated: {context.Message.ItemId} resource: {context.Message.ResourceId}");

                if (context.Message.ProducerAction == "Publish Note" || context.Message.ProducerAction == "Publish Item")
                {
                    var item = await _client.GetItemXmlById(context.Message.ItemId);

                    var itemTypeId = GetItemType(item);

                    var selector = $"{context.Message.ResourceId}|{itemTypeId}";

                    var strategy = _harvesterStrategies.GetStrategies()[selector];

                    var results = await strategy.ApplyStrategyAsync(item);
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
            }
        }

        private string GetItemType(XElement item)
        {
            var itemType = item.Element("itemType");

            var itemTypeId = itemType.Attribute("itemTypeId")?.Value?.ToString();


            if (itemTypeId == null)
            {
                throw new Exception($"Not able to retrieve itemTypeId from item {itemType.Attribute("itemId")?.ToString()}");
            }

            return itemTypeId;
        }
    }
}

namespace Annotations.Messaging.Contracts.Items
{
    public interface IItemUpdated
    {
        public string ItemId { get; set; }

        public string ResourceId { get; set; }

        public string ProducerAction { get; set; }

        public string ProducerType { get; set; }
    }
}
