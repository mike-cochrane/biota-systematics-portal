using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystematicsPortal.Model.Models.Documents
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DocumentType
    {

        private string nameIdField;

        private DocumentTypeDocumentClass documentClassField;

        private DocumentTypeSource sourceField;

        private System.DateTime addedField;

        private bool addedFieldSpecified;

        private System.DateTime updatedField;

        private bool updatedFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string nameId
        {
            get
            {
                return this.nameIdField;
            }
            set
            {
                this.nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public DocumentTypeDocumentClass documentClass
        {
            get
            {
                return this.documentClassField;
            }
            set
            {
                this.documentClassField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public DocumentTypeSource source
        {
            get
            {
                return this.sourceField;
            }
            set
            {
                this.sourceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime added
        {
            get
            {
                return this.addedField;
            }
            set
            {
                this.addedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool addedSpecified
        {
            get
            {
                return this.addedFieldSpecified;
            }
            set
            {
                this.addedFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime updated
        {
            get
            {
                return this.updatedField;
            }
            set
            {
                this.updatedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool updatedSpecified
        {
            get
            {
                return this.updatedFieldSpecified;
            }
            set
            {
                this.updatedFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public enum DocumentTypeDocumentClass
    {

        /// <remarks/>
        name,

        /// <remarks/>
        vernacular,

        /// <remarks/>
        reference,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public enum DocumentTypeSource
    {

        /// <remarks/>
        Names_Plants,

        /// <remarks/>
        Names_Fungi,

        /// <remarks/>
        Names_NZAC,
    }


}
