using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsPortal.Models.Entities.Database;
using SystematicsPortal.Models.Infrastructure.Exceptions;
using SystematicsPortal.Models.Interfaces;

namespace SystematicsPortal.Data
{
    public class WebConfigurationRepository : IWebConfigurationRepository
    {
        private readonly NamesWebContext _context;
        private readonly ILogger _logger;

        public WebConfigurationRepository(NamesWebContext context, ILogger<WebConfigurationRepository> logger)
        {
            _context = context;
            _logger = logger;
        }


        /// TODO: Ask Aaron if we want to save static content also in the 

        /// <summary>
        /// Writes documents to the store and returns a number of documents that were updated.
        /// </summary>
        //public async Task<int> SaveStaticContent(IEnumerable<XElement> staticContentList)
        //{
        //    foreach (var staticContent in staticContentList)
        //    {
        //        await SaveDocument(staticContent);
        //    }

        //    var result = await SaveChangesAsync();

        //    return result;
        //}

        //public async Task SaveDocument(XElement document)
        //{
        //    string documentId = (string)document.Attribute("documentId");

        //    if (String.IsNullOrEmpty(documentId))
        //    {
        //        throw new InvalidInputException("DocumentId has not been found");
        //    }

        //    _logger.LogDebug("{Action} - DocumentId: {documentId} - Document: {document}", "WriteDocuments", documentId, document);

        //    var staticContentDb = _context.ContentConfiguration.FirstOrDefault(content => content.ExternalId !=null && content.ExternalId.ToString() == documentId);

        //    staticContentDb.Content = document.ToString();

        //    SaveChangesAsync();
        //}

        //private async Task<int> SaveChangesAsync()
        //{
        //    int result = 0;
        //    try
        //    {
        //        result = await _context.SaveChangesAsync();
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }

        //    return result;
        //}

        /// <summary>
        /// Get specific document based on document id.
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns>Document access model with docuemnt as XmlDocument property</returns>
        public async Task<Models.Entities.Access.ContentConfiguration> GetDocumentAsync(Guid externalId)
        {
            var contentConfiguration = new Models.Entities.Access.ContentConfiguration();

            var contentConfigurationDb = await _context.ContentConfiguration.FirstOrDefaultAsync(content => content.ExternalId == externalId);

            if (contentConfigurationDb is null)
            {
                throw new NotFoundException($"Document with Id: {externalId} has not been found", null);
            }

            var content = _context.Document.FirstOrDefault(doc => doc.DocumentId == contentConfigurationDb.ExternalId);

            // TODO: Grab content from document store and put it in a class
            //contentConfiguration

            return contentConfiguration;
        }
    }
}
