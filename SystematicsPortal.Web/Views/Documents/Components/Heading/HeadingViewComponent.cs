using SystematicsPortal.Web.Views.Documents.Components.Heading;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Collections.Generic;

namespace SystematicsPortal.Web.ViewComponents
{
    public class HeadingViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(XElement data)
        {
            var viewModel = new HeadingViewModel();

            if (data != null)
            {
                viewModel.Text = data.Value;
            }

            return View(viewModel);
        }
    }
}
