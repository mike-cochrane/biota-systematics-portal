using Microsoft.AspNetCore.Mvc.RazorPages;
using SolrNet.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systematics.Portal.Web.Models.Search;

namespace Systematics.Portal.Web.Services
{
    public class SearchService : ISearchService
    {
        public async Task<SearchResult> Search(string searchTerm, int pageNumber, int resultsPerPage, string sortBy, string sortOrder)
        {
            var client = new Systematics.Portal.Web.Api.Access.Client.Client("http://localhost:29578/");

            var response  = await client.CallService(searchTerm, pageNumber, resultsPerPage);

            var searchResut = new SearchResult();

            searchResut.FoundDocuments = response.Results.ToDictionary(id=>id.Id, document=>document);

            searchResut.TotalSpecimens = response.TotalHits;


            return searchResut;


        }
    }
}
