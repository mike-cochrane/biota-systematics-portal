using System.Collections.Generic;

namespace Systematics.Portal.Web.Search.Tools.Models
{
    public class Query
    {
        public Query(int startPos, int rowsNumber)
        {
            Rows = rowsNumber;
            Start = startPos;
            WidthFilter = new List<long>();
            HeightFilter = new List<long>();
            AspectRatioFilter = new List<string>();
            LibraryFilter = new List<string>();
            CategoryFilter = new List<string>();
            TitleFilter = new List<string>();
            CopyrightFilter = new List<string>();
            AlbumFilter = new List<string>();
            KeywordFilter = new List<string>();
            GrantDenyIndividualPermissionsFilter = new List<string>();
            GrantDenyGroupPermissionsFilter = new List<string>();
            GrantDenyPublicPermissionsFilter = new List<string>();
            OriginalFileTypeFilter = new List<string>();
            FacetFilters = new List<KeyValuePair<string, string>>();
        }

        // Default constructor with default number of rows
        public Query() : this(0, 100)
        {
        }

        // Query that holds parameters sent to the search library
        public string TextQuery { get; set; }

        public int Start { get; set; }
        public int Rows { get; set; }
        public List<long> WidthFilter { get; set; }
        public List<long> HeightFilter { get; set; }
        public List<string> AspectRatioFilter { get; set; }
        public List<string> LibraryFilter { get; set; }
        public List<string> OriginalFileTypeFilter { get; set; }
        public List<string> CategoryFilter { get; set; }
        public List<string> TitleFilter { get; set; }
        public List<string> CopyrightFilter { get; set; }
        public List<string> AlbumFilter { get; set; }
        public List<string> KeywordFilter { get; set; }
        public List<string> GrantDenyIndividualPermissionsFilter { get; set; }
        public List<string> GrantDenyGroupPermissionsFilter { get; set; }
        public List<string> GrantDenyPublicPermissionsFilter { get; set; }

        public List<KeyValuePair<string, string>> FacetFilters { get; set; }
    }
}