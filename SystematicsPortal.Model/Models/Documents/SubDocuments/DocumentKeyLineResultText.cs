namespace SystematicsPortal.Model.Models.Documents.SubDocuments
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DocumentKeyLineResultText : TextType
    {

        private string nameIdField;

        private string otherKeyLineIdField;


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
        public string otherKeyLineId
        {
            get
            {
                return this.otherKeyLineIdField;
            }
            set
            {
                this.otherKeyLineIdField = value;
            }
        }
    }

}
