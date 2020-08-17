using System.Collections.Generic;

namespace SystematicsData.Search.Models.Search
{
    public class FacetLists
    {
        public List<SelectedFacetValue> AppliedFacets { get; set; }

        public List<SelectedRange> AppliedRanges { get; set; }
    }
}
