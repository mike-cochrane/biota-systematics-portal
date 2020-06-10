using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Search.Tools.Models.Search
{
    public class SetSpecimen
    {
        public int SetSpecimenId { get; set; }
        public int SetId { get; set; }
        public Guid SpecimenGuid { get; set; }
        public DateTime AddedDate { get; set; }
        public Document Summary { get; set; }

        public SetSpecimen()
        {
            SetSpecimenId = -1;
            SetId = -1;
            SpecimenGuid = Guid.Empty;
            AddedDate = DateTime.Now;
            Summary = new Document();
        }
    }
}
