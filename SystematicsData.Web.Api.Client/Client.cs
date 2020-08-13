using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SystematicsData.Models.Entities.Access;
using SystematicsData.Search.Tools.Models.Search;
using SystematicsData.Utility.Extensions;
using SystematicsData.Utility.Helpers;

namespace SystematicsData.Web.Api.Client
{
    public class Client
    {
        private readonly string _url;

        public Client(string url)
        {
            _url = url;
        }

        public async Task<SearchResult> Search(string query, List<SelectedFacetValue> appliedFacets, List<SelectedRange> appliedRanges, int pageNumber = 0, int resultsPerPage = 100, string facets = "", string sortOrder = null)
        {
            string urlToQuery = $"{_url}search?query={query}&resultsPerPage={resultsPerPage}&pageNumber={pageNumber}&facets={facets}";
            var baseAddress = urlToQuery;
            SearchResult queryResponse;

            // TODO: Use new .net core http client factory 
            var client = new HttpClient()
            {
                BaseAddress = new Uri(baseAddress)
            };

            var facetLists = new FacetLists();

            facetLists.AppliedFacets = appliedFacets;
            facetLists.AppliedRanges = appliedRanges;

            var response = await client.PostAsync(urlToQuery, new StringContent(JsonConvert.SerializeObject(facetLists), Encoding.UTF8, "application/json"));

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

        public async Task<ContentConfigurations> GeContent(string page)
        {
            ContentConfigurations contentConfigurations;
            
            string urlToQuery = $"{_url}content?page={page}";

            // TODO: Use new .net core http client factory 
            var client = new HttpClient()
            {
                BaseAddress = new Uri(urlToQuery)
            };

            var response = await client.GetAsync(urlToQuery);

            if (response.IsSuccessStatusCode)
            {
                var contentConfigurationsString = await response.Content.ReadAsStringAsync();

                contentConfigurations = SerializationHelper.Deserialize<ContentConfigurations>(contentConfigurationsString);
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return contentConfigurations;
        }
    }
}
