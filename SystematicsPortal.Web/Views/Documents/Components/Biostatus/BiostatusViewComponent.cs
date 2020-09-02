using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SystematicsPortal.Web.Models;
using SystematicsPortal.Web.Views.Documents.Components.Biostatus;

namespace SystematicsPortal.Web.ViewComponents
{
    public class BiostatusViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(FieldData data)
        {
            var viewModel = new BiostatusViewModel();

            if (data != null)
            {
                foreach (var biostatusXml in data.Data.Elements("BiostatusValue"))
                {
                    viewModel.Biostatuses.Add(new Biostatus()
                    {
                        Occurence = biostatusXml.Element("Occurrence").Value,
                        Georegion = biostatusXml.Element("Georegion").Value
                    });

                    viewModel.Labels = data.DataLabels;
                }
            }

            return View(viewModel);
        }
    }
}
