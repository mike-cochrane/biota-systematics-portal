using Microsoft.AspNetCore.Mvc.Rendering;
using Systematics.Portal.Web.Helpers;

namespace Systematics.Portal.Web.Models
{
    public class SearchPartialViewModel {
        public string Query { get; set; }
        public string UncorrectedQuery { get; set; }
        public string SelectedCollection { get; set; }
        public SelectList Collections { get; set; }
        public string ErrorMessage { get; set; }

        public SearchPartialViewModel(ComboList collectionList, string selectedCollection) {
            Query = string.Empty;
            UncorrectedQuery = string.Empty;
            SelectedCollection = selectedCollection;
            Collections = new SelectList(collectionList.Items, "Key", "DisplayText", SelectedCollection);
            ErrorMessage = string.Empty;
        }
    }
}