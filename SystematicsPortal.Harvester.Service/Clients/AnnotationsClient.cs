using Microsoft.Extensions.DependencyInjection;
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
using SystematicsPortal.Models.Entities.Annotations;
using SystematicsPortal.Models.Interfaces;
using SystematicsPortal.Utility.Extensions;

namespace SystematicsPortal.Harvester.Service.Clients
{
    public class AnnotationsClient
    {
        private readonly string _apiContentUrl;
        private readonly IDocumentsRepository _repository;
        private readonly ILogger<AnnotationsClient> _logger;

        public AnnotationsClient(IDocumentsRepository repository, string contentServiceUrl, ILogger<AnnotationsClient> logger)
        {
            _repository = repository;
            _apiContentUrl = contentServiceUrl;
            _logger = logger;
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
            Items itemIds;

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
            Items items;

            var response = await GetItemsResponseByIds(itemIds);

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

        //public async Task<XElement> GetItemXmlById(string id)
        //{
        //    return await GetItemsXmlByIds(new List<string>() { id})
        //}

        public async Task<IEnumerable<XElement>> GetItemsXmlByIds(List<string> itemIds)
        {
            List<XElement> itemsList = new List<XElement>();
            var response = await GetItemsResponseByIds(itemIds);

            if (response.IsSuccessStatusCode)
            {
                itemsList = await GetItemsXElementList(response);
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return itemsList;
        }

        private async Task<List<XElement>> GetItemsXElementList(HttpResponseMessage response)
        {
            List<XElement> itemsList = new List<XElement>();

            var items = await response.Content.ReadAsStringAsync();

            TextReader tr = new StringReader(items);
            XDocument itemsXDocument = XDocument.Load(tr);

            //var itemsXDocument = XDocument.Parse(items);
            var documentsElements = itemsXDocument.Element("items");
            itemsList = documentsElements.Descendants("item").ToList();

            itemsList = itemsList.Select(item =>
            {
                string itemId = (string)item.Attribute("itemId");
                item.Add(new XAttribute("documentId", itemId));
                return item;
            }
            ).ToList();

            return itemsList;
        }

        private async Task<HttpResponseMessage> GetItemsResponseByIds(List<string> itemIds)
        {
            string urlToQuery = $"{_apiContentUrl}/items";

            // TODO: Use new .net core http client factory
            var client = new HttpClient()
            {
                BaseAddress = new Uri(urlToQuery),
            };

            var jsonInString = JsonConvert.SerializeObject(itemIds);

            client.DefaultRequestHeaders.Add("Accept", "application/xml");

            var response = await client.PostAsync(urlToQuery, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

            return response;
        }
    }
}