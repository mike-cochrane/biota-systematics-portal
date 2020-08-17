using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SystematicsData.Utility.Helpers;

namespace Annotations.Web.Api.Management.Controllers
{
    [Produces("application/json")]
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(new
            {
                name = AssemblyInfoHelper.GetTitle(),
                description = AssemblyInfoHelper.GetDescription(),
                version = AssemblyInfoHelper.GetInformationalVersion(),
                environment = _hostingEnvironment.EnvironmentName,
            });
        }
    }
}
