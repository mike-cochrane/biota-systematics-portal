using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsData.Models.Entities.Annotations;
using SystematicsData.Utility.Extensions;

namespace SystematicsData.Harvester.Service.Clients
{
    /// <summary>
    /// Client for making API calls to the Annotations API.
    /// </summary>
    public class AnnotationsClient
    {
        private readonly HttpClient _httpClient;

        private readonly ILogger<AnnotationsClient> _logger;

        public AnnotationsClient(HttpClient httpClient, ILogger<AnnotationsClient> logger)
        {
            _httpClient = httpClient;

            _logger = logger;
        }

        public async Task<List<string>> GetResourcesAsStringList()
        {
            var resourcesList = new List<string>();

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

            using var response = await _httpClient.GetAsync("resources");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var results = await response.Content.ReadAsStringAsync();
                var returnXml = XDocument.Parse(results);
                var resourcesElements = returnXml.Element("Resources").Descendants("Resource");

                foreach (var resource in resourcesElements)
                {
                    // _logger.Verbose("{Action} {NameFullName} (Record {Index} of {NameCount})", "Process Consensus Name Document", name.FullName, index, consensusNameCount);
                    var resourceId = (string)resource.Attribute("resourceId");

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
            Resources resources;

            using var response = await _httpClient.GetAsync("resources");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                resources = await response.Content.ReadAsAsync<Resources>();
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return resources;
        }

        public async Task<ItemTypes> GetItemTypes(string resourceId)
        {
            using var response = await _httpClient.GetAsync($"itemtypes?resourceid={resourceId}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var itemTypes = await response.Content.ReadAsAsync<ItemTypes>();

                return itemTypes;
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }

        public async Task<Items> GetItemIds(string itemTypeId)
        {
            Items itemIds;

            using var response = await _httpClient.GetAsync($"itemids?itemtypeid={itemTypeId}");

            response.EnsureSuccessStatusCode();

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

        public async Task<XElement> GetItemXmlById(string id)
        {
            var item = (await GetItemsXmlByIds(new List<string>() { id })).FirstOrDefault();

            if (item == null)
            {
                throw new Exception($"Item {id} has not been found");
            }

            return item;
        }

        public async Task<Items> GetItemsByIds(List<string> itemIds)
        {
            Items items;

            using var response = await GetItemsResponseByIds(itemIds);

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

        public async Task<Item> GetItemById(string id)
        {
            var item = (await GetItemsByIds(new List<string>() { id })).ItemsList.FirstOrDefault();

            if (item == null)
            {
                throw new Exception($"Item {id} has not been found");
            }

            return item;
        }

        public async Task<IEnumerable<XElement>> GetItemsXmlByIds(List<string> itemIds)
        {
            using var response = await GetItemsResponseByIds(itemIds);

            if (response.IsSuccessStatusCode)
            {
                var itemsList = await GetItemsXElementList(response);

                return itemsList;
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }

        private async Task<List<XElement>> GetItemsXElementList(HttpResponseMessage response)
        {
            var items = new List<XElement>();
            var itemsAsString = await response.Content.ReadAsStringAsync();
            using var itemsStringReader = new StringReader(itemsAsString);
            var itemsDocument = XDocument.Load(itemsStringReader);
            var itemsElement = itemsDocument.Element("items");

            items = itemsElement.Descendants("item").ToList();
            items = items.Select(item =>
            {
                string itemId = (string)item.Attribute("itemId");
                item.Add(new XAttribute("documentId", itemId));

                return item;
            }
            ).ToList();

            return items;
        }

        private async Task<HttpResponseMessage> GetItemsResponseByIds(List<string> itemIds)
        {
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/xml");

            var jsonInString = JsonConvert.SerializeObject(itemIds);
            var response = await _httpClient.PostAsync("items", new StringContent(jsonInString, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            return response;
        }
    }
}
