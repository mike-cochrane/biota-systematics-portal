using System.Collections.Generic;
using System.Linq;
using SolrNet;
using Systematics.Portal.Web.Search.Tools.Helpers;
using Systematics.Portal.Web.Search.Tools.Models;
using Systematics.Portal.Web.Search.Tools.Models.Search;

namespace SearchLibrary.Implementation
{
    public class ResponseExtraction
    {
        // Extract part of the SolrNet response and set them in QueryResponse class
        internal void SetHeader(SearchResult queryResponse, SolrQueryResults<SolrDocument> solrResults)
        {
            queryResponse.QueryTime = solrResults.Header.QTime;
            queryResponse.Status = solrResults.Header.Status;
            queryResponse.TotalSpecimens = solrResults.NumFound;
        }

        internal void SetBody(SearchResult queryResponse, SolrQueryResults<SolrDocument> solrResults)
        {
            queryResponse.FoundDocuments = solrResults.ToDictionary(id => id.Id, document => document);
        }

        internal void SetSpellCheck(SearchResult queryResponse, SolrQueryResults<SolrDocument> solrResults)
        {
            var spellSuggestions = new List<string>();

            foreach (var spellResult in solrResults.SpellChecking)
            {
                foreach (var suggestion in spellResult.Suggestions)
                {
                    spellSuggestions.Add(suggestion);
                }
            }

            queryResponse.DidYouMean = spellSuggestions;
        }

        internal void SetFacets(SearchResult searchResult, SolrQueryResults<SolrDocument> results)
        {
            var facetConfigList = Utils.GetFacetConfigList();

            foreach (AdminFacet config in facetConfigList)
            {
                var current = results.FacetFields.Where(c => c.Key == config.SolrFieldName);
                if (current.Any())
                {
                    var f = current.First();
                    switch (config.Type)
                    {
                        case "text":
                        default:
                            Facet facet = new Facet();
                            facet.Name = f.Key;

                            facet.DisplayText = config.Facet;

                            foreach (var v in f.Value)
                            {
                                if (v.Value > 0)
                                {
                                    FacetValue value = new FacetValue()
                                    {
                                        Name = v.Key,
                                        Count = v.Value
                                    };
                                    facet.Values.Add(value);
                                }
                            }

                           
                            if (facet.Values.Any())
                            {
                                searchResult.Filters.Add(facet);
                            }
                            break;
                    }
                }
            }
        }
    }
}