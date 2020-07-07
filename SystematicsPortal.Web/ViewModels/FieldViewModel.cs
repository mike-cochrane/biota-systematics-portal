using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystematicsPortal.Models.Entities.Documents.SubDocuments;

namespace SystematicsPortal.Web.ViewModels
{
    public class FieldViewModel
    {
        public Object Field { get; set; }
        public TextType FieldTextType { get; set; }
        public ReferenceType FieldReferenceType { get; set; }
        public LinkedNameType FieldLinkedNameType { get; set; }
        public string EnglishLabel { get; set; }
        public int Order { get; set; }
        public string FieldType { get; set; }
        public string FieldName { get; set; }
    }
}
