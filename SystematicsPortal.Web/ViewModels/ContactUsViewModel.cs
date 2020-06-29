using System;
using System.ComponentModel.DataAnnotations;

namespace SystematicsPortal.Web.ViewModels
{
    public class ContactUsViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string Organisation { get; set; }

        public string Location { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        public ContactUsViewModel()
        {
            Name = String.Empty;
            Email = String.Empty;
            Organisation = String.Empty;
            Location = String.Empty;
            Subject = String.Empty;
            Message = String.Empty;
        }
    }
}
