using System;

namespace SystematicsPortal.Search.Tools.Models.Search
{
    public class SelectedFacetValue
    {
        public string GroupName { get; set; }
        public string FacetName { get; set; }
        public string FacetLabel { get; set; }
        public string ValueName { get; set; }
        public string Label
        {
            get
            {
                return (FacetLabel + ": " + ValueName).Replace(" ", "&nbsp;");
            }
        }

        public SelectedFacetValue()
        {
            GroupName = String.Empty;
            FacetName = String.Empty;
            ValueName = String.Empty;
        }
    }
}
