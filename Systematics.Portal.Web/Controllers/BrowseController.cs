using Microsoft.AspNetCore.Mvc;

namespace Systematics.Portal.Web.Controllers
{
    public class BrowseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}