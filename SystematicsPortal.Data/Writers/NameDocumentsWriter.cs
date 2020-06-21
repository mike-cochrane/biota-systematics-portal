
using Microsoft.Extensions.Logging;
using Org.XmlUnit.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using SystematicsPortal.Data.dbmodels;
using SystematicsPortal.Model.Interfaces;
using SystematicsPortal.Model.Models.Documents;
using SystematicsPortal.Utility.Helpers;

namespace NZOR.Publish.Publisher.Writers.Documents
{
    class NameDocumentsWriter
    {
        private readonly INamesWebRepository _namesRepository;

        private readonly ILogger _logger;

        public NameDocumentsWriter(INamesWebRepository namesRepository, ILogger logger)
        {
            _namesRepository = namesRepository;
            _logger = logger;
        }

    }
}
