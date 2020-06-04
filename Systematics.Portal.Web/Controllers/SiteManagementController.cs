using Microsoft.AspNetCore.Mvc;

namespace Systematics.Portal.Web.Controllers
{
    public class SiteManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}