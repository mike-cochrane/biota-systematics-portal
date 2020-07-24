using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystematicsPortal.Models.Entities.Access
{
    public class ContentConfiguration
    {
        public Guid ContentConfigurationId { get; set; }
        public string Page { get; set; }
        public string Section { get; set; }
        public string SectionTitle { get; set; }
        public Guid? ExternalId { get; set; }
        public int? DisplayOrder { get; set; }
        public Content Content { get; set; }
    }
}
