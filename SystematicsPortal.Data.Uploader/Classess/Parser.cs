using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsPortal.Data.Uploader.Models;
using SystematicsPortal.Models.Interfaces;

namespace SystematicsPortal.Data.Uploader.Classess
{
    public class Parser
    {
        private readonly Serilog.ILogger _logger;
        private readonly string _sourcePath;
        private readonly IDocumentsRepository _repository;

        public Parser(string connectionString, string sourcePath, Serilog.ILogger logger)
        {
            _repository = new DocumentsRepository(new NamesWebContext(connectionString));
            _sourcePath = sourcePath;
            _logger = logger;
        }
        public async Task<List<Result>> StoreFilesInDocumentStoreAsync()
        {
            _logger.Debug("SystematicsPortal.Data.Uploader: Starting upload process for files");

            var results = new List<Result>();
            Result result;
            var files = Directory.GetFiles(_sourcePath, "*DOCUMENT*.xml");

            foreach (var file in files)
            {
                result = new Result()
                {
                    FileName = file,
                };

                try
                {
                    var document = XDocument.Load(file);
                    int numberResults = await _repository.WriteDocuments(document);

                    result.UploadResult = true;
                    result.Message = $"Upload Succesful - {numberResults} persisted";
                }
                catch (Exception e)
                {
                    result.UploadResult = false;
                    result.Message = $"Upload failed - message: {e.Message}";
                }

                results.Add(result);
            }

            return results;
        }
    }
}
