using System;
using System.Collections.Generic;

namespace SystematicsPortal.Models.Entities.Database
{
    public class FieldGroup
    {
        public FieldGroup()
        {
            FieldConfiguration = new HashSet<FieldConfiguration>();
        }

        public Guid FieldGroupId { get; set; }
        public string DocumentClass { get; set; }
        public string DisplayTitle { get; set; }
        public string Name { get; set; }
        public int? DisplayOrder { get; set; }
        public string DisplayFormat { get; set; }

        public virtual ICollection<FieldConfiguration> FieldConfiguration { get; set; }
    }
}
