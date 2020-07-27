using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SystematicsPortal.Models.Entities.Access
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
