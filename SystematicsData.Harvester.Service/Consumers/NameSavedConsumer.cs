using MassTransit;
using Microsoft.Extensions.Logging;
using Names.Messaging.Contracts.Names;
using System;
using System.Threading.Tasks;
using SystematicsData.Harvester.Service.Clients;
using SystematicsData.Harvester.Service.Strategies.Interfaces;

namespace SystematicsData.Harvester.Service.Consumers
{
    /// <summary>
    /// Processes the Name Saved events from the message broker.
    /// </summary>
    internal class NameSavedConsumer : IConsumer<INameSaved>
    {
        private readonly IHarvesterStrategies _harvesterStrategies;
        private readonly AnnotationsClient _client;

        private readonly ILogger<NameSavedConsumer> _logger;

        public NameSavedConsumer(IHarvesterStrategies harvesterStrategies, AnnotationsClient client, ILogger<NameSavedConsumer> logger)
        {
            _harvesterStrategies = harvesterStrategies;
            _client = client;

            _logger = logger;
        }

        public async Task Consume(ConsumeContext<INameSaved> context)
        {
            try
            {
                await Task.Run(() =>
                {
                    _logger.LogDebug("{Action} - NameId: {NameId}", "INameSaved Received", context.Message.NameId);
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
    }
}
