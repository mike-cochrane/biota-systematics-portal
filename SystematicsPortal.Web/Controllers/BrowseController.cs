using Microsoft.AspNetCore.Mvc;

namespace SystematicsPortal.Web.Controllers
{
    public class BrowseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}