using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SystematicsPortal.Web.Services;
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
            SearchViewModel search = new SearchViewModel(null, null, null);
            search.Query = query;
            return View(search);
        }
    }
}
