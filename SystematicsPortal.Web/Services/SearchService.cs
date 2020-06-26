using System.Collections.Generic;
using System.Threading.Tasks;
using SystematicsPortal.Model.Models.Access;
using SystematicsPortal.Search.Tools.Models.Search;
using SystematicsPortal.Utility.Helpers;

namespace SystematicsPortal.Web.Services
{
    public class SearchService : ISearchService
    {
        public Api.Client.Client _apiClient;

        public SearchService(Api.Client.Client apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<SearchResult> Search(string searchTerm,
            List<SelectedFacetValue> appliedFacets = null,
            List<SelectedRange> appliedRanges = null,
            int pageNumber = 0,
            int resultsPerPage = 100,
            string sortBy = "",
            string sortOrder = "")
        {
            var response  = await _apiClient.Search(searchTerm, pageNumber, resultsPerPage);

            return response;
        }

        public async Task<Model.Models.Access.Document> GetDocument(string id)
        {
            var documentXml = await _apiClient.GetDocument(id);

            return documentXml;
        }


        public async Task<Model.Models.Documents.DocumentType> GetDocumentAsCSharpClass(string id)
        {
            var documentXml = await _apiClient.GetDocument(id);


            Model.Models.Documents.DocumentType document = null; 


            return document;
        }
    }
}
