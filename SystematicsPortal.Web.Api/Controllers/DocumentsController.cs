using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using SystematicsPortal.Web.Api.Infrastructure;
using SystematicsPortal.Web.Api.Services;

namespace SystematicsPortal.Web.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly AppSettings _appSettings;
        private readonly IDocumentsService _documentsService;


        public DocumentsController(IDocumentsService namesService, IOptions<AppSettings> appSettings, ILogger<SearchController> logger)
        {
            _documentsService = namesService;
            _appSettings = appSettings.Value;
            _logger = logger;
        }

        [HttpGet("{id}", Name = "GetName")]
        public async Task<IActionResult> Get(string id)
        {
            _logger.LogDebug(
                "NamesController - Get - id: {id}",
                             id);

            var response = await _documentsService.GetDocument(id);

            return Ok(response.XmlDocument);
        }
    }
}
