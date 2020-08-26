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

        /// <summary>
        /// Method to provide search capabilities to the website using the API client 
        /// </summary>
        /// <param name="searchTerm">Text query to search for</param>
        /// <param name="appliedFacets">List of applied factes</param>
        /// <param name="appliedRanges">List of applied ranges</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="resultsPerPage">Number of results per page</param>
        /// <param name="sortBy">Field to be used for sorting</param>
        /// <param name="sortOrder">Sorting order</param>
        /// <returns></returns>
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
                FacetLists = new FacetLists()
                {
                    AppliedFacets = appliedFacets ?? new List<SelectedFacetValue>(),
                    AppliedRanges = appliedRanges ?? new List<SelectedRange>()
                },
                TextQuery = searchTerm,
                SortBy = sortBy,
                SortOrder = sortOrder
            };

            var response = await _apiClient.Search(queryToUse);

            return response;
        }

        /// <summary>
        /// Prepares the list of applied facets with current facets and selected facet.
        /// </summary>
        /// <param name="appliedFacets">String that containt the facets that are already selected</param>
        /// <param name="selectedFacet">Facet that has been selected</param>
        /// <param name="selectedValue">Value for the facet that has been selected</param>
        /// <param name="selectedFacetType">Indicates if it is a text or range field</param>
        /// <param name="addRemoveFilterToggle">Toggle used by the UI to add or remove the facet</param>
        /// <returns></returns>
        public List<SelectedFacetValue> SetAppliedFacets(string appliedFacets, string selectedFacet, string selectedValue, string selectedFacetType, bool addRemoveFilterToggle)
        {
            var searchResult = new SearchResult();

            searchResult.SetAppliedFacets(appliedFacets);

            var appliedFacetsList = ApplySelectedFacet(selectedFacet, selectedValue, selectedFacetType, addRemoveFilterToggle, searchResult);

            return appliedFacetsList;
        }

        /// <summary>
        /// Applies the specific slected facet to the list (adds or remove according to toggle)
        /// </summary>
        /// <param name="selectedFacet"></param>
        /// <param name="selectedValue"></param>
        /// <param name="selectedFacetType"></param>
        /// <param name="addRemoveFilterToggle"></param>
        /// <param name="searchResult"></param>
        /// <returns></returns>
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

        /// <summary>
        ///  Prepares the list of applied ranges with current ranges and selected range.
        /// </summary>
        /// <param name="appliedRanges">String that containt the ranges that are already selected</param>
        /// <param name="selectedFacet">Range that has been selected</param>
        /// <param name="selectedValue">Value for the range that has been selected</param>
        /// <param name="selectedFacetType">Indicates if it is a text or range field</param>
        /// <param name="selectedUpperValue">Indicate the upper value limit for the range</param>
        /// <param name="addRemoveFilterToggle">Toggle used by the UI to add or remove the range</param>
        /// <returns></returns>
        public List<SelectedRange> SetAppliedRanges(string appliedRanges, string selectedFacet, string selectedValue, string selectedFacetType, string selectedUpperValue, bool addRemoveFilterToggle)
        {
            var searchResult = new SearchResult();

            searchResult.SetAppliedRanges(appliedRanges);

            var appliedRangesList = ApplySelectedRange(selectedFacet, selectedValue, selectedFacetType, selectedUpperValue, addRemoveFilterToggle, searchResult);

            return appliedRangesList;
        }

        /// <summary>
        ///  Applies the specific slected range to the list (adds or remove according to toggle)
        /// </summary>
        /// <param name="selectedFacet"></param>
        /// <param name="selectedValue"></param>
        /// <param name="selectedFacetType"></param>
        /// <param name="selectedUpperValue"></param>
        /// <param name="addRemoveFilterToggle"></param>
        /// <param name="searchResult"></param>
        /// <returns></returns>
        private static List<SelectedRange> ApplySelectedRange(string selectedFacet, string selectedValue, string selectedFacetType, string selectedUpperValue, bool addRemoveFilterToggle, SearchResult searchResult)
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
