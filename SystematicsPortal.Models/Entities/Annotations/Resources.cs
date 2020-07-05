using System.Collections.Generic;
using System.Xml.Serialization;

namespace SystematicsPortal.Models.Entities.Annotations
{
    [XmlRoot("resources")]
    public class Resources
    {
        [XmlElement("resource")]
        public List<Resource> ResourceList { get; set; }
    }
}
