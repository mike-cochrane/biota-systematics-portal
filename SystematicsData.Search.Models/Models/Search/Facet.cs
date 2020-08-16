using System;
using System.Collections.Generic;

namespace SystematicsData.Search.Models.Search
{
    public class Facet : Filter
    {
        public List<FacetValue> Values { get; set; }

        public Facet(): base()
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
