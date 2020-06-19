using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystematicsPortal.Model.Models.Documents
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public partial class NameDocumentDto
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
                return nameField;
            }
            set
            {
                nameField = value;
            }
        }

        /// <remarks/>
        public string NameFull
        {
            get
            {
                return nameFullField;
            }
            set
            {
                nameFullField = value;
            }
        }

        /// <remarks/>
        public string NameFormatted
        {
            get
            {
                return nameFormattedField;
            }
            set
            {
                nameFormattedField = value;
            }
        }

        /// <remarks/>
        public string NamePartFormatted
        {
            get
            {
                return namePartFormattedField;
            }
            set
            {
                namePartFormattedField = value;
            }
        }

        /// <remarks/>
        public string Orthography
        {
            get
            {
                return orthographyField;
            }
            set
            {
                orthographyField = value;
            }
        }

        /// <remarks/>
        public string Page
        {
            get
            {
                return pageField;
            }
            set
            {
                pageField = value;
            }
        }

        /// <remarks/>
        public string YearOfPublication
        {
            get
            {
                return yearOfPublicationField;
            }
            set
            {
                yearOfPublicationField = value;
            }
        }

        /// <remarks/>
        public string YearOnPublication
        {
            get
            {
                return yearOnPublicationField;
            }
            set
            {
                yearOnPublicationField = value;
            }
        }

        /// <remarks/>
        public DocumentClassification Classification
        {
            get
            {
                return classificationField;
            }
            set
            {
                classificationField = value;
            }
        }

        /// <remarks/>
        public string TypeLocality
        {
            get
            {
                return typeLocalityField;
            }
            set
            {
                typeLocalityField = value;
            }
        }

        /// <remarks/>
        public string SanctioningAuthor
        {
            get
            {
                return sanctioningAuthorField;
            }
            set
            {
                sanctioningAuthorField = value;
            }
        }

        /// <remarks/>
        public string SanctioningPage
        {
            get
            {
                return sanctioningPageField;
            }
            set
            {
                sanctioningPageField = value;
            }
        }

        /// <remarks/>
        public string HybridLink
        {
            get
            {
                return hybridLinkField;
            }
            set
            {
                hybridLinkField = value;
            }
        }

        /// <remarks/>
        public string CheckStatus
        {
            get
            {
                return checkStatusField;
            }
            set
            {
                checkStatusField = value;
            }
        }

        /// <remarks/>
        public DocumentNameReference NameReference
        {
            get
            {
                return nameReferenceField;
            }
            set
            {
                nameReferenceField = value;
            }
        }

        /// <remarks/>
        public DocumentTaxonomyReference TaxonomyReference
        {
            get
            {
                return taxonomyReferenceField;
            }
            set
            {
                taxonomyReferenceField = value;
            }
        }

        /// <remarks/>
        public DocumentParentReference ParentReference
        {
            get
            {
                return parentReferenceField;
            }
            set
            {
                parentReferenceField = value;
            }
        }

        /// <remarks/>
        public DocumentParent Parent
        {
            get
            {
                return parentField;
            }
            set
            {
                parentField = value;
            }
        }

        /// <remarks/>
        public DocumentCurrentName CurrentName
        {
            get
            {
                return currentNameField;
            }
            set
            {
                currentNameField = value;
            }
        }

        /// <remarks/>
        public DocumentBasionym Basionym
        {
            get
            {
                return basionymField;
            }
            set
            {
                basionymField = value;
            }
        }

        /// <remarks/>
        public DocumentBasedOn BasedOn
        {
            get
            {
                return basedOnField;
            }
            set
            {
                basedOnField = value;
            }
        }

        /// <remarks/>
        public DocumentBlocking Blocking
        {
            get
            {
                return blockingField;
            }
            set
            {
                blockingField = value;
            }
        }

        /// <remarks/>
        public DocumentAnamorphGenus AnamorphGenus
        {
            get
            {
                return anamorphGenusField;
            }
            set
            {
                anamorphGenusField = value;
            }
        }

        /// <remarks/>
        public DocumentAnamorphReference AnamorphReference
        {
            get
            {
                return anamorphReferenceField;
            }
            set
            {
                anamorphReferenceField = value;
            }
        }

        /// <remarks/>
        public DocumentTypeTaxon TypeTaxon
        {
            get
            {
                return typeTaxonField;
            }
            set
            {
                typeTaxonField = value;
            }
        }

        /// <remarks/>
        public string ForeignId
        {
            get
            {
                return foreignIdField;
            }
            set
            {
                foreignIdField = value;
            }
        }

        /// <remarks/>
        public DocumentKingdom Kingdom
        {
            get
            {
                return kingdomField;
            }
            set
            {
                kingdomField = value;
            }
        }

        /// <remarks/>
        public DocumentPhylum Phylum
        {
            get
            {
                return phylumField;
            }
            set
            {
                phylumField = value;
            }
        }

        /// <remarks/>
        public DocumentClass Class
        {
            get
            {
                return classField;
            }
            set
            {
                classField = value;
            }
        }

        /// <remarks/>
        public DocumentOrder Order
        {
            get
            {
                return orderField;
            }
            set
            {
                orderField = value;
            }
        }

        /// <remarks/>
        public DocumentFamily Family
        {
            get
            {
                return familyField;
            }
            set
            {
                familyField = value;
            }
        }

        /// <remarks/>
        public DocumentGenus Genus
        {
            get
            {
                return genusField;
            }
            set
            {
                genusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("AppliedVernacular", IsNullable = false)]
        public DocumentAppliedVernacular[] AppliedVernaculars
        {
            get
            {
                return appliedVernacularsField;
            }
            set
            {
                appliedVernacularsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("BiostatusValue", IsNullable = false)]
        public DocumentBiostatusValue[] BiostatusValues
        {
            get
            {
                return biostatusValuesField;
            }
            set
            {
                biostatusValuesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("Concept", IsNullable = false)]
        public DocumentConcept[] Concepts
        {
            get
            {
                return conceptsField;
            }
            set
            {
                conceptsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("Note", IsNullable = false)]
        public DocumentNote[] Notes
        {
            get
            {
                return notesField;
            }
            set
            {
                notesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("Image", IsNullable = false)]
        public DocumentImage[] Images
        {
            get
            {
                return imagesField;
            }
            set
            {
                imagesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("ExternalLink", IsNullable = false)]
        public DocumentExternalLink[] ExternalLinks
        {
            get
            {
                return externalLinksField;
            }
            set
            {
                externalLinksField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("NomenclaturalStatus", IsNullable = false)]
        public DocumentNomenclaturalStatus[] NomenclaturalStatusValues
        {
            get
            {
                return nomenclaturalStatusValuesField;
            }
            set
            {
                nomenclaturalStatusValuesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("HybridData", IsNullable = false)]
        public DocumentHybridData[] Hybridisation
        {
            get
            {
                return hybridisationField;
            }
            set
            {
                hybridisationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("Hyperlink", IsNullable = false)]
        public DocumentHyperlink[] Hyperlinks
        {
            get
            {
                return hyperlinksField;
            }
            set
            {
                hyperlinksField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("CollectionObject", IsNullable = false)]
        public DocumentCollectionObject[] CollectionObjects
        {
            get
            {
                return collectionObjectsField;
            }
            set
            {
                collectionObjectsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("Key", IsNullable = false)]
        public DocumentKey[] InKeys
        {
            get
            {
                return inKeysField;
            }
            set
            {
                inKeysField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string nameId
        {
            get
            {
                return nameIdField;
            }
            set
            {
                nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string referenceId
        {
            get
            {
                return referenceIdField;
            }
            set
            {
                referenceIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string vernacularId
        {
            get
            {
                return vernacularIdField;
            }
            set
            {
                vernacularIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string documentClass
        {
            get
            {
                return documentClassField;
            }
            set
            {
                documentClassField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string source
        {
            get
            {
                return sourceField;
            }
            set
            {
                sourceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public DateTime added
        {
            get
            {
                return addedField;
            }
            set
            {
                addedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public DateTime updated
        {
            get
            {
                return updatedField;
            }
            set
            {
                updatedField = value;
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
                return namePartField;
            }
            set
            {
                namePartField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string canonical
        {
            get
            {
                return canonicalField;
            }
            set
            {
                canonicalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public bool inCitation
        {
            get
            {
                return inCitationField;
            }
            set
            {
                inCitationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public bool misapplied
        {
            get
            {
                return misappliedField;
            }
            set
            {
                misappliedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public bool dubium
        {
            get
            {
                return dubiumField;
            }
            set
            {
                dubiumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public bool proParte
        {
            get
            {
                return proParteField;
            }
            set
            {
                proParteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public bool novum
        {
            get
            {
                return novumField;
            }
            set
            {
                novumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public bool invalid
        {
            get
            {
                return invalidField;
            }
            set
            {
                invalidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public bool illegitimate
        {
            get
            {
                return illegitimateField;
            }
            set
            {
                illegitimateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public bool autonym
        {
            get
            {
                return autonymField;
            }
            set
            {
                autonymField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public bool recombination
        {
            get
            {
                return recombinationField;
            }
            set
            {
                recombinationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string nomCode
        {
            get
            {
                return nomCodeField;
            }
            set
            {
                nomCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string isSuppressed
        {
            get
            {
                return isSuppressedField;
            }
            set
            {
                isSuppressedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string taxonRank
        {
            get
            {
                return taxonRankField;
            }
            set
            {
                taxonRankField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string taxonRankSort
        {
            get
            {
                return taxonRankSortField;
            }
            set
            {
                taxonRankSortField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public bool isAggregate
        {
            get
            {
                return isAggregateField;
            }
            set
            {
                isAggregateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public bool isAnamorph
        {
            get
            {
                return isAnamorphField;
            }
            set
            {
                isAnamorphField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string nzRelevance
        {
            get
            {
                return nzRelevanceField;
            }
            set
            {
                nzRelevanceField = value;
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
                return idField;
            }
            set
            {
                idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
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
                return iField;
            }
            set
            {
                iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return textField;
            }
            set
            {
                textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string referenceId
        {
            get
            {
                return referenceIdField;
            }
            set
            {
                referenceIdField = value;
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
                return iField;
            }
            set
            {
                iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return textField;
            }
            set
            {
                textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string referenceId
        {
            get
            {
                return referenceIdField;
            }
            set
            {
                referenceIdField = value;
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
                return iField;
            }
            set
            {
                iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return textField;
            }
            set
            {
                textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string referenceId
        {
            get
            {
                return referenceIdField;
            }
            set
            {
                referenceIdField = value;
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
                return nameIdField;
            }
            set
            {
                nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
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
                return nameIdField;
            }
            set
            {
                nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
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
                return nameIdField;
            }
            set
            {
                nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
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
                return nameIdField;
            }
            set
            {
                nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
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
                return nameIdField;
            }
            set
            {
                nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
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
                return nameIdField;
            }
            set
            {
                nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
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
                return iField;
            }
            set
            {
                iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return textField;
            }
            set
            {
                textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string referenceId
        {
            get
            {
                return referenceIdField;
            }
            set
            {
                referenceIdField = value;
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
                return nameIdField;
            }
            set
            {
                nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
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
                return nameIdField;
            }
            set
            {
                nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
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
                return nameIdField;
            }
            set
            {
                nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
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
                return nameIdField;
            }
            set
            {
                nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
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
                return nameIdField;
            }
            set
            {
                nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
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
                return nameIdField;
            }
            set
            {
                nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
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
                return nameIdField;
            }
            set
            {
                nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
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
                return vernacularNameField;
            }
            set
            {
                vernacularNameField = value;
            }
        }

        /// <remarks/>
        public DocumentAppliedVernacularVernacularUseNote VernacularUseNote
        {
            get
            {
                return vernacularUseNoteField;
            }
            set
            {
                vernacularUseNoteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string id
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string languageOfUseId
        {
            get
            {
                return languageOfUseIdField;
            }
            set
            {
                languageOfUseIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string languageOfUse
        {
            get
            {
                return languageOfUseField;
            }
            set
            {
                languageOfUseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string languageOfUseIso
        {
            get
            {
                return languageOfUseIsoField;
            }
            set
            {
                languageOfUseIsoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string regionOfUseSchema
        {
            get
            {
                return regionOfUseSchemaField;
            }
            set
            {
                regionOfUseSchemaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string regionOfUse
        {
            get
            {
                return regionOfUseField;
            }
            set
            {
                regionOfUseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string added
        {
            get
            {
                return addedField;
            }
            set
            {
                addedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string updated
        {
            get
            {
                return updatedField;
            }
            set
            {
                updatedField = value;
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
                return vernacularIdField;
            }
            set
            {
                vernacularIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string languageOfOrigin
        {
            get
            {
                return languageOfOriginField;
            }
            set
            {
                languageOfOriginField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string languageOfOriginIso
        {
            get
            {
                return languageOfOriginIsoField;
            }
            set
            {
                languageOfOriginIsoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string added
        {
            get
            {
                return addedField;
            }
            set
            {
                addedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string updated
        {
            get
            {
                return updatedField;
            }
            set
            {
                updatedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
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
                return iField;
            }
            set
            {
                iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return textField;
            }
            set
            {
                textField = value;
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
                return biostatusReferenceField;
            }
            set
            {
                biostatusReferenceField = value;
            }
        }

        /// <remarks/>
        public DocumentBiostatusValueOrigin Origin
        {
            get
            {
                return originField;
            }
            set
            {
                originField = value;
            }
        }

        /// <remarks/>
        public DocumentBiostatusValueOccurrence Occurrence
        {
            get
            {
                return occurrenceField;
            }
            set
            {
                occurrenceField = value;
            }
        }

        /// <remarks/>
        public DocumentBiostatusValueGeoregion Georegion
        {
            get
            {
                return georegionField;
            }
            set
            {
                georegionField = value;
            }
        }

        /// <remarks/>
        public DocumentBiostatusValueComment Comment
        {
            get
            {
                return commentField;
            }
            set
            {
                commentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string id
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string isActive
        {
            get
            {
                return isActiveField;
            }
            set
            {
                isActiveField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string isFirstRecord
        {
            get
            {
                return isFirstRecordField;
            }
            set
            {
                isFirstRecordField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string added
        {
            get
            {
                return addedField;
            }
            set
            {
                addedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string updated
        {
            get
            {
                return updatedField;
            }
            set
            {
                updatedField = value;
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
                return iField;
            }
            set
            {
                iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return textField;
            }
            set
            {
                textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string referenceId
        {
            get
            {
                return referenceIdField;
            }
            set
            {
                referenceIdField = value;
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
                return codeField;
            }
            set
            {
                codeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
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
                return codeField;
            }
            set
            {
                codeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
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
                return schemaField;
            }
            set
            {
                schemaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
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
                return iField;
            }
            set
            {
                iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return textField;
            }
            set
            {
                textField = value;
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
                return nameField;
            }
            set
            {
                nameField = value;
            }
        }

        /// <remarks/>
        public string Orthography
        {
            get
            {
                return orthographyField;
            }
            set
            {
                orthographyField = value;
            }
        }

        /// <remarks/>
        public string Page
        {
            get
            {
                return pageField;
            }
            set
            {
                pageField = value;
            }
        }

        /// <remarks/>
        public DocumentConceptAccordingTo AccordingTo
        {
            get
            {
                return accordingToField;
            }
            set
            {
                accordingToField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("Keyword", IsNullable = false)]
        public string[] Keywords
        {
            get
            {
                return keywordsField;
            }
            set
            {
                keywordsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("RelatedConcept", IsNullable = false)]
        public DocumentConceptRelatedConcept[] RelatedConcepts
        {
            get
            {
                return relatedConceptsField;
            }
            set
            {
                relatedConceptsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("Description", IsNullable = false)]
        public DocumentConceptDescription[] Descriptions
        {
            get
            {
                return descriptionsField;
            }
            set
            {
                descriptionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string id
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string @explicit
        {
            get
            {
                return explicitField;
            }
            set
            {
                explicitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public DateTime added
        {
            get
            {
                return addedField;
            }
            set
            {
                addedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public DateTime updated
        {
            get
            {
                return updatedField;
            }
            set
            {
                updatedField = value;
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
                return iField;
            }
            set
            {
                iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return textField;
            }
            set
            {
                textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string referenceId
        {
            get
            {
                return referenceIdField;
            }
            set
            {
                referenceIdField = value;
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
                return relatedTaxonField;
            }
            set
            {
                relatedTaxonField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string conceptId
        {
            get
            {
                return conceptIdField;
            }
            set
            {
                conceptIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string direction
        {
            get
            {
                return directionField;
            }
            set
            {
                directionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string type
        {
            get
            {
                return typeField;
            }
            set
            {
                typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string added
        {
            get
            {
                return addedField;
            }
            set
            {
                addedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string updated
        {
            get
            {
                return updatedField;
            }
            set
            {
                updatedField = value;
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
                return descriptionIconFilenameField;
            }
            set
            {
                descriptionIconFilenameField = value;
            }
        }

        /// <remarks/>
        public string DescriptionText
        {
            get
            {
                return descriptionTextField;
            }
            set
            {
                descriptionTextField = value;
            }
        }

        /// <remarks/>
        public string DescriptionUrl
        {
            get
            {
                return descriptionUrlField;
            }
            set
            {
                descriptionUrlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string id
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string type
        {
            get
            {
                return typeField;
            }
            set
            {
                typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string language
        {
            get
            {
                return languageField;
            }
            set
            {
                languageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string languageIso
        {
            get
            {
                return languageIsoField;
            }
            set
            {
                languageIsoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string category
        {
            get
            {
                return categoryField;
            }
            set
            {
                categoryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public DateTime added
        {
            get
            {
                return addedField;
            }
            set
            {
                addedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public DateTime updated
        {
            get
            {
                return updatedField;
            }
            set
            {
                updatedField = value;
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
                return textField;
            }
            set
            {
                textField = value;
            }
        }

        /// <remarks/>
        public DocumentNoteReference Reference
        {
            get
            {
                return referenceField;
            }
            set
            {
                referenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string id
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string type
        {
            get
            {
                return typeField;
            }
            set
            {
                typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public DateTime added
        {
            get
            {
                return addedField;
            }
            set
            {
                addedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public DateTime updated
        {
            get
            {
                return updatedField;
            }
            set
            {
                updatedField = value;
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
                return iField;
            }
            set
            {
                iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return textField;
            }
            set
            {
                textField = value;
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
                return iField;
            }
            set
            {
                iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return textField;
            }
            set
            {
                textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string referenceId
        {
            get
            {
                return referenceIdField;
            }
            set
            {
                referenceIdField = value;
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
                return imageURIField;
            }
            set
            {
                imageURIField = value;
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
                return externalFullNameField;
            }
            set
            {
                externalFullNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string id
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string externalId
        {
            get
            {
                return externalIdField;
            }
            set
            {
                externalIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string source
        {
            get
            {
                return sourceField;
            }
            set
            {
                sourceField = value;
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
                return commentField;
            }
            set
            {
                commentField = value;
            }
        }

        /// <remarks/>
        public DocumentNomenclaturalStatusReference Reference
        {
            get
            {
                return referenceField;
            }
            set
            {
                referenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string id
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string type
        {
            get
            {
                return typeField;
            }
            set
            {
                typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string isTrue
        {
            get
            {
                return isTrueField;
            }
            set
            {
                isTrueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public DateTime added
        {
            get
            {
                return addedField;
            }
            set
            {
                addedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public DateTime updated
        {
            get
            {
                return updatedField;
            }
            set
            {
                updatedField = value;
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
                return iField;
            }
            set
            {
                iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return textField;
            }
            set
            {
                textField = value;
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
                return iField;
            }
            set
            {
                iField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string[] Text
        {
            get
            {
                return textField;
            }
            set
            {
                textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string referenceId
        {
            get
            {
                return referenceIdField;
            }
            set
            {
                referenceIdField = value;
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
                return hybridTextField;
            }
            set
            {
                hybridTextField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("HybridParentName", IsNullable = false)]
        public DocumentHybridDataHybridParentName[] HybridParentNames
        {
            get
            {
                return hybridParentNamesField;
            }
            set
            {
                hybridParentNamesField = value;
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
                return nameFullField;
            }
            set
            {
                nameFullField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string nameId
        {
            get
            {
                return nameIdField;
            }
            set
            {
                nameIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string prefixText
        {
            get
            {
                return prefixTextField;
            }
            set
            {
                prefixTextField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string suffixText
        {
            get
            {
                return suffixTextField;
            }
            set
            {
                suffixTextField = value;
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
                return linkUrlField;
            }
            set
            {
                linkUrlField = value;
            }
        }

        /// <remarks/>
        public string Caption
        {
            get
            {
                return captionField;
            }
            set
            {
                captionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string type
        {
            get
            {
                return typeField;
            }
            set
            {
                typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string added
        {
            get
            {
                return addedField;
            }
            set
            {
                addedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string updated
        {
            get
            {
                return updatedField;
            }
            set
            {
                updatedField = value;
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
                return collectorField;
            }
            set
            {
                collectorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("CollectionEventRegion", IsNullable = false)]
        public DocumentCollectionObjectCollectionEventRegion[] CollectionEventRegions
        {
            get
            {
                return collectionEventRegionsField;
            }
            set
            {
                collectionEventRegionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItem("Image", IsNullable = false)]
        public DocumentCollectionObjectImage[] CollectionObjectImages
        {
            get
            {
                return collectionObjectImagesField;
            }
            set
            {
                collectionObjectImagesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string specimenGuid
        {
            get
            {
                return specimenGuidField;
            }
            set
            {
                specimenGuidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string specimenId
        {
            get
            {
                return specimenIdField;
            }
            set
            {
                specimenIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string accessionNumber
        {
            get
            {
                return accessionNumberField;
            }
            set
            {
                accessionNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string collectionAcronym
        {
            get
            {
                return collectionAcronymField;
            }
            set
            {
                collectionAcronymField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string collectionDateISO
        {
            get
            {
                return collectionDateISOField;
            }
            set
            {
                collectionDateISOField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string typeStatus
        {
            get
            {
                return typeStatusField;
            }
            set
            {
                typeStatusField = value;
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
                return georegionField;
            }
            set
            {
                georegionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string georegionSchema
        {
            get
            {
                return georegionSchemaField;
            }
            set
            {
                georegionSchemaField = value;
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
                return imageUrlField;
            }
            set
            {
                imageUrlField = value;
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
                return keyIdField;
            }
            set
            {
                keyIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string referenceId
        {
            get
            {
                return referenceIdField;
            }
            set
            {
                referenceIdField = value;
            }
        }
    }


}
