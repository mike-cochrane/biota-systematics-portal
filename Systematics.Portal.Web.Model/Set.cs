using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Model {
    public class Set {
        public int SetId { get; set; }
        public Guid OwnerId { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<SetSpecimen> Specimens { get; set; }

        public Set() {
            SetId = -1;
            OwnerId = Guid.Empty;
            DisplayName = string.Empty;
            Description = string.Empty;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.MinValue;
            Specimens = new List<SetSpecimen>();
        }
    }
}
