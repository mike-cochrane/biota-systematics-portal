using System.Collections.Generic;
using System.Threading.Tasks;
using SystematicsData.Models.Entities.Access;
using SystematicsData.Search.Models.Search;

namespace SystematicsPortal.Web.Services.Interfaces
{
    public interface ISearchService
    {
        Task<SearchResult> Search(string searchTerm, List<SelectedFacetValue> appliedFacets = null, List<SelectedRange> appliedRanges = null,
            int pageNumber=0, int resultsPerPage=100, string sortBy ="", string sortOrder="");

        List<SelectedFacetValue> SetAppliedFacets(string appliedFacets, string selectedFacet, string selectedValue, string selectedFacetType,
            bool addRemoveFilterToggle);

        List<SelectedRange> SetAppliedRanges(string appliedRanges, string selectedFacet, string selectedValue, string selectedFacetType,
            string selectedUpperValue, bool addRemoveFilterToggle);
    }

}
