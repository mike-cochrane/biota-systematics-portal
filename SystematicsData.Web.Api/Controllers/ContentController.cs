using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using SystematicsData.Web.Api.Services;

namespace SystematicsData.Web.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ContentController : ControllerBase
    {
        private readonly ILogger<ContentController> _logger;
        private readonly IContentService _contentservice;

        public ContentController(IContentService contentservice, ILogger<ContentController> logger)
        {
            _contentservice = contentservice;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string page)
        {
            _logger.LogDebug("ContentController - GetContent");

            var response = await _contentservice.GetContentAsync(page);

            return Ok(response);
        }
    }
}