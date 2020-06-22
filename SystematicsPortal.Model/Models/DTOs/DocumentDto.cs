//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SystematicsPortal.Model.Models.Documents;
//using SystematicsPortal.Model.Models.Documents.SubDocuments;

//namespace SystematicsPortal.Model.Models.DTOs
//{
//    public class DocumentDto
//    {
//        public DocumentName Name { get; set; }

//        public TextType NameFormatted { get; set; }
        
//        /// <remarks/>
//        public TextType NameScientific { get; set; }
       
//        /// <remarks/>
//        public string NamePartFormatted { get; set; }
        
//        /// <remarks/>
//        public string Orthography { get; set; }

//        /// <remarks/>
//        public string Page { get; set; }

//        /// <remarks/>
//        public string YearOfPublication { get; set; }
        
//        /// <remarks/>
//        public string YearOnPublication { get; set; }
       
//        /// <remarks/>
//        public DocumentClassification Classification { get; set; }
        
//        /// <remarks/>
//        public string TypeLocality { get; set; }
        
        
//        public string SanctioningAuthor { get; set; }
        
//        /// <remarks/>
//        public string SanctioningPage { get; set; }
        
//        /// <remarks/>
//        public string HybridLink { get; set; }
        
//        /// <remarks/>
//        public string CheckStatus { get; set; }


//        /// <remarks/>
//        public ReferenceType NameReference { get; set; }
      
//        /// <remarks/>
//        public ReferenceType TaxonomyReference { get; set; }
        
//        /// <remarks/>

//        public ReferenceType ParentReference { get; set; }
        
//        /// <remarks/>
//        public LinkedNameType Parent { get; set; }
        

//        /// <remarks/>
//        public LinkedNameType CurrentName { get; set; }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("Synonym", IsNullable = false)]
//        public LinkedNameType[] Synonyms { get; set; }
        
//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("Sibling", IsNullable = false)]
//        public LinkedNameType[] Siblings { get; set; }
        
//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("Subordinate", IsNullable = false)]
//        public LinkedNameType[] Subordinates { get; set; }
        
//        /// <remarks/>
//        public LinkedNameType Basionym { get; set; }
        
//        /// <remarks/>
//        public LinkedNameType BasedOn { get; set; }

//        /// <remarks/>
//        public LinkedNameType Blocking { get; set; }
        
//        /// <remarks/>
//        public LinkedNameType AnamorphGenus { get; set; }

        
//        public ReferenceType AnamorphReference { get; set; }
        
//        public LinkedNameType TypeTaxon { get; set; }
        

//        public string ForeignId { get; set; }

//        /// <remarks/>
//        public LinkedNameType Kingdom { get; set; }

//        /// <remarks/>
//        public LinkedNameType Phylum { get; set; }

//        /// <remarks/>
//        public LinkedNameType Class { get; set; }
        
//        /// <remarks/>
//        public LinkedNameType Order { get; set; }
        
//        /// <remarks/>
//        public LinkedNameType Family { get; set; }

//        /// <remarks/>
//        public LinkedNameType Genus { get; set; }
        
//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("AppliedVernacular", IsNullable = false)]
//        public DocumentAppliedVernacular[] AppliedVernaculars { get; set; }
        
//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("BiostatusValue", IsNullable = false)]
//        public DocumentBiostatusValue[] BiostatusValues { get; set; }
        
//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("Concept", IsNullable = false)]
//        public DocumentConcept[] Concepts { get; set; }
        
//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("Note", IsNullable = false)]
//        public DocumentNote[] Notes { get; set; }
        
//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("Image", IsNullable = false)]
//        public DocumentImage[] Images { get; set; }
        
//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("ExternalLink", IsNullable = false)]
//        public DocumentExternalLink[] ExternalLinks { get; set; }
        
//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("NomenclaturalStatus", IsNullable = false)]
//        public DocumentNomenclaturalStatus[] NomenclaturalStatusValues { get; set; }
        
//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("HybridData", IsNullable = false)]
//        public DocumentHybridData[] Hybridisation { get; set; }

//        /// <remarks/>
//        public DocumentHyperlinks Hyperlinks { get; set; }
        
//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("Collectionstring", IsNullable = false)]
//        public DocumentCollectionstring[] Collectionstrings { get; set; }
//        {
//            get
//            {
//                return this.collectionstringsField;
//            }
//            set
//            {
//                this.collectionstringsField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("Key", IsNullable = false)]
//        public DocumentKey[] InKeys
//        {
//            get
//            {
//                return this.inKeysField;
//            }
//            set
//            {
//                this.inKeysField = value;
//            }
//        }


//    }
//}
