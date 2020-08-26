using Microsoft.Extensions.Logging;
using SolrNet;
using SolrNet.Commands.Parameters;
using System;
using System.Collections.Generic;
using SystematicsData.Search.Infrastructure;
using SystematicsData.Search.Models;
using SystematicsData.Search.Models.Interfaces;
using SystematicsData.Search.Models.Search;
using ISolrConnection = SystematicsData.Search.Models.Interfaces.ISolrConnection;

namespace SystematicsData.Search
{
    public class Search : ISearch, IDisposable
    {
        private readonly ISolrConnection _connection;

        private readonly ILogger _logger;

        public Search(ISolrConnection solrConnection, ILogger<Search> logger)
        {
            _connection = solrConnection;

            _logger = logger;
        }

        /// <summary>
        ///  This function is the one that actually does the search
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public SearchResult DoSearch(Query query)
        {
            // Create an object to hold results
            var queryResponse = new SearchResult();

            try
            {
                // Get a connection 
                var solrDocumentsCore = _connection.DocumentsSolrCore();

                var queryOptions = new QueryOptions
                {
                    Facet = FilterFacets.BuildFacets(),
                    FilterQueries = FilterFacets.BuildFilterQueries(query),
                    OrderBy = GetSortArray(query),
                    Rows = query.Rows,
                    StartOrCursor = new StartOrCursor.Start(query.Start)
                };

                queryOptions.ExtraParams = ExtraParameters.BuildExtraParameters();

                // Execute the query
                ISolrQuery solrQuery = new SolrQuery(query.TextQuery);

                var solrResults = solrDocumentsCore.Query(solrQuery, queryOptions);

                ResponseExtraction.SetHeader(queryResponse, solrResults);
                ResponseExtraction.SetBody(queryResponse, solrResults);
                ResponseExtraction.SetSpellCheck(queryResponse, solrResults);
                ResponseExtraction.SetFacets(queryResponse, solrResults, query.FacetLists);

                //log result
                _logger.LogDebug("Search results:  {queryResponse.FoundDocuments}", queryResponse.FoundDocuments);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                throw;
            }

            return queryResponse;
        }

        /// <summary>
        /// Gets the sort array according to the sort order and sort field specified
        /// </summary>
        /// <param name="query">General query received from the client</param>
        /// <returns>List of sort criteria with order</returns>
        private ICollection<SortOrder> GetSortArray(Query query)
        {
            var order = String.Equals(query.SortOrder, "ascending", StringComparison.InvariantCultureIgnoreCase) ? Order.ASC : Order.DESC;

            var orderBy = new List<SortOrder>();

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                orderBy.Add(new SortOrder(query.SortBy, order));
            }

            return orderBy;
        }

        public void Dispose()
        {
        }
    }
}
