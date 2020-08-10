using System.Collections.Generic;
using System.Threading.Tasks;
using SystematicsData.Models.Entities.Annotations;

namespace SystematicsData.Models.Interfaces
{
    public interface IAnnotationsClient
    {
        Task<Resources> GetResources();
        Task<ItemTypes> GetItemTypes(string resourceId);
        Task<Items> GetItemIds(string itemTypeId);
        Task<Items> GetItemsByIds(List<string> itemIds);
    }
}
