using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using Systematics.Portal.Web.ViewModels;
using Systematics.Portal.Web.Helpers;

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
        public IActionResult ContactUs()
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
        public IActionResult ReleaseNotes()
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

        /*[System.Web.Mvc.HttpPost]
        public System.Web.Mvc.ActionResult ContactUs(ContactUsViewModel model)
        {
            string info = string.Empty;
            string error = string.Empty;

            try
            {
                if (model != null)
                {
                    string recipient = "nikoos@landcareresearch.co.nz";

                    string message = "<p>" + model.Name;
                    if (model.Organisation != null && !model.Organisation.Equals(string.Empty))
                    {
                        message += ", " + model.Organisation;
                        if (model.Location != null && !model.Location.Equals(string.Empty))
                        {
                            message += ", " + model.Location;
                        }
                    }
                    else if (model.Location != null && !model.Location.Equals(string.Empty))
                    {
                        message += " from " + model.Location;
                    }
                    message += " has sent the following comment via the Systematics Collections Data website."
                        + " To respond to " + model.Name + ", please use the following email address: " + model.Email + ".</p>"
                        + model.Message;

                    Utility.SendEmail(recipient, model.Subject, message);

                    info = "Thank you for your feedback. Your comment will be attended to within the next few days.";
                }
                else
                {
                    throw new Exception("null model");
                }
            }
            catch (Exception)
            {
                error = "Sorry, an error occurred while processing your request.";
            }

            JSONBaseModel viewData = new JSONBaseModel()
            {
                Error = error,
                Information = info
            };
            return Json(viewData, JsonRequestBehavior.AllowGet);
        }*/
    }
}