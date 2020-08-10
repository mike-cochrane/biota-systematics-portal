using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystematicsData.Harvester.Service.Helpers;
using SystematicsData.Models.Interfaces;

namespace SystematicsData.Harvester.Service.Classes
{
    public class Parser
    {
        private readonly ILogger<Parser> _logger;
        private readonly string _sourcePath;
        private readonly IDocumentsRepository _repository;

        public Parser(IDocumentsRepository repository, string sourcePath, ILogger<Parser> logger)
        {
            _repository = repository; //new DocumentsRepository(new NamesWebContext(connectionString),_logger);
            _sourcePath = sourcePath;
            _logger = logger;
        }

        public async Task<List<Result>> StoreFilesInDocumentStoreAsync()
        {
            _logger.LogDebug("SystematicsData.Data.Uploader: Starting upload process for files");

            var results = new List<Result>();

            return results;
        }
    }
}