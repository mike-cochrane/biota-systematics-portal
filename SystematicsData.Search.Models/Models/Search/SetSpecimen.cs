using System;

namespace SystematicsData.Search.Models.Search
{
    public class SetSpecimen
    {
        public int SetSpecimenId { get; set; }
        public int SetId { get; set; }
        public Guid SpecimenGuid { get; set; }
        public DateTime AddedDate { get; set; }
        public SolrDocument SpecimenSummary { get; set; }

        public SetSpecimen()
        {
            SetSpecimenId = -1;
            SetId = -1;
            SpecimenGuid = Guid.Empty;
            AddedDate = DateTime.Now;
            SpecimenSummary = new SolrDocument();
        }
    }
}
