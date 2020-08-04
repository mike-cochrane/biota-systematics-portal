using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsPortal.Data.Harvester.Clients;
using SystematicsPortal.Models.Interfaces;

namespace SystematicsPortal.Data.Harvester.Strategies
{
    public class StaticContentStrategy : IHarvesterActionStrategy
    {
        private readonly IDocumentsRepository _repository;
        private readonly AnnotationsClient _client;
        private readonly ILogger<StaticContentStrategy> _logger;

        public StaticContentStrategy(IDocumentsRepository repository, AnnotationsClient client/*, ILogger<StaticContentStrategy> logger*/)
        {
            _repository = repository;
            _client = client;
            //_logger = logger;
        }

        public async Task<int> ApplyStrategyAsync(string resourceId, string itemTypeId, string itemId)
        {
            var documents = await GetDocumentsAsync(resourceId, itemTypeId, itemId);

            var results = await _repository.WriteDocuments(documents);

            return results;
        }

        private async Task<IEnumerable<XElement>> GetDocumentsAsync(string resourceId, string itemTypeId, string itemId)
        {
            var itemIds = new List<string>() { itemId };

            var items = await _client.GetItemsXmlByIds(itemIds);

            return items;
        }
    }
}