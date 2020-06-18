using System.Collections.Generic;

namespace SystematicsPortal.Search.Tools.Models
{
    public class Query
    {
        // Query that holds parameters sent to the search library
        public string TextQuery { get; set; }

        public int Start { get; set; }
        public int Rows { get; set; }

        public List<KeyValuePair<string, string>> FacetFilters { get; set; }

        // Default constructor with default number of rows
        public Query() : this(0, 100)
        {
        }

        public Query(int startPos, int rowsNumber)
        {
            Rows = rowsNumber;
            Start = startPos;
            FacetFilters = new List<KeyValuePair<string, string>>();
        }
    }
}