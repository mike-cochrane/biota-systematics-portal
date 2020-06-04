using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Model {
    public class Query {
        public int QueryId { get; private set; }
        public string QueryString { get; set; }
        public string CollectionFilter { get; set; }
        public Guid UserId { get; set; }
        public string AppliedFacetValues { get; set; }
        public string AppliedRanges { get; set; }
        public DateTime SubmittedTime { get; set; }
        public DateTime ReturnedTime { get; set; }
        public bool Success { get; set; }
        public int SpecimenCount { get; set; }
    }
}
