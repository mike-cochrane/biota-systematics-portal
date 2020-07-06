using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using SystematicsPortal.Web.Helpers;

namespace SystematicsPortal.Web.Models
{
    public class SearchPartialViewModel {
        public string Query { get; set; }
        public string UncorrectedQuery { get; set; }
        public string SelectedCollection { get; set; }
        public SelectList Collections { get; set; }
        public string ErrorMessage { get; set; }

        public SearchPartialViewModel(ComboList collectionList, string selectedCollection) {
            Query = String.Empty;
            UncorrectedQuery = String.Empty;
            SelectedCollection = selectedCollection;
            // siamac commented to get working temporarily until backend completed - Collections = new SelectList(collectionList.Items, "Key", "DisplayText", SelectedCollection);
            ErrorMessage = String.Empty;
        }
    }
}