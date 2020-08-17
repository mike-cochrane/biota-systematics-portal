using System.Collections.Generic;
using System.ComponentModel;

namespace SystematicsData.Search.Models.Search
{
    public class Facet : Filter
    {
        public List<FacetValue> Values { get; set; }

        public Facet(): base("Facet")
        {
            Values = new List<FacetValue>();
        }

        public FacetValue GetValue(string name)
        {
            foreach (FacetValue f in Values)
            {
                if (f.Name.Equals(name))
                {
                    return f;
                }
            }
            return null;
        }
    }
}
