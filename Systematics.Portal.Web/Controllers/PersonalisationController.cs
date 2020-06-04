using Microsoft.AspNetCore.Mvc;

namespace Systematics.Portal.Web.Controllers
{
    public class PersonalisationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}