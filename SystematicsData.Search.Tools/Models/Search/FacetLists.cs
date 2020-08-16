using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystematicsData.Search.Tools.Models.Search
{
    public class FacetLists
    {
        public List<SelectedFacetValue> AppliedFacets { get; set; }
        public List<SelectedRange> AppliedRanges { get; set; }
    }
}
