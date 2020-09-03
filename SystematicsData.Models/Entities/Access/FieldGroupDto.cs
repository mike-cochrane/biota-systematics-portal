using System;
using System.Collections.Generic;

namespace SystematicsData.Models.Entities.Access
{
    public class FieldGroupDto
    {
        public Guid FieldGroupId { get; set; }

        public string DocumentClass { get; set; }
        
        public string DisplayTitle { get; set; }
        
        public string Name { get; set; }
        
        public int? DisplayOrder { get; set; }
        
        public string DisplayFormat { get; set; }

        public  List<FieldConfigurationDto> FieldConfigurations { get; set; }

        public FieldGroupDto()
        {
            FieldConfigurations = new List<FieldConfigurationDto>();
        }
    }
}
