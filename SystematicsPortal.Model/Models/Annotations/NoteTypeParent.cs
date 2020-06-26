﻿using System;
using System.Xml.Serialization;

namespace Systematics.Portal.Model.Models.Annotations
{
    public class NoteTypeParent
    {
        [XmlIgnore]
        public Guid? Id { get; set; }
        [XmlAttribute("id")]
        public Guid IdSerializable { get { return Id.Value; } set { Id = value;} }
        public bool ShouldSerializeIdSerializable() { return Id.HasValue; }
        [XmlText]
        public string Title { get; set; }
    }
}
