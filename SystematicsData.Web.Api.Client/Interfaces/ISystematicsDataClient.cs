using System.Threading.Tasks;
using SystematicsData.Models.Entities.Access;
using SystematicsData.Search.Tools.Models;
using SystematicsData.Search.Tools.Models.Search;

namespace SystematicsData.Web.Api.Client.Interfaces
{
    public interface ISystematicsDataClient
    {
        Task<SearchResult> Search(Query query);

        Task<Document> GetDocument(string documentId);

        Task<ContentConfigurations> GeContent(string page);
    }
}
