using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsData.Harvester.Service.Clients;
using SystematicsData.Harvester.Service.Strategies.Interfaces;
using SystematicsData.Models.Entities.Annotations;
using SystematicsData.Models.Interfaces;
using SystematicsData.Utility.Helpers;

namespace SystematicsData.Harvester.Service.Strategies
{
    public class StaticContentStrategy : IHarvesterActionStrategy
    {
        private readonly IDocumentsRepository _repository;
        private readonly AnnotationsClient _client;
        private readonly ILogger _logger;

        public StaticContentStrategy(IDocumentsRepository repository, AnnotationsClient client, ILogger logger)
        {
            _repository = repository;
            _client = client;
            _logger = logger;
        }

        public async Task<int> ApplyStrategyAsync(XElement document)
        {
            _logger.LogInformation("{Action} - document: {document}" , "Applying stategy StaticContentRepository", document);

            var documents = new List<XElement>() { document };

            documents.AddRange(await GetRelatedDocumentsAsync(document));

            var results = await _repository.WriteDocuments(documents);

            return results;
        }

        private async Task<IEnumerable<XElement>> GetRelatedDocumentsAsync(XElement document)
        {
            IEnumerable<XElement> relatedItems = new List<XElement>();
            var item = SerializationHelper.Deserialize<Item>(document.ToString());

            var relatedItemsIds = item.relatedItems.Select(x => x.RelatedItemId).ToList();

            if (relatedItemsIds.Count > 0)
            { 
                relatedItems = await _client.GetItemsXmlByIds(relatedItemsIds); 
            }

            return relatedItems;
        }
    }
}
