using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SystematicsPortal.Search.Tools.Models.Search
{
    [Serializable()]
    [XmlRoot("Record")]
    public class SpecimenDetails
    {
        [XmlElement("AccessionNumber")]
        public string AccessionNumber { get; set; }
        [XmlElement("SpecimenGuid")]
        public string SpecimenGuid { get; set; }
        [XmlElement("Barcode")]
        public string Barcode { get; set; }
        [XmlElement("TypeStatusId")]
        public string TypeStatus { get; set; }
        [XmlElement("SpecimenTypeId")]
        public string SpecimenType { get; set; }
        [XmlElement("Quantity")]
        public string Quantity { get; set; }
        [XmlElement("Quality")]
        public string Quality { get; set; }
        [XmlElement("IsMissing")]
        public bool IsMissing { get; set; }
        [XmlElement("IsDeaccessioned")]
        public bool IsDeaccessioned { get; set; }
        [XmlElement("IsDeleted")]
        public bool IsDeleted { get; set; }
        [XmlElement("ExsiccataId")]
        public string Exsiccata { get; set; }
        [XmlElement("AddedUser")]
        public string AddedUser { get; set; }
        [XmlElement("AddedDate")]
        public DateTime AddedDate { get; set; }
        [XmlElement("ChangeUser")]
        public string ChangeUser { get; set; }
        [XmlElement("ChangeDate")]
        public DateTime ChangeDate { get; set; }

        //storageLocation??

        [XmlElement("Extensions")]
        public List<SpecimenDetailsExtensions> Extensions { get; set; }
        [XmlArray("ImageLinks")]
        public List<ImageLink> Images { get; set; }
        [XmlArray("Components")]
        public List<SpecimenComponent> Components { get; set; }
        [XmlArray("CollectionEvents")]
        public List<CollectionEventSpecimen> CollectionEvents { get; set; }
        [XmlArray("SpecimenFlags")]
        public List<SpecimenFlag> Flags { get; set; }
        [XmlArray("SpecimenNotes")]
        public List<SpecimenNote> SpecimenNotes { get; set; }
        [XmlArray("SpecimenRelationships")]
        public List<SpecimenRelationship> SpecimenLinks { get; set; }
        [XmlArray("SpecimenEvents")]
        public List<SpecimenEvent> Events { get; set; }
        [XmlArray("Duplicates")]
        public List<Duplicate> Duplicates { get; set; }
        [XmlArray("AssignedRefNumbers")]
        public List<AssignedRefNumber> AssignedReferenceNumbers { get; set; }
        [XmlArray("ExternalLinks")]
        public List<ExternalLink> ExternalLinks { get; set; }
        [XmlArray("Batches")]
        public List<Batch> Batches { get; set; }
        [XmlArray("InventoryItems")]
        public List<InventoryItem> InventoryItems { get; set; }

        public SpecimenDetails()
        {
            AccessionNumber = String.Empty;
            SpecimenGuid = String.Empty;
            Barcode = String.Empty;
            TypeStatus = String.Empty;
            SpecimenType = String.Empty;
            Quantity = String.Empty;
            Quality = String.Empty;
            IsMissing = false;
            IsDeaccessioned = false;
            IsDeleted = false;
            Exsiccata = String.Empty;
            AddedUser = String.Empty;
            AddedDate = DateTime.MinValue;
            ChangeUser = String.Empty;
            ChangeDate = DateTime.MinValue;

            Images = new List<ImageLink>();
            Components = new List<SpecimenComponent>();
            CollectionEvents = new List<CollectionEventSpecimen>();
            Flags = new List<SpecimenFlag>();
            SpecimenNotes = new List<SpecimenNote>();
            SpecimenLinks = new List<SpecimenRelationship>();
            Events = new List<SpecimenEvent>();
            Duplicates = new List<Duplicate>();
            AssignedReferenceNumbers = new List<AssignedRefNumber>();
            ExternalLinks = new List<ExternalLink>();
            Batches = new List<Batch>();
            InventoryItems = new List<InventoryItem>();
            Extensions = new List<SpecimenDetailsExtensions>();
        }
    }

    [Serializable()]
    [XmlRoot("Extensions")]
    public class SpecimenDetailsExtensions
    {
        [XmlElement("CollectionAcronym")]
        public string DataProvider { get; set; }
        [XmlElement("LoanStatus")]
        public string LoanStatus { get; set; }

        public SpecimenDetailsExtensions()
        {
            DataProvider = String.Empty;
            LoanStatus = String.Empty;
        }
    }

    [Serializable()]
    [XmlRoot("ImageLink")]
    public class ImageLink
    {
        [XmlElement("ImageURL")]
        public string ImageURL { get; set; }

        public ImageLink()
        {
            ImageURL = String.Empty;
        }
    }

    [Serializable()]
    [XmlRoot("SpecimenComponent")]
    public class SpecimenComponent
    {
        [XmlElement("IsPrimary")]
        public bool IsPrimary { get; set; }
        [XmlElement("SpecimenTypeId")]
        public string Type { get; set; }
        [XmlElement("IsPresent")]
        public bool IsPresent { get; set; }
        [XmlElement("Substrate")]
        public string Substrate { get; set; }
        [XmlElement("PartAffected")]
        public string PartAffected { get; set; }

        [XmlElement("Extensions")]
        public List<ComponentExtension> Extensions { get; set; }
        [XmlArray("Identifications")]
        public List<Identification> Identifications { get; set; }

        public SpecimenComponent()
        {
            IsPrimary = false;
            Type = String.Empty;
            IsPresent = true;
            Substrate = String.Empty;
            PartAffected = String.Empty;

            Extensions = new List<ComponentExtension>();
            Identifications = new List<Identification>();
        }
    }

    [Serializable()]
    [XmlRoot("Extensions")]
    public class ComponentExtension
    {
        [XmlElement("ComponentAssociationText")]
        public string Association { get; set; }

        public ComponentExtension()
        {
            Association = String.Empty;
        }
    }

    [Serializable()]
    [XmlRoot("Identification")]
    public class Identification
    {
        [XmlElement("TaxonName")]
        public string TaxonName { get; set; }
        [XmlElement("Determiner")]
        public string Determiner { get; set; }
        [XmlElement("IdentifiersRefNumber")]
        public string DeterminerReferenceNumber { get; set; }
        [XmlElement("Date")]
        public string VerbatimDeterminationDate { get; set; }
        [XmlElement("ISODate")]
        public string ISODate { get; set; }
        [XmlElement("IsUncertain")]
        public bool IsUncertain { get; set; }
        [XmlElement("IsActive")]
        public bool IsActive { get; set; }
        [XmlElement("VernacularName")]
        public string VernacularName { get; set; }
        [XmlElement("IdentificationTypeId")]
        public string IdentificationType { get; set; }
        [XmlElement("Note")]
        public string IdentificationNote { get; set; }
        [XmlElement("ReferenceText")]
        public string ReferenceText { get; set; }
        [XmlElement("TypeStatusId")]
        public string TypeStatus { get; set; }

        [XmlArray("IdentificationNames")]
        public List<IdentificationName> IdentificationNames { get; set; }

        public Identification()
        {
            TaxonName = String.Empty;
            Determiner = String.Empty;
            DeterminerReferenceNumber = String.Empty;
            VerbatimDeterminationDate = String.Empty;
            ISODate = String.Empty;
            IsUncertain = false;
            IsActive = false;
            VernacularName = String.Empty;
            IdentificationType = String.Empty;
            IdentificationNote = String.Empty;
            ReferenceText = String.Empty;
            TypeStatus = String.Empty;

            IdentificationNames = new List<IdentificationName>();
        }
    }

    [Serializable()]
    [XmlRoot("IdentificationName")]
    public class IdentificationName
    {
        [XmlElement("WorkingNameId")]
        public string WorkingName { get; set; }

        [XmlElement("Extensions")]
        public List<IdentificationNameExtension> Extensions { get; set; }

        public IdentificationName()
        {
            WorkingName = String.Empty;

            Extensions = new List<IdentificationNameExtension>();
        }
    }

    [Serializable()]
    [XmlRoot("Extensions")]
    public class IdentificationNameExtension
    {
        [XmlElement("Division")]
        public string Division { get; set; }
        [XmlElement("Phylum")]
        public string Phylum { get; set; }
        [XmlElement("Class")]
        public string Class { get; set; }
        [XmlElement("Order")]
        public string Order { get; set; }
        [XmlElement("Family")]
        public string Family { get; set; }

        public IdentificationNameExtension()
        {
            Division = String.Empty;
            Phylum = String.Empty;
            Class = String.Empty;
            Order = String.Empty;
            Family = String.Empty;
        }
    }

    [Serializable()]
    [XmlRoot("CollectionEventSpecimen")]
    public class CollectionEventSpecimen
    {
        [XmlElement("Representation")]
        public List<CollectionEventSpecimenRepresentation> Representation { get; set; }
        [XmlElement("CollectionEvent")]
        public List<CollectionEvent> CollectionEvent { get; set; }

        [XmlElement("IsPrimary")]
        public bool IsPrimary { get; set; }
        //?? public string Context { get; set; }
        [XmlElement("CollectorsRefNumber")]
        public string CollectorsRefNumber { get; set; }
        [XmlElement("MicroHabitat")]
        public string MicroHabitat { get; set; }
        [XmlElement("AbundanceTypeId")]
        public string Abundance { get; set; }

        public CollectionEventSpecimen()
        {
            Representation = new List<CollectionEventSpecimenRepresentation>();
            CollectionEvent = new List<CollectionEvent>();

            IsPrimary = false;
            CollectorsRefNumber = String.Empty;
            MicroHabitat = String.Empty;
            Abundance = String.Empty;
        }
    }

    [Serializable()]
    [XmlRoot("Representation")]
    public class CollectionEventSpecimenRepresentation
    {
        [XmlElement("MicroHabitat")]
        public string MicroHabitat { get; set; }

        public CollectionEventSpecimenRepresentation()
        {
            MicroHabitat = String.Empty;
        }
    }

    [Serializable()]
    [XmlRoot("CollectionEvent")]
    public class CollectionEvent
    {
        [XmlElement("CollectionEventTypeId")]
        public string Type { get; set; }
        [XmlElement("VerbatimCollector")]
        public string Collector { get; set; }
        [XmlElement("VerbatimDate")]
        public string CollectionDate { get; set; }
        [XmlElement("StartDate")]
        public string StartDate { get; set; }
        [XmlElement("EndDate")]
        public string EndDate { get; set; }
        [XmlElement("Locality")]
        public string VerbatimLocality { get; set; }
        [XmlElement("LocalityId")]
        public string GazeteerLocality { get; set; }
        [XmlElement("CollectionEventCode")]
        public string CollectionEventCode { get; set; }
        [XmlElement("MethodId")]
        public string MethodId { get; set; }

        [XmlElement("Representation")]
        public List<CollectionEventRepresentation> Representation { get; set; }
        [XmlArray("CollectionEventRegions")]
        public List<CollectionEventRegion> GeoRegions { get; set; }
        [XmlArray("GeoReferences")]
        public List<GeoReference> GeoReferences { get; set; }
        [XmlArray("ObservedSpecies")]
        public List<ObservedSpecies> ObservedSpecies { get; set; }
        [XmlArray("CollectionEventKeywords")]
        public List<CollectionEventKeywords> Keywords { get; set; }
        [XmlArray("Altitudes")]
        public List<Altitude> Altitudes { get; set; }
        [XmlArray("LocalHeights")]
        public List<LocalHeight> LocalHeights { get; set; }

        public CollectionEvent()
        {
            Type = String.Empty;
            VerbatimLocality = String.Empty;
            GazeteerLocality = String.Empty;
            Collector = String.Empty;
            CollectionDate = String.Empty;
            StartDate = String.Empty;
            EndDate = String.Empty;
            CollectionEventCode = String.Empty;
            MethodId = String.Empty;

            Representation = new List<CollectionEventRepresentation>();
            LocalHeights = new List<LocalHeight>();
            GeoReferences = new List<GeoReference>();
            Altitudes = new List<Altitude>();
            GeoRegions = new List<CollectionEventRegion>();
            ObservedSpecies = new List<ObservedSpecies>();
            Keywords = new List<CollectionEventKeywords>();
        }
    }

    [Serializable()]
    [XmlRoot("Representation")]
    public class CollectionEventRepresentation
    {
        [XmlElement("Habitat")]
        public string Habitat { get; set; }
        [XmlElement("Notes")]
        public string CollectionEventNotes { get; set; }

        public CollectionEventRepresentation()
        {
            Habitat = String.Empty;
            CollectionEventNotes = String.Empty;
        }
    }

    [Serializable()]
    [XmlRoot("GeoReference")]
    public class GeoReference
    {
        [XmlElement("CoordinateSystemId")]
        public string CoordinateSystem { get; set; }
        [XmlElement("GeodeticDatumId")]
        public string Datum { get; set; }

        [XmlElement("Representation")]
        public List<Representation> Representation { get; set; }

        public GeoReference()
        {
            CoordinateSystem = String.Empty;
            Datum = String.Empty;

            Representation = new List<Representation>();
        }
    }

    [Serializable()]
    [XmlRoot("Representation")]
    public class Representation
    {//Georeference Representation
        [XmlElement("Georeference")]
        public string Georeference { get; set; }

        public Representation()
        {
            Georeference = String.Empty;
        }
    }

    [Serializable()]
    [XmlRoot("CollectionEventRegion")] //GeoRegions
    public class CollectionEventRegion
    {
        [XmlElement("GeoRegionSchemaId")]
        public string Schema { get; set; }
        [XmlElement("GeoRegionId")]
        public string Region { get; set; }
        [XmlElement("VerbatimRegion")]
        public string VerbatimRegion { get; set; }

        public CollectionEventRegion()
        {
            Schema = String.Empty;
            Region = String.Empty;
            VerbatimRegion = String.Empty;
        }
    }

    [Serializable()]
    [XmlRoot("ObservedSpecies")]
    public class ObservedSpecies
    {
        [XmlElement("AssociationTypeId")]
        public string AssociationType { get; set; }
        [XmlElement("TaxonName")]
        public string TaxonName { get; set; }
        [XmlElement("WorkingNameId")]
        public string WorkingName { get; set; }
        [XmlElement("IsDerived")]
        public bool IsDerived { get; set; }

        public ObservedSpecies()
        {
            AssociationType = String.Empty;
            TaxonName = String.Empty;
            WorkingName = String.Empty;
            IsDerived = false;
        }
    }

    [Serializable()]
    [XmlRoot("CollectionEventKeywords")]
    public class CollectionEventKeywords
    {
        [XmlElement("GeoEcologicalKeywordID")]
        public string Word { get; set; }

        public CollectionEventKeywords()
        {
            Word = String.Empty;
        }
    }

    [Serializable()]
    [XmlRoot("Altitude")]
    public class Altitude
    {
        [XmlElement("Representation")]
        public List<AltitudeRepresentation> Representations { get; set; }

        public Altitude()
        {
            Representations = new List<AltitudeRepresentation>();
        }
    }

    [Serializable()]
    [XmlRoot("Representation")]
    public class AltitudeRepresentation
    {
        [XmlElement("CalculatedLower")]
        public string CalculatedLower { get; set; }
        [XmlElement("CalculatedUpper")]
        public string CalculatedUpper { get; set; }

        public AltitudeRepresentation()
        {
            CalculatedLower = String.Empty;
            CalculatedUpper = String.Empty;
        }
    }

    [Serializable()]
    [XmlRoot("LocalHeight")]
    public class LocalHeight
    {
        [XmlElement("Representation")]
        public List<AltitudeRepresentation> Representations { get; set; }

        public LocalHeight()
        {
            Representations = new List<AltitudeRepresentation>();
        }
    }

    [Serializable()]
    [XmlRoot("SpecimenFlag")]
    public class SpecimenFlag
    {
        [XmlElement("SpecimenFlagTypeId")]
        public string Type { get; set; }
        [XmlElement("Value")]
        public string Value { get; set; }
        [XmlElement("Note")]
        public string Note { get; set; }

        public SpecimenFlag()
        {
            Type = String.Empty;
            Value = String.Empty;
            Note = String.Empty;
        }
    }

    [Serializable()]
    [XmlRoot("SpecimenNote")]
    public class SpecimenNote
    {
        [XmlElement("SpecimenNoteTypeId")]
        public string NoteType { get; set; }
        [XmlElement("Note")]
        public string Text { get; set; }
        [XmlElement("Author")]
        public string Author { get; set; }
        [XmlElement("Date")]
        public string Date { get; set; }

        public SpecimenNote()
        {
            NoteType = String.Empty;
            Text = String.Empty;
            Author = String.Empty;
            Date = String.Empty;
        }
    }

    [Serializable()]
    [XmlRoot("SpecimenRelationship")]
    public class SpecimenRelationship
    {
        [XmlElement("SpecimenRelationshipTypeId")]
        public string Type { get; set; }
        [XmlElement("Note")]
        public string Note { get; set; }

        [XmlElement("SpecimenRelationshipMember")]
        public List<SpecimenRelationshipMember> Members { get; set; }

        public SpecimenRelationship()
        {
            Type = String.Empty;
            Note = String.Empty;

            Members = new List<SpecimenRelationshipMember>();
        }
    }

    [Serializable()]
    [XmlRoot("SpecimenRelationshipMember")]
    public class SpecimenRelationshipMember
    {
        [XmlElement("AccessionNumber")]
        public string AccessionNumber { get; set; }
        [XmlElement("Note")]
        public string Note { get; set; }

        public SpecimenRelationshipMember()
        {
            AccessionNumber = String.Empty;
            Note = String.Empty;
        }
    }

    [Serializable()]
    [XmlRoot("SpecimenEvent")]
    public class SpecimenEvent
    {
        [XmlElement("SpecimenEventTypeId")]
        public string Type { get; set; }
        [XmlElement("MethodId")]
        public string SpecimenEventMethod { get; set; }
        [XmlElement("Note")]
        public string SpecimenEventNote { get; set; }
        [XmlElement("ActionedBy")]
        public string ActionedBy { get; set; }
        [XmlElement("RefNumberForActionedBy")]
        public string ActionedByReferenceNumber { get; set; }
        [XmlElement("DateText")]
        public string VerbatimDate { get; set; }
        [XmlElement("ISODate")]
        public string ISODate { get; set; }

        public SpecimenEvent()
        {
            Type = String.Empty;
            SpecimenEventMethod = String.Empty;
            SpecimenEventNote = String.Empty;
            ActionedBy = String.Empty;
            ActionedByReferenceNumber = String.Empty;
            VerbatimDate = String.Empty;
            ISODate = String.Empty;
        }
    }

    [Serializable()]
    [XmlRoot("Duplicate")]
    public class Duplicate
    {
        [XmlElement("Collection")]
        public string Collection { get; set; }
        [XmlElement("AccessionNumber")]
        public string AccessionNumber { get; set; }
        [XmlElement("DuplicateDirectionTypeId")]
        public string Direction { get; set; }
        [XmlElement("DateReceived")]
        public string DateReceived { get; set; }
        [XmlElement("Note")]
        public string DuplicateNote { get; set; }

        public Duplicate()
        {
            Collection = String.Empty;
            AccessionNumber = String.Empty;
            Direction = String.Empty;
            DateReceived = String.Empty;
            DuplicateNote = String.Empty;
        }
    }

    [Serializable()]
    [XmlRoot("AssignedRefNumber")]
    public class AssignedRefNumber
    {
        [XmlElement("RefNumberId")]
        public string ReferenceNumber { get; set; }
        [XmlElement("RefNumberValue")]
        public string Value { get; set; }

        public AssignedRefNumber()
        {
            ReferenceNumber = String.Empty;
            Value = String.Empty;
        }
    }

    [Serializable()]
    [XmlRoot("ExternalLink")]
    public class ExternalLink
    {
        [XmlElement("ExternalLinkTypeId")]
        public string ExternalLinkType { get; set; }
        [XmlElement("DisplayValue")]
        public string Value { get; set; }
        [XmlElement("URL")]
        public string Url { get; set; }
        [XmlElement("Note")]
        public string Note { get; set; }
        [XmlElement("IsValid")]
        public bool IsValid { get; set; }

        public ExternalLink()
        {
            ExternalLinkType = String.Empty;
            Value = String.Empty;
            Url = String.Empty;
            Note = String.Empty;
            IsValid = false;
        }
    }

    [Serializable()]
    [XmlRoot("Batch")]
    public class Batch
    {
        [XmlElement("DateCreated")]
        public DateTime DateCreated { get; set; }
        [XmlElement("DateFrozen")]
        public DateTime DateFrozen { get; set; }
        [XmlElement("PhysicalLocation")]
        public string PhysicalLocation { get; set; }
        [XmlElement("OriginalViability")]
        public string OriginalViability { get; set; }
        [XmlElement("Viability")]
        public string Viability { get; set; }
        [XmlElement("ViabilityDate")]
        public string ViabilityDate { get; set; }
        [XmlElement("Note")]
        public string BatchNote { get; set; }
        [XmlElement("IsGone")]
        public bool IsGone { get; set; }
        [XmlElement("BatchStorageMethodTypeId")]
        public string StorageMethod { get; set; }
        [XmlElement("Quantity")]
        public string BatchQuantity { get; set; }

        public Batch()
        {
            DateCreated = DateTime.MinValue;
            DateFrozen = DateTime.MinValue;
            PhysicalLocation = String.Empty;
            OriginalViability = String.Empty;
            Viability = String.Empty;
            ViabilityDate = String.Empty;
            BatchNote = String.Empty;
            IsGone = false;
            StorageMethod = String.Empty;
            BatchQuantity = String.Empty;
        }
    }

    [Serializable()]
    [XmlRoot("InventoryItem")]
    public class InventoryItem
    {
        [XmlElement("TransactionId")]
        public string TransactionReferenceNumber { get; set; }
        [XmlElement("SpecimenId")]
        public string LCRCatalogueId { get; set; }
        [XmlElement("TaxonName")]
        public string TaxonName { get; set; }
        [XmlElement("InventoryItemStatusTypeId")]
        public string ItemStatus { get; set; }
        [XmlElement("DestructionApproved")]
        public bool IsApprovedForDestruction { get; set; }
        [XmlElement("IsType")]
        public bool IsType { get; set; }
        [XmlElement("Quantity")]
        public int Quantity { get; set; }
        [XmlElement("Comments")]
        public string Comments { get; set; }
        [XmlElement("InwardInventoryItemDamageTypeId")]
        public string DamageLevelIn { get; set; }
        [XmlElement("OutwardInventoryItemDamageTypeId")]
        public string DamageLevelOut { get; set; }
        [XmlElement("SpecimenTypeId")]
        public string PreservationMethod { get; set; }

        [XmlElement("Extensions")]
        public List<InventoryItemExtension> Extensions { get; set; }

        public InventoryItem()
        {
            TransactionReferenceNumber = String.Empty;
            LCRCatalogueId = String.Empty;
            TaxonName = String.Empty;
            ItemStatus = String.Empty;
            IsApprovedForDestruction = false;
            IsType = false;
            Quantity = 0;
            Comments = String.Empty;
            DamageLevelIn = String.Empty;
            DamageLevelOut = String.Empty;
            PreservationMethod = String.Empty;
        }
    }

    [Serializable()]
    [XmlRoot("Extensions")]
    public class InventoryItemExtension
    {
        [XmlElement("OrganisationAcronym")]
        public string OrganisationAcronym { get; set; }

        public InventoryItemExtension()
        {
            OrganisationAcronym = String.Empty;
        }
    }
}
