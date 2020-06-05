using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Systematics.Portal.Web.Search.Tools.Client
{
    public class SolrClient
    {
        public string Query { get; set; }
        public string PageNumber { get; set; }
        public string ResultsPerPage { get; set; }
        public string ReturnType { get; set; }
        public List<KeyValuePair<string, string>> Facets { get; set; }
        public HttpClient Client { get; set; }

        public SolrClient(string imageApiUrl, System.Net.Http.Headers.AuthenticationHeaderValue authenticationHeader)
        {
            Facets = new List<KeyValuePair<string, string>>();

            Client = new HttpClient();

            Client.BaseAddress = new Uri(imageApiUrl);

            Client.DefaultRequestHeaders.Authorization = authenticationHeader;
        }
        // use a class to wrap, implement Dispose and when calling, pass the info as parameters

        public string AssemblyQuery()
        {
            string queryForFacets = string.Empty;

            string query = string.Empty;

            if (!(string.IsNullOrEmpty(Query) || string.IsNullOrWhiteSpace(Query)))
            {
                query = query + "?query=" + Query;
            }

           
            if (!(string.IsNullOrEmpty(PageNumber) || string.IsNullOrWhiteSpace(PageNumber)))
            {
                query = query + "&pageNumber=" + PageNumber;
            }
            if (!(string.IsNullOrEmpty(ResultsPerPage) || string.IsNullOrWhiteSpace(ResultsPerPage)))
            {
                query = query + "&ResultsPerPage=" + ResultsPerPage;
            }
            if (!(string.IsNullOrEmpty(ReturnType) || string.IsNullOrWhiteSpace(ReturnType)))
            {
                query = query + "&returnType=" + ReturnType;
            }

            foreach (var facet in Facets)
            {
                queryForFacets = string.IsNullOrEmpty(queryForFacets) || string.IsNullOrWhiteSpace(queryForFacets) ? "facets=" : $"{queryForFacets};";

                queryForFacets = $"{queryForFacets}{facet.Key}:{facet.Value}";
            }
            if (!(string.IsNullOrEmpty(queryForFacets) || string.IsNullOrWhiteSpace(queryForFacets)))
            {
                query = $"{query}&{queryForFacets}";
            }

            return query;
        }
    }
}