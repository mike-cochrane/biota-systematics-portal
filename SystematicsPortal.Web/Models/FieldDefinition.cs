using System.Collections.Generic;

namespace SystematicsPortal.Web.Models
{
    public class FieldDefinition
    {
        public string Label { get; set; }

        public string XPath { get; set; }

        public int Order { get; set; }

        public string Template { get; set; }

        public Dictionary<string, string> DataLabels { get; set; }

        public List<FieldConfiguration> FieldConfigurations { get; set; }


        public FieldDefinition()
        {
            DataLabels = new Dictionary<string, string>();
            FieldConfigurations = new List<FieldConfiguration>();
        }
    }
}
