using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Model {
    public class Contact {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Contact() {
            ContactId = -1;
            Name = string.Empty;
            Email = string.Empty;
        }
    }
}
