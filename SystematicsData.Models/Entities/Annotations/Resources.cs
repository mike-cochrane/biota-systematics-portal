using System.Collections.Generic;
using System.Xml.Serialization;

namespace SystematicsData.Models.Entities.Annotations
{
    [XmlRoot("resources")]
    public class Resources
    {
        [XmlElement("resource")]
        public List<Resource> ResourceList { get; set; }
    }
}
