using System.Threading.Tasks;
using SystematicsData.Models.Entities.Access;
using SystematicsData.Web.Api.Client.Interfaces;
using SystematicsPortal.Web.Services.Interfaces;

namespace SystematicsPortal.Web.Services
{
    public class ContentService : IContentService
    {
        private readonly ISystematicsDataClient _apiClient;


        public ContentService(ISystematicsDataClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<ContentConfigurations> GetContent(string page)
        {
            return await _apiClient.GeContent(page);
        }
    }
}
