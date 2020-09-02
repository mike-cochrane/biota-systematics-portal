using System.Collections.Generic;
using System.Xml.Linq;

namespace SystematicsPortal.Web.Views.Documents.Components.Siblings
{
    public class SiblingsViewModel
    {
        public List<Sibling> Siblings { get; set; }

        public SiblingsViewModel()
        {
            Siblings = new List<Sibling>();
        }
    }

    public class Sibling
    {
        public string Name { get; set; }

        public XElement NameXml { get; set; }
    }
}
