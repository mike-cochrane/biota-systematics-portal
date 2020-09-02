using SystematicsPortal.Web.Views.Documents.Components.Label;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsPortal.Web.Models;

namespace SystematicsPortal.Web.ViewComponents
{
    public class LabelViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(FieldData data)
        {
            var viewModel = new LabelViewModel();

            if (data != null)
            {
                viewModel.Text = data.Data.Value;
            }

            return View(viewModel);
        }
    }
}
