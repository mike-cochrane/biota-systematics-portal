using System.Collections.Generic;

namespace SystematicsPortal.Web.Views.Documents.Components.Biostatus
{
    public class BiostatusViewModel
    {
        public List<Biostatus> Biostatuses { get; set; }

        public BiostatusViewModel()
        {
            Biostatuses = new List<Biostatus>();
        }
    }

    public class Biostatus
    {
        public string Origin { get; set; }

        public string Occurence { get; set; }

        public string Georegion { get; set; }
    }
}
