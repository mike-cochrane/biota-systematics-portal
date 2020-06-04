using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Model {
    public class SectionContent {
        public int SectionContentId { get; set; }
        public string PageType { get; set; }
        public string SectionType { get; set; }
        public string Content { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
    }
}
