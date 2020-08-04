using System.Collections.Generic;

namespace SystematicsPortal.Data.Harvester.Helpers
{
    public class AppSettings
    {
        public string SourcePath { get; set; }

        public ContentServiceSettings ContentService { get; set; }

        public Dictionary<string, string> Strategies { get; set; }

        public RabbitMqSettings RabbitMq { get; set; }
    }

    public class ContentServiceSettings
    {
        public string Url { get; set; }

        public string Name { get; set; }
    }

    public class RabbitMqSettings
    {
        public string Host { get; set; }

        public string VirtualHost { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}