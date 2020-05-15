using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Systematics.Portal.Web.Models
{
    public class LoginViewData
    {
        [Required()]
        public string Username { get; set; }

        [Required(),
        DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Remeber me?")]
        public bool RememberMe { get; set; }

        public string SelectedProvider { get; set; }

        [DisplayName("Log In Failed")]
        public string ErrorMessage { get; set; }

        public string AccountManagerUrl { get; set; }

        public LoginViewData()
        {
            Username = string.Empty;
            Password = string.Empty;
            RememberMe = false;
            ErrorMessage = string.Empty;
            SelectedProvider = "none";
            // TODO: Get url using DI
            AccountManagerUrl = "";//ConfigurationManager.AppSettings["AccountManager"];
        }

        public string GetCreateAccountUrl()
        {
            return AccountManagerUrl + "/Account/Create?referringApplication=CIS_Web";
        }

        public string GetForgottenPasswordUrl()
        {
            return AccountManagerUrl + "/Account/ForgotPassword";
        }
    }
}
