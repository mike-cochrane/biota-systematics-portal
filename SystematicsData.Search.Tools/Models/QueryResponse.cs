using System.Collections.Generic;
using SystematicsData.Search.Tools.Models.Search;

namespace SystematicsData.Search.Tools.Models
{
    /// <summary>
    /// Internal class for managing the solr query response.
    /// </summary>
    internal class QueryResponse
    {
        public QueryResponse()
        {
            Facets = new List<Facet>();
        }

        // Expose properties that will be returned from the search library
        public List<SolrDocument> Results { get; set; }

        public int TotalHits { get; set; }

        public int QueryTime { get; set; }

        public int Status { get; set; }
        //public Query OriginalQuery { get; set; }

        public List<string> DidYouMean { get; set; }

        public List<Facet> Facets { get; set; }
    }
}
