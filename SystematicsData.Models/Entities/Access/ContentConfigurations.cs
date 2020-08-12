using System.Collections.Generic;
using System.Xml.Serialization;

namespace SystematicsData.Models.Entities.Access
{
    [XmlRoot("contentConfigurations")]
    public class ContentConfigurations
    {
        [XmlElement("contentConfiguration")]
        public List<ContentConfiguration> ContentConfigurationList { get; set; }

        public ContentConfigurations()
        {
            ContentConfigurationList = new List<ContentConfiguration>();
        }
    }
}
