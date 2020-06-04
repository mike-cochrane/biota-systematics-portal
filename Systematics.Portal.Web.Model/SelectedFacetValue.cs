using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Model {
    public class SelectedFacetValue {
        public string GroupName { get; set; }
        public string FacetName { get; set; }
        public string FacetLabel { get; set; }
        public string ValueName { get; set; }
        public string Label {
            get {
                return (FacetLabel + ": " + ValueName).Replace(" ", "&nbsp;");
            }
        }

        public SelectedFacetValue() {
            GroupName = string.Empty;
            FacetName = string.Empty;
            ValueName = string.Empty;
        }
    }
}
