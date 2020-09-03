using System;
using System.Collections.Generic;

namespace SystematicsData.Data.Models
{
    public class FieldGroup
    {
        public Guid FieldGroupId { get; set; }

        public Guid? ExternalId { get; set; }

        public string DocumentClass { get; set; }

        public string Name { get; set; }

        public string DisplayTitle { get; set; }

        public string Labels { get; set; }

        public int? DisplayOrder { get; set; }

        public virtual ICollection<FieldConfiguration> FieldConfiguration { get; set; }

        public FieldGroup()
        {
            FieldConfiguration = new HashSet<FieldConfiguration>();
        }
    }
}
