using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystematicsPortal.Search.Tools.Models.Search
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
            FacetGroup = string.Empty;
            Facet = string.Empty;
            Type = string.Empty;
            SolrFieldName = string.Empty;
            DisplayOrder = int.MaxValue;
        }
    }
}
