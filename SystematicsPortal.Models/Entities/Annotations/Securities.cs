using System.Collections.Generic;
using System.Xml.Serialization;

namespace SystematicsPortal.Models.Entities.Annotations
{
    [XmlRoot("securities")]
    public class Securities
    {
        [XmlElement("security")]
        public List<SecurityLevelType> SecurityList { get; set; }

    }
}
