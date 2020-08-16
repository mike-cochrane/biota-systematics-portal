using System.Threading.Tasks;
using SystematicsData.Models.Entities.Access;
using SystematicsData.Web.Api.Client.Interfaces;
using SystematicsPortal.Web.Services.Interfaces;

namespace SystematicsPortal.Web.Services
{
    public class DocumentService : IDocumentService
    {
        public readonly ISystematicsDataClient _apiClient;

        public DocumentService(ISystematicsDataClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<Document> GetDocument(string id)
        {
            var documentXml = await _apiClient.GetDocument(id);

            return documentXml;
        }
    }
}
