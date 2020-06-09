using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systematics.Portal.Web.Api.Access.Services
{
    public interface ISearchService : IDisposable
    {
        List<KeyValuePair<string, string>> ParseFilterQueries(string filter);
        Search.Search GetSearch();
    }
}
