﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SystematicsPortal.Models.Entities.Access;
using SystematicsPortal.Models.Entities.Documents;
using SystematicsPortal.Search.Tools.Models.Search;

namespace SystematicsPortal.Web.Services
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

        Task<Document> GetDocument (string id);
    }
}
