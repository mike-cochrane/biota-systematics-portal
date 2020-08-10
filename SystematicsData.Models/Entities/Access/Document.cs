using System.Xml;

namespace SystematicsData.Models.Entities.Access
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
