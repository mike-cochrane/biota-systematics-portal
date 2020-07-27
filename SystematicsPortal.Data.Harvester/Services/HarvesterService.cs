using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsPortal.Data.Harvester.Classes;
using SystematicsPortal.Data.Harvester.Clients;
using SystematicsPortal.Models.Interfaces;

namespace SystematicsPortal.Data.Harvester.Services
{
    public class HarvesterService
    {
        public readonly AnnotationsClient _client;
        private readonly IDocumentsRepository _repository;
        private readonly IBusControl _busControl;
        private readonly ILogger<HarvesterService> _logger;
        private readonly IDictionary<string, IHarvesterActionReceiver> _strategies;

        public HarvesterService(IDocumentsRepository repository, AnnotationsClient client, IDictionary<string, IHarvesterActionReceiver> strategies, ILogger<HarvesterService> logger)
        {
            _repository = repository;
            _client = client;
            _busControl = busControl;

            _logger = logger;
            _strategies = strategies;
        }

        public async Task StartAsync()
        {
            await _busControl.StartAsync();

            // TODO: Listen for a message

            var resourceId = "C7EA0FE3-40A4-453A-BBB8-9F1AAF6673D7";
            var itemTypeId = "299B3954-6119-4265-AD5E-799CB7F53DE6";
            // var itemId = "8F766C02-BD56-4B9A-BB35-27ED8F2E1826";
            var itemId = "";

            var strategies = new Dictionary<string, IHarvesterActionReceiver>
                         (StringComparer.OrdinalIgnoreCase);

            IEnumerable<XElement> documentsToSave = new List<XElement>();

            switch (resourceId)
            {
                case "C7EA0FE3-40A4-453A-BBB8-9F1AAF6673D7":
                    if (itemId == "8F766C02-BD56-4B9A-BB35-27ED8F2E1826")
                    {
                        var fieldReceiver = new FieldConfigurationReceiver(_client, null);

                        documentsToSave = await fieldReceiver.GetDocumentsAsync(resourceId, itemTypeId, itemId);
                    }
                    if (itemTypeId == "299B3954-6119-4265-AD5E-799CB7F53DE6")
                    {
                        var contentReceiver = new StaticContentReceiver(_client, null);

                        documentsToSave = await contentReceiver.GetDocumentsAsync(resourceId, itemTypeId, itemId);
                    }
                    break;

                default:
                    break;
            }

            await _repository.WriteDocuments(documentsToSave);
        }

        public void Stop()
        {
            _busControl?.Stop();
        }
    }
}
