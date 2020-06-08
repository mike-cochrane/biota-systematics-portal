using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systematics.Portal.Web.Models.Search;

namespace Systematics.Portal.Web.Services
{
    public interface ISearchService
    {
        Task<SearchResult> Search(/*List<SelectedFacetValue> appliedFacets,
            List<SelectedRange> appliedRanges,*/
            string searchTerm,
            int pageNumber=0,
            int resultsPerPage=100,
            string sortBy ="",
            string sortOrder="");
    }
}
