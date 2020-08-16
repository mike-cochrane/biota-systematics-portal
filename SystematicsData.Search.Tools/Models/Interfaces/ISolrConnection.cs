using SolrNet;

namespace SystematicsData.Search.Tools.Models.Interfaces
{
    public interface ISolrConnection
    {
        ISolrOperations<SolrDocument> DocumentsSolrCore();
    }
}
