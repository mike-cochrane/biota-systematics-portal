using SolrNet.Attributes;
using System;
using System.Collections.Generic;

namespace SystematicsData.Search.Models
{
    public class SolrDocument
    {
        [SolrUniqueKey("id")]
        public string Id { get; set; }

        [SolrField("added")]
        public DateTime Added { get; set; }

        [SolrField("appliedToNameFull")]
        public List<string> AppliedToNameFull { get; set; }

        [SolrField("appliedToNameId")]
        public List<string> AppliedToNameId { get; set; }


        [SolrField("associationType")]
        public string AssociationType { get; set; }

        [SolrField("basionymAuthor")]
        public string BasionymAuthor { get; set; }

        [SolrField("canonical")]
        public string Canonical { get; set; }

        [SolrField("citeNameId")]
        public List<string> CiteNameId { get; set; }

        [SolrField("citedName")]
        public List<string> CitedName { get; set; }

        [SolrField("class")]
        public string Class { get; set; }

        [SolrField("classId")]
        public string ClassId { get; set; }

        [SolrField("combinationAuthor")]
        public string CombinationAuthor { get; set; }

        [SolrField("current")]
        public string Current { get; set; }

        [SolrField("currentFormatted")]
        public string CurrentFormatted { get; set; }

        [SolrField("currentId")]
        public string CurrentId { get; set; }

        [SolrField("deprecatedId")]
        public List<string> DeprecatedId { get; set; }

        [SolrField("documentClass")]
        public string DocumentClass { get; set; }

        [SolrField("externalLinkSource")]
        public List<string> ExternalLinkSource { get; set; }

        [SolrField("family")]
        public string Family { get; set; }

        [SolrField("familyId")]
        public string FamilyId { get; set; }
        //
        [SolrField("genus")]
        public string Genus { get; set; }

        [SolrField("genusId")]
        public string GenusId { get; set; }

        [SolrField("hybridParent")]
        public List<string> hybridParent { get; set; }

        [SolrField("hybridParentId")]
        public List<string> HybridParentId { get; set; }

        [SolrField("hyperLinkType")]
        public List<string> HyperLinkType { get; set; }

        [SolrField("imageUri")]
        public List<string> ImageUri { get; set; }

        [SolrField("kingdom")]
        public string Kingdom { get; set; }

        [SolrField("nameAuthor")]
        public string NameAuthor { get; set; }

        [SolrField("nameFormatted")]
        public string NameFormatted { get; set; }

        [SolrField("nameFull")]
        public string NameFull { get; set; }

        [SolrField("namePart")]
        public string NamePart { get; set; }

        [SolrField("namePartFormatted")]
        public List<string> NamePartFormatted { get; set; }

        [SolrField("nomCode")]
        public string NomCode { get; set; }

        [SolrField("note")]
        public List<string> Note { get; set; }
        [SolrField("nzBiostatusReference")]
        public List<string> NzBiostatusReference { get; set; }
        [SolrField("nzBiostatusReferenceId")]
        public string NzBiostatusReferenceId { get; set; }

        [SolrField("nzOccurrence")]
        public List<string> NzOccurrence { get; set; }

        [SolrField("nzOrigin")]
        public List<string> NzOrigin { get; set; }
        [SolrField("NzbioStatusAdded")]
        public List<DateTime> NzbioStatusAdded { get; set; }
        ///

        [SolrField("nzbioStatusUpdated")]
        public List<DateTime> NzbioStatusUpdated { get; set; }

        [SolrField("order")]
        public string Order { get; set; }

        [SolrField("orderId")]
        public string orderId { get; set; }

        [SolrField("parent")]
        public string Parent { get; set; }

        [SolrField("parentId")]
        public string ParentId { get; set; }

        [SolrField("parentReference")]
        public List<string> ParentReference { get; set; }

        [SolrField("parentReferenceId")]
        public string ParentReferenceId { get; set; }

        [SolrField("phylum")]
        public string Phylum { get; set; }

        [SolrField("phylumId")]
        public string PhylumId { get; set; }

        [SolrField("referenceType")]
        public string ReferenceType { get; set; }

        [SolrField("source")]
        public string Source { get; set; }

        [SolrField("taxonRank")]
        public string TaxonRank { get; set; }

        [SolrField("taxonRankSort")]
        public string TaxonRankSort { get; set; }

        [SolrField("title")]
        public string Title { get; set; }

        [SolrField("titleFormatted")]
        public List<string> TitleFormatted { get; set; }

        [SolrField("titleUnformatted")]
        public string TitleUnformatted { get; set; }
        [SolrField("updated")]
        public DateTime Updated { get; set; }

        [SolrField("vernacularId")]
        public List<string> VernacularId { get; set; }

        [SolrField("vernacularLanguageOfOrigin")]
        public List<string> VernacularLanguageOfOrigin { get; set; }

        [SolrField("vernacularLanguageOfUse")]
        public List<string> VernacularLanguageOfUse { get; set; }

        [SolrField("vernacularName")]
        public List<string> VernacularName { get; set; }

        [SolrField("vernacularRegionOfOrigin")]
        public string VernacularRegionOfOrigin { get; set; }

        [SolrField("vernacularRegionOfUse")]
        public string VernacularRegionOfUse { get; set; }

    }
}