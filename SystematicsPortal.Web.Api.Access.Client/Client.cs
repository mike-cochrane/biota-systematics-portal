using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SystematicsPortal.Web.Api.Access.Client.Extensions;
using SystematicsPortal.Web.Search.Tools.Models;
using SystematicsPortal.Web.Search.Tools.Models.Search;

namespace SystematicsPortal.Web.Api.Access.Client
{
    public class Client
    {
        private readonly string _url;

        public Client(string url)
        {
            _url = url;
        }

        public async Task<SearchResult> CallService(string query, int pageNumber = 0, int resultsPerPage = 100, string facets = "")
        {
            string urlToQuery = $"{_url}search?query={query}&resultsPerPage={resultsPerPage}&pageNumber={pageNumber}&facets={facets}";
            SearchResult queryResponse = null;

            var baseAddress = urlToQuery;

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
            { throw new HttpRequestException(response.ReasonPhrase); }

            // Do event logging
            //Console.WriteLine(response.ToString());


            return queryResponse;
        }
    }
}
