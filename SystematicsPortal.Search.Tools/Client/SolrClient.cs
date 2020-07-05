using System;
using System.Collections.Generic;
using System.Net.Http;

namespace SystematicsPortal.Search.Tools.Client
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
            string queryForFacets = String.Empty;

            string query = String.Empty;

            if (!(String.IsNullOrEmpty(Query) || String.IsNullOrWhiteSpace(Query)))
            {
                query = query + "?query=" + Query;
            }


            if (!(String.IsNullOrEmpty(PageNumber) || String.IsNullOrWhiteSpace(PageNumber)))
            {
                query = query + "&pageNumber=" + PageNumber;
            }
            if (!(String.IsNullOrEmpty(ResultsPerPage) || String.IsNullOrWhiteSpace(ResultsPerPage)))
            {
                query = query + "&ResultsPerPage=" + ResultsPerPage;
            }
            if (!(String.IsNullOrEmpty(ReturnType) || String.IsNullOrWhiteSpace(ReturnType)))
            {
                query = query + "&returnType=" + ReturnType;
            }

            foreach (var facet in Facets)
            {
                queryForFacets = String.IsNullOrEmpty(queryForFacets) || String.IsNullOrWhiteSpace(queryForFacets) ? "facets=" : $"{queryForFacets};";

                queryForFacets = $"{queryForFacets}{facet.Key}:{facet.Value}";
            }
            if (!(String.IsNullOrEmpty(queryForFacets) || String.IsNullOrWhiteSpace(queryForFacets)))
            {
                query = $"{query}&{queryForFacets}";
            }

            return query;
        }
    }
}