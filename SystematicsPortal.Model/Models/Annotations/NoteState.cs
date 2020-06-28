using System;
using System.Xml.Serialization;

namespace Systematics.Portal.Model.Models.Annotations
{
    public class NoteState
    {
        [XmlAttribute("id")]
        public Guid Id { get; set; }
        [XmlElement("label")]
        public string Label { get; set; }
        [XmlAttribute("isEditable")]
        public bool IsEditable { get; set; }
        [XmlAttribute("displayOrder")]
        public int DisplayOrder { get; set; }

    }
}
