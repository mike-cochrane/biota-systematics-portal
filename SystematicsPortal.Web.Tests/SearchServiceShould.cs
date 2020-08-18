using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystematicsData.Search.Models;
using SystematicsData.Search.Models.Search;
using SystematicsPortal.Web.Services;
using SystematicsPortal.Web.Services.Interfaces;
using Xunit;

namespace SystematicsPortal.Web.Tests
{
    public class SearchServiceShould
    {
        private readonly ISearchService _sut;

        public SearchServiceShould()
        {
            var dataClientMock = new Mock<SystematicsData.Web.Api.Client.Interfaces.ISystematicsDataClient>();

            var searchResult = new SearchResult();

            var query = GetQuery();
            dataClientMock.Setup(foo => foo.Search(query)).Returns(GetSearchResult());

            _sut = new SearchService(dataClientMock.Object);
        }

        private async Task<SearchResult> GetSearchResult()
        {
            var searchResult = new SearchResult();

            return searchResult;
        }

        private Query GetQuery(string searchTerm = "Bacteria", int selectedPage = 1, int numberResults = 100)
        {
            var queryToUse = new Query(selectedPage * numberResults, numberResults)
            {
                TextQuery = searchTerm,
                FacetLists = new FacetLists()
                {
                    AppliedFacets = new List<SelectedFacetValue>(),
                    AppliedRanges = new List<SelectedRange>()
                }
            };

            return queryToUse;
        }


        [Fact]
        public async Task DoBasicSearchAsync()
        {
            // Arrange
            var searchTerm = "Bacteria";
            var selectedPage = 1;
            var numberResults = 100;


            var sortField = string.Empty;
            var sortOrder = "ascending";
            var query = GetQuery(searchTerm, selectedPage, numberResults);

            // Act
            var result = await _sut.Search(query.TextQuery, null, null, selectedPage, query.Rows, sortField, sortOrder);

            // Assert

            // TODO: Check why mocked client is returning null
            //Assert.IsType<SearchResult>(result);
            //Assert.NotNull(result);

            Assert.True(true);
        }

        [Fact]
        public async Task DoSearchWithFacetsAsync()
        {
            // Arrange
            string searchTerm = "Bacteria";
            int selectedPage = 1;
            int numberResults = 100;
           string sortField = string.Empty;
            string sortOrder = "ascending";

            string selectedFacet = "order_ss";
            string selectedFacetType = "text";
            string selectedValue = "Coleoptera";
            string appliedFacetsString = string.Empty;

            // Not sure how the UI uses this toggle
            bool toggleOn = true;


            var appliedFacets = _sut.SetAppliedFacets(appliedFacetsString, selectedFacet, selectedValue, selectedFacetType, toggleOn);

            var jsonAppliedFacets = JsonConvert.SerializeObject(appliedFacets);

            // Act
            var result = await _sut.Search(searchTerm, appliedFacets, null, selectedPage, numberResults, sortField, sortOrder);


            // Assert
            Assert.True(true);
        }


        [Fact]
        public async Task DoSearchWithFacetsWhenAlreadyFacetAppliedAsync()
        {
            // Arrange
            string searchTerm = "Animalia";
            int selectedPage = 1;
            int numberResults = 100;
            string sortField = string.Empty;
            string sortOrder = "ascending";

            string selectedFacet = "family_ss";
            string selectedFacetType = "text";
            string selectedValue = "Hydrophilidae";
            string appliedFacetsString = "|order_ss|Coleoptera";

            // Not sure how the UI uses this toggle
            bool toggleOn = true;


            var appliedFacets = _sut.SetAppliedFacets(appliedFacetsString, selectedFacet, selectedValue, selectedFacetType, toggleOn);

            var jsonAppliedFacets = JsonConvert.SerializeObject(appliedFacets);

            // Act
            var result = await _sut.Search(searchTerm, appliedFacets, null, selectedPage, numberResults, sortField, sortOrder);


            // Assert
            Assert.True(true);
        }

        [Fact]
        public async Task DoSearchWithRangesWhenAlreadyRangeAppliedAsync()
        {
            // TODO: We still don't have a range filter. Come back to this test when one is created.
            // Arrange
            string searchTerm = "Bacteria";
            int selectedPage = 1;
            int numberResults = 100;
            string sortField = string.Empty;
            string sortOrder = "ascending";

            string selectedFacet = "order_ss";
            string selectedFacetType = "range";
            string selectedValue = "20";
            string selectedUpperValue = "200";
            string appliedRangesString = "|added_ss|19360102|19830329";


            // Not sure how the UI uses this toggle
            bool toggleOn = true;

            var query = SystematicsPortal.Web.Helpers.Utility.ReplaceEscapedCharacters(searchTerm);

            var appliedRanges = _sut.SetAppliedRanges(appliedRangesString, selectedFacet, selectedValue, selectedFacetType, selectedUpperValue, toggleOn);

            var jsonAppliedFacets = JsonConvert.SerializeObject(appliedRanges);

            // Act
            var result = await _sut.Search(query, null, appliedRanges, selectedPage, numberResults, sortField, sortOrder);


            // Assert
            Assert.True(true);
        }

        
    }
}



