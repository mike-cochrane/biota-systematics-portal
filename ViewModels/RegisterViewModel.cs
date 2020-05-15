using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SystematicPortal.Models
{
    public class RegisterViewModel
    {
        public string SelectedProvider { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Registration Failed")]
        public string ErrorMessage { get; set; }

        public string AccountManagerUrl { get; set; }

        public RegisterViewModel()
        {
            SelectedProvider = "none";
            Username = string.Empty;
            Password = string.Empty;
            ErrorMessage = string.Empty;
            AccountManagerUrl = ConfigurationManager.AppSettings["AccountManager"];
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
