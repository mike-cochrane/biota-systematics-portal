using System;
using System.Collections.Generic;

namespace SystematicsPortal.Web.Api.Services
{
    public interface ISearchService : IDisposable
    {
        List<KeyValuePair<string, string>> ParseFilterQueries(string filter);
        Search.Search GetSearch();
    }
}
