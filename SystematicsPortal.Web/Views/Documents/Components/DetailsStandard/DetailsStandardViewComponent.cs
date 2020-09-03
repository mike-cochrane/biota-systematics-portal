using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SystematicsPortal.Web.Models;
using SystematicsPortal.Web.Views.Documents.Components.DetailsStandard;

namespace SystematicsPortal.Web.ViewComponents
{
    public class DetailsStandardViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(FieldData data)
        {
            var viewModel = new DetailsStandardViewModel();

            if (data != null)
            {
                
            }

            return View(viewModel);
        }
    }
}
