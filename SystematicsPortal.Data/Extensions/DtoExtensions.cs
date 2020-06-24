using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystematicsPortal.Data.dbmodels;
using SystematicsPortal.Model.Models.DTOs;
using SystematicsPortal.Utility.Helpers;

namespace SystematicsPortal.Data.Extensions
{
    public static class DtoExtensions
    {
        public static DocumentDto ToDto(this Document nameDocument)
        {
            var name = SerializationHelper.Deserialize<SystematicsPortal.Model.Models.Documents.Name.Document>(nameDocument.SerializedDocument);


            var docDto = new DocumentDto();
            
                docDto.NameId = nameDocument.DocumentId.ToString();
                docDto.DocumentClass = name.documentClass;
                docDto.Source = name.source;
                docDto.Added = name.added;
                docDto.AddedSpecified = name.addedSpecified;
                docDto.Updated = name.updated;
                docDto.UpdatedSpecified = name.updatedSpecified;
                docDto.ParentReference = name.ParentReference;
                docDto.Name = name.Name;
                docDto.NameFormatted = name.NameFormatted;
                docDto.NameScientific = name.NameScientific;
                docDto.NamePartFormatted = name.NamePartFormatted.ToString();
                docDto.Orthography = name.Orthography;
                docDto.Page = name.Page;
                docDto.YearOfPublication = name.YearOfPublication;
                docDto.YearOnPublication = name.YearOfPublication;
                docDto.Classification = name.Classification;
                docDto.TypeLocality = name.TypeLocality;
                docDto.SanctioningAuthor = name.SanctioningAuthor;
                docDto.SanctioningPage = name.SanctioningPage;
                docDto.HybridLink = name.HybridLink;
                docDto.CheckStatus = name.CheckStatus;
                docDto.NameReference = name.NameReference;
                docDto.TaxonomyReference = name.TaxonomyReference;
                docDto.Parent = name.Parent;
                docDto.CurrentName = name.CurrentName;
                docDto.Synonyms = name.Synonyms?.ToList();
                docDto.Siblings = name.Siblings?.ToList();
                docDto.Subordinates = name.Subordinates?.ToList();
                docDto.Basionym = name.Basionym;
                docDto.BasedOn = name.BasedOn;
                docDto.Blocking = name.Blocking;
                docDto.AnamorphGenus = name.AnamorphGenus;
                docDto.AnamorphReference = name.AnamorphReference;
                docDto.TypeTaxon = name.TypeTaxon;
                docDto.ForeignId = name.ForeignId;
                docDto.Kingdom = name.Kingdom;
                docDto.Phylum = name.Phylum;
                docDto.Class = name.Class;
                docDto.Order = name.Order;
                docDto.Family = name.Family;
                docDto.Genus = name.Genus;
                docDto.AppliedVernaculars = name.AppliedVernaculars?.ToList();
                docDto.BiostatusValues = name.BiostatusValues?.ToList();
                docDto.Concepts = name.Concepts?.ToList();
                docDto.Notes = name.Notes?.ToList();
                docDto.Images = name.Images?.ToList();
                docDto.ExternalLinks = name.ExternalLinks?.ToList();
                docDto.NomenclaturalStatusValues = name.NomenclaturalStatusValues?.ToList();
                docDto.Hybridisation = name.Hybridisation?.ToList();
                docDto.Hyperlinks = name.Hyperlinks;
                docDto.CollectionObjects = name.CollectionObjects?.ToList();
                docDto.InKeys = name.InKeys?.ToList();

                return docDto;
            
        }
    }
}
