using System.ComponentModel;

namespace SystematicsData.Models.Entities.Access
{
    public class Concept
    {
        [DisplayName("Title")]
        public string Title { get; set; }
        [DisplayName("Definition")]
        public string Definition { get; set; }
    }
}
