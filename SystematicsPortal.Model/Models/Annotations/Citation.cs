using System;
using System.Xml.Serialization;

namespace Systematics.Portal.Model.Models.Annotations
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class Citation
    {
        // The unique identifier assigned to the citation by dScribe upon saving when it is empty
        [System.Xml.Serialization.XmlAttributeAttribute("citationId")]
        public string CitationId { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute("citationDirection")]
        public ItemCitationCitationDirection CitationDirection { get; set; }

        // ItemId of the Item which is cited
        [System.Xml.Serialization.XmlAttributeAttribute("itemId")]
        public string ItemId { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute("itemExternalId")]
        public string ItemExternalId { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute("tableId")]
        public string TableId { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute("imageUseId")]
        public string ImageUseId { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute("plateImageUseId")]
        public string PlateImageUseId { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute("imageUrl")]
        public string ImageUrl { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute("plateUrl")]
        public string PlateUrl { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute("brokenLink")]
        public bool BrokenLink { get; set; }

        // Display title of the Item which cites
        [System.Xml.Serialization.XmlTextAttribute()]
        public string CitedItemDisplayTitle { get; set; }
        
        public Citation()
        {
            CitedItemDisplayTitle = string.Empty;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public enum ItemCitationCitationDirection
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("cites")]
        Cites,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("cited by")]
        CitedBy
    }
}
