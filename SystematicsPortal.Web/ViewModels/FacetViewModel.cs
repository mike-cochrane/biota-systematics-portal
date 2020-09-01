﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SystematicsPortal.Web.ViewModels
{
    public class SearchQueryViewModel
    {
        public string selectedFacet { get; set; }

        public string selectedFacetType { get; set; }

        public string selectedValue { get; set; }

        public int selectedUpperValue { get; set; }

        public string query { get; set; }

        public string appliedFacets { get; set; }

        public string appliedRanges { get; set; }

        public bool toggleOn { get; set; }

        public string currentDisplayTab { get; set; }

        public string sortField { get; set; }

        public int pageNumber { get; set; }

        public bool selectAll { get; set; }

        public SearchQueryViewModel()
        {
            selectedFacet = String.Empty;
            selectedFacetType = String.Empty;
            selectedValue = String.Empty;
            selectedUpperValue = 0;
            query = String.Empty;
            appliedFacets = String.Empty;
            appliedRanges = String.Empty;
            toggleOn = false;
            currentDisplayTab = String.Empty;
            sortField = String.Empty;
            pageNumber = 0;
            selectAll = false;
        }
    }
}
