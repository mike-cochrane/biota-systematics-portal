using System.Collections.Generic;
using System.Xml.Serialization;

namespace Systematics.Portal.Model.Models.Annotations
{
    [XmlRoot("resources")]
    public class Resources
    {
        [XmlElement("resource")]
        public List<Resource> ResourceList { get; set; }
    }
}
