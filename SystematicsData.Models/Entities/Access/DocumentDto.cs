using System.Xml.Linq;
using System.Xml.Serialization;

namespace SystematicsData.Models.Entities.Access
{
    [XmlRoot(ElementName = "Document")]
    public class DocumentDto
    {
        public XElement XmlDocument { get; set; }

        public DocumentDto()
        {
        }
    }
}
