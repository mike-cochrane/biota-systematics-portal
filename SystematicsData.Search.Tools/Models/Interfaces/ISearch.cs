using SystematicsData.Search.Tools.Models.Search;

namespace SystematicsData.Search.Tools.Models.Interfaces
{
    public interface ISearch
    {
        SearchResult DoSearch(Query query);
    }
}
