using System.Collections.Generic;
using SystematicsData.Search.Models.Search;

namespace SystematicsData.Search.Models
{
    public class Query
    {
        // Query that holds parameters sent to the search library
        public string TextQuery { get; set; }

        public int Start { get; set; }

        public int Rows { get; set; }

        public string SortBy { get; set; }

        public string SortOrder { get; set; }

        public FacetLists FacetLists { get; set; }

        // Default constructor with default number of rows
        public Query() : this(0, 100)
        {
        }

        public Query(int startPos, int rowsNumber)
        {
            Rows = rowsNumber;
            Start = startPos;
            FacetLists = new FacetLists()
            {
                AppliedFacets = new List<SelectedFacetValue>(),
                AppliedRanges = new List<SelectedRange>()
            };
        }
    }
}