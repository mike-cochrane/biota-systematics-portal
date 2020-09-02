using SystematicsPortal.Web.Views.Documents.Components.ReferenceHyperlink;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsPortal.Web.Models;

namespace SystematicsPortal.Web.ViewComponents
{
    public class ReferenceHyperlinkViewComponent : ViewComponent
    {
        private readonly ReferenceHyperlinkViewComponentSettings _settings;

        public ReferenceHyperlinkViewComponent(ReferenceHyperlinkViewComponentSettings settings)
        {
            _settings = settings;
        }

        public async Task<IViewComponentResult> InvokeAsync(FieldData data)
        {
            var viewModel = new NameHyperlinkViewModel();

            if (data != null)
            {
                viewModel.Text = data.Data.Value;
                viewModel.Href = new Uri(_settings.ReferenceHyperlinkBase, data.Data.Attribute("referenceId")?.Value);
                viewModel.Title = "";
            }

            return View(viewModel);
        }
    }
}
