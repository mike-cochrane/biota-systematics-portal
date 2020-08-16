﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
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
        public SearchResult Search(Query query)
        {
            Verifyquery(ref query);

            _logger.LogDebug("SearchService - queryToUse: {query}", query);

            return _search.DoSearch(query);
        }

        private void Verifyquery(ref Query query)
        {
            query ??= new Query(); 

            query.TextQuery ??= String.Empty;

            query.FacetLists ??= new FacetLists();

            query.Rows = query.Rows == 0 ? 100 : query.Rows;
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
