using System;
using System.Collections.Generic;

namespace SystematicsPortal.Data.dbmodels
{
    public partial class StaticContentDocument
    {
        public Guid StaticContentId { get; set; }
        public int Version { get; set; }
        public string SerializedDocument { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
