using Annotations.Messaging.Contracts.Items;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace SystematicsPortal.Data.Harvester.Consumers
{
    class ItemSavedConsumer : IConsumer<IItemSaved>
    {
        public async Task Consume(ConsumeContext<IItemSaved> context)
        {
            await Task.Run(() => Console.WriteLine("Item Saved: " + context.Message.ItemId + " - " + context.Message.ResourceId));
        }
    }
}

namespace Annotations.Messaging.Contracts.Items
{
    public interface IItemSaved
    {
        public string ItemId { get; set; }

        public string ResourceId { get; set; }
    }
}
