using Microsoft.AspNetCore.Mvc.RazorPages;
using SolrNet.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systematics.Portal.Web.Search.Tools.Models.Search;

namespace Systematics.Portal.Web.Services
{
    public class SearchService : ISearchService
    {
        public Api.Access.Client.Client _apiClient;

        public SearchService(Api.Access.Client.Client apiClient)
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
            var response  = await _apiClient.CallService(searchTerm, pageNumber, resultsPerPage);

            return response;
        }
    }
}
