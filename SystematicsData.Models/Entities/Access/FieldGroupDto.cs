using System.Collections.Generic;

namespace SystematicsData.Models.Entities.Access
{
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
