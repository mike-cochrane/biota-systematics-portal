using System;
using System.Collections.Generic;

namespace SystematicsPortal.Data.dbmodels
{
    public partial class ReferenceDocument
    {
        public Guid ReferenceId { get; set; }
        public int Version { get; set; }
        public string SerializedDocument { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
