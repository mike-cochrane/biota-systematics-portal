using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystematicsPortal.Model.Interfaces;
using SystematicsPortal.Model.Models.DTOs;

namespace SystematicsPortal.Web.Api.Services
{
    public class NamesService : INamesService
    {
        private readonly INamesWebRepository _namesRepository;
        private readonly INamesWebRepository _vernacularRepository;
        private readonly INamesWebRepository _referenceRepository;

        private readonly ILogger<NamesService> _logger;

        public NamesService(INamesWebRepository namesRepository, ILogger<NamesService> logger)
        {
            _namesRepository = namesRepository;
            _logger = logger;
        }

        public async Task<DocumentDto> GetDocument(string id)
        {
            DocumentDto name;
            if (Guid.TryParse(id, out var idGuid))
            { 
                name = await _namesRepository.GetDocument(idGuid);
            }
            else
            {
                throw new Exception("Not valid Id");
            }

            return name;


        }
    }
}
