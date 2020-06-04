using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Systematics.Portal.Web.Helpers;
using Systematics.Portal.Web.Models.Search;

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

        public List<SetSpecimen> Specimens { get; set; }

        public string SelectedSortOption { get; set; }
        public SelectList SortOptions
        {
            get { return GetSortOptions(); }
        }

        public List<SetSpecimen> SortedSpecimens
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

            Specimens = new List<SetSpecimen>();

            SelectedView = "list";
            SelectedSortOption = "accessionNumber";
            IsNew = true;
        }

        public List<SetSpecimen> SortSpecimens()
        {
            List<SetSpecimen> sortedSpecimens = Specimens;

            switch (SelectedSortOption)
            {
                case "accessionNumber":
                    sortedSpecimens = Specimens.OrderBy(s => s.SpecimenSummary.AccessionNumberSort).ToList();
                    break;
                case "country":
                    sortedSpecimens = Specimens.OrderBy(s => s.SpecimenSummary.Country).ToList();
                    break;
                case "collection":
                    sortedSpecimens = Specimens.OrderBy(s => s.SpecimenSummary.Collection).ToList();
                    break;
                case "addedDate":
                    sortedSpecimens = Specimens.OrderBy(s => s.AddedDate).ToList();
                    break;
                case "ecologicalDistrict":
                    sortedSpecimens = Specimens.OrderBy(s => s.SpecimenSummary.EcologicalDistrict).ToList();
                    break;
                case "hasImages":
                    sortedSpecimens = Specimens.OrderByDescending(s => s.SpecimenSummary.HasImages).ToList();
                    break;
                case "landDistrict":
                    sortedSpecimens = Specimens.OrderBy(s => s.SpecimenSummary.LandDistrict).ToList();
                    break;
                case "locality":
                    //TODO - sortedSpecimens = Specimens.OrderBy(s => s.SpecimenSummary.Locality).ToList();
                    break;
                case "newZealandAreaCode":
                    sortedSpecimens = Specimens.OrderBy(s => s.SpecimenSummary.NZAreaCode).ToList();
                    break;
                case "taxonName":
                    sortedSpecimens = Specimens.OrderBy(s => s.SpecimenSummary.TaxonNameSort).ToList();
                    break;
                case "typeStatus":
                    sortedSpecimens = Specimens.OrderBy(s => s.SpecimenSummary.TypeStatus).ToList();
                    break;
                case "specimenType":
                    sortedSpecimens = Specimens.OrderBy(s => s.SpecimenSummary.SpecimenType).ToList();
                    break;
                default:
                    sortedSpecimens = Specimens.OrderBy(s => s.SpecimenSummary.AccessionNumberSort).ToList();
                    break;
            }

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