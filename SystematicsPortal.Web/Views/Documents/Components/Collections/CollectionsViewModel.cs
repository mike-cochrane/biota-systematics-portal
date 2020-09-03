using System.Collections.Generic;
using System.Xml.Linq;

namespace SystematicsPortal.Web.Views.Documents.Components.Collections
{
    public class CollectionsViewModel
    {
        public List<Collection> Collections { get; set; }

        public CollectionsViewModel()
        {
            Collections = new List<Collection>();
        }
    }

    public class Collection
    {
        public XElement Name { get; set; }

        public string Country { get; set; }

        public string LandDistrict { get; set; }

        public int SpecimenCount { get; set; }
    }
}
