using SystematicsPortal.Web.Views.Documents.Components.Concepts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Collections.Generic;
using SystematicsPortal.Web.Models;

namespace SystematicsPortal.Web.ViewComponents
{
    public class ConceptsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(FieldData data)
        {
            var viewModel = new ConceptsViewModel();

            if (data != null)
            {
                viewModel.Labels = new Dictionary<string, string>() {
                    {"Name", "Name"}, 
                    {"AccordingTo", "Reference"}
                };

                // TODO: Obtain labels from a language service
                // viewModel.Labels = _service.getLabels("Concepts");

                foreach (var conceptXml in data.Data.Elements("Concept"))
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
