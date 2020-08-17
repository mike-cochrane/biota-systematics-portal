using System.Collections.Generic;
using System.Threading.Tasks;
using SystematicsData.Search.Models;
using SystematicsData.Search.Models.Search;
using SystematicsData.Web.Api.Client.Interfaces;
using SystematicsPortal.Web.Services.Interfaces;

namespace SystematicsPortal.Web.Services
{
    public class SearchService : ISearchService
    {
        public ISystematicsDataClient _apiClient;

        public SearchService(ISystematicsDataClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<SearchResult> Search(string searchTerm,
            List<SelectedFacetValue> appliedFacets = null,
            List<SelectedRange> appliedRanges = null,
            int pageNumber = 0,
            int resultsPerPage = 100,
            string sortBy = "",
            string sortOrder = "")
        {
            // This is the object that will be used to parse the query and the parameter. Start Position equals to pageNumber * resultsPerPage. Rows number will be the results per page.
            var queryToUse = new Query(pageNumber * resultsPerPage, resultsPerPage)
            {
                TextQuery = searchTerm,
                FacetLists = new FacetLists()
                {
                    AppliedFacets = appliedFacets ?? new List<SelectedFacetValue>(),
                    AppliedRanges = appliedRanges ?? new List<SelectedRange>()
                }
            };

            var response = await _apiClient.Search(queryToUse);

            return response;
        }
    }
}
