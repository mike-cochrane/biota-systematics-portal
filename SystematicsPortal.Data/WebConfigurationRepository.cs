using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystematicsPortal.Data.Extensions;
using SystematicsPortal.Models.Entities.Access;
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
        /// Get content configuration for the web site.
        /// </summary>
        /// <returns>Content configurations with specific content</returns>
        public async Task<ContentConfigurations> GetContentConfigurationsAsync()
        {
            ContentConfigurations contentConfigurations = new ContentConfigurations();

            var contentConfigurationsDb = _context.ContentConfiguration;

            var contentConfigurationsList = contentConfigurationsDb.Select(cc =>
               cc.ToDto());

            foreach (var contentConfiguration in contentConfigurationsList)
            {
                if (contentConfiguration.ExternalId != null)
                {
                    contentConfiguration.Content = await GetContentFromDocumentStoreAsync(contentConfiguration.ExternalId.Value);
                }
            }

            contentConfigurations.ContentConfigurationList = contentConfigurationsList.ToList();

            return contentConfigurations;
        }

        /// <summary>
        /// Get specific content configuration based on external id.
        /// </summary>
        /// <param name="externalId"></param>
        /// <returns>Content configuration with content</returns>
        public async Task<ContentConfiguration> GetContentConfiguration(Guid externalId)
        {
            ContentConfiguration contentConfiguration;

            var contentConfigurationDb = await _context.ContentConfiguration.FirstOrDefaultAsync(content => content.ExternalId == externalId);

            if (contentConfigurationDb is null)
            {
                throw new NotFoundException($"Document with Id: {externalId} has not been found", null);
            }

            contentConfiguration = contentConfigurationDb.ToDto();

            contentConfiguration.Content = await GetContentFromDocumentStoreAsync(externalId);

            return contentConfiguration;
        }

        private async Task<Content> GetContentFromDocumentStoreAsync(Guid externalId)
        {
            var documentDb = await _context.Document.FirstOrDefaultAsync(doc => doc.DocumentId == externalId);

            if (documentDb is null)
            {
                throw new NotFoundException($"Document with Id: {externalId} has not been found", null);
            }

            var item = SerializationHelper.Deserialize<Models.Entities.Annotations.Item>(documentDb.SerializedDocument);

            var content = new Content();

            var citationTitle = PropertyHelpers.GetPropertyDisplayName<Content>(nameof(Content.CitationTitle));
            content.CitationTitle = item.Notes.FirstOrDefault(n => n.NoteTypeTitle == citationTitle).Content.ToString();

            var lede = PropertyHelpers.GetPropertyDisplayName<Content>(nameof(Content.Lede));
            content.Lede = item.Notes.FirstOrDefault(n => n.NoteTypeTitle == lede).Content.ToString();

            var sectionTitle = PropertyHelpers.GetPropertyDisplayName<Content>(nameof(Content.SectionTitle));
            content.SectionTitle = item.Notes.FirstOrDefault(n => n.NoteTypeTitle == sectionTitle).Content.ToString();

            var text = PropertyHelpers.GetPropertyDisplayName<Content>(nameof(Content.Text));
            content.Text = item.Notes.FirstOrDefault(n => n.NoteTypeTitle == text).Content.ToString();

            return content;
        }
    }
}