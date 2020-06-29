using SystematicsPortal.Search.Tools.Models.Search;

namespace SystematicsPortal.Search.Tools.Models.Interfaces
{
    public interface ISearch
    {
        SearchResult DoSearch(Query query);
    }
}
