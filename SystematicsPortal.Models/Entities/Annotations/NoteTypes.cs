using System.Collections.Generic;
using System.Xml.Serialization;

namespace SystematicsPortal.Models.Entities.Annotations
{
    [XmlRoot("noteTypes")]
    public class NoteTypes
    {
        [XmlElement("noteType")]
        public List<NoteType> Types { get; set; }
    }
}
