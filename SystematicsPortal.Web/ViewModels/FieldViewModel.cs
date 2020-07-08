using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using SystematicsPortal.Models.Entities.Documents.SubDocuments;

namespace SystematicsPortal.Web.ViewModels
{
    public class FieldViewModel
    {
        public XmlNode xmlNode { get; set; }
        public XmlNodeList xmlNodeList { get; set; }
        public int Order { get; set; }
        public string Label { get; set; }
    }
}
