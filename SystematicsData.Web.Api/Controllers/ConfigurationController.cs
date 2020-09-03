using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SystematicsData.Web.Api.Services.Interfaces;

namespace SystematicsData.Web.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ConfigurationController : Controller
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [HttpGet("viewdefinitions/{documentClass}")]
        public async Task<IActionResult> GetViewDefinition(string documentClass)
        {
            var response = await _configurationService.GetViewDefinitionAsync(documentClass);

            return Ok(response);
        }
    }
}
