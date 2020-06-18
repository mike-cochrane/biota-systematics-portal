using Microsoft.AspNetCore.Mvc;

namespace SystematicsPortal.Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SavedList()
        {
            return View();
        }

        public IActionResult TaxonWatchList()
        {
            return View();
        }
        public IActionResult RequestDownload()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }
    }
}