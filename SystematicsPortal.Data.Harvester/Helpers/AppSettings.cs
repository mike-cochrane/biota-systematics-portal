namespace SystematicsPortal.Data.Harvester.Helpers
{
    public class AppSettings
    {
        public string SourcePath { get; set; }

        public ContentServiceSettings ContentService { get; set; }

    }
    public class ContentServiceSettings
    {
        public string Url { get; set; }
        public string Name { get; set; }
    }
}
