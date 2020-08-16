using System;
using System.Collections.Generic;
using System.Linq;

namespace SystematicsData.Search.Tools.Models.Search
{
    public class SearchResult
    {
        public int QueryTime { get; set; }

        public int Status { get; set; }

        public Dictionary<string, SolrDocument> FoundDocuments { get; set; }

        public int TotalSpecimens { get; set; }

        public List<Filter> Filters { get; set; }

        public List<SelectedFacetValue> AppliedFacets { get; set; }

        public List<SelectedRange> AppliedRanges { get; set; }

        public List<string> DidYouMean { get; set; }

        //public int SecondsToRetrieveData { get; set; }
        //public int SecondsToProcessData { get; set; }
        //public int SecondsToRenderData { get; set; }

        public SearchResult() : this("relevance")
        {
        }

        public SearchResult(string sortBy = "relevance")
        {
            FoundDocuments = new Dictionary<string, SolrDocument>();
            TotalSpecimens = 0;

            Filters = new List<Filter>();

            AppliedFacets = new List<SelectedFacetValue>();
            AppliedRanges = new List<SelectedRange>();
        }

        public List<SolrDocument> DisplayedDocuments() // siamac this didn't work SpecimenSummary
        {
            List<SolrDocument> documents = FoundDocuments.Values.ToList();

            return documents;
        }

        public string GetAppliedFacets()
        {
            string appliedFacets = String.Empty;

            foreach (SelectedFacetValue facet in AppliedFacets)
            {
                if (!appliedFacets.Equals(String.Empty))
                {
                    appliedFacets += "|";
                }
                appliedFacets += facet.GroupName + "|" + facet.FacetName + "|" + facet.ValueName;
            }

            return appliedFacets;
        }

        public void SetAppliedFacets(string appliedFacets)
        {
            AppliedFacets.Clear();

            if (appliedFacets == null)
            {
                return;
            }

            appliedFacets = appliedFacets.Replace("&amp;", "&");

            char[] separator = new char[] { '|' };
            string[] values = appliedFacets.Split(separator);

            int groupIndex = 0;
            int facetIndex = 1;
            int valueIndex = 2;

            while (valueIndex < values.Count())
            {
                SelectedFacetValue facet = new SelectedFacetValue()
                {
                    GroupName = values[groupIndex],
                    FacetName = values[facetIndex],
                    ValueName = values[valueIndex]
                };
                AppliedFacets.Add(facet);

                groupIndex += 3;
                facetIndex += 3;
                valueIndex += 3;
            }
        }

        public bool ContainsAppliedFacet(SelectedFacetValue facet)
        {
            bool contains = false;

            foreach (SelectedFacetValue appliedFacet in AppliedFacets)
            {
                if (appliedFacet.GroupName.Equals(facet.GroupName) && appliedFacet.FacetName.Equals(facet.FacetName) && appliedFacet.ValueName.Equals(facet.ValueName))
                {
                    contains = true;
                    break;
                }
            }

            return contains;
        }

        public void RemoveAppliedFacet(SelectedFacetValue facet)
        {
            foreach (SelectedFacetValue appliedFacet in AppliedFacets)
            {
                if (appliedFacet.GroupName.Equals(facet.GroupName) && appliedFacet.FacetName.Equals(facet.FacetName) && appliedFacet.ValueName.Equals(facet.ValueName))
                {
                    AppliedFacets.Remove(appliedFacet);
                    break;
                }
            }
        }

        public string GetAppliedRanges()
        {
            string appliedRanges = String.Empty;

            foreach (SelectedRange range in AppliedRanges)
            {
                if (!appliedRanges.Equals(String.Empty))
                {
                    appliedRanges += "|";
                }
                appliedRanges += range.GroupName + "|" + range.FacetName + "|" + range.MinimumValue + "|" + range.MaximumValue;
            }

            return appliedRanges;
        }

        public void SetAppliedRanges(string appliedRanges)
        {
            if (appliedRanges == null)
            {
                return;
            }

            AppliedRanges.Clear();

            if (AppliedRanges == null)
            {
                return;
            }

            char[] separator = new char[] { '|' };
            string[] values = appliedRanges.Split(separator);

            int groupIndex = 0;
            int facetIndex = 1;
            int minValueIndex = 2;
            int maxValueIndex = 3;
            int includeNullsIndex = 4;

            while (maxValueIndex < values.Count())
            {
                SelectedRange range = new SelectedRange()
                {
                    GroupName = values[groupIndex],
                    FacetName = values[facetIndex],
                    MinimumValue = Convert.ToInt32(values[minValueIndex]),
                    MaximumValue = Convert.ToInt32(values[maxValueIndex])
                };
                AppliedRanges.Add(range);

                groupIndex += 4;
                facetIndex += 4;
                minValueIndex += 4;
                maxValueIndex += 4;
                includeNullsIndex += 4;
            }
        }

        public void AddOrUpdateAppliedRange(SelectedRange range)
        {
            SelectedRange specifiedRange = null;

            foreach (SelectedRange appliedRange in AppliedRanges)
            {
                if (appliedRange.GroupName.Equals(range.GroupName) && appliedRange.FacetName.Equals(range.FacetName))
                {
                    specifiedRange = appliedRange;
                    break;
                }
            }

            if (specifiedRange == null)
            {
                AppliedRanges.Add(range);
            }
            else
            {
                specifiedRange.MinimumValue = range.MinimumValue;
                specifiedRange.MaximumValue = range.MaximumValue;
            }
        }

        public bool ContainsAppliedRange(SelectedRange range)
        {
            bool contains = false;

            foreach (SelectedRange appliedRange in AppliedRanges)
            {
                if (appliedRange.GroupName.Equals(range.GroupName) && appliedRange.FacetName.Equals(range.FacetName))
                {
                    contains = true;
                    break;
                }
            }

            return contains;
        }

        public void RemoveAppliedRange(SelectedRange range)
        {
            foreach (SelectedRange appliedRange in AppliedRanges)
            {
                if (appliedRange.GroupName.Equals(range.GroupName) && appliedRange.FacetName.Equals(range.FacetName))
                {
                    AppliedRanges.Remove(appliedRange);
                    break;
                }
            }
        }

        public void RemoveAppliedRange(string groupName, string facetName)
        {
            SelectedRange range = null;

            foreach (SelectedRange item in AppliedRanges)
            {
                if (item.GroupName == groupName && item.FacetName == facetName)
                {
                    range = item;
                    break;
                }
            }

            if (range != null)
            {
                AppliedRanges.Remove(range);
            }
        }

        public void RemoveAppliedRange(string facetName)
        {
            SelectedRange range = AppliedRanges.Where(r => r.FacetName == facetName).First();
            if (range != null)
            {
                AppliedRanges.Remove(range);
            }
        }

        public List<FacetValue> TopFive(Facet facet)
        {
            var topFive = facet.Values.OrderByDescending(v => v.Count).Where(v => v.Selected == false).Take(5).ToList();
            return topFive;
        }
    }
}
