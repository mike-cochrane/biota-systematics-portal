using System;
using System.Xml.Serialization;

namespace Systematics.Portal.Model.Models.Annotations
{
    public class NoteType
    {
        [XmlAttribute("id")]
        public Guid Id { get; set; }
        [XmlIgnore]
        public Guid ClassId { get; set; }
        [XmlAttribute("class")]
        public string ClassTitle { get; set; }

        [XmlIgnore]
        public int? DisplayOrder { get; set; }
        [XmlAttribute("displayOrder")]
        public int DisplayOrderSerializable { get { return DisplayOrder.Value; } set { DisplayOrder = value; } }
        public bool ShouldSerializeDisplayOrder() { return DisplayOrder.HasValue; }

        [XmlIgnore]
        public int? NumberAllowedMin { get; set; }
        [XmlAttribute("minOccurrence")]
        public int NumberAllowedMinSerializable { get { return this.NumberAllowedMin.Value; } set { this.NumberAllowedMin = value; } }
        public bool ShouldSerializeNumberAllowedMinSerializable() { return this.NumberAllowedMin.HasValue; }

        [XmlIgnore]
        public int? NumberAllowedMax { get; set; }
        [XmlAttribute("maxOccurrence")]
        public int NumberAllowedMaxSerializable { get { return NumberAllowedMax.Value; } set { NumberAllowedMax = value; } }
        public bool ShouldSerializeNumberAllowedMaxSerializable() { return NumberAllowedMax.HasValue; }

        [XmlElement("parent")]
        public NoteTypeParent Parent { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
    }
}
