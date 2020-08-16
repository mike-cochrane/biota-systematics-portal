using Microsoft.Extensions.Logging;
using SolrNet;
using SolrNet.Commands.Parameters;
using System;
using SystematicsData.Search.Infrastructure;
using SystematicsData.Search.Tools.Models;
using SystematicsData.Search.Tools.Models.Interfaces;
using SystematicsData.Search.Tools.Models.Search;

namespace SystematicsData.Search
{
    public class Search : ISearch, IDisposable
    {
        private readonly Tools.Models.Interfaces.ISolrConnection _connection;

        private readonly ILogger _logger;

        public Search(Tools.Models.Interfaces.ISolrConnection solrConnection, ILogger<Search> logger)
        {
            _connection = solrConnection;
            _logger = logger;
        }

        /// <summary>
        ///  This funtion is the one that actually does the search
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public SearchResult DoSearch(Query query)
        {
            // Create an object to hold results
            SearchResult queryResponse = new SearchResult();

            try
            {
                // Get a connection 
                var solr = _connection.GetSolrCore();

                var queryOptions = new QueryOptions
                {
                    Rows = query.Rows,
                    StartOrCursor = new StartOrCursor.Start(query.Start),
                    FilterQueries = FilterFacets.BuildFilterQueries(query),
                    Facet = FilterFacets.BuildFacets()
                };

                // TODO: Check if we should we get sort order by parameter
                queryOptions.AddOrder(new SortOrder("title", Order.ASC));

                queryOptions.ExtraParams = ExtraParameters.BuildExtraParameters();
                
                // Execute the query
                ISolrQuery solrQuery = new SolrQuery(query.TextQuery);

                var solrResults = solr.Query(solrQuery, queryOptions);

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

            // Return response
            return queryResponse;
        }

        public void Dispose()
        {
        }
    }
}