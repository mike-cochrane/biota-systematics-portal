using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Systematics.Portal.Web.Models {
    public class ViewModelBase {
        public string ImportantNotice { get; set; }

        public ViewModelBase() {
            ImportantNotice = string.Empty;
        }
    }
}