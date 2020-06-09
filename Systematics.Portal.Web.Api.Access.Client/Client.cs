using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Systematics.Portal.Web.Api.Access.Client.Extensions;
using Systematics.Portal.Web.Search.Tools.Models;

namespace Systematics.Portal.Web.Api.Access.Client
{
    public class Client
    {
        private readonly HttpClient _client;
        private readonly string _url;

        public Client(string url)
        {
            _client = new HttpClient();
            _url = url;
        }

        public async Task<QueryResponse> CallService(string query, int pageNumber = 0, int resultsPerPage = 100, string facets = "")
        {
            string urlToQuery = $"{_url}search?query={query}&resultsPerPage={resultsPerPage}&pageNumber={pageNumber}&facets={facets}";
            QueryResponse queryResponse = null;

            var baseAddress = urlToQuery;

            var client = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };

            var response = await client.GetAsync(urlToQuery);

            if (response.IsSuccessStatusCode)
            {
                queryResponse = await response.Content.ReadAsAsync<QueryResponse>();

            }
            else
            { throw new HttpRequestException(response.ReasonPhrase); }

            // Do event logging
            //Console.WriteLine(response.ToString());


            return queryResponse;
        }
    }
}
