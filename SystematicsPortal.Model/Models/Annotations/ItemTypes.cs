using System.Collections.Generic;
using System.Xml.Serialization;

namespace Systematics.Portal.Model.Models.Annotations
{
    [XmlRoot("itemTypes")]
    public class ItemTypes
    {
        [XmlElement("itemType")]
        public List<ItemType> Types { get; set; }
    }
}
