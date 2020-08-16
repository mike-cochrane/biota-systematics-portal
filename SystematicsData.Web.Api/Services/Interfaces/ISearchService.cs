using System.Collections.Generic;
using SystematicsData.Search.Models;
using SystematicsData.Search.Models.Search;

namespace SystematicsData.Web.Api.Services.Interfaces
{
    public interface ISearchService
    {
        SearchResult Search(Query query);
    }
}
