namespace SystematicsPortal.Model.Models.Documents.SubDocuments
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DocumentDefinedConcept
    {

        private DocumentDefinedConceptAssociation[] associationsField;

        private string conceptIdField;

        private string nameIdField;

        private string nameFullField;


        [System.Xml.Serialization.XmlArrayItemAttribute("Association", IsNullable = false)]
        public DocumentDefinedConceptAssociation[] Associations
        {
            get
            {
                return this.associationsField;
            }
            set
            {
                this.associationsField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string conceptId
        {
            get
            {
                return this.conceptIdField;
            }
            set
            {
                this.conceptIdField = value;
            }
        }


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
        public string nameFull
        {
            get
            {
                return this.nameFullField;
            }
            set
            {
                this.nameFullField = value;
            }
        }
    }

}
