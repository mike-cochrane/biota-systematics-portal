using System;
using System.Net.Http;
using System.Threading.Tasks;
using SystematicsPortal.Models.Entities.Access;
using SystematicsPortal.Search.Tools.Models.Search;
using SystematicsPortal.Web.Api.Client.Extensions;

namespace SystematicsPortal.Web.Api.Client
{
    public class Client
    {
        private readonly string _url;

        public Client(string url)
        {
            _url = url;
        }

        public async Task<SearchResult> Search(string query, int pageNumber = 0, int resultsPerPage = 100, string facets = "")
        {
            string urlToQuery = $"{_url}search?query={query}&resultsPerPage={resultsPerPage}&pageNumber={pageNumber}&facets={facets}";
            var baseAddress = urlToQuery;
            SearchResult queryResponse;

            // TODO: Use new .net core http client factory 
            var client = new HttpClient()
            {
                BaseAddress = new Uri(baseAddress)
            };


            var response = await client.GetAsync(urlToQuery);

            if (response.IsSuccessStatusCode)
            {
                queryResponse = await response.Content.ReadAsAsync<SearchResult>();
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            // Do event logging

            return queryResponse;
        }

        public async Task<Document> GetDocument(string documentId)
        {
            string urlToQuery = $"{_url}documents/{documentId}";
            Document document = null;

            var baseAddress = urlToQuery;

            // TODO: Use new .net core http client factory 
            var client = new HttpClient()
            {
                BaseAddress = new Uri(baseAddress)
            };


            var response = await client.GetAsync(urlToQuery);

            if (response.IsSuccessStatusCode)
            {
                string incomingText = await response.Content.ReadAsStringAsync();

                document = new Document();

                document.XmlDocument.LoadXml(incomingText);
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            // Do event logging


            return document;
        }
    }
}
