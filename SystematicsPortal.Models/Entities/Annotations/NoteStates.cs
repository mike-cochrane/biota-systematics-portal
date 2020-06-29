using System.Collections.Generic;
using System.Xml.Serialization;

namespace SystematicsPortal.Models.Entities.Annotations
{
    [XmlRoot("noteStates")]
    public class NoteStates
    {
        [XmlElement("noteState")]
        public List<NoteState> States { get; set; }
    }
}
