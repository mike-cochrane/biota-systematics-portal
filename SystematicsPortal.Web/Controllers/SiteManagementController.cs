using Microsoft.AspNetCore.Mvc;

namespace SystematicsPortal.Web.Controllers
{
    public class SiteManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}