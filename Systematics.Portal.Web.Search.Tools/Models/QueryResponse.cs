using System.Collections.Generic;
using Systematics.Portal.Web.Search.Tools.Models.Search;

namespace Systematics.Portal.Web.Search.Tools.Models
{
    public class QueryResponse
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

