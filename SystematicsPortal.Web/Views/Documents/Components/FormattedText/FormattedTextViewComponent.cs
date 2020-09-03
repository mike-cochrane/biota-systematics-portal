using SystematicsPortal.Web.Views.Documents.Components.FormattedText;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsPortal.Web.Models;

namespace SystematicsPortal.Web.ViewComponents
{
    public class FormattedTextViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(FieldData data)
        {
            var viewModel = new FormattedTextViewModel();

            if (data != null)
            {
                viewModel.Text = data.Data.Value;
            }

            return View(viewModel);
        }
    }
}
