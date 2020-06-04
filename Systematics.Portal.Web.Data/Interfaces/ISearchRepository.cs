using Systematics.Portal.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Data.Interfaces {
    public interface ISearchRepository {
        SearchResult Search(
            List<SelectedFacetValue> appliedFacets, 
            List<SelectedRange> appliedRanges, 
            string searchTerm, 
            string collection, 
            Dictionary<string, int> userAccessLevels, 
            int pageNumber, 
            int resultsPerPage,
            string sortBy,
            string sortOrder);
        List<string> GetSpecimenIds(List<SelectedFacetValue> appliedFacets, List<SelectedRange> appliedRanges, string searchTerm, string collection, Dictionary<string, int> userAccessLevels);
        List<SpecimenSummary> FindSpecimens(List<Guid> specimenIds, Dictionary<string, int> userAccessLevels);
    }
}
