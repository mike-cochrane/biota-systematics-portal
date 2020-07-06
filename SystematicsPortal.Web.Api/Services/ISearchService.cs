using System.Collections.Generic;
using SystematicsPortal.Search.Tools.Models.Search;

namespace SystematicsPortal.Web.Api.Services
{
    public interface ISearchService 
    {
        List<KeyValuePair<string, string>> ParseFilterQueries(string filter);
        SearchResult Search(string query, int pageNumber, int resultsPerPage, string facets);
    }
}
