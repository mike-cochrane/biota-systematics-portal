using System;

namespace SystematicsPortal.Search.Tools.Models.Search
{
    public class FacetValue
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public bool Selected { get; set; }

        public FacetValue()
        {
            Name = String.Empty;
            Count = 0;
            Selected = false;
        }
    }
}
