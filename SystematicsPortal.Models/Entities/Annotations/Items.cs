using System.Collections.Generic;
using System.Xml.Serialization;

namespace SystematicsPortal.Models.Entities.Annotations
{
    [XmlRoot("items")]
    public class Items
    {
        [XmlElement("item")]
        public List<Item> ItemsList { get; set; }

        public Items()
        {
            ItemsList = new List<Item>();
        }
    }
}
