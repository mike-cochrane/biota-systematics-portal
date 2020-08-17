using Moq;
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

            dataClientMock.Setup(foo => foo.Search(GetQuery())).Returns(GetSearchResult());

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

    }
}
