using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systematics.Portal.Web.Search.Tools.Models.Search;

namespace Systematics.Portal.Web.Services
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
