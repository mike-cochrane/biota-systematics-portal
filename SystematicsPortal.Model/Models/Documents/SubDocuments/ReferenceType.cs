namespace SystematicsPortal.Model.Models.Documents.SubDocuments
{

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class ReferenceType
    {

        private object[] itemsField;

        private string[] textField;

        private string referenceIdField;


        [System.Xml.Serialization.XmlElementAttribute("i")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }


        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string referenceId
        {
            get
            {
                return this.referenceIdField;
            }
            set
            {
                this.referenceIdField = value;
            }
        }
    }

}
