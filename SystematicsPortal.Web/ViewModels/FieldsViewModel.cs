using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystematicsPortal.Models.Entities.Documents.Name;

namespace SystematicsPortal.Web.ViewModels
{
    public class FieldsViewModel
    {
        public List<FieldViewModel> Fields { get; set; }
        public NameDocument NameDocument { get; set; }
    }
}
