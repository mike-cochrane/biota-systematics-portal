using System;
using System.Collections.Generic;

namespace SystematicsData.Search.Models.Search
{
    public class Set
    {
        public int SetId { get; set; }
        public Guid OwnerId { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<SetSpecimen> Specimens { get; set; }

        public Set()
        {
            SetId = -1;
            OwnerId = Guid.Empty;
            DisplayName = String.Empty;
            Description = String.Empty;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.MinValue;
            Specimens = new List<SetSpecimen>();
        }
    }
}
