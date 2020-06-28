using System.Xml;
using System.Xml.Linq;

namespace SystematicsPortal.Model.Models.Access
{
    public class Document
    {
        public XDocument XDocument { get; set; }
        public string SDocument { get; set; }
        public XmlDocument XmlDocument { get; set; }
    }
}
