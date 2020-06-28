
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Systematics.Portal.Model.Models.Annotations
{
    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [XmlAttribute("itemId")]
        //[XmlElement("itemId")]
        public string ItemId { get; set; }
        [XmlAttribute("providedId")]
        public string ProvidedId { get; set; }
        [XmlAttribute("response")]
        public string Response { get; set; }

        [XmlElement("itemType", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ItemType ItemType { get; set; }
        [XmlElement("added", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Added Added { get; set; }

        [XmlElement("updated", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Updated Updated { get; set; }
        [XmlElement("displayTitle", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XElement DisplayTitle { get; set; }

        [XmlElement("resource", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Resource Resource { get; set; }
        [XmlElement("external", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public External External { get; set; }
        [XmlElement("securityLevel", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SecurityLevelType SecurityLevel { get; set; }
        [XmlArray("notes", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [XmlArrayItem("note", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<Note> Notes { get; set; }

        //This list is ordered by vocabulary, then by sequence as defined in the vocabulary
        [XmlArray("associatedTerms", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [XmlArrayItem("associatedTerm", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<Term> AssociatedTerms { get; set; }

        // We will receive all the related items including parent
        [XmlArray("relatedItems", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [XmlArrayItem("relationship", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<Relationship> relatedItems { get; set; }

        //This list is ordered alphabetically by the unformatted display title of the items this Item is cited from
        [XmlArray("citations", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [XmlArrayItem("citation", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<Citation> Citations { get; set; }


        public Item()
        {
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Added
    {
        [System.Xml.Serialization.XmlAttributeAttribute("addedBy")]
        public string AddedBy { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute("addedDate")]
        public DateTime AddedDate { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Updated
    {
        [System.Xml.Serialization.XmlAttributeAttribute("updatedBy")]
        public string UpdatedBy { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("updatedDate")]
        public System.DateTime UpdatedDate { get; set; }
    }
}
