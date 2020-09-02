using SystematicsPortal.Web.Views.Documents.Components.Biostatus;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SystematicsPortal.Web.ViewComponents
{
    public class BiostatusViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(XElement data)
        {
            var viewModel = new BiostatusViewModel();

            if (data != null)
            {
                foreach (var biostatusXml in data.Elements("BiostatusValue"))
                {
                    viewModel.Biostatuses.Add(new Biostatus()
                    {
                        Origin = biostatusXml.Element("Origin")?.Value,
                        Occurence = biostatusXml.Element("Occurrence")?.Value,
                        Georegion = biostatusXml.Element("Georegion")?.Value
                    });
                }
            }

            return View(viewModel);
        }
    }
}
