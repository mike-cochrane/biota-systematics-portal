using SolrNet;

namespace SystematicsData.Search.Models.Interfaces
{
    public interface ISolrConnection
    {
        ISolrOperations<SolrDocument> DocumentsSolrCore();
    }
}
