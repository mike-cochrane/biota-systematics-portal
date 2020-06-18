using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystematicsPortal.Web.Search.Tools.Models.Search
{
    public class FacetValue
    {
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
