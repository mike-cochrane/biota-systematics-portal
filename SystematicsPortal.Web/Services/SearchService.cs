using System.Collections.Generic;
using System.Threading.Tasks;
using SystematicsData.Models.Entities.Access;
using SystematicsData.Search.Tools.Models.Search;
using SystematicsData.Web.Api.Client;
using SystematicsPortal.Web.Services.Interfaces;

namespace SystematicsPortal.Web.Services
{
    public class SearchService : ISearchService
    {
        public Client _apiClient;

        public SearchService(Client apiClient)
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
            var response = await _apiClient.Search(searchTerm, appliedFacets, appliedRanges, pageNumber, resultsPerPage, sortBy, sortOrder);

            return response;
        }
    }
}
