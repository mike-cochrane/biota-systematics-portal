using System.Collections.Generic;
using System.Xml.Serialization;

namespace SystematicsData.Models.Entities.Access
{
    [XmlType(TypeName = "FieldGroup")]
    public class FieldGroupDto
    {
        public string DisplayTitle { get; set; }

        public string Name { get; set; }

        public int? DisplayOrder { get; set; }

        public List<FieldConfigurationDto> FieldConfigurations { get; set; }

        public FieldGroupDto()
        {
            FieldConfigurations = new List<FieldConfigurationDto>();
        }
    }
}
