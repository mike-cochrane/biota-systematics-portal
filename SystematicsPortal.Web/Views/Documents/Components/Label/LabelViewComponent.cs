using SystematicsPortal.Web.Views.Documents.Components.Label;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SystematicsPortal.Web.ViewComponents
{
    public class LabelViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(XElement data)
        {
            var viewModel = new LabelViewModel();

            if (data != null)
            {
                viewModel.Text = data.Value;
                viewModel.Label = "LABEL";
            }

            return View(viewModel);
        }
    }
}
