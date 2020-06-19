using Microsoft.Extensions.Logging;
using SearchLibrary.Implementation;
using SolrNet;
using SolrNet.Commands.Parameters;
using System;
using System.Collections.Generic;
using SystematicsPortal.Search.Tools.Models;
using SystematicsPortal.Search.Tools.Models.Search;

namespace SystematicsPortal.Search
{
    public class Search : IDisposable
    {
        private readonly Connection _connection;

         private readonly ILogger _logger;

        public Search(string connection, string userName, string password, ILogger logger)
        {
            _connection = new Connection(connection, userName, password);
            _logger = logger;
        }

        /// <summary>
        ///  This funtion is the one that actually does the search
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public SearchResult DoSearch(Query query)
        {
            SearchResult queryResponse;
            try
            {
                var filterFacets = new FilterFacets();

                // Create an object to hold results
                queryResponse = new SearchResult
                {
                    // Store the original query
                    //OriginalQuery = query
                };

                // Get a connection 
                var solr = _connection.SolrCore;

                if (solr == null)
                {
                    //_logger.LogError("Problem to get solr instance");
                    throw new Exception("Problem to get solr instance");
                }

                var queryOptions = new QueryOptions
                {
                    Rows = query.Rows,
                    StartOrCursor = new StartOrCursor.Start(query.Start),
                    FilterQueries = filterFacets.BuildFilterQueries(query),
                    Facet = filterFacets.BuildFacets()
                };
                // Set response
                var extractResponse = new ResponseExtraction();

                // TODO: Check if we should we get sort order by parameter
                queryOptions.AddOrder(new SortOrder("title", Order.ASC));

                ExtraParameters extraParameters = new ExtraParameters();

                queryOptions.ExtraParams = extraParameters.BuildExtraParameters();
                // Execute the query
                ISolrQuery solrQuery = new SolrQuery(query.TextQuery);

                var solrResults = solr.Query(solrQuery, queryOptions);

                extractResponse.SetHeader(queryResponse, solrResults);
                extractResponse.SetBody(queryResponse, solrResults);
                extractResponse.SetSpellCheck(queryResponse, solrResults);
                extractResponse.SetFacets(queryResponse, solrResults);

                //log result
                //_logger.LogDebug($"Search results:  {queryResponse.Results}");
            }
            catch (Exception e)
            {
                //_logger.LogError(e, e.Message);
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