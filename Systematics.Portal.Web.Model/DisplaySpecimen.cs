using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Systematics.Portal.Web.Model {
    public class DisplaySpecimen {
        public int SpecimenWebId { get; set; }
        public Guid SpecimenGuid { get; set; }
        public int SecurityLevel { get; set; }
        public string AccessionNumber { get; set; }
        public XElement Display { get; set; }
        public Guid CollectionId { get; set; }
        public string CollectionName { get; set; }
        public string CollectionAcronym { get; set; }

        public DisplaySpecimen() {
            SpecimenWebId = -1;
            SpecimenGuid = Guid.Empty;
            SecurityLevel = 40;
            AccessionNumber = string.Empty;
            Display = null;
            CollectionId = Guid.Empty;
            CollectionName = string.Empty;
            CollectionAcronym = string.Empty;
        }
    }
}
