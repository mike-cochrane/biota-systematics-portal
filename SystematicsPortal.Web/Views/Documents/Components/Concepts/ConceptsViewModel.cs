using System.Collections.Generic;
using System.Xml.Linq;

namespace SystematicsPortal.Web.Views.Documents.Components.Concepts
{
    public class ConceptsViewModel
    {
        public List<Concept> Concepts { get; set; }

        public ConceptsViewModel()
        {
            Concepts = new List<Concept>();
        }
    }

    public class Concept
    {
        public string Name { get; set; }

        public XElement ReferenceXml { get; set; }
    }
}
