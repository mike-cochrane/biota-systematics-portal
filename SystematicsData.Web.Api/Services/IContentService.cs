using System.Threading.Tasks;
using SystematicsData.Models.Entities.Access;

namespace SystematicsData.Web.Api.Services
{
    public interface IContentService
    {
        Task<ContentConfigurations> GetContentAsync(string page);
    }
}
