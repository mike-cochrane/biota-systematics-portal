using SolrNet;

namespace SystematicsPortal.Search.Tools.Models.Interfaces
{
    public interface ISolrConnection
    {
        ISolrOperations<SolrDocument> GetSolrCore();
    }
}
