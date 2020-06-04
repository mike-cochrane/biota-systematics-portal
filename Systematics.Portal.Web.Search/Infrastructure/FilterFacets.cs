using SolrNet;
using SolrNet.Commands.Parameters;
using System.Collections.Generic;
using Systematics.Portal.Web.Search.Tools.Models;

namespace SearchLibrary.Implementation
{
    internal class FilterFacets
    {
        // Building the filters: Filter queries do not affect score of the search and improve performance, as they are catched
        internal ICollection<ISolrQuery> BuildFilterQueries(Query query)
        {
            ICollection<ISolrQuery> filters = new List<ISolrQuery>();
            var refinersAlbum = new List<SolrQueryByField>();

            var refinersAspectRatio = new List<SolrQueryByField>();

            var refinersCategory = new List<SolrQueryByField>();

            var refinersCopyright = new List<SolrQueryByField>();

            var refinersHeight = new List<SolrQueryByField>();

            var refinersKeyword = new List<SolrQueryByField>();

            var refinersLibrary = new List<SolrQueryByField>();

            var refinersOriginalFileType = new List<SolrQueryByField>();

            var refinersTitle = new List<SolrQueryByField>();

            var refinersWidth = new List<SolrQueryByField>();

            var refinersGrantView = new List<ISolrQuery>();

            foreach (var facetFilter in query.FacetFilters)
            {
                long aux;
                switch (facetFilter.Key)
                {
                    case "album":
                        query.AlbumFilter.Add(facetFilter.Value);
                        break;
                    case "album_ss":
                        query.AlbumFilter.Add(facetFilter.Value);
                        break;
                    case "aspectRatio":
                        query.AspectRatioFilter.Add(facetFilter.Value);
                        break;
                    case "aspectRatio_ss":
                        query.AspectRatioFilter.Add(facetFilter.Value);
                        break;
                    case "category":
                        query.CategoryFilter.Add(facetFilter.Value);
                        break;
                    case "category_ss":
                        query.CategoryFilter.Add(facetFilter.Value);
                        break;
                    case "copyright":
                        query.CopyrightFilter.Add(facetFilter.Value);
                        break;
                    case "copyright_ss":
                        query.CopyrightFilter.Add(facetFilter.Value);
                        break;
                    case "height":
                        if (long.TryParse(facetFilter.Value, out aux))
                        {
                            query.HeightFilter.Add(aux);
                        }
                        break;
                    case "height_ss":
                        if (long.TryParse(facetFilter.Value, out aux))
                        {
                            query.HeightFilter.Add(aux);
                        }
                        break;
                    case "keyword":
                        query.KeywordFilter.Add(facetFilter.Value);
                        break;
                    case "keyword_ss":
                        query.KeywordFilter.Add(facetFilter.Value);
                        break;
                    case "library":
                        query.LibraryFilter.Add(facetFilter.Value);
                        break;
                    case "library_ss":
                        query.LibraryFilter.Add(facetFilter.Value);
                        break;
                    case "originalFileType":
                        query.OriginalFileTypeFilter.Add(facetFilter.Value);
                        break;
                    case "originalFileType_ss":
                        query.OriginalFileTypeFilter.Add(facetFilter.Value);
                        break;
                    case "title":
                        query.TitleFilter.Add(facetFilter.Value);
                        break;
                    case "title_ss":
                        query.TitleFilter.Add(facetFilter.Value);
                        break;
                    case "width":
                        if (long.TryParse(facetFilter.Value, out aux))
                        {
                            query.WidthFilter.Add(aux);
                        }
                        break;
                    case "width_ss":
                        if (long.TryParse(facetFilter.Value, out aux))
                        {
                            query.WidthFilter.Add(aux);
                        }
                        break;
                }
            }

            foreach (var album in query.AlbumFilter)
            {
                refinersAlbum.Add(new SolrQueryByField("album", album));
            }
            if (refinersAlbum.Count > 0)
            {
                filters.Add(new SolrMultipleCriteriaQuery(refinersAlbum, "AND")); // Also possible to use OR
            }

            foreach (var aspectRatio in query.AspectRatioFilter)
            {
                refinersAspectRatio.Add(new SolrQueryByField("aspectRatio", aspectRatio));
            }
            if (refinersAspectRatio.Count > 0)
            {
                filters.Add(new SolrMultipleCriteriaQuery(refinersAspectRatio, "AND"));
            }

            foreach (var category in query.CategoryFilter)
            {
                refinersCategory.Add(new SolrQueryByField("category", category));
            }
            if (refinersCategory.Count > 0)
            {
                filters.Add(new SolrMultipleCriteriaQuery(refinersCategory, "AND"));
            }

            foreach (var copyright in query.CopyrightFilter)
            {
                refinersCopyright.Add(new SolrQueryByField("copyright", copyright));
            }
            if (refinersCopyright.Count > 0)
            {
                filters.Add(new SolrMultipleCriteriaQuery(refinersCopyright, "AND"));
            }

            foreach (var height in query.HeightFilter)
            {
                refinersHeight.Add(new SolrQueryByField("height", height.ToString()));
            }
            if (refinersHeight.Count > 0)
            {
                filters.Add(new SolrMultipleCriteriaQuery(refinersHeight, "AND"));
            }

            foreach (var keyword in query.KeywordFilter)
            {
                refinersKeyword.Add(new SolrQueryByField("keyword", keyword));
            }
            if (refinersKeyword.Count > 0)
            {
                filters.Add(new SolrMultipleCriteriaQuery(refinersKeyword, "AND"));
            }

            foreach (var library in query.LibraryFilter)
            {
                refinersLibrary.Add(new SolrQueryByField("library", library));
            }
            if (refinersLibrary.Count > 0)
            {
                filters.Add(new SolrMultipleCriteriaQuery(refinersLibrary, "AND"));
            }

            foreach (var originalFileType in query.OriginalFileTypeFilter)
            {
                refinersOriginalFileType.Add(new SolrQueryByField("originalFileType", originalFileType));
            }
            if (refinersOriginalFileType.Count > 0)
            {
                filters.Add(new SolrMultipleCriteriaQuery(refinersOriginalFileType, "AND"));
            }

            foreach (var title in query.TitleFilter)
            {
                refinersTitle.Add(new SolrQueryByField("title", title));
            }
            if (refinersTitle.Count > 0)
            {
                filters.Add(new SolrMultipleCriteriaQuery(refinersTitle, "AND"));
            }

            foreach (var width in query.WidthFilter)
            {
                refinersWidth.Add(new SolrQueryByField("width", width.ToString()));
            }
            if (refinersWidth.Count > 0)
            {
                filters.Add(new SolrMultipleCriteriaQuery(refinersWidth, "AND"));
            }

            // We filter the search considering the permissions that the user has.
            // More information on https://confluence.landcareresearch.co.nz/x/z4WSB
            var individualPermissions = $"({string.Join(" || ", query.GrantDenyIndividualPermissionsFilter)})";

            // DII: Deny image individual
            var DII = new SolrQuery("imageDenyView:" + individualPermissions);
            // DCI: Deny category individual
            var DCI = new SolrQuery("categoryDenyView:" + individualPermissions);
            // DLI: Deny library individual
            var DLI = new SolrQuery("libraryDenyView:" + individualPermissions);
            // GII: Grant image individual
            var GII = new SolrQuery("imageGrantView:" + individualPermissions);
            // GCI: Grant category individual
            var GCI = new SolrQuery("categoryGrantView:" + individualPermissions);
            // GLI: Grant library Individual
            var GLI = new SolrQuery("libraryGrantView:" + individualPermissions);

            // If there are not groups assigned to the user, we fill in the group constraints using the operatorId, to keep the query uncorropted
            var groupPermissions = query.GrantDenyGroupPermissionsFilter.Count > 0 ? $"({string.Join(" || ", query.GrantDenyGroupPermissionsFilter)})" : $"({string.Join(" || ", query.GrantDenyIndividualPermissionsFilter)})";

            // DIG: Deny image group
            var DIG = new SolrQuery("imageDenyView:" + groupPermissions);
            // DCG: Deny category group
            var DCG = new SolrQuery("categoryDenyView:" + groupPermissions);
            // DLG: Deny  library group
            var DLG = new SolrQuery("libraryDenyView:" + groupPermissions);
            // GLG: Grant library group
            var GLG = new SolrQuery("libraryGrantView:" + groupPermissions);
            // GCG: Grant category group
            var GCG = new SolrQuery("categoryGrantView:" + groupPermissions);
            // GIG: Grant image group
            var GIG = new SolrQuery("imageGrantView:" + groupPermissions);

            var publicPermissions = $"({string.Join(" || ", query.GrantDenyPublicPermissionsFilter)})";

            // DIP: Deny image public
            var DIP = new SolrQuery("imageDenyView:" + publicPermissions);
            // DCP: Deny category public
            var DCP = new SolrQuery("categoryDenyView:" + publicPermissions);
            // DLP: Deny  library public
            var DLP = new SolrQuery("libraryDenyView:" + publicPermissions);
            // GIP: Grant image public
            var GIP = new SolrQuery("imageGrantView:" + publicPermissions);
            // GCP: Grant category public
            var GCP = new SolrQuery("categoryGrantView:" + publicPermissions);
            // GLP: Grant library public
            var GLP = new SolrQuery("libraryGrantView:" + publicPermissions);


            var q =
            (
                    !DII
                    &&
                    (
                        (
                            !DIG
                            &&
                            (
                                (
                                    !DIP
                                    &&
                                    (
                                        (
                                            !DCI
                                            &&
                                            (
                                                (
                                                    !DCG
                                                    &&
                                                    (
                                                        (
                                                            !DCP
                                                            &&
                                                            (
                                                                (
                                                                    !DLI
                                                                    &&
                                                                    (
                                                                        (
                                                                            !DLG
                                                                            &&
                                                                            (
                                                                                (
                                                                                    !DLP && GLP
                                                                                )
                                                                                || GLP
                                                                            )
                                                                        )
                                                                        || GLG
                                                                    )
                                                                )
                                                                || GLI
                                                            )
                                                        )
                                                        || GCP
                                                    )
                                                )
                                                || GCG
                                            )
                                        )
                                        || GCI
                                    )
                                )
                                || GIP
                            )
                        )
                        || GIG
                    )
                )
                ||
                GII;

            refinersGrantView.Add(q);

            if (refinersGrantView.Count > 0)
            {
                filters.Add(new SolrMultipleCriteriaQuery(refinersGrantView, "OR"));
            }

            return filters;
        }

        internal FacetParameters BuildFacets()
        {
            return new FacetParameters
            {
                Queries = new List<ISolrFacetQuery>
                {
                    new SolrFacetFieldQuery("aspectRatio_ss")
                    {
                        // This way we avoid bringing facets without elements
                        MinCount = 1
                    },
                    new SolrFacetFieldQuery("library_ss")
                    {
                        // This way we avoid bringing facets without elements
                        MinCount = 1
                    },
                    new SolrFacetFieldQuery("category_ss")
                    {
                        // This way we avoid bringing facets without elements
                        MinCount = 1
                    },
                    new SolrFacetFieldQuery("copyright_ss")
                    {
                        // This way we avoid bringing facets without elements
                        MinCount = 1
                    },
                    new SolrFacetFieldQuery("album_ss")
                    {
                        // This way we avoid bringing facets without elements
                        MinCount = 1
                    },
                    new SolrFacetFieldQuery("keyword_ss")
                    {
                        // This way we avoid bringing facets without elements
                        MinCount = 1
                    },
                    new SolrFacetFieldQuery("originalFileType_ss")
                    {
                        // This way we avoid bringing facets without elements
                        MinCount = 1
                    }
                }
            };
        }
    }
}