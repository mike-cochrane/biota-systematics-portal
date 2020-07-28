using System.Threading.Tasks;
using SystematicsPortal.Models.Entities.Access;

namespace SystematicsPortal.Web.Services
{
    public class ContentService : IContentService
    {
        private readonly Api.Client.Client _apiClient;


        public ContentService(Api.Client.Client apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<ContentConfigurations> GetContent(string page)
        {
            return await _apiClient.GeContent(page);
        }
    }
}
