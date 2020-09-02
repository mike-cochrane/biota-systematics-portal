using SystematicsPortal.Web.Views.Documents.Components.NameHyperlink;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsPortal.Web.Models;

namespace SystematicsPortal.Web.ViewComponents
{
    public class NameHyperlinkViewComponent : ViewComponent
    {
        private readonly NameHyperlinkViewComponentSettings _settings;

        public NameHyperlinkViewComponent(NameHyperlinkViewComponentSettings settings)
        {
            _settings = settings;
        }

        public async Task<IViewComponentResult> InvokeAsync(FieldData data)
        {
            var viewModel = new NameHyperlinkViewModel();

            if (data != null)
            {
                viewModel.Text = data.Data.Value;
                viewModel.Href = new Uri(_settings.NameHyperlinkBase, data.Data.Attribute("nameId")?.Value);
                viewModel.Title = "";
            }

            return View(viewModel);
        }
    }
}
