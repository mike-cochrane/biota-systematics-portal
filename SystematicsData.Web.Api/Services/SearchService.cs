using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using SystematicsData.Search.Tools.Models;
using SystematicsData.Search.Tools.Models.Interfaces;
using SystematicsData.Search.Tools.Models.Search;
using SystematicsData.Web.Api.Services.Interfaces;

namespace SystematicsData.Web.Api.Services
{
    public class SearchService : ISearchService
    {
        public readonly ISearch _search;
        private readonly ILogger<SearchService> _logger;



        public SearchService(ISearch search,  ILogger<SearchService> logger)
        {
            _search = search;
            _logger = logger;
        }

        /// <summary>
        /// Assembly the query and call the search library to do search
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pageNumber"></param>
        /// <param name="resultsPerPage"></param>
        /// <param name="facets"></param>
        /// <returns>Search result with solr documents and properties to enable paging and facting</returns>
        public SearchResult Search(string query, int pageNumber, int resultsPerPage, FacetLists facetLists)
        {
            // This is the object that will be used to parse the query and the parameter. Start Position equals to pageNumber * resultsPerPage. Rows number will be the results per page.
            var queryToUse = new Query(pageNumber * resultsPerPage, resultsPerPage) { TextQuery = query };

            //var appliedFacets = ParseFilterQueries(facets);

            if (facetLists != null && (facetLists.AppliedFacets.Count > 0|| facetLists.AppliedRanges.Count > 0))
            {
                queryToUse.FacetLists = facetLists;
            }

            _logger.LogDebug(
                "SearchService - queryToUse: {queryToUse}",
                queryToUse);

            return _search.DoSearch(queryToUse);
        }

        /// <summary>
        /// Parse the filter into separate filter queries. Use the display name from the facet fields if possible for the display name
        /// of the query filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        private List<KeyValuePair<string, string>> ParseFilterQueries(string filter)
        {
            var filterQueries = new List<KeyValuePair<string, string>>();

            if (!String.IsNullOrWhiteSpace(filter))
            {
                List<string> filters = filter.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                filters.ForEach(o =>
                {
                    string[] filterParts = o.Split(new char[] { ':' });

                    if (filterParts.Length == 2)
                    {
                        string fieldName = filterParts[0];
                        string text = filterParts[1];

                        KeyValuePair<string, string> facet = new KeyValuePair<string, string>(fieldName, text);

                        filterQueries.Add(facet);
                    }
                });
            }

            return filterQueries;
        }
    }
}
