using System;

namespace SystematicsData.Models.Entities.Database
{
    public class Facet
    {
        public Guid FacetId { get; set; }
        public string FacetGroup { get; set; }
        public string Facet1 { get; set; }
        public string Labels { get; set; }
        public string FacetType { get; set; }
        public string SolrFieldName { get; set; }
        public int? DisplayOrder { get; set; }
    }
}
