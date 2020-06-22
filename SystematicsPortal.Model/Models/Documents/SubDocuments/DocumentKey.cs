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
    public class DocumentKey
    {

        private DocumentKeyLine[] lineField;

        private string keyIdField;

        private string titleField;

        
        [System.Xml.Serialization.XmlElementAttribute("Line")]
        public DocumentKeyLine[] Line
        {
            get
            {
                return this.lineField;
            }
            set
            {
                this.lineField = value;
            }
        }

        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string keyId
        {
            get
            {
                return this.keyIdField;
            }
            set
            {
                this.keyIdField = value;
            }
        }

        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }
    }
}
