using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using SystematicsData.Models.Entities.Access;
using SystematicsPortal.Web.Services.Interfaces;
using SystematicsPortal.Web.ViewModels;

namespace SystematicsPortal.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContentService _contentService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(IContentService contentService, ILogger<HomeController> logger)
        {
            _contentService = contentService;
        
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ContentConfigurations contentConfigurations = await _contentService.GetContent("home");
            return View(contentConfigurations);
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Acknowledgement()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
