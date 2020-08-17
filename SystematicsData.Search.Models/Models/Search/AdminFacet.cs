using System;

namespace SystematicsData.Search.Models.Search
{
    public class AdminFacet
    {
        public int AdminFacetId { get; set; }
        public string FacetGroup { get; set; }
        public string Facet { get; set; }
        public string Type { get; set; }
        public string SolrFieldName { get; set; }
        public int DisplayOrder { get; set; }

        public AdminFacet()
        {
            AdminFacetId = -1;
            FacetGroup = String.Empty;
            Facet = String.Empty;
            Type = String.Empty;
            SolrFieldName = String.Empty;
            DisplayOrder = int.MaxValue;
        }
    }
}
