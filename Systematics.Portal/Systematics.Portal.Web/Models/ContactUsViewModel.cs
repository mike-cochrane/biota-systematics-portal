using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Systematics.Portal.Web.Models
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
            Name = string.Empty;
            Email = string.Empty;
            Organisation = string.Empty;
            Location = string.Empty;
            Subject = string.Empty;
            Message = string.Empty;
        }
    }
}
