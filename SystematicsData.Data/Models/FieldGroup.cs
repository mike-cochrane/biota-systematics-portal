using System;
using System.Collections.Generic;

namespace SystematicsData.Data.Models
{
    public class FieldGroup
    {
        public Guid FieldGroupId { get; set; }
        public string DocumentClass { get; set; }
        public string DisplayTitle { get; set; }
        public string Name { get; set; }
        public int? DisplayOrder { get; set; }
        public string DisplayFormat { get; set; }

        public virtual ICollection<FieldConfiguration> FieldConfiguration { get; set; }

        public FieldGroup()
        {
            FieldConfiguration = new HashSet<FieldConfiguration>();
        }
    }
}
