using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using SystematicsPortal.Model.Interfaces;

namespace SystematicsPortal.Web.Api.Services
{
    public class DocumentsService : IDocumentsService
    {
        private readonly IDocumentsRepository _namesRepository;
        private readonly IDocumentsRepository _vernacularRepository;
        private readonly IDocumentsRepository _referenceRepository;

        private readonly ILogger<DocumentsService> _logger;

        public DocumentsService(IDocumentsRepository namesRepository, ILogger<DocumentsService> logger)
        {
            _namesRepository = namesRepository;
            _logger = logger;
        }

        public async Task<Model.Models.Access.Document> GetDocument(string id)
        {
            Model.Models.Access.Document document;

            if (Guid.TryParse(id, out var idGuid))
            {
                document = await _namesRepository.GetDocument(idGuid);
            }
            else
            {
                throw new Exception("Not valid Id");
            }

            return document;


        }
    }
}
