using System;
using SystematicsData.Models.Configuration;

namespace SystematicsData.Models.Entities.Access
{
    public class FieldConfigurationDto
    {
        public Guid FieldConfigurationId { get; set; }

       
        public string DocumentClass { get; set; }
        
        public string DataDocumentXpath { get; set; }
        
        public int? DisplayOrder { get; set; }
        
        public string DisplayFormat { get; set; }
        
        public string DisplayAsIcon { get; set; }
        
        public string ExternalId { get; set; }
        
        public bool ShowAlways { get; set; }
    }
}
