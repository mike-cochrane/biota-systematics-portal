using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using SystematicsPortal.Data.Uploader.Models;
using SystematicsPortal.Model.Interfaces;
using SystematicsPortal.Model.Models.Documents;

namespace SystematicsPortal.Data.Uploader.Classess
{
    public class Parser
    {
        private readonly Serilog.ILogger _logger;
        private readonly string _sourcePath;
        private readonly IDocumentsRepository _repository;

        public Parser(Serilog.ILogger logger, string connectionString, string sourcePath)
        {
            _logger = logger;
            _sourcePath = sourcePath;
            _repository = new DocumentsRepository(new NamesWebContext(connectionString));
        }
        public async Task<List<Result>> StoreFilesInDocumentStore()
        {
            _logger.Debug("SystematicsPortal.Data.Uploader: Starting upload process for files");
            var results = new List<Result>();
            Result result;
            var documents = new List<XDocument>();
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
