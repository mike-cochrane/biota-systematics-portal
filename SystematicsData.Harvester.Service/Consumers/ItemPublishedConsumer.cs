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
    /// <summary>
    /// Processes the Item Published events from the message broker.
    /// </summary>
    internal class ItemPublishedConsumer : IConsumer<IItemPublished>
    {
        private readonly IHarvesterStrategies _harvesterStrategies;
        private readonly AnnotationsClient _client;

        private readonly ILogger<ItemPublishedConsumer> _logger;

        public ItemPublishedConsumer(IHarvesterStrategies harvesterStrategies, AnnotationsClient client, ILogger<ItemPublishedConsumer> logger)
        {
            _harvesterStrategies = harvesterStrategies;
            _client = client;

            _logger = logger;
        }

        public async Task Consume(ConsumeContext<IItemPublished> context)
        {
            try
            {
                _logger.LogDebug("{Action} - ItemId: {ItemId} (ResourceId: {ResourceId})", "IItemPublished Received", context.Message.ItemId, context.Message.ResourceId);

                var item = await _client.GetItemXmlById(context.Message.ItemId);
                var itemTypeId = GetItemType(item);
                var selector = $"{context.Message.ResourceId}|{itemTypeId}";
                var strategy = _harvesterStrategies.GetStrategies()[selector];

                var results = await strategy.ApplyStrategyAsync(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
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
