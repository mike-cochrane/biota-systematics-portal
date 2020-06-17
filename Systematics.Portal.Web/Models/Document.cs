using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systematics.Portal.Web.Models
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public partial class Document
    {

        private DocumentName nameField;

        private string nameFullField;

        private string nameFormattedField;

        private string namePartFormattedField;

        private string orthographyField;

        private string pageField;

        private string yearOfPublicationField;

        private string yearOnPublicationField;

        private DocumentClassification classificationField;

        private string typeLocalityField;

        private string sanctioningAuthorField;

        private string sanctioningPageField;

        private string hybridLinkField;

        private string checkStatusField;

        private DocumentNameReference nameReferenceField;

        private DocumentTaxonomyReference taxonomyReferenceField;

        private DocumentParentReference parentReferenceField;

        private DocumentParent parentField;

        private DocumentCurrentName currentNameField;

        private DocumentBasionym basionymField;

        private DocumentBasedOn basedOnField;

        private DocumentBlocking blockingField;

        private DocumentAnamorphGenus anamorphGenusField;

        private DocumentAnamorphReference anamorphReferenceField;

        private DocumentTypeTaxon typeTaxonField;

        private string foreignIdField;

        private DocumentKingdom kingdomField;

        private DocumentPhylum phylumField;

        private DocumentClass classField;

        private DocumentOrder orderField;

        private DocumentFamily familyField;

        private DocumentGenus genusField;

        private DocumentAppliedVernacular[] appliedVernacularsField;

        private DocumentBiostatusValue[] biostatusValuesField;

        private DocumentConcept[] conceptsField;

        private DocumentNote[] notesField;

        private DocumentImage[] imagesField;

        private DocumentExternalLink[] externalLinksField;

        private DocumentNomenclaturalStatus[] nomenclaturalStatusValuesField;

        private DocumentHybridData[] hybridisationField;

        private DocumentHyperlink[] hyperlinksField;

        private DocumentCollectionObject[] collectionObjectsField;

        private DocumentKey[] inKeysField;

        private string nameIdField;

        private string referenceIdField;

        private string vernacularIdField;

        private string documentClassField;

        private string sourceField;

        private DateTime addedField;

        private DateTime updatedField;

        /// <remarks/>
        public DocumentName Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string NameFull
        {
            get
            {
                return this.nameFullField;
            }
            set
            {
                this.nameFullField = value;
            }
        }

        /// <remarks/>
        public string NameFormatted
        {
            get
            {
                return this.nameFormattedField;
            }
            set
            {
                this.nameFormattedField = value;
            }
        }

        /// <remarks/>
        public string NamePartFormatted
        {
            get
            {
                return this.namePartFormattedField;
            }
            set
            {
                this.namePartFormattedField = value;
            }
        }

        /// <remarks/>
        public string Orthography
        {
            get
            {
                return this.orthographyField;
            }
            set
            {
                this.orthographyField = value;
            }
        }

        /// <remarks/>
        public string Page
        {
            get
            {
                return this.pageField;
            }
            set
            {
                this.pageField = value;
            }
        }

        /// <remarks/>
        public string YearOfPublication
        {
            get
            {
                return this.yearOfPublicationField;
            }
            set
            {
                this.yearOfPublicationField = value;
            }
        }

        /// <remarks/>
        public string YearOnPublication
        {
            get
            {
                return this.yearOnPublicationField;
            }
            set
            {
                this.yearOnPublicationField = value;
            }
        }

        /// <remarks/>
        public DocumentClassification Classification
        {
            get
            {
                return this.classificationField;
            }
            set
            {
                this.classificationField = value;
            }
        }

        /// <remarks/>
        public string TypeLocality
        {
            get
            {
                return this.typeLocalityField;
            }
            set
            {
                this.typeLocalityField = value;
            }
        }

        /// <remarks/>
        public string SanctioningAuthor
        {
            get
            {
                return this.sanctioningAuthorField;
            }
            set
            {
                this.sanctioningAuthorField = value;
            }
        }

        /// <remarks/>
        public string SanctioningPage
        {
            get
            {
                return this.sanctioningPageField;
            }
            set
            {
                this.sanctioningPageField = value;
            }
        }

        /// <remarks/>
        public string HybridLink
        {
            get
            {
                return this.hybridLinkField;
            }
            set
            {
                this.hybridLinkField = value;
            }
        }

        /// <remarks/>
        public string CheckStatus
        {
            get
            {
                return this.checkStatusField;
            }
            set
            {
                this.checkStatusField = value;
            }
        }

        /// <remarks/>
        public DocumentNameReference NameReference
        {
            get
            {
                return this.nameReferenceField;
            }
            set
            {
                this.nameReferenceField = value;
            }
        }

        /// <remarks/>
        public DocumentTaxonomyReference TaxonomyReference
        {
            get
            {
                return this.taxonomyReferenceField;
            }
            set
            {
                this.taxonomyReferenceField = value;
            }
        }

        /// <remarks/>
        public DocumentParentReference ParentReference
        {
            get
            {
                return this.parentReferenceField;
            }
            set
            {
                this.parentReferenceField = value;
            }
        }

        /// <remarks/>
        public DocumentParent Parent
        {
            get
            {
                return this.parentField;
            }
            set
            {
                this.parentField = value;
            }
        }

        /// <remarks/>
        public DocumentCurrentName CurrentName
        {
            get
            {
                return this.currentNameField;
            }
            set
            {
                this.currentNameField = value;
            }
        }

        /// <remarks/>
        public DocumentBasionym Basionym
        {
            get
            {
                return this.basionymField;
            }
            set
            {
                this.basionymField = value;
            }
        }

        /// <remarks/>
        public DocumentBasedOn BasedOn
        {
            get
            {
                return this.basedOnField;
            }
            set
            {
                this.basedOnField = value;
            }
        }

        /// <remarks/>
        public DocumentBlocking Blocking
        {
            get
            {
                return this.blockingField;
            }
            set
            {
                this.blockingField = value;
            }
        }

        /// <remarks/>
        public DocumentAnamorphGenus AnamorphGenus
        {
            get
            {
                return this.anamorphGenusField;
            }
            set
            {
                this.anamorphGenusField = value;
            }
        }

        /// <remarks/>
        public DocumentAnamorphReference AnamorphReference
        {
            get
            {
                return this.anamorphReferenceField;
            }
            set
            {
                this.anamorphReferenceField = value;
            }
        }

        /// <remarks/>
        public DocumentTypeTaxon TypeTaxon
        {
            get
            {
                return this.typeTaxonField;
            }
            set
            {
                this.typeTaxonField = value;
            }
        }

        /// <remarks/>
        public string ForeignId
        {
            get
            {
                return this.foreignIdField;
            }
            set
            {
                this.foreignIdField = value;
            }
        }

        /// <remarks/>
        public DocumentKingdom Kingdom
        {
            get
            {
                return this.kingdomField;
            }
            set
            {
                this.kingdomField = value;
            }
        }

        /// <remarks/>
        public DocumentPhylum Phylum
        {
            get
            {
                return this.phylumField;
            }
            set
            {
                this.phylumField = value;
            }
        }

        /// <remarks/>
        public DocumentClass Class
        {
            get
            {
                return this.classField;
            }
            set
            {
                this.classField = value;
            }
        }

        /// <remarks/>
        public DocumentOrder Order
        {
            get
            {
                return this.orderField;
            }
            set
            {
                this.orderField = value;
            }
        }

        /// <remarks/>
        public DocumentFamily Family
        {
            get
            {
                return this.familyField;
            }
            set
            {
                this.familyField = value;
            }
        }

        /// <remarks/>
        public DocumentGenus Genus
        {
            get
            {
                return this.genusField;
            }
            set
            {
                this.genusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("AppliedVernacular", IsNullable = false)]
        public DocumentAppliedVernacular[] AppliedVernaculars
        {
            get
            {
                return this.appliedVernacularsField;
            }
            set
            {
                this.appliedVernacularsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("BiostatusValue", IsNullable = false)]
        public DocumentBiostatusValue[] BiostatusValues
        {
            get
            {
                return this.biostatusValuesField;
            }
            set
            {
                this.biostatusValuesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("Concept", IsNullable = false)]
        public DocumentConcept[] Concepts
        {
            get
            {
                return this.conceptsField;
            }
            set
            {
                this.conceptsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("Note", IsNullable = false)]
        public DocumentNote[] Notes
        {
            get
            {
                return this.notesField;
            }
            set
            {
                this.notesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("Image", IsNullable = false)]
        public DocumentImage[] Images
        {
            get
            {
                return this.imagesField;
            }
            set
            {
                this.imagesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("ExternalLink", IsNullable = false)]
        public DocumentExternalLink[] ExternalLinks
        {
            get
            {
                return this.externalLinksField;
            }
            set
            {
                this.externalLinksField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("NomenclaturalStatus", IsNullable = false)]
        public DocumentNomenclaturalStatus[] NomenclaturalStatusValues
        {
            get
            {
                return this.nomenclaturalStatusValuesField;
            }
            set
            {
                this.nomenclaturalStatusValuesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("HybridData", IsNullable = false)]
        public DocumentHybridData[] Hybridisation
        {
            get
            {
                return this.hybridisationField;
            }
            set
            {
                this.hybridisationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("Hyperlink", IsNullable = false)]
        public DocumentHyperlink[] Hyperlinks
        {
            get
            {
                return this.hyperlinksField;
            }
            set
            {
                this.hyperlinksField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("CollectionObject", IsNullable = false)]
        public DocumentCollectionObject[] CollectionObjects
        {
            get
            {
                return this.collectionObjectsField;
            }
            set
            {
                this.collectionObjectsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("Key", IsNullable = false)]
        public DocumentKey[] InKeys
        {
            get
            {
                return this.inKeysField;
            }
            set
            {
                this.inKeysField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string nameId
        {
            get
            {
                return this.nameIdField;
            }
            set
            {
                this.nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string referenceId
        {
            get
            {
                return this.referenceIdField;
            }
            set
            {
                this.referenceIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string vernacularId
        {
            get
            {
                return this.vernacularIdField;
            }
            set
            {
                this.vernacularIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string documentClass
        {
            get
            {
                return this.documentClassField;
            }
            set
            {
                this.documentClassField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string source
        {
            get
            {
                return this.sourceField;
            }
            set
            {
                this.sourceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public DateTime added
        {
            get
            {
                return this.addedField;
            }
            set
            {
                this.addedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public DateTime updated
        {
            get
            {
                return this.updatedField;
            }
            set
            {
                this.updatedField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentName
    {

        private string namePartField;

        private string canonicalField;

        private bool inCitationField;

        private bool misappliedField;

        private bool dubiumField;

        private bool proParteField;

        private bool novumField;

        private bool invalidField;

        private bool illegitimateField;

        private bool autonymField;

        private bool recombinationField;

        private string nomCodeField;

        private string isSuppressedField;

        private string taxonRankField;

        private string taxonRankSortField;

        private bool isAggregateField;

        private bool isAnamorphField;

        private string nzRelevanceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string namePart
        {
            get
            {
                return this.namePartField;
            }
            set
            {
                this.namePartField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string canonical
        {
            get
            {
                return this.canonicalField;
            }
            set
            {
                this.canonicalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public bool inCitation
        {
            get
            {
                return this.inCitationField;
            }
            set
            {
                this.inCitationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public bool misapplied
        {
            get
            {
                return this.misappliedField;
            }
            set
            {
                this.misappliedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public bool dubium
        {
            get
            {
                return this.dubiumField;
            }
            set
            {
                this.dubiumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public bool proParte
        {
            get
            {
                return this.proParteField;
            }
            set
            {
                this.proParteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public bool novum
        {
            get
            {
                return this.novumField;
            }
            set
            {
                this.novumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public bool invalid
        {
            get
            {
                return this.invalidField;
            }
            set
            {
                this.invalidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public bool illegitimate
        {
            get
            {
                return this.illegitimateField;
            }
            set
            {
                this.illegitimateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public bool autonym
        {
            get
            {
                return this.autonymField;
            }
            set
            {
                this.autonymField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public bool recombination
        {
            get
            {
                return this.recombinationField;
            }
            set
            {
                this.recombinationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string nomCode
        {
            get
            {
                return this.nomCodeField;
            }
            set
            {
                this.nomCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string isSuppressed
        {
            get
            {
                return this.isSuppressedField;
            }
            set
            {
                this.isSuppressedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string taxonRank
        {
            get
            {
                return this.taxonRankField;
            }
            set
            {
                this.taxonRankField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string taxonRankSort
        {
            get
            {
                return this.taxonRankSortField;
            }
            set
            {
                this.taxonRankSortField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public bool isAggregate
        {
            get
            {
                return this.isAggregateField;
            }
            set
            {
                this.isAggregateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public bool isAnamorph
        {
            get
            {
                return this.isAnamorphField;
            }
            set
            {
                this.isAnamorphField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string nzRelevance
        {
            get
            {
                return this.nzRelevanceField;
            }
            set
            {
                this.nzRelevanceField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentClassification
    {

        private string idField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentNameReference
    {

        private string[] iField;

        private string[] textField;

        private string referenceIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("i")]
        public string[] i
        {
            get
            {
                return this.iField;
            }
            set
            {
                this.iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string referenceId
        {
            get
            {
                return this.referenceIdField;
            }
            set
            {
                this.referenceIdField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentTaxonomyReference
    {

        private string[] iField;

        private string[] textField;

        private string referenceIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("i")]
        public string[] i
        {
            get
            {
                return this.iField;
            }
            set
            {
                this.iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string referenceId
        {
            get
            {
                return this.referenceIdField;
            }
            set
            {
                this.referenceIdField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentParentReference
    {

        private string[] iField;

        private string[] textField;

        private string referenceIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("i")]
        public string[] i
        {
            get
            {
                return this.iField;
            }
            set
            {
                this.iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string referenceId
        {
            get
            {
                return this.referenceIdField;
            }
            set
            {
                this.referenceIdField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentParent
    {

        private string nameIdField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string nameId
        {
            get
            {
                return this.nameIdField;
            }
            set
            {
                this.nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentCurrentName
    {

        private string nameIdField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string nameId
        {
            get
            {
                return this.nameIdField;
            }
            set
            {
                this.nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentBasionym
    {

        private string nameIdField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string nameId
        {
            get
            {
                return this.nameIdField;
            }
            set
            {
                this.nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentBasedOn
    {

        private string nameIdField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string nameId
        {
            get
            {
                return this.nameIdField;
            }
            set
            {
                this.nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentBlocking
    {

        private string nameIdField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string nameId
        {
            get
            {
                return this.nameIdField;
            }
            set
            {
                this.nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentAnamorphGenus
    {

        private string nameIdField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string nameId
        {
            get
            {
                return this.nameIdField;
            }
            set
            {
                this.nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentAnamorphReference
    {

        private string[] iField;

        private string[] textField;

        private string referenceIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("i")]
        public string[] i
        {
            get
            {
                return this.iField;
            }
            set
            {
                this.iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string referenceId
        {
            get
            {
                return this.referenceIdField;
            }
            set
            {
                this.referenceIdField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentTypeTaxon
    {

        private string nameIdField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string nameId
        {
            get
            {
                return this.nameIdField;
            }
            set
            {
                this.nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentKingdom
    {

        private string nameIdField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string nameId
        {
            get
            {
                return this.nameIdField;
            }
            set
            {
                this.nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentPhylum
    {

        private string nameIdField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string nameId
        {
            get
            {
                return this.nameIdField;
            }
            set
            {
                this.nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentClass
    {

        private string nameIdField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string nameId
        {
            get
            {
                return this.nameIdField;
            }
            set
            {
                this.nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentOrder
    {

        private string nameIdField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string nameId
        {
            get
            {
                return this.nameIdField;
            }
            set
            {
                this.nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentFamily
    {

        private string nameIdField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string nameId
        {
            get
            {
                return this.nameIdField;
            }
            set
            {
                this.nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentGenus
    {

        private string nameIdField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string nameId
        {
            get
            {
                return this.nameIdField;
            }
            set
            {
                this.nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentAppliedVernacular
    {

        private DocumentAppliedVernacularVernacularName vernacularNameField;

        private DocumentAppliedVernacularVernacularUseNote vernacularUseNoteField;

        private string idField;

        private string languageOfUseIdField;

        private string languageOfUseField;

        private string languageOfUseIsoField;

        private string regionOfUseSchemaField;

        private string regionOfUseField;

        private string addedField;

        private string updatedField;

        /// <remarks/>
        public DocumentAppliedVernacularVernacularName VernacularName
        {
            get
            {
                return this.vernacularNameField;
            }
            set
            {
                this.vernacularNameField = value;
            }
        }

        /// <remarks/>
        public DocumentAppliedVernacularVernacularUseNote VernacularUseNote
        {
            get
            {
                return this.vernacularUseNoteField;
            }
            set
            {
                this.vernacularUseNoteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string languageOfUseId
        {
            get
            {
                return this.languageOfUseIdField;
            }
            set
            {
                this.languageOfUseIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string languageOfUse
        {
            get
            {
                return this.languageOfUseField;
            }
            set
            {
                this.languageOfUseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string languageOfUseIso
        {
            get
            {
                return this.languageOfUseIsoField;
            }
            set
            {
                this.languageOfUseIsoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string regionOfUseSchema
        {
            get
            {
                return this.regionOfUseSchemaField;
            }
            set
            {
                this.regionOfUseSchemaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string regionOfUse
        {
            get
            {
                return this.regionOfUseField;
            }
            set
            {
                this.regionOfUseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string added
        {
            get
            {
                return this.addedField;
            }
            set
            {
                this.addedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string updated
        {
            get
            {
                return this.updatedField;
            }
            set
            {
                this.updatedField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentAppliedVernacularVernacularName
    {

        private string vernacularIdField;

        private string languageOfOriginField;

        private string languageOfOriginIsoField;

        private string addedField;

        private string updatedField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string vernacularId
        {
            get
            {
                return this.vernacularIdField;
            }
            set
            {
                this.vernacularIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string languageOfOrigin
        {
            get
            {
                return this.languageOfOriginField;
            }
            set
            {
                this.languageOfOriginField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string languageOfOriginIso
        {
            get
            {
                return this.languageOfOriginIsoField;
            }
            set
            {
                this.languageOfOriginIsoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string added
        {
            get
            {
                return this.addedField;
            }
            set
            {
                this.addedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string updated
        {
            get
            {
                return this.updatedField;
            }
            set
            {
                this.updatedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentAppliedVernacularVernacularUseNote
    {

        private string[] iField;

        private string[] textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("i")]
        public string[] i
        {
            get
            {
                return this.iField;
            }
            set
            {
                this.iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentBiostatusValue
    {

        private DocumentBiostatusValueBiostatusReference biostatusReferenceField;

        private DocumentBiostatusValueOrigin originField;

        private DocumentBiostatusValueOccurrence occurrenceField;

        private DocumentBiostatusValueGeoregion georegionField;

        private DocumentBiostatusValueComment commentField;

        private string idField;

        private string isActiveField;

        private string isFirstRecordField;

        private string addedField;

        private string updatedField;

        /// <remarks/>
        public DocumentBiostatusValueBiostatusReference BiostatusReference
        {
            get
            {
                return this.biostatusReferenceField;
            }
            set
            {
                this.biostatusReferenceField = value;
            }
        }

        /// <remarks/>
        public DocumentBiostatusValueOrigin Origin
        {
            get
            {
                return this.originField;
            }
            set
            {
                this.originField = value;
            }
        }

        /// <remarks/>
        public DocumentBiostatusValueOccurrence Occurrence
        {
            get
            {
                return this.occurrenceField;
            }
            set
            {
                this.occurrenceField = value;
            }
        }

        /// <remarks/>
        public DocumentBiostatusValueGeoregion Georegion
        {
            get
            {
                return this.georegionField;
            }
            set
            {
                this.georegionField = value;
            }
        }

        /// <remarks/>
        public DocumentBiostatusValueComment Comment
        {
            get
            {
                return this.commentField;
            }
            set
            {
                this.commentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string isActive
        {
            get
            {
                return this.isActiveField;
            }
            set
            {
                this.isActiveField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string isFirstRecord
        {
            get
            {
                return this.isFirstRecordField;
            }
            set
            {
                this.isFirstRecordField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string added
        {
            get
            {
                return this.addedField;
            }
            set
            {
                this.addedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string updated
        {
            get
            {
                return this.updatedField;
            }
            set
            {
                this.updatedField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentBiostatusValueBiostatusReference
    {

        private string[] iField;

        private string[] textField;

        private string referenceIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("i")]
        public string[] i
        {
            get
            {
                return this.iField;
            }
            set
            {
                this.iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string referenceId
        {
            get
            {
                return this.referenceIdField;
            }
            set
            {
                this.referenceIdField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentBiostatusValueOrigin
    {

        private string codeField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentBiostatusValueOccurrence
    {

        private string codeField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentBiostatusValueGeoregion
    {

        private string schemaField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string schema
        {
            get
            {
                return this.schemaField;
            }
            set
            {
                this.schemaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentBiostatusValueComment
    {

        private string[] iField;

        private string[] textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("i")]
        public string[] i
        {
            get
            {
                return this.iField;
            }
            set
            {
                this.iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentConcept
    {

        private string nameField;

        private string orthographyField;

        private string pageField;

        private DocumentConceptAccordingTo accordingToField;

        private string[] keywordsField;

        private DocumentConceptRelatedConcept[] relatedConceptsField;

        private DocumentConceptDescription[] descriptionsField;

        private string idField;

        private string explicitField;

        private DateTime addedField;

        private DateTime updatedField;

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string Orthography
        {
            get
            {
                return this.orthographyField;
            }
            set
            {
                this.orthographyField = value;
            }
        }

        /// <remarks/>
        public string Page
        {
            get
            {
                return this.pageField;
            }
            set
            {
                this.pageField = value;
            }
        }

        /// <remarks/>
        public DocumentConceptAccordingTo AccordingTo
        {
            get
            {
                return this.accordingToField;
            }
            set
            {
                this.accordingToField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("Keyword", IsNullable = false)]
        public string[] Keywords
        {
            get
            {
                return this.keywordsField;
            }
            set
            {
                this.keywordsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("RelatedConcept", IsNullable = false)]
        public DocumentConceptRelatedConcept[] RelatedConcepts
        {
            get
            {
                return this.relatedConceptsField;
            }
            set
            {
                this.relatedConceptsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("Description", IsNullable = false)]
        public DocumentConceptDescription[] Descriptions
        {
            get
            {
                return this.descriptionsField;
            }
            set
            {
                this.descriptionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string @explicit
        {
            get
            {
                return this.explicitField;
            }
            set
            {
                this.explicitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public DateTime added
        {
            get
            {
                return this.addedField;
            }
            set
            {
                this.addedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public DateTime updated
        {
            get
            {
                return this.updatedField;
            }
            set
            {
                this.updatedField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentConceptAccordingTo
    {

        private string[] iField;

        private string[] textField;

        private string referenceIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("i")]
        public string[] i
        {
            get
            {
                return this.iField;
            }
            set
            {
                this.iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string referenceId
        {
            get
            {
                return this.referenceIdField;
            }
            set
            {
                this.referenceIdField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentConceptRelatedConcept
    {

        private string relatedTaxonField;

        private string conceptIdField;

        private string directionField;

        private string typeField;

        private string addedField;

        private string updatedField;

        /// <remarks/>
        public string RelatedTaxon
        {
            get
            {
                return this.relatedTaxonField;
            }
            set
            {
                this.relatedTaxonField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string conceptId
        {
            get
            {
                return this.conceptIdField;
            }
            set
            {
                this.conceptIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string direction
        {
            get
            {
                return this.directionField;
            }
            set
            {
                this.directionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string added
        {
            get
            {
                return this.addedField;
            }
            set
            {
                this.addedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string updated
        {
            get
            {
                return this.updatedField;
            }
            set
            {
                this.updatedField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentConceptDescription
    {

        private string descriptionIconFilenameField;

        private string descriptionTextField;

        private string descriptionUrlField;

        private string idField;

        private string typeField;

        private string languageField;

        private string languageIsoField;

        private string categoryField;

        private DateTime addedField;

        private DateTime updatedField;

        /// <remarks/>
        public string DescriptionIconFilename
        {
            get
            {
                return this.descriptionIconFilenameField;
            }
            set
            {
                this.descriptionIconFilenameField = value;
            }
        }

        /// <remarks/>
        public string DescriptionText
        {
            get
            {
                return this.descriptionTextField;
            }
            set
            {
                this.descriptionTextField = value;
            }
        }

        /// <remarks/>
        public string DescriptionUrl
        {
            get
            {
                return this.descriptionUrlField;
            }
            set
            {
                this.descriptionUrlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string language
        {
            get
            {
                return this.languageField;
            }
            set
            {
                this.languageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string languageIso
        {
            get
            {
                return this.languageIsoField;
            }
            set
            {
                this.languageIsoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public DateTime added
        {
            get
            {
                return this.addedField;
            }
            set
            {
                this.addedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public DateTime updated
        {
            get
            {
                return this.updatedField;
            }
            set
            {
                this.updatedField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentNote
    {

        private DocumentNoteText textField;

        private DocumentNoteReference referenceField;

        private string idField;

        private string typeField;

        private DateTime addedField;

        private DateTime updatedField;

        /// <remarks/>
        public DocumentNoteText Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        public DocumentNoteReference Reference
        {
            get
            {
                return this.referenceField;
            }
            set
            {
                this.referenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public DateTime added
        {
            get
            {
                return this.addedField;
            }
            set
            {
                this.addedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public DateTime updated
        {
            get
            {
                return this.updatedField;
            }
            set
            {
                this.updatedField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentNoteText
    {

        private string[] iField;

        private string[] textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("i")]
        public string[] i
        {
            get
            {
                return this.iField;
            }
            set
            {
                this.iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentNoteReference
    {

        private string[] iField;

        private string[] textField;

        private string referenceIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("i")]
        public string[] i
        {
            get
            {
                return this.iField;
            }
            set
            {
                this.iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string referenceId
        {
            get
            {
                return this.referenceIdField;
            }
            set
            {
                this.referenceIdField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentImage
    {

        private string imageURIField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string imageURI
        {
            get
            {
                return this.imageURIField;
            }
            set
            {
                this.imageURIField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentExternalLink
    {

        private string externalFullNameField;

        private string idField;

        private string externalIdField;

        private string sourceField;

        /// <remarks/>
        public string ExternalFullName
        {
            get
            {
                return this.externalFullNameField;
            }
            set
            {
                this.externalFullNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string externalId
        {
            get
            {
                return this.externalIdField;
            }
            set
            {
                this.externalIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string source
        {
            get
            {
                return this.sourceField;
            }
            set
            {
                this.sourceField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentNomenclaturalStatus
    {

        private DocumentNomenclaturalStatusComment commentField;

        private DocumentNomenclaturalStatusReference referenceField;

        private string idField;

        private string typeField;

        private string isTrueField;

        private DateTime addedField;

        private DateTime updatedField;

        /// <remarks/>
        public DocumentNomenclaturalStatusComment Comment
        {
            get
            {
                return this.commentField;
            }
            set
            {
                this.commentField = value;
            }
        }

        /// <remarks/>
        public DocumentNomenclaturalStatusReference Reference
        {
            get
            {
                return this.referenceField;
            }
            set
            {
                this.referenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string isTrue
        {
            get
            {
                return this.isTrueField;
            }
            set
            {
                this.isTrueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public DateTime added
        {
            get
            {
                return this.addedField;
            }
            set
            {
                this.addedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public DateTime updated
        {
            get
            {
                return this.updatedField;
            }
            set
            {
                this.updatedField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentNomenclaturalStatusComment
    {

        private string[] iField;

        private string[] textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("i")]
        public string[] i
        {
            get
            {
                return this.iField;
            }
            set
            {
                this.iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentNomenclaturalStatusReference
    {

        private string[] iField;

        private string[] textField;

        private string referenceIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("i")]
        public string[] i
        {
            get
            {
                return this.iField;
            }
            set
            {
                this.iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string referenceId
        {
            get
            {
                return this.referenceIdField;
            }
            set
            {
                this.referenceIdField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentHybridData
    {

        private string hybridTextField;

        private DocumentHybridDataHybridParentName[] hybridParentNamesField;

        /// <remarks/>
        public string HybridText
        {
            get
            {
                return this.hybridTextField;
            }
            set
            {
                this.hybridTextField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("HybridParentName", IsNullable = false)]
        public DocumentHybridDataHybridParentName[] HybridParentNames
        {
            get
            {
                return this.hybridParentNamesField;
            }
            set
            {
                this.hybridParentNamesField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentHybridDataHybridParentName
    {

        private string nameFullField;

        private string nameIdField;

        private string prefixTextField;

        private string suffixTextField;

        /// <remarks/>
        public string NameFull
        {
            get
            {
                return this.nameFullField;
            }
            set
            {
                this.nameFullField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string nameId
        {
            get
            {
                return this.nameIdField;
            }
            set
            {
                this.nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string prefixText
        {
            get
            {
                return this.prefixTextField;
            }
            set
            {
                this.prefixTextField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string suffixText
        {
            get
            {
                return this.suffixTextField;
            }
            set
            {
                this.suffixTextField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentHyperlink
    {

        private string linkUrlField;

        private string captionField;

        private string typeField;

        private string addedField;

        private string updatedField;

        /// <remarks/>
        public string LinkUrl
        {
            get
            {
                return this.linkUrlField;
            }
            set
            {
                this.linkUrlField = value;
            }
        }

        /// <remarks/>
        public string Caption
        {
            get
            {
                return this.captionField;
            }
            set
            {
                this.captionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string added
        {
            get
            {
                return this.addedField;
            }
            set
            {
                this.addedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string updated
        {
            get
            {
                return this.updatedField;
            }
            set
            {
                this.updatedField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentCollectionObject
    {

        private string collectorField;

        private DocumentCollectionObjectCollectionEventRegion[] collectionEventRegionsField;

        private DocumentCollectionObjectImage[] collectionObjectImagesField;

        private string specimenGuidField;

        private string specimenIdField;

        private string accessionNumberField;

        private string collectionAcronymField;

        private string collectionDateISOField;

        private string typeStatusField;

        /// <remarks/>
        public string Collector
        {
            get
            {
                return this.collectorField;
            }
            set
            {
                this.collectorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("CollectionEventRegion", IsNullable = false)]
        public DocumentCollectionObjectCollectionEventRegion[] CollectionEventRegions
        {
            get
            {
                return this.collectionEventRegionsField;
            }
            set
            {
                this.collectionEventRegionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("Image", IsNullable = false)]
        public DocumentCollectionObjectImage[] CollectionObjectImages
        {
            get
            {
                return this.collectionObjectImagesField;
            }
            set
            {
                this.collectionObjectImagesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string specimenGuid
        {
            get
            {
                return this.specimenGuidField;
            }
            set
            {
                this.specimenGuidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string specimenId
        {
            get
            {
                return this.specimenIdField;
            }
            set
            {
                this.specimenIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string accessionNumber
        {
            get
            {
                return this.accessionNumberField;
            }
            set
            {
                this.accessionNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string collectionAcronym
        {
            get
            {
                return this.collectionAcronymField;
            }
            set
            {
                this.collectionAcronymField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string collectionDateISO
        {
            get
            {
                return this.collectionDateISOField;
            }
            set
            {
                this.collectionDateISOField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string typeStatus
        {
            get
            {
                return this.typeStatusField;
            }
            set
            {
                this.typeStatusField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentCollectionObjectCollectionEventRegion
    {

        private string georegionField;

        private string georegionSchemaField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string georegion
        {
            get
            {
                return this.georegionField;
            }
            set
            {
                this.georegionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string georegionSchema
        {
            get
            {
                return this.georegionSchemaField;
            }
            set
            {
                this.georegionSchemaField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentCollectionObjectImage
    {

        private string imageUrlField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string imageUrl
        {
            get
            {
                return this.imageUrlField;
            }
            set
            {
                this.imageUrlField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class DocumentKey
    {

        private string keyIdField;

        private string referenceIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string keyId
        {
            get
            {
                return this.keyIdField;
            }
            set
            {
                this.keyIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string referenceId
        {
            get
            {
                return this.referenceIdField;
            }
            set
            {
                this.referenceIdField = value;
            }
        }
    }


}
