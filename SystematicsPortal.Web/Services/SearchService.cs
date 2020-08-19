using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystematicsData.Search.Models;
using SystematicsData.Search.Models.Search;
using SystematicsData.Web.Api.Client.Interfaces;
using SystematicsPortal.Web.Services.Interfaces;

namespace SystematicsPortal.Web.Services
{
    public class SearchService : ISearchService
    {
        public ISystematicsDataClient _apiClient;

        public SearchService(ISystematicsDataClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<SearchResult> Search(string searchTerm,
            List<SelectedFacetValue> appliedFacets = null,
            List<SelectedRange> appliedRanges = null,
            int pageNumber = 0,
            int resultsPerPage = 100,
            string sortBy = "",
            string sortOrder = "")
        {
            // This is the object that will be used to parse the query and the parameter. Start Position equals to pageNumber * resultsPerPage. Rows number will be the results per page.
            var queryToUse = new Query(pageNumber * resultsPerPage, resultsPerPage)
            {
                TextQuery = searchTerm,
                FacetLists = new FacetLists()
                {
                    AppliedFacets = appliedFacets ?? new List<SelectedFacetValue>(),
                    AppliedRanges = appliedRanges ?? new List<SelectedRange>()
                }
        };

            var response = await _apiClient.Search(queryToUse);

            return response;
        }

        public List<SelectedFacetValue> SetAppliedFacets(string appliedFacets, string selectedFacet, string selectedValue, string selectedFacetType, bool addRemoveFilterToggle)
        {
            var searchResult = new SearchResult();

            searchResult.SetAppliedFacets(appliedFacets);

            var appliedFacetsList = ApplySelectedFacet(selectedFacet, selectedValue, selectedFacetType, addRemoveFilterToggle, searchResult);

            return appliedFacetsList;
        }

        private static List<SelectedFacetValue> ApplySelectedFacet(string selectedFacet, string selectedValue, string selectedFacetType, bool addRemoveFilterToggle, SearchResult searchResult)
        {
            if (selectedFacetType.ToLower().Equals("text"))
            {
                var appliedFacet = new SelectedFacetValue()
                {
                    FacetName = selectedFacet,
                    ValueName = selectedValue
                };
                if (addRemoveFilterToggle)
                {
                    if (!searchResult.AppliedFacets.Contains(appliedFacet))
                    {
                        searchResult.AppliedFacets.Add(appliedFacet);
                    }
                }
                else
                {
                    if (searchResult.ContainsAppliedFacet(appliedFacet))
                    {
                        searchResult.RemoveAppliedFacet(appliedFacet);
                    }
                }
            }

            return searchResult.AppliedFacets;
        }

        public List<SelectedRange> SetAppliedRanges(string appliedRanges, string selectedFacet, string selectedValue, string selectedFacetType, string selectedUpperValue, bool addRemoveFilterToggle)
        {
            var searchResult = new SearchResult();

            searchResult.SetAppliedRanges(appliedRanges);

            var appliedRangesList = ApplySelectedRange(selectedFacet, selectedValue, selectedFacetType, selectedUpperValue, addRemoveFilterToggle, searchResult);

            return appliedRangesList;
        }

        private static List<SelectedRange> ApplySelectedRange(string selectedFacet, string selectedValue, string selectedFacetType, string selectedUpperValue,  bool addRemoveFilterToggle, SearchResult searchResult)
        {
            if (selectedFacetType.ToLower().Equals("range"))
            {
                if (addRemoveFilterToggle)
                {
                    if (selectedValue.Contains('.'))
                    {
                        selectedValue = selectedValue.Split('.')[0];
                    }
                    if (selectedUpperValue.Contains('.'))
                    {
                        selectedUpperValue = selectedUpperValue.Split('.')[0];
                    }

                    var appliedRange = new SelectedRange()
                    {
                        FacetName = selectedFacet,
                        MinimumValue = Convert.ToInt32(selectedValue),
                        MaximumValue = Convert.ToInt32(selectedUpperValue)
                    };

                    searchResult.AddOrUpdateAppliedRange(appliedRange);
                }
                else
                {
                    searchResult.RemoveAppliedRange(selectedFacet);
                }
            }

            return searchResult.AppliedRanges;
        }

    }
}
