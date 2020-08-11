using Annotations.Messaging.Contracts.Items;
using MassTransit;
using System;
using System.Threading.Tasks;
using SystematicsData.Harvester.Service.Clients;
using SystematicsData.Harvester.Service.Strategies.Interfaces;

namespace SystematicsData.Harvester.Service.Consumers
{
    internal class ItemUpdatedConsumer : IConsumer<IItemUpdated>
    {
        private readonly IHarvesterStrategies _harvesterStrategies;
        private readonly AnnotationsClient _client;


        public ItemUpdatedConsumer(IHarvesterStrategies harvesterStrategies, AnnotationsClient client)
        {
            _harvesterStrategies = harvesterStrategies;
            _client = client;
        }

        public async Task Consume(ConsumeContext<IItemUpdated> context)
        {
            await Task.Run(() => Console.WriteLine("Item Updated: " + context.Message.ItemId + " - " + context.Message.ResourceId));

            if (context.Message.ProducerAction == "Publish Note" || context.Message.ProducerAction == "Publish Item")
            {
                var item = await _client.GetItemXmlById(context.Message.ItemId);

                var itemTypeId =  item.Attribute("itemTypeId")?.ToString();

                var selector = $"{context.Message.ResourceId}|{itemTypeId}";

                var strategy = _harvesterStrategies.GetStrategies()[selector];

                var results = strategy.ApplyStrategyAsync(item);
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
