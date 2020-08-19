namespace Annotations.Messaging.Contracts.Items
{
    public interface IItemPublished
    {
        public string ItemId { get; set; }

        public string ResourceId { get; set; }
    }
}
