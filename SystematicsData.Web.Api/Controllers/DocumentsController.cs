using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using SystematicsData.Web.Api.Services.Interfaces;

namespace SystematicsData.Web.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentsService _documentsService;

        public DocumentsController(IDocumentsService namesService)
        {
            _documentsService = namesService;
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpGet("{id}", Name = "GetName")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _documentsService.GetDocument(id);

            return Ok(response.XmlDocument);
        }
    }
}
