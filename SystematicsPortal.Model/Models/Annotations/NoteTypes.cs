using System.Collections.Generic;
using System.Xml.Serialization;

namespace Systematics.Portal.Model.Models.Annotations
{
    [XmlRoot("noteTypes")]
    public class NoteTypes
    {
        [XmlElement("noteType")]
        public List<NoteType> Types { get; set; }
    }
}
