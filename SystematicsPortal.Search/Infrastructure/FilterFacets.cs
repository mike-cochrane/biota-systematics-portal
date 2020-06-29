using SolrNet;
using SolrNet.Commands.Parameters;
using System.Collections.Generic;
using SystematicsPortal.Search.Tools.Models;

namespace SystematicsPortal.Search.Infrastructure
{
    internal class FilterFacets
    {
        // Building the filters: Filter queries do not affect score of the search and improve performance, as they are catched
        internal ICollection<ISolrQuery> BuildFilterQueries(Query query)
        {
            ICollection<ISolrQuery> filters = new List<ISolrQuery>();
            var refinersAlbum = new List<SolrQueryByField>();

            foreach (var facetFilter in query.FacetFilters)
            {
                switch (facetFilter.Key)
                {
                    //case "album":
                    //    query.AlbumFilter.Add(facetFilter.Value);
                    //    break;
                    //case "album_ss":
                    //    query.AlbumFilter.Add(facetFilter.Value);
                    //    break;
                    //case "aspectRatio":
                    //    query.AspectRatioFilter.Add(facetFilter.Value);
                    //    break;
                    //case "aspectRatio_ss":
                    //    query.AspectRatioFilter.Add(facetFilter.Value);
                    //    break;
                    //case "category":
                    //    query.CategoryFilter.Add(facetFilter.Value);
                    //    break;
                    //case "category_ss":
                    //    query.CategoryFilter.Add(facetFilter.Value);
                    //    break;
                    //case "copyright":
                    //    query.CopyrightFilter.Add(facetFilter.Value);
                    //    break;
                    //case "copyright_ss":
                    //    query.CopyrightFilter.Add(facetFilter.Value);
                    //    break;
                    //case "height":
                    //    if (long.TryParse(facetFilter.Value, out aux))
                    //    {
                    //        query.HeightFilter.Add(aux);
                    //    }
                    //    break;
                    //case "height_ss":
                    //    if (long.TryParse(facetFilter.Value, out aux))
                    //    {
                    //        query.HeightFilter.Add(aux);
                    //    }
                    //    break;
                    //case "keyword":
                    //    query.KeywordFilter.Add(facetFilter.Value);
                    //    break;
                    //case "keyword_ss":
                    //    query.KeywordFilter.Add(facetFilter.Value);
                    //    break;
                    //case "library":
                    //    query.LibraryFilter.Add(facetFilter.Value);
                    //    break;
                    //case "library_ss":
                    //    query.LibraryFilter.Add(facetFilter.Value);
                    //    break;
                    //case "originalFileType":
                    //    query.OriginalFileTypeFilter.Add(facetFilter.Value);
                    //    break;
                    //case "originalFileType_ss":
                    //    query.OriginalFileTypeFilter.Add(facetFilter.Value);
                    //    break;
                    //case "title":
                    //    query.TitleFilter.Add(facetFilter.Value);
                    //    break;
                    //case "title_ss":
                    //    query.TitleFilter.Add(facetFilter.Value);
                    //    break;
                    //case "width":
                    //    if (long.TryParse(facetFilter.Value, out aux))
                    //    {
                    //        query.WidthFilter.Add(aux);
                    //    }
                    //    break;
                    //case "width_ss":
                    //    if (long.TryParse(facetFilter.Value, out aux))
                    //    {
                    //        query.WidthFilter.Add(aux);
                    //    }
                    //    break;
                }
            }

            //foreach (var album in query.AlbumFilter)
            //{
            //    refinersAlbum.Add(new SolrQueryByField("album", album));
            //}
            //if (refinersAlbum.Count > 0)
            //{
            //    filters.Add(new SolrMultipleCriteriaQuery(refinersAlbum, "AND")); // Also possible to use OR
            //}

            return filters;
        }

        internal FacetParameters BuildFacets()
        {
            return new FacetParameters
            {
                Queries = new List<ISolrFacetQuery>
                {
                    //new SolrFacetFieldQuery("aspectRatio_ss")
                    //{
                    //    // This way we avoid bringing facets without elements
                    //    MinCount = 1
                    //}
                }
            };
        }
    }
}