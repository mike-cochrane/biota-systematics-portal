using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsPortal.Web.Models;
using SystematicsPortal.Web.Views.Documents.Components.Siblings;

namespace SystematicsPortal.Web.ViewComponents
{
    public class SiblingsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(FieldData data)
        {
            var viewModel = new SiblingsViewModel();

            if (data != null)
            {
                foreach (var siblingXml in data.Data.Elements("Sibling"))
                {
                    viewModel.Siblings.Add(new Sibling()
                    {
                        Name = siblingXml.Value,
                        NameXml = siblingXml
                    });
                }
            }

            return View(viewModel);
        }
    }
}
