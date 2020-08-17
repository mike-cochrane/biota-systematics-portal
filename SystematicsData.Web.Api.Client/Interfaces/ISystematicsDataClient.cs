using System.Threading.Tasks;
using SystematicsData.Models.Entities.Access;
using SystematicsData.Search.Models;
using SystematicsData.Search.Models.Search;

namespace SystematicsData.Web.Api.Client.Interfaces
{
    public interface ISystematicsDataClient
    {
        Task<SearchResult> Search(Query query);

        Task<Document> GetDocument(string documentId);

        Task<ContentConfigurations> GetContent(string page);
    }
}
