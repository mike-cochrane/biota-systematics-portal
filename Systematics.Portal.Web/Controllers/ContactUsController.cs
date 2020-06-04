using System;
using Microsoft.AspNetCore.Mvc;
using Systematics.Portal.Web.ViewModels;
using Systematics.Portal.Web.Helpers;

namespace Systematics.Portal.Web.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult ContactUs()
        {
            /*ContactUsViewModel viewData = new ContactUsViewModel();

            if (ClaimsPrincipal.Current.Identity.IsAuthenticated)
            {
                string firstName = ClaimsPrincipal.Current.FindFirst(ClaimTypes.GivenName).Value;
                string lastName = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Surname).Value;
                viewData.Name = firstName + " " + lastName;
                viewData.Email = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Email).Value;
            }*/

            //return View(viewData);
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs([FromBody] ContactUsViewModel model)
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
                    message += " has sent the following comment via the Systematics Collections Data website.</p>"
                        + model.Message;

                    Utility.SendEmail(recipient, model.Subject, message, model.Email);

                    info = "Thank you for your feedback. Your comment will be attended to within the next few days.";
                }
                else
                {
                    throw new Exception("null model");
                }
            }
            catch (Exception e)
            {
                error = "Sorry, an error occurred while processing your request. Error: " + e.Message;
            }

            JSONBaseModel viewData = new JSONBaseModel()
            {
                Error = error,
                Information = info
            };
            return Json(viewData);
        }
    }
}