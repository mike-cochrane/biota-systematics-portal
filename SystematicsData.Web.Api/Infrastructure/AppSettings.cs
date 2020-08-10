namespace SystematicsData.Web.Api.Infrastructure
{
    public class AppSettings
    {
        public IdentityServerSettings IdentityServer { get; set; }

        public SolrSettings Solr { get; set; }
    }

    public class IdentityServerSettings
    {
        public string Url { get; set; }
        public string ApiName { get; set; }
    }

    public class SolrSettings
    {
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}
