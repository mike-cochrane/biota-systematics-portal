using System.Threading.Tasks;
using SystematicsData.Models.Entities.Access;
using SystematicsData.Web.Api.Client;
using SystematicsPortal.Web.Services.Interfaces;

namespace SystematicsPortal.Web.Services
{
    public class ContentService : IContentService
    {
        private readonly Client _apiClient;


        public ContentService(Client apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<ContentConfigurations> GetContent(string page)
        {
            return await _apiClient.GeContent(page);
        }
    }
}
