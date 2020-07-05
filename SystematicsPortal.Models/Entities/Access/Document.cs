using System.Xml;

namespace SystematicsPortal.Models.Entities.Access
{
    public class Document
    {
        public XmlDocument XmlDocument { get; set; }

        public Document()
        {
            XmlDocument = new XmlDocument();
        }
    }
}
