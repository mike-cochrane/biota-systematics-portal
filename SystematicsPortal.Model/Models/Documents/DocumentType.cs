namespace SystematicsPortal.Model.Models.Documents
{

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


    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public enum DocumentTypeDocumentClass
    {


        name,


        vernacular,


        reference,
    }


    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public enum DocumentTypeSource
    {


        Names_Plants,


        Names_Fungi,


        Names_NZAC,
    }


}
