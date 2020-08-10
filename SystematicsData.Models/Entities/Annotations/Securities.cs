using System.Collections.Generic;
using System.Xml.Serialization;

namespace SystematicsData.Models.Entities.Annotations
{
    [XmlRoot("securities")]
    public class Securities
    {
        [XmlElement("security")]
        public List<SecurityLevelType> SecurityList { get; set; }

    }
}
