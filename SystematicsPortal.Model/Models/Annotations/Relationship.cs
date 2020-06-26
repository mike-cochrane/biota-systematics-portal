namespace Systematics.Portal.Model.Models.Annotations
{
    public class Relationship
    {
        [System.Xml.Serialization.XmlAttribute("relationshipTypeId")]
        public string RelationshipTypeId { get; set; }

        [System.Xml.Serialization.XmlAttribute("relationshipDirection")]
        public ItemRelationshipRelationshipDirection RelationshipDirection { get; set; }

        [System.Xml.Serialization.XmlAttribute("relatedItemId")]
        public string RelatedItemId { get; set; }

        [System.Xml.Serialization.XmlAttribute("relatedItemExternalId")]
        public string RelatedItemExternalId { get; set; }

        [System.Xml.Serialization.XmlText()]
        public string Title { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public enum ItemRelationshipRelationshipDirection
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("references")]
        References,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("is referenced")]
        IsReferenced,
    }
}
