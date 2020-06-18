using Microsoft.AspNetCore.Mvc;

namespace SystematicsPortal.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}