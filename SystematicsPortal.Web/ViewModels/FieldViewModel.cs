using System.Collections.Generic;
using System.Xml;

namespace SystematicsPortal.Web.ViewModels
{
    public class FieldViewModel
    {
        public XmlNode xmlNode { get; set; }
        public List<XmlNode> xmlNodeList { get; set; }
        public int Order { get; set; }
        public string Label { get; set; }
        public string SectionHeading { get; set; }
        public bool IsSection { get; set; }
    }
}
