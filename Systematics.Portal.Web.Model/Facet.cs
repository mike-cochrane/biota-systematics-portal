using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Model {
    public class Facet : Filter {
        public List<FacetValue> Values { get; set; }

        public Facet() {
            Name = string.Empty;
            DisplayText = string.Empty;
            Values = new List<FacetValue>();
        }

        public FacetValue GetValue(string name) {
            foreach (FacetValue f in Values) {
                if (f.Name.Equals(name)) {
                    return f;
                }
            }
            return null;
        }
    }
}
