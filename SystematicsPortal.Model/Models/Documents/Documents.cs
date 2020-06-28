using SystematicsPortal.Model.Models.Documents.Name;

namespace SystematicsPortal.Model.Models.Documents
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Documents
    {

        private NameDocument[] documentField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Document")]
        public NameDocument[] Document
        {
            get
            {
                return this.documentField;
            }
            set
            {
                this.documentField = value;
            }
        }
    }
}
