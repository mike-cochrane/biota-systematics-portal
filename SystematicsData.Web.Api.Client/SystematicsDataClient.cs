using Newtonsoft.Json;
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
    /// <summary>
    /// Client for making API calls to the systematics data API.
    /// </summary>
    public class SystematicsDataClient : ISystematicsDataClient
    {
        private readonly HttpClient _httpClient;

        public SystematicsDataClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SearchResult> Search(Query query)
        {
            SearchResult queryResponse;

            using var response = await _httpClient.PostAsync("search", new StringContent(JsonConvert.SerializeObject(query), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                queryResponse = await response.Content.ReadAsAsync<SearchResult>();
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return queryResponse;
        }

        public async Task<Document> GetDocument(string documentId)
        {
            Document document;

            using var response = await _httpClient.GetAsync($"documents/{documentId}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                document = new Document();

                document.XmlDocument.LoadXml(responseString);
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return document;
        }

        public async Task<ContentConfigurations> GetContent(string page)
        {
            ContentConfigurations contentConfigurations;

            using var response = await _httpClient.GetAsync($"content?page={page}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                contentConfigurations = SerializationHelper.Deserialize<ContentConfigurations>(responseString);
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return contentConfigurations;
        }
    }
}
