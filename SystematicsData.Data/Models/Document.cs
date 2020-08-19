using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystematicsData.Data.Models
{
    public class Document
    {
        public Guid DocumentId { get; set; }

        public int Version { get; set; }

        public string SerializedDocument { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime ValidFrom { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime ValidTo { get; set; }
    }
}
