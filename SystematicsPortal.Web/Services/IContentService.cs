using System.Collections.Generic;
using System.Threading.Tasks;
using Systematics.Portal.Model.Models.Annotations;

namespace SystematicsPortal.Web.Services
{
    public interface IContentService
    {
        Task<Resources> GetResources();
        Task<ItemTypes> GetItemTypes(string resourceId);
        Task<Items> GetItemIds(string itemTypeId);
        Task<Items> GetItemsByIds(List<string> itemIds);
    }
}
