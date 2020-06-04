using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Model {
    public class Collection {
        public Guid CollectionId { get; set; }
        public string DisplayText { get; set; }
        public string Acronym { get; set; }
        public string Deck { get; set; }
        public string ImageFileName { get; set; }
        public string ReadMoreURL { get; set; }
        public string ResearchURL { get; set; }
        public int RecordCount { get; set; }
        public int SpecimenCount { get; set; }

        public Collection() {
            CollectionId = new Guid();
            DisplayText = string.Empty;
            Acronym = string.Empty;
            Deck = string.Empty;
            ImageFileName = string.Empty;
            ReadMoreURL = string.Empty;
            ResearchURL = string.Empty;
            RecordCount = 0;
            SpecimenCount = 0;
        }
    }
}
