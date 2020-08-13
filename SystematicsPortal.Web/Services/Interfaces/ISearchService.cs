using System.Collections.Generic;
using System.Threading.Tasks;
using SystematicsData.Models.Entities.Access;
using SystematicsData.Search.Tools.Models.Search;

namespace SystematicsPortal.Web.Services.Interfaces
{
    public interface ISearchService
    {
        Task<SearchResult> Search(string searchTerm, 
            List<SelectedFacetValue> appliedFacets = null,
            List<SelectedRange> appliedRanges = null,
            int pageNumber=0,
            int resultsPerPage=100,
            string sortBy ="",
            string sortOrder="");
    }
}
