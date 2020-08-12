using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using SystematicsData.Search.Tools.Models.Search;
using SystematicsPortal.Web.Helpers;

namespace SystematicsPortal.Web.Models
{
    public class SearchViewModel : ViewModelBase
    {

        private string _query;

        public string Query
        {
            get { return _query; }
            set
            {
                _query = value;
                if (SearchData != null)
                {
                    SearchData.Query = value;
                }
            }
        }

        //public string SelectedCollection { get; set; }
        //public SelectList Collections { get; set; }
        public SearchPartialViewModel SearchData { get; set; }
        public SearchResult Result { get; set; }
        public string SelectedView { get; set; }
        public string SelectedSortOption { get; set; }
        public SelectList SortOptions { get; set; }
        public bool HaveSearched { get; set; }
        public int ResultsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public List<SetViewModel> Sets { get; set; }
        // public DownloadLogViewModel DownloadLog { get; set; }
        public bool AllSelected { get; set; }
        public bool OneOrMoreSelected { get; set; }

        public SearchViewModel(ComboList collectionList, string selectedCollection, string sortBy = "relevance") : base()
        {
            //SelectedCollection = selectedCollection;
            //Collections = new SelectList(collectionList.Items, "Key", "DisplayText", SelectedCollection);
            Query = String.Empty;
            SearchData = new SearchPartialViewModel(collectionList, selectedCollection);
            Result = new SearchResult(sortBy);
            SelectedView = "list";
            SelectedSortOption = sortBy;
            SortOptions = GetSortOptions();
            HaveSearched = false;
            ResultsPerPage = 500;
            CurrentPage = 0;
            Sets = null;
            //DownloadLog = new DownloadLogViewModel();
            AllSelected = false;
            OneOrMoreSelected = false;
        }

        public void SetSortField(string sortBy)
        {
            SelectedSortOption = sortBy;
            SortOptions = GetSortOptions();
        }

        public int GetTotalPages()
        {
            int quotient = 0;
            int remainder = 0;
            //quotient = Math.DivRem(Result.TotalSpecimens, ResultsPerPage, out remainder);
            int totalPages = quotient;
            if (remainder > 0)
            {
                totalPages += 1;
            }
            return totalPages;
        }

        public int GetCurrentLowEndOfRange()
        {
            return GetCurrentHighEndOfRange() - ResultsPerPage + 1;
        }

        public int GetCurrentHighEndOfRange()
        {
            return (CurrentPage + 1) * ResultsPerPage;
        }

        private SelectList GetSortOptions()
        {
            ComboList sortOptions = new ComboList();
            sortOptions.AddItem("accessionNumber", "Accession number");
            sortOptions.AddItem("country", "Country");
            sortOptions.AddItem("collection", "Data provider");
            sortOptions.AddItem("ecologicalDistrict", "Ecological district");
            sortOptions.AddItem("hasImages", "Images available");
            sortOptions.AddItem("landDistrict", "Land district");
            sortOptions.AddItem("locality", "Standard locality");
            sortOptions.AddItem("relevance", "Most relevant");
            sortOptions.AddItem("newZealandAreaCode", "New Zealand area code");
            sortOptions.AddItem("taxonName", "Taxonomic name");
            sortOptions.AddItem("typeStatus", "Type status");
            sortOptions.AddItem("specimenType", "Specimen type");

            return new SelectList(sortOptions.Items, "Key", "DisplayText", SelectedSortOption);
        }
    }
}