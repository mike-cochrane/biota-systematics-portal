using Annotations.Messaging.Contracts.Items;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using SystematicsData.Harvester.Service.Clients;
using SystematicsData.Harvester.Service.Strategies.Interfaces;

namespace SystematicsData.Harvester.Service.Consumers
{
    /// <summary>
    /// Processes the Item Published events from the message broker.
    /// </summary>
    internal class ItemSavedConsumer : IConsumer<IItemSaved>
    {
        private readonly IHarvesterStrategies _harvesterStrategies;
        private readonly AnnotationsClient _client;

        private readonly ILogger<ItemSavedConsumer> _logger;

        public ItemSavedConsumer(IHarvesterStrategies harvesterStrategies, AnnotationsClient client, ILogger<ItemSavedConsumer> logger)
        {
            _harvesterStrategies = harvesterStrategies;
            _client = client;

            _logger = logger;
        }

        public async Task Consume(ConsumeContext<IItemSaved> context)
        {
            try
            {
                await Task.Run(() =>
                {
                    _logger.LogDebug($"SystematicsData.Harvester.Service - Message received: Item Saved: {context.Message.ItemId} resource: {context.Message.ResourceId}");
                });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
    }
}
