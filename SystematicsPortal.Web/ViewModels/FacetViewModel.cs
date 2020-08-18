using System;
using System.ComponentModel.DataAnnotations;

namespace SystematicsPortal.Web.ViewModels
{
    public class FacetViewModel
    {
        public string selectedFacet { get; set; }

        public string selectedFacetType { get; set; }

        public string selectedValue { get; set; }

        public string selectedUpperValue { get; set; }

        public string query { get; set; }

        public string appliedFacets { get; set; }

        public string appliedRanges { get; set; }

        public bool toggleOn { get; set; }

        public string currentDisplayTab { get; set; }

        public string sortField { get; set; }

        public int pageNumber { get; set; }

        public string selectAll { get; set; }

        public FacetViewModel()
        {
            selectedFacet = String.Empty;
            selectedFacetType = String.Empty;
            selectedValue = String.Empty;
            selectedUpperValue = String.Empty;
            query = String.Empty;
            appliedFacets = String.Empty;
            appliedRanges = String.Empty;
            toggleOn = false;
            currentDisplayTab = String.Empty;
            sortField = String.Empty;
            pageNumber = 0;
            selectAll = String.Empty;
        }
    }
}
