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
            int pageNumber,
            int resultsPerPage,
            string sortBy,
            string sortOrder);
    }
}
