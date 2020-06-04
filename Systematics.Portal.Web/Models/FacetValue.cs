using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Systematics.Portal.Web.Models {
    public class FacetValue {
        public string Name { get; set; }
        public int Count { get; set; }
        public bool Selected { get; set; }

        public FacetValue()
        {
            Name = string.Empty;
            Count = 0;
            Selected = false;
        }
    }
}