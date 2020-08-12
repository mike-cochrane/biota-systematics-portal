using System.Threading.Tasks;
using SystematicsData.Models.Entities.Access;

namespace SystematicsPortal.Web.Services.Interfaces
{
    public interface IContentService
    {
        Task<ContentConfigurations> GetContent(string page);
    }
}
