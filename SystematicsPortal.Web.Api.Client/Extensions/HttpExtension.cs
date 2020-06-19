using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SystematicsPortal.Web.Api.Client.Extensions
{
    public static class HttpExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent content)
        {
            var messageString = await content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<T>(messageString,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }

        public static async Task PostAsJsonAsync<T>(this HttpClient client, string uri, T model)
        {
            var modelString = System.Text.Json.JsonSerializer.Serialize(model);
            await client.PostAsync(uri, new StringContent(modelString,
                Encoding.UTF8, "application/json"));
        }
    }
}
