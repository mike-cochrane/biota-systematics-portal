using System.Collections.Generic;

namespace SystematicsPortal.Web.Views.Documents.Components.Biostatus
{
    public class BiostatusViewModel
    {
        public List<Biostatus> Biostatuses { get; set; }

        public Dictionary<string, string> Labels { get; set; }

        public BiostatusViewModel()
        {
            Biostatuses = new List<Biostatus>();

            Labels = new Dictionary<string, string>();
        }
    }

    public class Biostatus
    {
        public string Occurence { get; set; }

        public string Georegion { get; set; }
    }
}
