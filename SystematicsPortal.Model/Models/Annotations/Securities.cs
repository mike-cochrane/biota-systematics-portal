using System.Collections.Generic;
using System.Xml.Serialization;

namespace Systematics.Portal.Model.Models.Annotations
{
    [XmlRoot("securities")]
    public class Securities
    {
        [XmlElement("security")]
        public List<SecurityLevelType> SecurityList { get; set; }

    }
}
