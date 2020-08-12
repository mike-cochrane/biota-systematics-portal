using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SystematicsData.Utility.Helpers
{
    public static class SerializationHelper
    {
        public static string Serialize<T>(T data)
        {
            using (var stringWriter = new StringWriter())
            using (var writer = XmlWriter.Create(stringWriter, new XmlWriterSettings()
            {
                OmitXmlDeclaration = true,
                ConformanceLevel = ConformanceLevel.Auto,
                Indent = true
            }))
            {
                var serializer = new XmlSerializer(typeof(T));

                serializer.Serialize(writer, data, null);

                writer.Flush();

                return stringWriter.ToString();
            }
        }

        public static T Deserialize<T>(string data) where T : class
        {
            if (String.IsNullOrWhiteSpace(data)) { return null; }

            using (var reader = new StringReader(data))
            {
                var serializer = new XmlSerializer(typeof(T));

                return serializer.Deserialize(reader) as T;
            }
        }
    }
}
