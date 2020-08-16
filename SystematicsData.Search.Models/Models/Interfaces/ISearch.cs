using SystematicsData.Search.Models.Search;

namespace SystematicsData.Search.Models.Interfaces
{
    public interface ISearch
    {
        SearchResult DoSearch(Query query);
    }
}
