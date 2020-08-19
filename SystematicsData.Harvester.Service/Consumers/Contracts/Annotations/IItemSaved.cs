namespace Annotations.Messaging.Contracts.Items
{
    public interface IItemSaved
    {
        public string ItemId { get; set; }

        public string ResourceId { get; set; }
    }
}
