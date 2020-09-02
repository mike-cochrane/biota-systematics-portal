using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystematicsData.Data.Extensions;
using SystematicsData.Data.Interfaces;
using SystematicsData.Models.Configuration;
using SystematicsData.Models.Entities.Access;
using SystematicsData.Models.Entities.Annotations;
using SystematicsData.Models.Infrastructure.Exceptions;
using SystematicsData.Utility.Helpers;

namespace SystematicsData.Data
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

        /// <summary>
        /// Get content configuration for the web site.
        /// </summary>
        /// <returns>Content configurations with specific content</returns>
        public async Task<ContentConfigurations> GetContentConfigurationsAsync(string page)
        {
            var contentConfigurationsList = new List<ContentConfiguration>();

            ContentConfigurations contentConfigurations = new ContentConfigurations();

            var contentConfigurationsListDb = await _context.ContentConfigurations.Where(ccfg => ccfg.Page.ToLower() == page.ToLower()).ToListAsync();

            foreach (var contentConfigurationDb in contentConfigurationsListDb)
            {
                var contentConfiguration = contentConfigurationDb.ToDto();

                if (contentConfigurationDb.ExternalId != null)
                {
                    contentConfiguration.Content = await GetContentFromDocumentStoreAsync(contentConfigurationDb.ExternalId.Value);
                }

                contentConfigurationsList.Add(contentConfiguration);
            }

            contentConfigurations.ContentConfigurationList = contentConfigurationsList;

            return contentConfigurations;
        }

        /// <summary>
        /// Get field configuration to be able to proper display the document in the web site.
        /// </summary>
        /// <returns>Field grpups with field configurations with each specific field</returns>
        public async Task<FieldGroupsDto> GetFieldGroupConfigurations(string documentClass)
        {
            var fieldGroups = new FieldGroupsDto();

            var fieldGroupListtDb = await _context.FieldGroups.Include(fg=>fg.FieldConfiguration).Where(fg => fg.DocumentClass.ToLower() == documentClass.ToLower()).ToListAsync();

            foreach (var fieldGroupDb in fieldGroupListtDb)
            {
                var fieldGroup = fieldGroupDb.ToDto();

                GetFieldsFromDocumentStore(ref fieldGroup);

                fieldGroups.FieldGroups.Add(fieldGroup);
            }

            return fieldGroups;
        }

        private void GetFieldsFromDocumentStore(ref FieldGroupDto fieldGroup)
        {

            foreach (var fieldConfiguration in fieldGroup.FieldConfigurations)
            {
                var documentDb = GetDocumentDb(Guid.Parse(fieldConfiguration.ExternalId));

                fieldConfiguration.Field = SerializationHelper.Deserialize<Field>(documentDb.ToString());
            }
        }

        private async Task<Content> GetContentFromDocumentStoreAsync(Guid externalId)
        {
            var documentDb = await GetDocumentDb(externalId);

            var content = await FillInContentAsync(documentDb.SerializedDocument);

            return content;
        }

        private async Task<Models.Document> GetDocumentDb(Guid externalId)
        {
            var documentDb = await _context.Documents.FindAsync(externalId);

            if (documentDb is null)
            {
                throw new NotFoundException($"Document with Id: {externalId} has not been found", null);
            }

            return documentDb;
        }

        private async Task<Content> FillInContentAsync(string serializedDocument)
        {
            var item = SerializationHelper.Deserialize<Item>(serializedDocument);

            var content = new Content();

            var citationTitle = PropertyHelpers.GetPropertyDisplayName<Content>(nameof(Content.CitationTitle));
            content.CitationTitle = item.Notes.FirstOrDefault(n => n.NoteTypeTitle == citationTitle).Content.ToString();

            var lede = PropertyHelpers.GetPropertyDisplayName<Content>(nameof(Content.Lede));
            content.Lede = item.Notes.FirstOrDefault(n => n.NoteTypeTitle == lede).Content.ToString();

            var sectionTitle = PropertyHelpers.GetPropertyDisplayName<Content>(nameof(Content.SectionTitle));
            content.SectionTitle = item.Notes.FirstOrDefault(n => n.NoteTypeTitle == sectionTitle).Content.ToString();

            var text = PropertyHelpers.GetPropertyDisplayName<Content>(nameof(Content.Text));
            content.Text = item.Notes.FirstOrDefault(n => n.NoteTypeTitle == text).Content.ToString();

            content.RelatedConcepts = (await GetRelatedConceptsAsync(item)).ToList();

            return content;
        }

        private async Task<IEnumerable<Concept>> GetRelatedConceptsAsync(Item item)
        {
            var concepts = new List<Concept>();
            var relatedItemsIds = item.relatedItems.Select(x => x.RelatedItemId).ToList();

            foreach (var relatedItemId in relatedItemsIds)
            {
                var concept = await GetConceptAsync(relatedItemId);

                concepts.Add(concept);
            }

            return concepts;
        }

        private async Task<Concept> GetConceptAsync(string conceptId)
        {
            var concept = new Concept();

            if (Guid.TryParse(conceptId, out var conceptIdGuid))
            {
                var conceptDb = await GetDocumentDb(conceptIdGuid);

                var item = SerializationHelper.Deserialize<Item>(conceptDb.SerializedDocument);

                var title = PropertyHelpers.GetPropertyDisplayName<Concept>(nameof(Concept.Title));
                concept.Title = item.Notes.FirstOrDefault(n => n.NoteTypeTitle == title).Content.ToString();

                var definition = PropertyHelpers.GetPropertyDisplayName<Concept>(nameof(Concept.Definition));
                concept.Definition = item.Notes.FirstOrDefault(n => n.NoteTypeTitle == definition).Content.ToString();
            }
            else
            {
                throw new Exception($"GetConcept - {conceptId} is not a valid documentId");
            }

            return concept;
        }
    }
}