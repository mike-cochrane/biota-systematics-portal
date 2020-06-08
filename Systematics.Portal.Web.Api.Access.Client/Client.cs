using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

        public async Task CallService(string query, int pageNumber = 0, int resultsPerPage = 100, string facets = "")
        {
            string urlToQuery = $"{_url}search?query={query}&resultsPerPage={resultsPerPage}&pageNumber={pageNumber}&facets={facets}";

            try
            {
                var baseAddress = urlToQuery;

                var client = new HttpClient
                {
                    BaseAddress = new Uri(baseAddress)
                };

                var response = await client.GetStringAsync(urlToQuery);

                Console.WriteLine(response.ToString());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);

            }
        }
    }
}
