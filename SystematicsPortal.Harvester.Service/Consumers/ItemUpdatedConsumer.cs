using Annotations.Messaging.Contracts.Items;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystematicsPortal.Models.Interfaces;

namespace SystematicsPortal.Harvester.Service.Consumers
{
    internal class ItemUpdatedConsumer : IConsumer<IItemUpdated>
    {
        private readonly IHarvesterStrategies _harvesterStrategies;

        public ItemUpdatedConsumer(IHarvesterStrategies harvesterStrategies)
        {
            _harvesterStrategies = harvesterStrategies;
        }

        public async Task Consume(ConsumeContext<IItemUpdated> context)
        {
            await Task.Run(() => Console.WriteLine("Item Updated: " + context.Message.ItemId + " - " + context.Message.ResourceId));

            if (context.Message.ProducerAction == "Publish Note" || context.Message.ProducerAction == "Publish Item")
            {
                // TODO: 
                // Get itemTypeId from Annotations Access API using itemId. Now hardcoding to continue development
                var itemTypeId = "299b3954-6119-4265-ad5e-799cb7f53de6";

                var selector = $"{context.Message.ResourceId}|{itemTypeId}";

                var strategy = _harvesterStrategies.GetStrategies()[selector];

                var results = strategy.ApplyStrategyAsync(context.Message.ResourceId, itemTypeId, context.Message.ItemId);
            }
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
