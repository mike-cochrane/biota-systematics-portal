using Microsoft.AspNetCore.Mvc;

namespace Systematics.Portal.Web.Controllers
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