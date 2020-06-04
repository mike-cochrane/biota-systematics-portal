using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Model {
    public class SpecimenSummary {
        public Guid SpecimenId { get; set; }
        public int SecurityLevel { get; set; }
        public string Collection { get; set; }
        public string AccessionNumber { get; set; }
        public string TaxonName { get; set; }
        public string SubCollection { get; set; }
        public string Country { get; set; }
        public string LandDistrict { get; set; }
        public string EcologicalDistrict { get; set; }
        public string NZAreaCode { get; set; }
        public string Locality { get; set; }
        public string SpecimenType { get; set; }
        public string TypeStatus { get; set; }
        public bool HasImages { get; set; }
        public bool Selected { get; set; }

        public Int64 AccessionNumberSort { get; set; }
        public string TaxonNameSort { get; set; }
        //public string CountrySort { get; set; }
        //public string LandDistrictSort { get; set; }
        //public string EcologicalDistrictSort { get; set; }
        //public string NZAreaCodeSort { get; set; }

        public SpecimenSummary() {
            SpecimenId = Guid.Empty;
            SecurityLevel = 0;
            Collection = string.Empty;
            AccessionNumber = string.Empty;
            TaxonName = string.Empty;
            SubCollection = string.Empty;
            Country = string.Empty;
            LandDistrict = string.Empty;
            EcologicalDistrict = string.Empty;
            NZAreaCode = string.Empty;
            Locality = string.Empty;
            SpecimenType = string.Empty;
            TypeStatus = string.Empty;
            HasImages = false;
            Selected = false;

            AccessionNumberSort = Int64.MaxValue;
            TaxonNameSort = string.Empty;
            //CountrySort = string.Empty;
            //LandDistrictSort = string.Empty;
            //EcologicalDistrictSort = string.Empty;
            //NZAreaCodeSort = string.Empty;
        }
    }
}
