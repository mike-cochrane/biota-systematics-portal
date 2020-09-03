using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystematicsPortal.Web.Models;
using SystematicsPortal.Web.Views.Documents.Components.DetailsStandard;

namespace SystematicsPortal.Web.ViewComponents
{
    public class DetailsStandardViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(List<Field> data)
        {
            var viewModel = new DetailsStandardViewModel();

            if (data != null)
            {
                viewModel.Fields = data;
            }

            return View(viewModel);
        }
    }
}
