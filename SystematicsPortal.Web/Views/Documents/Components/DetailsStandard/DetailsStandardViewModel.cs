using System.Collections.Generic;
using SystematicsPortal.Web.Models;

namespace SystematicsPortal.Web.Views.Documents.Components.DetailsStandard
{
    public class DetailsStandardViewModel
    {
        //public List<Biostatus> Biostatuses { get; set; }

        public List<Field> Fields { get; set; }

        public DetailsStandardViewModel()
        {
            Fields = new List<Field>();
        }
    }
}
