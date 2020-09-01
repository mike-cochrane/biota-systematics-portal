using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystematicsData.Models.Entities.Access
{
    public class FieldGroup
    {
        public Guid FieldGroupId { get; set; }
        public string DocumentClass { get; set; }
        public string DisplayTitle { get; set; }
        public string Name { get; set; }
        public int? DisplayOrder { get; set; }
        public string DisplayFormat { get; set; }

        public virtual IEnumerable<FieldConfiguration> FieldConfigurations { get; set; }

        public FieldGroup()
        {
            FieldConfigurations = new HashSet<FieldConfiguration>();
        }
    }
}
