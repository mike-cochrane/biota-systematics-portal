using Microsoft.AspNetCore.Mvc;

namespace Systematics.Portal.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}