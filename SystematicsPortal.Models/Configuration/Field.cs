using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SystematicsPortal.Models.Configuration
{
    [XmlRoot(ElementName = "field")]
    public class Field
    {
        [XmlAttribute("documentId")]
        public string DocumentId { get; set; }
        [XmlElement("description", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XElement Description { get; set; }
        [XmlArray("labels", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [XmlArrayItem("label", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<Label> Labels { get; set; }

    }

    [XmlRoot("labels")]
    public class Labels
    {
        [XmlElement("label")]
        public List<Label> LabelsList { get; set; }

        public Labels()
        {
            LabelsList = new List<Label>();
        }
    }

    public class Label
    {
        [XmlElement("title", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XElement Title;
        [XmlElement("language", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Language;
    }
}
