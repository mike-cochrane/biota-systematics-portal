﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SystematicsData.Models.Entities.Access;
using SystematicsData.Search.Models;
using SystematicsData.Search.Models.Search;
using SystematicsData.Utility.Extensions;
using SystematicsData.Utility.Helpers;
using SystematicsData.Web.Api.Client.Interfaces;

namespace SystematicsData.Web.Api.Client
{
    public class SystematicsDataClient : ISystematicsDataClient
    {
        private readonly string _url;

        public SystematicsDataClient(string url)
        {
            _url = url;
        }

        public async Task<SearchResult> Search(Query query)
        {
            string urlToQuery = $"{_url}search";
            var baseAddress = urlToQuery;
            SearchResult queryResponse;

            // TODO: Use new .net core http client factory 
            var client = new HttpClient()
            {
                BaseAddress = new Uri(baseAddress)
            };

            var jsonContent = JsonConvert.SerializeObject(query);

            var response = await client.PostAsync(urlToQuery, new StringContent(jsonContent, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                queryResponse = await response.Content.ReadAsAsyncUsingCustomConverter<SearchResult>();
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return queryResponse;
            // Do event logging
        }

        public async Task<Document> GetDocument(string documentId)
        {
            Document document;
            string urlToQuery = $"{_url}documents/{documentId}";
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
