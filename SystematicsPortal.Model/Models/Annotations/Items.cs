using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Systematics.Portal.Model.Models.Annotations
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
