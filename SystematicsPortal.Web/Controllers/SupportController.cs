using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using SystematicsData.Models.Entities.Access;
using SystematicsPortal.Web.Services.Interfaces;

namespace SystematicsPortal.Web.Controllers
{
    public class SupportController : Controller
    {
        private readonly IContentService _contentService;
        private readonly ILogger<SupportController> _logger;

        public SupportController(IContentService contentService, ILogger<SupportController> logger)
        {
            _contentService = contentService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AnnotateSpecimen()
        {
            return View();
        }
        public IActionResult DataDefinitions()
        {
            return View();
        }

        public async Task<IActionResult> DetailedHelp()
        {
            ContentConfigurations contentConfigurations = await _contentService.GetContent("Search Syntax");
            return View(contentConfigurations);
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult FAQ()
        {
            return View();
        }
        public IActionResult GettingStarted()
        {
            return View();
        }
        public IActionResult Glossary()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult LatestChanges()
        {
            return View();
        }
        public IActionResult TermsOfUse()
        {
            return View();
        }
        public IActionResult SiteMap()
        {
            return View();
        }

    }
}