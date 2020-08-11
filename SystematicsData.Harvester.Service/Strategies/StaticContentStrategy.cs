using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsData.Harvester.Service.Clients;
using SystematicsData.Harvester.Service.Strategies.Interfaces;
using SystematicsData.Models.Interfaces;

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

            var results = await _repository.WriteDocuments(documents);

            return results;
        }
    }
}
