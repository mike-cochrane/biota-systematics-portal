using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsPortal.Data.Harvester.Classes;
using SystematicsPortal.Data.Harvester.Clients;
using SystematicsPortal.Models.Configuration;
using SystematicsPortal.Models.Interfaces;
using SystematicsPortal.Utility.Helpers;

namespace SystematicsPortal.Data.Harvester.Services
{
    public class HarvesterService
    {
        public readonly AnnotationsClient _client;
        private readonly ILogger<HarvesterService> _logger;
        private readonly IDocumentsRepository _repository;

        public HarvesterService(IDocumentsRepository repository, AnnotationsClient client, ILogger<HarvesterService> logger)
        {
            _repository = repository;
            _client = client;
            _logger = logger;
        }

        public async Task StartAsync()
        {
            // TODO: Listen for a message

            var resourceId = "C7EA0FE3-40A4-453A-BBB8-9F1AAF6673D7";
            var itemTypeId = "299B3954-6119-4265-AD5E-799CB7F53DE6";
            var itemId = "8F766C02-BD56-4B9A-BB35-27ED8F2E1826";

            List<XElement> documentsToSave = new List<XElement>();

            switch (resourceId)
            {
                case "C7EA0FE3-40A4-453A-BBB8-9F1AAF6673D7":
                    var fieldReceiver = new FieldConfigurationReceiver(_client, null);

                    documentsToSave = await fieldReceiver.GetDocumentsAsync(resourceId, itemTypeId, itemId);
                    break;
                default:
                    //documentsToSave = await Get
                    break;
            }



            var fields2 = documentsToSave.Take(1);


            // Am
            await _repository.WriteDocuments(fields2);

        }

        public void Stop()
        {
            // write code here that runs when the Windows Service stops.
        }

    }
}