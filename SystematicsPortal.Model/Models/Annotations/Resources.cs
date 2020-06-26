using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
