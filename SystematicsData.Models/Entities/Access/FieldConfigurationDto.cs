using System.Xml.Serialization;

namespace SystematicsData.Models.Entities.Access
{
    [XmlType(TypeName = "FieldConfiguration")]
    public class FieldConfigurationDto
    {
        public string DataDocumentXpath { get; set; }

        public string SiblingFilterXPath { get; set; }

        public int? DisplayOrder { get; set; }

        public string DisplayTemplate { get; set; }

        public string DisplayAsIcon { get; set; }

        public bool ShowAlways { get; set; }
    }
}
