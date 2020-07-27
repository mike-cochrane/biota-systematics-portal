using MassTransit;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public HarvesterService(IDocumentsRepository repository, AnnotationsClient client, IBusControl busControl, ILogger<HarvesterService> logger)
        {
            _repository = repository;
            _client = client;
            _busControl = busControl;

            _logger = logger;
        }

        public async Task StartAsync()
        {
            await _busControl.StartAsync();

         
        }

        public void Stop()
        {
            _busControl?.Stop();
        }
    }
}
