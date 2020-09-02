using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SystematicsPortal.Web.Models;

namespace SystematicsPortal.Web.ViewComponents
{
    public class SearchFieldViewComponent : ViewComponent
    {
        public SearchFieldViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync(string query)
        {
            SearchViewModel search = new SearchViewModel(null);
            search.Query = query;

            return View(search);
        }
    }
}
