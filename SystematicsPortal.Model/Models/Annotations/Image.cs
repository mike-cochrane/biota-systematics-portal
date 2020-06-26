using System.Xml.Linq;
using System.Xml.Serialization;

namespace Systematics.Portal.Model.Models.Annotations
{
    public class Image
    {
        [XmlElement("caption")]
        public XElement Caption { get; set; }
        [XmlElement("externalSourceRetrieveString")]
        public string ExternalSourceRetrieveString { get; set; }
        [XmlAttribute("externalId")]
        public string ExternalId { get; set; }
        [XmlAttribute("displayOrder")]
        public int displayOrder { get; set; }
       

        public Image()
        {
            ExternalId = string.Empty;
            ExternalSourceRetrieveString = string.Empty;
        }
    }
}
