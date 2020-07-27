using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using SystematicsPortal.Search.Tools.Models.Search;
using SystematicsPortal.Web.Api.Services;

namespace SystematicsPortal.Web.Api.Controllers
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

        [HttpGet]
        public IActionResult Get(string query, int pageNumber = 0, int resultsPerPage = 100, string facets = "")
        {
            SearchResult response;

            _logger.LogDebug(
                "SearchController - Get - query: {query} - pageNumber {pageNumber} - resultsPerPage {resultsPerPage}",
                             query, pageNumber, resultsPerPage);

            try
            {
                response = _searchService.Search(query, pageNumber, resultsPerPage, facets);
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
