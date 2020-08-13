using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using SystematicsData.Search.Tools.Models.Search;
using SystematicsData.Web.Api.Services.Interfaces;

namespace SystematicsData.Web.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        private readonly ILogger<SearchController> _logger;


        public SearchController(ISearchService searchService, ILogger<SearchController> logger )
        {
            _searchService = searchService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Get(string query, int pageNumber = 0, int resultsPerPage = 100, [FromBody] FacetLists facetLists = null)
        {
            SearchResult response;

            _logger.LogDebug(
                "SearchController - Get - query: {query} - pageNumber {pageNumber} - resultsPerPage {resultsPerPage}",
                             query, pageNumber, resultsPerPage);

            try
            {
                response = _searchService.Search(query, pageNumber, resultsPerPage, facetLists);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"SearchController - Get - exception: {exception.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(response);
        }
    }
}
