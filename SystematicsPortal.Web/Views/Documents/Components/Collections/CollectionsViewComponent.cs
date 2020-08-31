using SystematicsPortal.Web.Views.Documents.Components.Collections;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SystematicsPortal.Web.ViewComponents
{
    public class CollectionsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(XElement data)
        {
            var viewModel = new CollectionsViewModel();

            if (data != null)
            {
                foreach (var conceptXml in data.Elements("CollectionObject"))
                {
                    string landDistrict = "";
                    string country = "";
                    var collectionEventRegions = conceptXml.Element("CollectionEventRegions");
                    if (collectionEventRegions != null) {
                        foreach(var regionXml in collectionEventRegions.Elements("CollectionEventRegion")) {
                            if (regionXml.Attribute("georegionSchema")?.Value == "Land District")
                            {
                                landDistrict = regionXml.Attribute("georegion")?.Value;
                            } 
                            else if (regionXml.Attribute("georegionSchema")?.Value == "Country")
                            {
                                country = regionXml.Attribute("georegion")?.Value;
                            }
                        }
                    }
                    viewModel.Collections.Add(new Collection()
                    {
                        // viewModel.Href = new Uri(_settings.ReferenceHyperlinkBase, data.Attribute("referenceId")?.Value);
                        Name = conceptXml.Element("NameFormatted"),
                        Country = country,
                        LandDistrict = landDistrict,
                        SpecimenCount = -1
                    });
                }
            }

            return View(viewModel);
        }
    }
}
