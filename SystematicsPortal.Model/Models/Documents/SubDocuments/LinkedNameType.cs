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
    public class LinkedNameType
    {

        private object[] iField;

        private string[] textField;

        private string nameFullField;

        private string nameIdField;

        
        [System.Xml.Serialization.XmlElementAttribute("i")]
        public object[] i
        {
            get
            {
                return this.iField;
            }
            set
            {
                this.iField = value;
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
    }
}
