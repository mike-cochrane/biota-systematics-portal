using System.Collections.Generic;

namespace Systematics.Portal.Web.Models
{
    public class Facet
    {

        public string Name { get; set; }
        public List<FacetValue> Values { get; set; }

        public Facet()
        {
            Name = string.Empty;
            Values = new List<FacetValue>();
        }
    }
}