using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystematicsPortal.Data.dbmodels
{
    public partial class NameDocument
    {
        public Guid NameId { get; set; }
        public int Version { get; set; }
        public string SerializedDocument { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime ValidFrom { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime ValidTo { get; set; }
    }
}
