using System.Threading.Tasks;
using SystematicsData.Models.Entities.Access;

namespace SystematicsData.Web.Api.Services.Interfaces
{
    public interface IContentService
    {
        Task<ContentConfigurations> GetContentAsync(string page);
    }
}
