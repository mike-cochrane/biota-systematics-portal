using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystematicsPortal.Harvester.Service.Helpers;
using SystematicsPortal.Models.Interfaces;

namespace SystematicsPortal.Harvester.Service.Classes
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
            _logger.LogDebug("SystematicsPortal.Data.Uploader: Starting upload process for files");

            var results = new List<Result>();

            return results;
        }
    }
}