using Microsoft.AspNetCore.Mvc;

namespace SystematicsPortal.Web.Controllers
{
    public class DownloadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListOfAvailableDownloads()
        {
            return View();
        }
    }
}