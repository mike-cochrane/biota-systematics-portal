using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using SystematicsData.Search.Models.Search;
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

        public SearchViewModel(string sortBy = "relevance") : base() // ComboList collectionList, string selectedCollection, 
        {
            //SelectedCollection = selectedCollection;
            //Collections = new SelectList(collectionList.Items, "Key", "DisplayText", SelectedCollection);
            Query = String.Empty;
            SearchData = new SearchPartialViewModel(); // collectionList, selectedCollection
            Result = new SearchResult(sortBy);
            SelectedView = "list";
            SelectedSortOption = sortBy;
            SortOptions = GetSortOptions();
            HaveSearched = false;
            ResultsPerPage = 100;
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
            quotient = Math.DivRem(Result.TotalSpecimens, ResultsPerPage, out remainder);
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
            sortOptions.AddItem("title", "Title");
            sortOptions.AddItem("family", "Family");
            sortOptions.AddItem("taxonRank", "Taxon Rank");

            return new SelectList(sortOptions.Items, "Key", "DisplayText", SelectedSortOption);
        }
    }
}