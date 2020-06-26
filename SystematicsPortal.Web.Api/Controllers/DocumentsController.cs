using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystematicsPortal.Web.Api.Infrastructure;
using SystematicsPortal.Web.Api.Services;

namespace SystematicsPortal.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly AppSettings _appSettings;
        private readonly IDocumentsService _namesService;


        public DocumentsController(IOptions<AppSettings> appSettings, ILogger<SearchController> logger, IDocumentsService namesService)
        {
            _logger = logger;
            _namesService = namesService;
            _appSettings = appSettings.Value;
        }

        [HttpGet("{id}", Name = "GetName")]
        public async Task<IActionResult> Get(string id/*, string documentType*/)
        {
            _logger.LogDebug(
                "NamesController - Get - id: {id}",
                             id);

            var response = await _namesService.GetDocument(id);



            return Ok(response.XmlDocument);

            // return Ok(response.XDocument.Document);
        }

    }
}
