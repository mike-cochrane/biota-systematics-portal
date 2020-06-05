using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Systematics.Portal.Web.Api.Access.Infrastructure;
using Systematics.Portal.Web.Api.Access.Services;
using Systematics.Portal.Web.Search.Tools.Models;

namespace Systematics.Portal.Web.Api.Access.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly AppSettings _appSettings;
        private readonly ISearchService _searchService;


        public SearchController(ILogger<SearchController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(string query, string width = "", string height = "", string aspectRatio = "",
            string library = "", string category = "", string title = "", string copyright = "",
            string album = "", string keyword = "", int pageNumber = 0, int resultsPerPage = 100, string facets = "")
        {
            QueryResponse response;

            //if (!(User is ClaimsPrincipal user))
            //{
            //    return BadRequest();
            //}

            // Getting operatorId, so we can use it to retrieve images according to user's permission.
            //var operatorIdObjClaim = User.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Subject);

            //var operatorId = operatorIdObjClaim == null ? string.Empty : operatorIdObjClaim.Value;

            // We obtain the groups that the user belongs to
            //var groups = User.Claims.Where(x => x.Type == "group").Select(@group => @group.Value).ToList();

            _logger.LogDebug(
                "ImagesController - Get - query: {query}- width: {width} - height: {height} - aspectRatio {aspectRatio} - library {library} - category {category} - title {title} - copyright {copyright} - album {album} - keyword {keyword} - pageNumber {pageNumber} - resultsPerPage {resultsPerPage}",
                             query, width, height, aspectRatio, library, category, title, copyright, album, keyword, pageNumber, resultsPerPage);


            try
            {
                // This is the object that will be used to parse the query and the parameter. Start Position equals to pageNumber * resultsPerPage. Rows number will be the results per page.
                var queryToUse = new Query(pageNumber * resultsPerPage, resultsPerPage) { TextQuery = query };

                // TODO: Check if it necessary the id as filter
                //if (!(string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id)))
                //{
                //    queryToUse.IdFilter.Add(id);
                //}

                //long auxToParse;
                //if (!(string.IsNullOrEmpty(width) || string.IsNullOrWhiteSpace(width)))
                //{
                //    if (long.TryParse(width, out auxToParse))
                //    {
                //        queryToUse.WidthFilter.Add(auxToParse);
                //    }
                //}



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
