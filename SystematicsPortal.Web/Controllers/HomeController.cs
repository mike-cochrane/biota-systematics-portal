using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SystematicsPortal.Web.Services;
using SystematicsPortal.Web.ViewModels;

namespace SystematicsPortal.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContentService _contentService;


        public HomeController(IContentService contentService, ILogger<HomeController> logger)
        {
            _contentService = contentService;
            _logger = logger;
        }

        public async System.Threading.Tasks.Task<IActionResult> Index()
        { 
            ViewBag.ContentConfigurations = await _contentService.GetContent("home");
            return View();
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
