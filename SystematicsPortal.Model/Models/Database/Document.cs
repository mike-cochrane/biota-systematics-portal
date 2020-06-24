using System;
using System.Collections.Generic;

namespace SystematicsPortal.Model.Models.Database
{
    public partial class Document
    {
        public Guid DocumentId { get; set; }
        public int Version { get; set; }
        public string SerializedDocument { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
