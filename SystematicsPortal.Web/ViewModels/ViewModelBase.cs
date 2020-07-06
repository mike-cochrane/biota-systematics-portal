using System;

namespace SystematicsPortal.Web.Models
{
    public class ViewModelBase {
        public string ImportantNotice { get; set; }

        public ViewModelBase() {
            ImportantNotice = String.Empty;
        }
    }
}