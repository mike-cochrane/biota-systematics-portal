using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Configuration;
using Systematics.Portal.Web.ViewModels;
using Systematics.Portal.Web.Helpers;
using System.Security.Claims;

namespace Systematics.Portal.Web.Controllers
{
    public class SupportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AnnotateSpecimen()
        {
            return View();
        }
        public IActionResult DataDefinitions()
        {
            return View();
        }

        public IActionResult DetailedHelp()
        {
            return View();
        }
        public IActionResult FAQ()
        {
            return View();
        }
        public IActionResult GettingStarted()
        {
            return View();
        }
        public IActionResult Glossary()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult LatestChanges()
        {
            return View();
        }
        public IActionResult TermsOfUse()
        {
            return View();
        }
        public IActionResult SiteMap()
        {
            return View();
        }

    }
}