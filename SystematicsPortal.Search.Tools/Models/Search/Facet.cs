using System;
using System.Collections.Generic;

namespace SystematicsPortal.Search.Tools.Models.Search
{
    public class Facet : Filter
    {
        public List<FacetValue> Values { get; set; }

        public Facet()
        {
            Name = String.Empty;
            DisplayText = String.Empty;
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
