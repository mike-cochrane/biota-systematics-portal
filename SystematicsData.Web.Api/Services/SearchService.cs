using Microsoft.Extensions.Logging;
using System;
using SystematicsData.Search.Models;
using SystematicsData.Search.Models.Interfaces;
using SystematicsData.Search.Models.Search;
using SystematicsData.Web.Api.Services.Interfaces;

namespace SystematicsData.Web.Api.Services
{
    public class SearchService : ISearchService
    {
        public readonly ISearch _search;
        private readonly ILogger<SearchService> _logger;

        public SearchService(ISearch search, ILogger<SearchService> logger)
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
        public SearchResult Search(Query query)
        {
            VerifyQuery(ref query);

            _logger.LogDebug("SearchService - queryToUse: {Query}", query);

            return _search.DoSearch(query);
        }

        private void VerifyQuery(ref Query query)
        {
            query ??= new Query();

            query.TextQuery ??= String.Empty;
            query.FacetLists ??= new FacetLists();
            query.Rows = query.Rows == 0 ? 100 : query.Rows;
        }
    }
}
