using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using SystematicsData.Data.Interfaces;
using SystematicsData.Models.Entities.Access;
using SystematicsData.Web.Api.Services.Interfaces;

namespace SystematicsData.Web.Api.Services
{
    /// <summary>
    /// Manages access to documents from the database.
    /// </summary>
    public class DocumentsService : IDocumentsService
    {
        private readonly IDocumentsRepository _documentsRepository;

        private readonly ILogger<DocumentsService> _logger;

        public DocumentsService(IDocumentsRepository documentsRepository, ILogger<DocumentsService> logger)
        {
            _documentsRepository = documentsRepository;

            _logger = logger;
        }

        /// <summary>
        /// Returns the document for the specified id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DocumentDto> GetDocument(Guid id)
        {
            var document = await _documentsRepository.GetDocumentAsync(id);

            return document;
        }
    }
}
