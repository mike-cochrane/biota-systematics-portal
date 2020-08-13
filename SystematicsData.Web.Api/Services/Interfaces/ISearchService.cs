using System.Collections.Generic;
using SystematicsData.Search.Tools.Models.Search;

namespace SystematicsData.Web.Api.Services.Interfaces
{
    public interface ISearchService
    {
        SearchResult Search(string query, int pageNumber, int resultsPerPage, FacetLists facetLists);
    }
}
