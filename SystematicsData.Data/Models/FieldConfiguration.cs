using System;

namespace SystematicsData.Data.Models
{
    public class FieldConfiguration
    {
        public Guid FieldConfigurationId { get; set; }

        public Guid FieldGroupId { get; set; }

        public Guid? ParentFieldConfigurationId { get; set; }

        public Guid? ExternalId { get; set; }

        public string DataDocumentXpath { get; set; }

        public string SiblingFilterXpath { get; set; }

        public string Labels { get; set; }

        public int? DisplayOrder { get; set; }

        public string DisplayTemplate { get; set; }

        public string DisplayAsIcon { get; set; }

        public bool ShowAlways { get; set; }

        public virtual FieldGroup FieldGroup { get; set; }
    }
}
