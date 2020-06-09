using Microsoft.Extensions.Logging;
using SearchLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using Systematics.Portal.Web.Api.Access.Infrastructure;

namespace Systematics.Portal.Web.Api.Access.Services
{
    public class SearchService : ISearchService
    {
        public Search.Search Search { get; }

        public SearchService(IOptions<AppSettings> appSettings, ILogger<SearchService> logger)
        {
            var solrUrl = appSettings.Value.Solr.Url;
            var userName = appSettings.Value.Solr.UserName;
            var password = appSettings.Value.Solr.Password;
            Search = new Search.Search(solrUrl, userName, password, logger);
        }

        public Search.Search GetSearch()
        {
            return Search;
        }

        /// <summary>
        /// Parse the filter into separate filter queries. Use the display name from the facet fields if possible for the display name
        /// of the query filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<KeyValuePair<string, string>> ParseFilterQueries(string filter)
        {
            var filterQueries = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrWhiteSpace(filter))
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

        public void Dispose()
        {
            Search?.Dispose();
        }
    }
}
