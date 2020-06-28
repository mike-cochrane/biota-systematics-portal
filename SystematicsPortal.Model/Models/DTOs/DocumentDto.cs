using System;
using System.Collections.Generic;
using SystematicsPortal.Model.Models.Documents;
using SystematicsPortal.Model.Models.Documents.Name;
using SystematicsPortal.Model.Models.Documents.SubDocuments;

namespace SystematicsPortal.Model.Models.DTOs
{
    public class DocumentDto
    {
        #region Common properties
        public string NameId { get; set; }

        public DocumentTypeDocumentClass DocumentClass { get; set; }

        public DocumentTypeSource Source { get; set; }

        public DateTime Added { get; set; }

        public bool AddedSpecified { get; set; }

        public DateTime Updated { get; set; }

        public bool UpdatedSpecified { get; set; }

        public ReferenceType ParentReference { get; set; }
        #endregion

        #region Document Type "Name Properties" 

        public DocumentName Name { get; set; }

        public TextType NameFormatted { get; set; }


        public TextType NameScientific { get; set; }


        public string NamePartFormatted { get; set; }


        public string Orthography { get; set; }


        public string Page { get; set; }


        public string YearOfPublication { get; set; }


        public string YearOnPublication { get; set; }


        public DocumentClassification Classification { get; set; }


        public string TypeLocality { get; set; }


        public string SanctioningAuthor { get; set; }


        public string SanctioningPage { get; set; }


        public string HybridLink { get; set; }


        public string CheckStatus { get; set; }



        public ReferenceType NameReference { get; set; }


        public ReferenceType TaxonomyReference { get; set; }

        public LinkedNameType Parent { get; set; }

        public LinkedNameType CurrentName { get; set; }

        public List<LinkedNameType> Synonyms { get; set; }

        public List<LinkedNameType> Siblings { get; set; }

        public List<LinkedNameType> Subordinates { get; set; }

        public LinkedNameType Basionym { get; set; }

        public LinkedNameType BasedOn { get; set; }

        public LinkedNameType Blocking { get; set; }

        public LinkedNameType AnamorphGenus { get; set; }

        public ReferenceType AnamorphReference { get; set; }

        public LinkedNameType TypeTaxon { get; set; }

        public string ForeignId { get; set; }

        public LinkedNameType Kingdom { get; set; }

        public LinkedNameType Phylum { get; set; }

        public LinkedNameType Class { get; set; }

        public LinkedNameType Order { get; set; }

        public LinkedNameType Family { get; set; }

        public LinkedNameType Genus { get; set; }

        public List<DocumentAppliedVernacular> AppliedVernaculars { get; set; }

        public List<DocumentBiostatusValue> BiostatusValues { get; set; }

        public List<DocumentConcept> Concepts { get; set; }

        public List<DocumentNote> Notes { get; set; }

        public List<DocumentImage> Images { get; set; }

        public List<DocumentExternalLink> ExternalLinks { get; set; }

        public List<DocumentNomenclaturalStatus> NomenclaturalStatusValues { get; set; }

        public List<DocumentHybridData> Hybridisation { get; set; }

        public DocumentHyperlinks Hyperlinks { get; set; }

        public List<DocumentCollectionObject> CollectionObjects { get; set; }

        public List<DocumentKey> InKeys { get; set; }
        #endregion

        #region Vernacular Document Properties

        public DocumentVernacularName VernacularName { get; set; }

        public string Translation { get; set; }

        public string Transliteration { get; set; }

        public List<DocumentVernacularUse> VernacularUses { get; set; }

        #endregion


        #region Reference document type properties
        public DocumentReference Reference { get; set; }

        public TextType Title { get; set; }

        public string TitleUnformatted { get; set; }

        public List<DocumentField> Fields { get; set; }

        public List<DocumentDefinedConcept> DefinedConcepts { get; set; }

        public List<string> CitedTaxa { get; set; }

        public List<DocumentKey> IncludedKeys { get; set; }

        #endregion
    }
}
