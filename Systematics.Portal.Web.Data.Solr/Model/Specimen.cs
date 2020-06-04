using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systematics.Portal.Web.Data.Solr.Model
{
    public class Specimen
    {
        [SolrUniqueKey("id")]
        public int Id { get; set; }

        //Display Result
        [SolrField("taxonomicName_dr")]
        public string TaxonomicName { get; set; }
        [SolrField("country_dr")]
        public string Country { get; set; }
        [SolrField("landDistrict_dr")]
        public string LandDistrict { get; set; }
        [SolrField("ecologicalDistrict_dr")]
        public string EcologicalDistrict { get; set; }
        [SolrField("nzAreaCode_dr")]
        public string NZAreaCode { get; set; }
        [SolrField("locality_dr")]
        public string Locality { get; set; }

        //Specimen
        [SolrField("specimenId")]
        public string SpecimenId { get; set; }
        [SolrField("accessionNumber")]
        public string AccessionNumber { get; set; }
        [SolrField("dateAdded")]
        public int DateAdded { get; set; }
        [SolrField("last_modified")]
        public int DateUpdated { get; set; }
        //[SolrField("securityLevel")]
        //public int SecurityLevel { get; set; }
        [SolrField("collection")]
        public string Collection { get; set; }
        //[SolrField("duplicates")]
        //public ICollection<string> Duplicates { get; set; }
        //[SolrField("exsiccata")]
        //public string Exsiccata { get; set; }
        [SolrField("kindOfSpecimen")]
        public string KindOfSpecimen { get; set; }
        //[SolrField("loanStatus")]
        //public string LoadStatus { get; set; }
        //[SolrField("referenceNumber")]
        //public ICollection<string> ReferenceNumber { get; set; }
        [SolrField("subcollection")]
        public string Subcollection { get; set; }
        [SolrField("typeStatus")]
        public string TypeStatus { get; set; }
        [SolrField("hasImages")]
        public bool HasImages { get; set; }

        //Collection Event
        [SolrField("collectionDate")]
        public ICollection<int> CollectionDate { get; set; }
        [SolrField("collectionYear")]
        public ICollection<int> CollectionYear { get; set; }
        [SolrField("altitude")]
        public ICollection<int> Altitude { get; set; }
        [SolrField("localHeight")]
        public ICollection<int> LocalHeight { get; set; }
        //[SolrField("abundance")]
        //public ICollection<string> Abundance { get; set; }
        //[SolrField("collectionMethod")]
        //public ICollection<string> CollectionMethod { get; set; }
        //[SolrField("collectionMonth")]
        //public ICollection<string> CollectionMonth { get; set; }
        //[SolrField("collector")]
        //public ICollection<string> Collector { get; set; }
        //[SolrField("country")]
        //public ICollection<string> Countries { get; set; }
        //[SolrField("ecologicalDistrict")]
        //public ICollection<string> EcologicalDistricts { get; set; }
        //[SolrField("keyword")]
        //public ICollection<string> Keyword { get; set; }
        //[SolrField("landDistrict")]
        //public ICollection<string> LandDistricts { get; set; }
        //[SolrField("nzAreaCode")]
        //public ICollection<string> NZAreaCodes { get; set; }
        //[SolrField("observedSpecies")]
        //public ICollection<string> ObservedSpecies { get; set; }
        //[SolrField("typeOfCollectionEvent")]
        //public ICollection<string> TypeOfCollectionEvet { get; set; }

        //Culture
        //[SolrField("cultureViability")]
        //public ICollection<string> CultureViability { get; set; }
        //[SolrField("storageMethod")]
        //public ICollection<string> StorageMethod { get; set; }

        //Identification
        [SolrField("identificationDate")]
        public ICollection<int> IdentificationDate { get; set; }
        //[SolrField("associationType")]
        //public ICollection<string> AssociationType { get; set; }
        //[SolrField("class")]
        //public ICollection<string> TaxonClass { get; set; }
        //[SolrField("componentLevel")]
        //public ICollection<string> ComponentLevel { get; set; }
        //[SolrField("determiner")]
        //public ICollection<string> Determiner { get; set; }
        //[SolrField("family")]
        //public ICollection<string> Family { get; set; }
        //[SolrField("identificationUncertain")]
        //public ICollection<string> IdenificationUncertain { get; set; }
        //[SolrField("occurrence")]
        //public ICollection<string> Occurrence { get; set; }
        //[SolrField("order")]
        //public ICollection<string> TaxonOrder { get; set; }
        //[SolrField("origin")]
        //public ICollection<string> Origin { get; set; }
        //[SolrField("preferredName")]
        //public ICollection<string> PreferredName { get; set; }
        //[SolrField("taxonomicName")]
        //public ICollection<string> TaxonomicNames { get; set; }
        //[SolrField("typeOfIdentification")]
        //public ICollection<string> TypeOfIdentification { get; set; }

        //Specimen event
        [SolrField("actionedDate")]
        public ICollection<int> ActionedDate { get; set; }
        //[SolrField("actionedBy")]
        //public ICollection<string> ActionedBy { get; set; }
        //[SolrField("typeOfEvent")]
        //public ICollection<string> TypeOfEvent { get; set; }

        //Specimen flag
        //[SolrField("flagValue")]
        //public ICollection<string> FlagValue { get; set; }
        //[SolrField("typeOfFlag")]
        //public ICollection<string> TypeOfFlag { get; set; }

        //Transaction
        //[SolrField("organisation")]
        //public ICollection<string> Organisation { get; set; }
        //[SolrField("transactionStatus")]
        //public ICollection<string> TransactionStatus { get; set; }

        //Sorting
        [SolrField("accessionNumberSort")]
        public Int64 AccessionNumberSort { get; set; }
        //[SolrField("countrySort")]
        //public string CountrySort { get; set; }
        //[SolrField("ecologicalDistrictSort")]
        //public string EcologicalDistrictSort { get; set; }
        //[SolrField("landDistrictSort")]
        //public string LandDistrictSort { get; set; }
        //[SolrField("nzAreaCodeSort")]
        //public string NZAreaCodeSort { get; set; }
        [SolrField("taxonomicNameSort_dr")]
        public string TaxonomicNameSort { get; set; }
    }
}
