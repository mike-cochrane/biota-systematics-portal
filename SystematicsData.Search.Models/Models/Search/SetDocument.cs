using System;

namespace SystematicsData.Search.Models.Search
{
    public class SetDocument
    {
        public int SetSpecimenId { get; set; }
        public int SetId { get; set; }
        public Guid SpecimenGuid { get; set; }
        public DateTime AddedDate { get; set; }
        public SolrDocument SolrDocument { get; set; }

        public SetDocument()
        {
            SetSpecimenId = -1;
            SetId = -1;
            SpecimenGuid = Guid.Empty;
            AddedDate = DateTime.Now;
            SolrDocument = new SolrDocument();
        }
    }
}
