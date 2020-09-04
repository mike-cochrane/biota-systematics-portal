using System.Collections.Generic;
using System.Xml.Serialization;

namespace SystematicsData.Models.Entities.Access
{
    [XmlRoot(ElementName = "ViewDefinition")]
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
