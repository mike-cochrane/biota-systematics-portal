﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsData.Data.Interfaces;
using SystematicsData.Data.Uploader.Models;

namespace SystematicsData.Data.Uploader.Classes
{
    public class Parser
    {
        private readonly ILogger<Parser> _logger;
        private readonly string _sourcePath;
        private readonly IDocumentsRepository _repository;

        public Parser(IDocumentsRepository repository, string sourcePath, ILogger<Parser> logger)
        {
            _repository = repository;
            _sourcePath = sourcePath;
            _logger = logger;
        }
        public async Task<List<Result>> StoreFilesInDocumentStoreAsync()
        {
            _logger.LogDebug("SystematicsData.Data.Uploader: Starting upload process for files");

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
                    var documents = XDocument.Load(file);
                    var documentsElements = documents.Element("Documents");
                    var documentsList = documentsElements.Descendants("Document");

                    int numberResults = await _repository.WriteDocuments(documentsList);

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
