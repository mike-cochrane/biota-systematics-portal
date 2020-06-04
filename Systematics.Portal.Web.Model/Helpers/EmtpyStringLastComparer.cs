using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Model.Helpers {
    public class EmptyStringLastComparer : IComparer<string> {
        public int Compare(string x, string y) {
            if (string.IsNullOrEmpty(y) && !string.IsNullOrEmpty(x)) {
                return -1;
            }
            else if (!string.IsNullOrEmpty(y) && string.IsNullOrEmpty(x)) {
                return 1;
            }
            else {
                return string.Compare(x, y);
            }
        }
    }
}
