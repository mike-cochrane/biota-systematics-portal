using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Model {
    public abstract class Filter {
        public string Name { get; set; }
        public string DisplayText { get; set; }
    }
}
