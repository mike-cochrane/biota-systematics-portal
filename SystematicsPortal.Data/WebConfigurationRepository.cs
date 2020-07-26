using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsPortal.Data.Extensions;
using SystematicsPortal.Models.Entities.Access;
using SystematicsPortal.Models.Entities.Database;
using SystematicsPortal.Models.Infrastructure.Exceptions;
using SystematicsPortal.Models.Interfaces;
using SystematicsPortal.Utility.Helpers;

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
        /// Get specific content configuration based on external id.
        /// </summary>
        /// <param name="externalId"></param>
        /// <returns>Content configuration with content</returns>
        public async Task<IEnumerable<Models.Entities.Access.ContentConfiguration>> GetContentConfigurations()
        {
            IEnumerable<Models.Entities.Access.ContentConfiguration> contentConfigurations;

            var contentConfigurationsDb = _context.ContentConfiguration;


            contentConfigurations = contentConfigurationsDb.Select(cc =>
               cc.ToDto( GetContentFromDocumentStore(Guid.NewGuid())));

            return contentConfigurations;
        }


        /// <summary>
        /// Get specific content configuration based on external id.
        /// </summary>
        /// <param name="externalId"></param>
        /// <returns>Content configuration with content</returns>
        public async Task<Models.Entities.Access.ContentConfiguration> GetContentConfiguration(Guid externalId)
        {
            Models.Entities.Access.ContentConfiguration contentConfiguration;

            var contentConfigurationDb = await _context.ContentConfiguration.FirstOrDefaultAsync(content => content.ExternalId == externalId);

            if (contentConfigurationDb is null)
            {
                throw new NotFoundException($"Document with Id: {externalId} has not been found", null);
            }

            var content =  GetContentFromDocumentStore(externalId);

            contentConfiguration =  contentConfigurationDb.ToDto(content);
           
           
            return contentConfiguration;
        }

        private Content GetContentFromDocumentStore(Guid externalId)
        {

            var documentDb = _context.Document.FirstOrDefault(doc => doc.DocumentId == externalId);

            if (documentDb is null)
            {
                throw new NotFoundException($"Document with Id: {externalId} has not been found", null);
            }

           var item = SerializationHelper.Deserialize<Models.Entities.Annotations.Item>(documentDb.SerializedDocument);

            var content = new Content()
            {
                // TODO: Ask if I need to do a conversion from xml to html
                CitationTitle = item.Notes.FirstOrDefault(n => n.NoteTypeTitle == nameof(Content.CitationTitle)).Content.ToString(),
                Lede = item.Notes.FirstOrDefault(n => n.NoteTypeTitle == nameof(Content.Lede)).Content.ToString(),
                SectionTitle = item.Notes.FirstOrDefault(n => n.NoteTypeTitle == nameof(Content.SectionTitle)).Content.ToString(),
                Text =  item.Notes.FirstOrDefault(n => n.NoteTypeTitle == nameof(Content.Text)).Content.ToString(),
            };

            return content;
        }
    }
}
