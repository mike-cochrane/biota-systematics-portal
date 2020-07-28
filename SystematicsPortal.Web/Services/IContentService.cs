using System.Threading.Tasks;
using SystematicsPortal.Models.Entities.Access;

namespace SystematicsPortal.Web.Services
{
    public interface IContentService
    {
        Task<ContentConfigurations> GetContent(string page);
    }
}
