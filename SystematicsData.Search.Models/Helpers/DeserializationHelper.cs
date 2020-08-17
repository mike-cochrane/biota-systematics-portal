using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SystematicsData.Search.Models.Search;

namespace SystematicsData.Utility.Extensions
{
    public static class DeserializationHelper
    {
        // Using custom JsonConvert in order to diferentiate facet and ranges, as both derive from filter.
        // Source: https://blog.codeinside.eu/2015/03/30/json-dotnet-deserialize-to-abstract-class-or-interface/
        public static async Task<T> ReadAsAsyncUsingCustomConverter<T>(this HttpContent content)
        {
            JsonConverter[] converters = { new FilterConverter() };

            var jsonSettings = new JsonSerializerSettings()
            {
                Converters = converters
            };

            var messageString = await content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<T>(messageString, jsonSettings);
        }
    }

    public class FilterConverter : JsonConverter
    {
        public override bool CanRead => base.CanRead;

        public override bool CanWrite => base.CanWrite;

        public override bool CanConvert(Type objectType)
        {
            return typeof(Filter).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            if (objectType == typeof(Filter))
            {
                if (jo["filterType"] != null && jo["filterType"].Value<string>() == "Facet")
                {
                    return jo.ToObject<Facet>(serializer);
                }

                if (jo["filterType"] != null && jo["filterType"].Value<string>() == "Range")
                {
                    return jo.ToObject<Range>(serializer);
                }
            }

            return jo.ToObject(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
