using System;

namespace SystematicsPortal.Models.Entities.Database
{
    public class FieldConfiguration
    {
        public Guid FieldConfigurationId { get; set; }
        public string DocumentClass { get; set; }
        public string DataDocumentXpath { get; set; }
        public Guid? ExternalId { get; set; }
        public string Labels { get; set; }
        public Guid FieldGroupId { get; set; }
        public int? DisplayOrder { get; set; }
        public bool ShowAlways { get; set; }
        public string DisplayFormat { get; set; }
        public string DisplayAsIcon { get; set; }

        public virtual FieldGroup FieldGroup { get; set; }
    }
}
