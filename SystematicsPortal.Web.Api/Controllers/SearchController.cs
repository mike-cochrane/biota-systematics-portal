using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using SystematicsPortal.Search.Tools.Models;
using SystematicsPortal.Search.Tools.Models.Search;
using SystematicsPortal.Web.Api.Infrastructure;
using SystematicsPortal.Web.Api.Services;

namespace SystematicsPortal.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        private readonly AppSettings _appSettings;
        private readonly ILogger<SearchController> _logger;


        public SearchController(ISearchService searchService, IOptions<AppSettings> appSettings, ILogger<SearchController> logger )
        {
            _searchService = searchService;
            _appSettings = appSettings.Value;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(string query, int pageNumber = 0, int resultsPerPage = 100, string facets = "")
        {
            SearchResult response;

            _logger.LogDebug(
                "ImagesController - Get - query: {query} - pageNumber {pageNumber} - resultsPerPage {resultsPerPage}",
                             query, pageNumber, resultsPerPage);

            try
            {
                // This is the object that will be used to parse the query and the parameter. Start Position equals to pageNumber * resultsPerPage. Rows number will be the results per page.
                var queryToUse = new Query(pageNumber * resultsPerPage, resultsPerPage) { TextQuery = query };

                var appliedFacets = _searchService.ParseFilterQueries(facets);

                if (appliedFacets != null && appliedFacets.Count > 0)
                {
                    queryToUse.FacetFilters = appliedFacets;
                }

                _logger.LogDebug(
                    "ImagesController - Get - queryToUse: {@queryToUse}",
                    queryToUse);

                // Actually using search library
                response = _searchService.GetSearch().DoSearch(queryToUse);
            }
            catch (Exception exception)
            {
                _logger.LogError("ImageController - Get - exception: {@exception}", exception);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(response);
        }

    }
}
