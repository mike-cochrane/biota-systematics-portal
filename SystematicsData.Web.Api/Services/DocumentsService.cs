using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using SystematicsData.Models.Entities.Access;
using SystematicsData.Models.Interfaces;

namespace SystematicsData.Web.Api.Services
{
    public class DocumentsService : IDocumentsService
    {
        private readonly IDocumentsRepository _documentsRepository;

        private readonly ILogger<DocumentsService> _logger;

        public DocumentsService(IDocumentsRepository documentsRepository, ILogger<DocumentsService> logger)
        {
            _documentsRepository = documentsRepository;
            _logger = logger;
        }

        public async Task<Document> GetDocument(string id)
        {
            Document document;

            if (Guid.TryParse(id, out var idGuid))
            {
                document = await _documentsRepository.GetDocumentAsync(idGuid);
            }
            else
            {
                throw new Exception("Not valid Id");
            }

            return document;
        }
    }
}
