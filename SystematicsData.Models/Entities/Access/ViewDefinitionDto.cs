using System.Collections.Generic;

namespace SystematicsData.Models.Entities.Access
{
    public class ViewDefinitionDto
    {
        public List<FieldGroupDto> FieldGroups { get; set; }

        public ViewDefinitionDto()
        {
            FieldGroups = new List<FieldGroupDto>();
        }
    }
}
