using System.Collections.Generic;
using System.Xml.Serialization;

namespace SystematicsData.Models.Entities.Annotations
{
    [XmlRoot("noteStates")]
    public class NoteStates
    {
        [XmlElement("noteState")]
        public List<NoteState> States { get; set; }
    }
}
