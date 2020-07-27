using Annotations.Messaging.Contracts.Items;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace SystematicsPortal.Data.Harvester.Consumers
{
    class NotePublishedConsumer : IConsumer<INotePublished>
    {
        public async Task Consume(ConsumeContext<INotePublished> context)
        {
            await Task.Run(() => Console.WriteLine("Note Published: " + context.Message.NoteId + " - " + context.Message.ResourceId));
        }
    }
}

namespace Annotations.Messaging.Contracts.Items
{
    public interface INotePublished
    {
        public string NoteId { get; set; }

        public string ResourceId { get; set; }
    }
}
