﻿using SolrNet;
using SolrNet.Commands.Parameters;
using System.Collections.Generic;
using SystematicsData.Search.Models.Helpers;
using SystematicsData.Search.Models;

namespace SystematicsData.Search.Infrastructure
{
    public static class FilterFacets
    {
        // Building the filters: Filter queries do not affect score of the search and improve performance, as they are catched
        public static ICollection<ISolrQuery> BuildFilterQueries(Query query)
        {
            var filters = new List<ISolrQuery>();

            filters.AddRange(GetAppliedFacets(query));
            filters.AddRange(GetAppliedRanges(query));

            return filters;
        }

        private static List<ISolrQuery> GetAppliedFacets(Query query)
        {
            var facets = new List<ISolrQuery>();

            foreach (var appliedFacet in query.FacetLists?.AppliedFacets)
            {
                facets.Add(new SolrQueryByField(appliedFacet.FacetName, appliedFacet.ValueName));
            }

            return facets;
        }

        private static List<ISolrQuery> GetAppliedRanges(Query query)
        {
            var ranges = new List<ISolrQuery>();

            foreach (var appliedRange in query.FacetLists.AppliedRanges)
            {
                ranges.Add(new SolrQueryByRange<int>(appliedRange.FacetName, appliedRange.MinimumValue, appliedRange.MaximumValue));
            }

            return ranges;
        }

        public static FacetParameters BuildFacets()
        {
            var facetsConfiguration = Utils.GetFacetConfigList();
            var queries = new List<ISolrFacetQuery>();

            foreach (var facetConfiguration in facetsConfiguration)
            {
                queries.Add(new SolrFacetFieldQuery(facetConfiguration.SolrFieldName)
                {
                    MinCount = 1
                });

            }

            var facetParameters = new FacetParameters()
            {
                Queries = queries
            };

            return facetParameters;
        }
    }
}
