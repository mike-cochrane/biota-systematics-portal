using System.Collections.Generic;

namespace SystematicsData.Models.Entities.Access
{
    public class ViewDefinitionDto
    {
        public string DocumentClass { get; set; }

        public List<FieldGroupDto> FieldGroups { get; set; }

        public ViewDefinitionDto()
        {
            FieldGroups = new List<FieldGroupDto>();
        }
    }
}
