using Microsoft.AspNetCore.Mvc;

namespace SystematicsPortal.Web.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}