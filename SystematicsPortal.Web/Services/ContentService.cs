using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsPortal.Models.Entities.Annotations;
using SystematicsPortal.Web.Api.Client.Extensions;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using SystematicsPortal.Web.Infrastructure;

namespace SystematicsPortal.Web.Services
{
    public class ContentService : IContentService
    {
        private readonly string _apiContentUrl;


        public ContentService(IOptions<AppSettings> appSettings)
        {
            var appsettingsObject = appSettings.Value;

            _apiContentUrl = appsettingsObject.ContentService.Url;
        }

        public async Task<List<string>> GetResourcesAsStringList()
        {
            string urlToQuery = $"{_apiContentUrl}/resources";
            List<string> resourcesList = new List<string>();

            // TODO: Use new .net core http client factory 
            var client = new HttpClient()
            {
                BaseAddress = new Uri(urlToQuery),
               
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

            var response = await client.GetAsync(urlToQuery);

            if (response.IsSuccessStatusCode)
            {
                var results = await response.Content.ReadAsStringAsync();

                var returnXml = XDocument.Parse(results);

                var resourcesElements = returnXml.Element("Resources").Descendants("Resource");

                foreach (var resource in resourcesElements)
                {
                    // _logger.Verbose("{Action} {NameFullName} (Record {Index} of {NameCount})", "Process Consensus Name Document", name.FullName, index, consensusNameCount);
                    string resourceId = (string)resource.Attribute("resourceId");

                    if (!String.IsNullOrEmpty(resourceId))
                    {
                        resourcesList.Add(resourceId);
                    }
                }
            }
            else
            { 
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return resourcesList;
        }

        public async Task<Resources> GetResources()
        {
            string urlToQuery = $"{_apiContentUrl}/resources";
            Resources resourcesList;

            // TODO: Use new .net core http client factory 
            var client = new HttpClient()
            {
                BaseAddress = new Uri(urlToQuery),

            };

            var response = await client.GetAsync(urlToQuery);

            if (response.IsSuccessStatusCode)
            {
                resourcesList = await response.Content.ReadAsAsync<Resources>();
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return resourcesList;
        }


        public async Task<ItemTypes> GetItemTypes(string resourceId)
        {
            string urlToQuery = $"{_apiContentUrl}/itemTypes?resourceId={resourceId}";
            ItemTypes itemTypes = new ItemTypes();

            // TODO: Use new .net core http client factory 
            var client = new HttpClient()
            {
                BaseAddress = new Uri(urlToQuery),

            };

            var response = await client.GetAsync(urlToQuery);

            if (response.IsSuccessStatusCode)
            {
                itemTypes = await response.Content.ReadAsAsync<ItemTypes>();
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return itemTypes;
        }

        public async Task<Items> GetItemIds(string itemTypeId)
        {
            string urlToQuery = $"{_apiContentUrl}/itemIds?itemTypeId={itemTypeId}";
            Items itemIds = new Items();

            // TODO: Use new .net core http client factory 
            var client = new HttpClient()
            {
                BaseAddress = new Uri(urlToQuery),

            };

            var response = await client.GetAsync(urlToQuery);

            if (response.IsSuccessStatusCode)
            {
                itemIds = await response.Content.ReadAsAsync<Items>();
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return itemIds;
        }

        public async Task<Items> GetItemsByIds(List<string> itemIds)
        {
            string urlToQuery = $"{_apiContentUrl}/items";
            Items items = new Items();

            // TODO: Use new .net core http client factory 
            var client = new HttpClient()
            {
                BaseAddress = new Uri(urlToQuery),

            };

            var jsonInString = JsonConvert.SerializeObject(itemIds);

            var response = await client.PostAsync(urlToQuery, new StringContent(jsonInString, Encoding.UTF8, "application/json"));


            if (response.IsSuccessStatusCode)
            {
                items = await response.Content.ReadAsAsync<Items>();
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return items;
        }
    }
}
