using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using SystematicsData.Web.Api.Services;

namespace SystematicsData.Web.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly IDocumentsService _documentsService;

        public DocumentsController(IDocumentsService namesService, ILogger<SearchController> logger)
        {
            _documentsService = namesService;
            _logger = logger;
        }

        [HttpGet("{id}", Name = "GetName")]
        public async Task<IActionResult> Get(string id)
        {
            _logger.LogDebug("DocumentsController - Get - id: {id}", id);

            var response = await _documentsService.GetDocument(id);

            return Ok(response.XmlDocument);
        }
    }
}