using System.Collections.Generic;
using System.Xml.Serialization;

namespace SystematicsPortal.Models.Entities.Annotations
{
    [XmlRoot("itemTypes")]
    public class ItemTypes
    {
        [XmlElement("itemType")]
        public List<ItemType> Types { get; set; }
    }
}
