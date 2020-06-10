using System.Collections.Generic;
using System.Linq;
using SolrNet;
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

        internal void SetBody(QueryResponse queryResponse, SolrQueryResults<SolrDocument> solrResults)
        {
            queryResponse.Results = solrResults;
        }

        internal void SetSpellCheck(QueryResponse queryResponse, SolrQueryResults<SolrDocument> solrResults)
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

        internal void SetFacets(QueryResponse queryResponse, SolrQueryResults<SolrDocument> solrResults)
        {
            if (solrResults.FacetFields.ContainsKey("aspectRatio_ss"))
            {
                queryResponse.Facets.Add(new Facet
                {
                    Name = "aspectRatio_ss",
                    Values = solrResults.FacetFields["aspectRatio_ss"]
                        .Select(
                            facet => new KeyValuePair<string, int>(facet.Key, facet.Value))
                        .ToList()
                });
            }
        }
    }
}