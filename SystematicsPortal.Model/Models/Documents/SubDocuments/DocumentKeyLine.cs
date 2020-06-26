using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystematicsPortal.Model.Models.Documents.SubDocuments
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class DocumentKeyLine
    {

        private TextType characteristicField;

        private DocumentKeyLineResultText resultTextField;

        private string idField;

        private string linePrefixField;


        public TextType Characteristic
        {
            get
            {
                return this.characteristicField;
            }
            set
            {
                this.characteristicField = value;
            }
        }


        public DocumentKeyLineResultText ResultText
        {
            get
            {
                return this.resultTextField;
            }
            set
            {
                this.resultTextField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string linePrefix
        {
            get
            {
                return this.linePrefixField;
            }
            set
            {
                this.linePrefixField = value;
            }
        }
    }

}
