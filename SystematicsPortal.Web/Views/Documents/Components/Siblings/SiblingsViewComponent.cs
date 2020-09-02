using SystematicsPortal.Web.Views.Documents.Components.Siblings;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SystematicsPortal.Web.ViewComponents
{
    public class SiblingsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(XElement data)
        {
            var viewModel = new SiblingsViewModel();

            if (data != null)
            {
                foreach (var siblingXml in data.Elements("Sibling"))
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
