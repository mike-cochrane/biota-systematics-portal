using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsPortal.Web.Services;
using SystematicsPortal.Web.Services.Interfaces;
using SystematicsPortal.Web.ViewModels.Documents;

namespace SystematicsPortal.Web.Controllers
{
    [Route("documents")]
    public class DocumentsController : Controller
    {
        private readonly IDocumentsService _documentsService;
        private readonly IViewDefinitionsService _viewDefinitionsService;

        public DocumentsController(IDocumentsService documentsService, IViewDefinitionsService viewDefinitionsService)
        {
            _documentsService = documentsService;
            _viewDefinitionsService = viewDefinitionsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var document = await _documentsService.GetDocument(id);
            var viewDefinition = _viewDefinitionsService.Get();
            var viewModel = new DetailsViewModel();

            viewModel.Fields = ViewGenerationService.Generate(new XDocument(document.XmlDocument), viewDefinition);

            return View(viewModel);
        }
    }
}
