using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Systematics.Portal.Model.Models.Annotations
{
    [XmlRoot(ElementName = "note")]

    public class Note
    {
        [XmlElement("added", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public NoteAdded Added { get; set; }
        
        // Solve NoteForm content problem
        [XmlElement("content", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XElement Content { get; set; }

        [XmlElement("securityLevel",Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SecurityLevelType SecurityLevel { get; set; }

        [XmlArray("images", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [XmlArrayItem("image", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<Image> Images { get; set; }

        /// <remarks/>
        [XmlAttribute("noteId")]
        public string NoteId { get; set; }
        
        /// <remarks/>
        [XmlAttribute("sequence")]
        public int Sequence { get; set; }
        
        /// <remarks/>
        [XmlAttribute("noteFormId")]
        public string NoteFormId { get; set; }

        /// <remarks/>
        [XmlAttribute("noteTypeId")]
        public string NoteTypeId { get; set; }

        /// <remarks/>
        [XmlAttribute("noteTypeTitle")]
        public string NoteTypeTitle { get; set; }


        /// <remarks/>
        [XmlAttribute("parentNoteTypeId")]
        public string ParentNoteTypeId { get; set; }

        /// <remarks/>
        [XmlAttribute("noteTypePath")]
        public string NoteTypePath { get; set; }
        
        /// <remarks/>
        [XmlAttribute("noteClass")]
        public string NoteClass { get; set; }
        
        public Note()
        {
            NoteId = string.Empty;
            NoteTypeId = string.Empty;
            Sequence = -1;
            NoteTypePath = string.Empty;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class NoteAdded
    {
        [System.Xml.Serialization.XmlAttributeAttribute("addedBy")]
        public string AddedBy { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute("addedDate")]
        public System.DateTime addedDate { get; set; }

        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value { get; set; }
    }
}
