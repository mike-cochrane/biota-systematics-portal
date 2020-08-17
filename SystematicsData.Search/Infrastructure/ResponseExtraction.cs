using SolrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using SystematicsData.Search.Models.Helpers;
using SystematicsData.Search.Models;
using SystematicsData.Search.Models.Search;

namespace SystematicsData.Search.Infrastructure
{
    public static class ResponseExtraction
    {
        // Extract part of the SolrNet response and set them in QueryResponse class
        public static void SetHeader(SearchResult queryResponse, SolrQueryResults<SolrDocument> solrResults)
        {
            queryResponse.QueryTime = solrResults.Header.QTime;
            queryResponse.Status = solrResults.Header.Status;
            queryResponse.TotalSpecimens = solrResults.NumFound;
        }

        public static void SetBody(SearchResult queryResponse, SolrQueryResults<SolrDocument> solrResults)
        {
            queryResponse.FoundDocuments = solrResults.ToDictionary(id => id.Id, document => document);
        }

        public static void SetSpellCheck(SearchResult queryResponse, SolrQueryResults<SolrDocument> solrResults)
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

        public static void SetFacets(SearchResult searchResult, SolrQueryResults<SolrDocument> results, FacetLists facetsLists)
        {
            var facetConfigList = Utils.GetFacetConfigList();

            foreach (AdminFacet config in facetConfigList)
            {
                var current = results.FacetFields.Where(c => c.Key == config.SolrFieldName);

                if (current.Any())
                {
                    var facetField = current.First();

                    switch (config.Type)
                    {
                        case "numeric":
                        case "date":
                            if (facetField.Value.Any() && facetField.Value.Where(v => v.Value > 0).Any())
                            {
                                Range range = new Range()
                                {
                                    Name = facetField.Key,
                                    DisplayText = config.Facet,
                                    Type = config.Type,
                                    MinimumValue = Convert.ToInt32(facetField.Value.First().Key),
                                    MaximumValue = Convert.ToInt32(facetField.Value.Last().Key)
                                };

                                //Calculate data for sparkline
                                if (range.Type.Equals("numeric"))
                                {
                                    if (range.MaximumValue != range.MinimumValue)
                                    {
                                        float sparklineIncrement = (range.MaximumValue - (float)range.MinimumValue) / Range.NUMBER_SPARKLINES;
                                        Dictionary<float, int> sparklineCounts = new Dictionary<float, int>();
                                        float currentKey = range.MinimumValue;
                                        sparklineCounts.Add(currentKey, 0);
                                        for (int i = 0; i < 94; i++)
                                        {
                                            currentKey += sparklineIncrement;
                                            sparklineCounts.Add(currentKey, 0);
                                        }

                                        if (facetField.Value.Any())
                                        {
                                            foreach (var item in facetField.Value)
                                            {
                                                int number = Convert.ToInt32(item.Key);
                                                float currentIncrement = float.NaN;
                                                float nextIncrement = float.NaN;
                                                bool inserted = false;
                                                foreach (float key in sparklineCounts.Keys)
                                                {
                                                    currentIncrement = nextIncrement;
                                                    nextIncrement = key;
                                                    if (!float.IsNaN(currentIncrement))
                                                    {
                                                        if (number >= currentIncrement && number < nextIncrement)
                                                        {
                                                            sparklineCounts[currentIncrement] += item.Value;
                                                            inserted = true;
                                                            break;
                                                        }
                                                    }
                                                }
                                                if (!inserted)
                                                {
                                                    sparklineCounts[nextIncrement] += 1;
                                                }
                                            }
                                        }

                                        bool first = true;
                                        foreach (int count in sparklineCounts.Values)
                                        {
                                            string value = string.Empty;
                                            if (count > 0)
                                            {
                                                value = Convert.ToString(Math.Log10(count + 10));
                                            }
                                            else
                                            {
                                                value = "0";
                                            }

                                            if (first)
                                            {
                                                range.SparklineData = value;
                                                first = false;
                                            }
                                            else
                                            {
                                                range.SparklineData += "," + value;
                                            }
                                        }
                                    }
                                }
                                else if (range.Type.Equals("date"))
                                {
                                    if (facetField.Value.Any())
                                    {
                                        //Calculate sparkline variables
                                        DateTime minDate = Utils.ConvertIntToDate(range.MinimumValue);
                                        DateTime maxDate = Utils.ConvertIntToDate(range.MaximumValue);
                                        if (minDate != maxDate)
                                        {
                                            double sparklineIncrement = maxDate.Subtract(minDate).TotalDays / Range.NUMBER_SPARKLINES;
                                            Dictionary<DateTime, int> sparklineCounts = new Dictionary<DateTime, int>();
                                            DateTime currentKey = minDate;
                                            sparklineCounts.Add(currentKey, 0);
                                            for (int i = 0; i < 94; i++)
                                            {
                                                currentKey = currentKey.AddDays(sparklineIncrement);
                                                sparklineCounts.Add(currentKey, 0);
                                            }

                                            //Calculate the counts for each interval
                                            foreach (var item in facetField.Value)
                                            {
                                                DateTime currentIncrement = DateTime.MaxValue;
                                                DateTime nextIncrement = DateTime.MaxValue;
                                                bool inserted = false;
                                                DateTime d = Utils.ConvertIntToDate(Convert.ToInt32(item.Key));
                                                foreach (DateTime key in sparklineCounts.Keys)
                                                {
                                                    currentIncrement = nextIncrement;
                                                    nextIncrement = key;
                                                    if (!currentIncrement.Equals(DateTime.MaxValue))
                                                    {
                                                        if (d.CompareTo(currentIncrement) >= 0 && d.CompareTo(nextIncrement) < 0)
                                                        {
                                                            sparklineCounts[currentIncrement] += item.Value;
                                                            inserted = true;
                                                            break;
                                                        }
                                                    }
                                                }
                                                if (!inserted)
                                                {
                                                    sparklineCounts[nextIncrement] += 1;
                                                }
                                            }

                                            //Build the sparkline string
                                            bool first = true;
                                            foreach (int count in sparklineCounts.Values)
                                            {
                                                string value = string.Empty;
                                                if (count > 0)
                                                {
                                                    value = Convert.ToString(Math.Log10(count + 10));
                                                }
                                                else
                                                {
                                                    value = "0";
                                                }

                                                if (first)
                                                {
                                                    range.SparklineData = value;
                                                    first = false;
                                                }
                                                else
                                                {
                                                    range.SparklineData += "," + value;
                                                }
                                            }
                                        }
                                    }
                                }

                                searchResult.Filters.Add(range);
                            }

                            break;

                        case "text":
                        default:
                            Facet facet = new Facet
                            {
                                Name = facetField.Key,
                                DisplayText = config.Facet
                            };

                            foreach (var v in facetField.Value)
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

            // process applied facets
            searchResult.AppliedFacets = facetsLists.AppliedFacets;

            foreach (var facet in searchResult.AppliedFacets)
            {
                facet.FacetLabel = Utils.GetFacetConfigList().Where(c => c.SolrFieldName == facet.FacetName).First().Facet;

                Filter filter = searchResult.Filters.Where(f => f.Name == facet.FacetName).FirstOrDefault();

                if (object.ReferenceEquals(filter.GetType(), typeof(SystematicsData.Search.Models.Search.Facet)))
                {
                    Facet f = (Facet)filter;
                    FacetValue value = f.Values.Where(v => v.Name == facet.ValueName).First();
                    value.Selected = true;
                }
            }

            //add in the applied ranges
            searchResult.AppliedRanges = facetsLists.AppliedRanges;
        }
    }
}
