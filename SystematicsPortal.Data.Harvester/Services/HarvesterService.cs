using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using SystematicsPortal.Data.Harvester.Clients;
using SystematicsPortal.Models.Interfaces;

namespace SystematicsPortal.Data.Harvester.Services
{
    public class HarvesterService
    {
        private readonly IBusControl _busControl;
        private readonly ILogger<HarvesterService> _logger;

        public HarvesterService(IBusControl busControl, ILogger<HarvesterService> logger)
        {
            _busControl = busControl;
            _logger = logger;
        }

        public async Task StartAsync()
        {
            _logger.LogDebug("Starting Systematics Portal Harvester Service: Listening for messages");
            await _busControl.StartAsync();
        }

        public void Stop()
        {
            _busControl?.Stop();
        }
    }
}