using System.Collections.Generic;

namespace SystematicsPortal.Web.Models
{
    public class ViewDefinition
    {
        public List<FieldDefinition> FieldDefinitions { get; set; }

        public ViewDefinition()
        {
            FieldDefinitions = new List<FieldDefinition>();
        }
    }
}
