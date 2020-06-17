using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Systematics.Portal.Web.Helpers;
using Systematics.Portal.Web.Search.Tools.Models.Search;

namespace Systematics.Portal.Web.Models
{
    public class SetViewModel
    {
        public int SetId { get; set; }

        [Required]
        [DisplayName("Name")]
       // [ExcludeRestrictedWords]
        public string DisplayName { get; set; }

        [DataType(DataType.MultilineText)]
       // [ExcludeRestrictedWords]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid OwnerId { get; set; }

        public List<SetDocument> Specimens { get; set; }

        public string SelectedSortOption { get; set; }
        public SelectList SortOptions
        {
            get { return GetSortOptions(); }
        }

        public List<SetDocument> SortedSpecimens
        {
            get { return SortSpecimens(); }
        }

        public string SelectedView { get; set; }
        public bool IsNew { get; set; }

        public SetViewModel()
        {
            SetId = -1;
            DisplayName = string.Empty;
            Description = string.Empty;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.MinValue;
            OwnerId = Guid.Empty;

            Specimens = new List<SetDocument>();

            SelectedView = "list";
            SelectedSortOption = "accessionNumber";
            IsNew = true;
        }

        public List<SetDocument> SortSpecimens()
        {
            List<SetDocument> sortedSpecimens = Specimens;

            //switch (SelectedSortOption)
            //{
            //    case "accessionNumber":
            //        sortedSpecimens = Specimens.OrderBy(s => s.Summary.AccessionNumberSort).ToList();
            //        break;
            //    case "country":
            //        sortedSpecimens = Specimens.OrderBy(s => s.Summary.Country).ToList();
            //        break;
            //    case "collection":
            //        sortedSpecimens = Specimens.OrderBy(s => s.Summary.Collection).ToList();
            //        break;
            //    case "addedDate":
            //        sortedSpecimens = Specimens.OrderBy(s => s.AddedDate).ToList();
            //        break;
            //    case "ecologicalDistrict":
            //        sortedSpecimens = Specimens.OrderBy(s => s.Summary.EcologicalDistrict).ToList();
            //        break;
            //    case "hasImages":
            //        sortedSpecimens = Specimens.OrderByDescending(s => s.Summary.HasImages).ToList();
            //        break;
            //    case "landDistrict":
            //        sortedSpecimens = Specimens.OrderBy(s => s.Summary.LandDistrict).ToList();
            //        break;
            //    case "locality":
            //        //TODO - sortedSpecimens = Specimens.OrderBy(s => s.SpecimenSummary.Locality).ToList();
            //        break;
            //    case "newZealandAreaCode":
            //        sortedSpecimens = Specimens.OrderBy(s => s.Summary.NZAreaCode).ToList();
            //        break;
            //    case "taxonName":
            //        sortedSpecimens = Specimens.OrderBy(s => s.Summary.TaxonNameSort).ToList();
            //        break;
            //    case "typeStatus":
            //        sortedSpecimens = Specimens.OrderBy(s => s.Summary.TypeStatus).ToList();
            //        break;
            //    case "specimenType":
            //        sortedSpecimens = Specimens.OrderBy(s => s.Summary.SpecimenType).ToList();
            //        break;
            //    default:
            //        sortedSpecimens = Specimens.OrderBy(s => s.Summary.AccessionNumberSort).ToList();
            //        break;
            //}

            return sortedSpecimens;
        }

        private SelectList GetSortOptions()
        {
            ComboList sortOptions = new ComboList();
            sortOptions.AddItem("accessionNumber", "Accession number");
            sortOptions.AddItem("country", "Country");
            sortOptions.AddItem("collection", "Data provider");
            sortOptions.AddItem("addedDate", "Date added");
            sortOptions.AddItem("ecologicalDistrict", "Ecological district");
            sortOptions.AddItem("hasImages", "Images available");
            sortOptions.AddItem("landDistrict", "Land district");
            sortOptions.AddItem("locality", "Standard locality");
            sortOptions.AddItem("newZealandAreaCode", "New Zealand area code");
            sortOptions.AddItem("taxonName", "Taxonomic name");
            sortOptions.AddItem("typeStatus", "Type status");
            sortOptions.AddItem("specimenType", "Specimen type");

            return new SelectList(sortOptions.Items, "Key", "DisplayText", SelectedSortOption);
        }
    }

    public class SelectSetViewModel
    {
        public string ErrorMessage { get; set; }
        public List<SetViewModel> SetData { get; set; }

        public SelectSetViewModel()
        {
            ErrorMessage = string.Empty;
            SetData = new List<SetViewModel>();
        }
    }
}