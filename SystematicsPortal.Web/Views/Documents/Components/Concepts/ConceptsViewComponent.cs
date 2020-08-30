using SystematicsPortal.Web.Views.Documents.Components.Concepts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SystematicsPortal.Web.ViewComponents
{
    public class ConceptsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(XElement data)
        {
            var viewModel = new ConceptsViewModel();

            if (data != null)
            {
                foreach (var conceptXml in data.Elements("Concept"))
                {
                    viewModel.Concepts.Add(new Concept()
                    {
                        Name = conceptXml.Element("Name").Value,
                        ReferenceXml = conceptXml.Element("AccordingTo")
                    });
                }
            }

            return View(viewModel);
        }
    }
}
