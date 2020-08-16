using System;
using System.Collections.Generic;
using SystematicsData.Search.Models.Search;

namespace SystematicsData.Search.Models.Helpers
{
    public class Utils
    {
        public static List<AdminFacet> GetFacetConfigList()
        {
            var facetConfigList = new List<AdminFacet>()
            {
                new AdminFacet()
                {
                    AdminFacetId = 0,
                    DisplayOrder = 0,
                    Facet = "Record Class",
                    SolrFieldName = "documentClass_ss",
                    FacetGroup = "",
                    Type = "text"
                },
                  new AdminFacet()
                {
                    AdminFacetId = 1,
                    DisplayOrder = 1,
                    Facet = "Record Source",
                    SolrFieldName = "source_ss",
                    FacetGroup = "",
                    Type = "text"
                },
                new AdminFacet()
                {
                    AdminFacetId = 2,
                    DisplayOrder = 2,
                    Facet = "Original author(s)",
                    SolrFieldName = "basionymAuthor_ss",
                    FacetGroup = "Nomenclature",
                    Type = "text"
                },
                   new AdminFacet()
                {
                    AdminFacetId = 3,
                    DisplayOrder = 3,
                    Facet = "Combination Author(s)",
                    SolrFieldName = "combinationAuthor_ss",
                    FacetGroup = "Nomenclature",
                    Type = "text"
                },
                    new AdminFacet()
                {
                    AdminFacetId = 4,
                    DisplayOrder = 4,
                    Facet = "Nomenclature code",
                    SolrFieldName = "nomCode_ss",
                    FacetGroup = "Nomenclature",
                    Type = "text"
                },
                 new AdminFacet()
                {
                    AdminFacetId = 5,
                    DisplayOrder = 5,
                    Facet = "Epithet",
                    SolrFieldName = "canonical_ss",
                    FacetGroup = "Nomenclature",
                    Type = "text"
                },
                new AdminFacet()
                {
                    AdminFacetId = 6,
                    DisplayOrder = 6,
                    Facet = "Nomenclatural status ",
                    SolrFieldName = "nomStatus_ss",
                    FacetGroup = "Nomenclature",
                    Type = "text"
                },
                new AdminFacet()
                {
                    AdminFacetId = 7,
                    DisplayOrder = 7,
                    Facet = "Kingdom",
                    SolrFieldName = "kingdom_ss",
                    FacetGroup = "Classification",
                    Type = "text"
                },
                new AdminFacet()
                {
                    AdminFacetId = 8,
                    DisplayOrder = 8,
                    Facet = "Phylum",
                    SolrFieldName = "phylum_ss",
                    FacetGroup = "Classification",
                    Type = "text"
                },
                new AdminFacet()
                {
                    AdminFacetId = 9,
                    DisplayOrder = 9,
                    Facet = "Class",
                    SolrFieldName = "class_ss",
                    FacetGroup = "Classification",
                    Type = "text"
                },
                new AdminFacet()
                {
                    AdminFacetId = 10,
                    DisplayOrder = 10,
                    Facet = "Order",
                    SolrFieldName = "order_ss",
                    FacetGroup = "Classification",
                    Type = "text"
                },
                 new AdminFacet()
                {
                    AdminFacetId = 11,
                    DisplayOrder = 11,
                    Facet = "Family",
                    SolrFieldName = "family_ss",
                    FacetGroup = "Classification",
                    Type = "text"
                },
                new AdminFacet()
                {
                    AdminFacetId = 12,
                    DisplayOrder = 12,
                    Facet = "Genus",
                    SolrFieldName = "genus_ss",
                    FacetGroup = "Classification",
                    Type = "text"
                },
                 new AdminFacet()
                {
                    AdminFacetId = 13,
                    DisplayOrder = 13,
                    Facet = "Taxonomic rank",
                    SolrFieldName = "taxonRank_ss",
                    FacetGroup = "Classification",
                    Type = "text"
                },
                new AdminFacet()
                {
                    AdminFacetId = 14,
                    DisplayOrder = 14,
                    Facet = "Parent",
                    SolrFieldName = "parent_ss",
                    FacetGroup = "Classification",
                    Type = "text"
                },
                new AdminFacet()
                {
                    AdminFacetId = 15,
                    DisplayOrder = 15,
                    Facet = "Preferred name",
                    SolrFieldName = "current_ss",
                    FacetGroup = "Classification",
                    Type = "text"
                },
                new AdminFacet()
                {
                    AdminFacetId = 16,
                    DisplayOrder = 16,
                    Facet = "Vernacular Name",
                    SolrFieldName = "vernacularName_ss",
                    FacetGroup = "Vernacular names",
                    Type = "text"
                },
                new AdminFacet()
                {
                    AdminFacetId = 17,
                    DisplayOrder = 17,
                    Facet = "Language Of Origin",
                    SolrFieldName = "vernacularLanguageOfOrigin_ss",
                    FacetGroup = "Vernacular names",
                    Type = "text"
                },
                new AdminFacet()
                {
                    AdminFacetId = 18,
                    DisplayOrder = 18,
                    Facet = "Language of use",
                    SolrFieldName = "verncularLanguageOfUse_ss",
                    FacetGroup = "Vernacular names",
                    Type = "text"
                },
                new AdminFacet()
                {
                    AdminFacetId = 19,
                    DisplayOrder = 19,
                    Facet = "Region Of Use",
                    SolrFieldName = "vernacularRegionOfUse_ss",
                    FacetGroup = "Vernacular names",
                    Type = "text"
                },
                new AdminFacet()
                {
                    AdminFacetId = 20,
                    DisplayOrder = 20,
                    Facet = "Region of origin",
                    SolrFieldName = "vernacularRegionofOrigin_ss",
                    FacetGroup = "Vernacular names",
                    Type = "text"
                },
                    new AdminFacet()
                {
                    AdminFacetId = 21,
                    DisplayOrder = 21,
                    Facet = "Origin",
                    SolrFieldName = "nzOrigin_ss",
                    FacetGroup = "New Zealand Biostatus",
                    Type = "text"
                },
                   new AdminFacet()
                {
                    AdminFacetId = 22,
                    DisplayOrder = 22,
                    Facet = "Occurrence",
                    SolrFieldName = "nzOccurrence_ss",
                    FacetGroup = "New Zealand Biostatus",
                    Type = "text"
                },
                new AdminFacet()
                {
                    AdminFacetId = 23,
                    DisplayOrder = 23,
                    Facet = "Type of reference",
                    SolrFieldName = "referenceType_ss",
                    FacetGroup = "Reference",
                    Type = "text"
                },
                   new AdminFacet()
                {
                    AdminFacetId = 24,
                    DisplayOrder = 24,
                    Facet = "Parent Reference",
                    SolrFieldName = "parentReference_ss",
                    FacetGroup = "Reference",
                    Type = "text"
                },
                new AdminFacet()
                {
                    AdminFacetId = 27,
                    DisplayOrder = 27,
                    Facet = "Associations",
                    SolrFieldName = "associationType_ss",
                    FacetGroup = "",
                    Type = "text"
                },
                new AdminFacet()
                {
                    AdminFacetId = 28,
                    DisplayOrder = 28,
                    Facet = "Added",
                    SolrFieldName = "added_ss",
                    FacetGroup = "Metadata",
                    Type = "text"
                },
                     new AdminFacet()
                {
                    AdminFacetId = 29,
                    DisplayOrder = 29,
                    Facet = "Updated",
                    SolrFieldName = "updated_ss",
                    FacetGroup = "Metadata",
                    Type = "text"
                },

                 new AdminFacet()
                {
                    AdminFacetId = 30,
                    DisplayOrder = 30,
                    Facet = "Hybrid Parent",
                    SolrFieldName = "hybridParent_ss",
                    FacetGroup = "",
                    Type = "text"
                },
                  new AdminFacet()
                {
                    AdminFacetId = 31,
                    DisplayOrder = 31,
                    Facet = "Hyperlink Type",
                    SolrFieldName = "hyperLinkType_ss",
                    FacetGroup = "",
                    Type = "text"
                },


                 new AdminFacet()
                {
                    AdminFacetId = 32,
                    DisplayOrder = 32,
                    Facet = "NZ BioStatus Reference",
                    SolrFieldName = "nzBioStatusReference_ss",
                    FacetGroup = "",
                    Type = "text"
                },

                    new AdminFacet()
                {
                    AdminFacetId = 33,
                    DisplayOrder = 33,
                    Facet = "externalLinkSource",
                    SolrFieldName = "externalLinkSource_ss",
                    FacetGroup = "",
                    Type = "text"
                },
            };

            return facetConfigList;
        }

        public static DateTime ConvertIntToDate(int i)
        {
            try
            {
                int year = i / 10000;
                int month = Math.Min(12, (i - (year * 10000)) / 100);
                int day = i - (year * 10000) - (month * 100);
                if (month == 2)
                {
                    day = Math.Min(29, day);
                }
                else if (month == 4 || month == 6 || month == 9 || month == 11)
                {
                    day = Math.Min(30, day);
                }
                else
                {
                    day = Math.Min(31, day);
                }
                return new DateTime(year, Math.Max(1, month), Math.Max(1, day));

            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }
    }
}
