using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SystematicsData.Web.Api.Services.Interfaces;

namespace SystematicsData.Web.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ContentController : ControllerBase
    {
        private readonly IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get(string page)
        {
            var response = await _contentService.GetContentAsync(page);

            return Ok(response);
        }
    }
}
