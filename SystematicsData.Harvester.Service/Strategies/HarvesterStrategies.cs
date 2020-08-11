using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using SystematicsData.Harvester.Service.Clients;
using SystematicsData.Harvester.Service.Helpers;
using SystematicsData.Harvester.Service.Strategies.Interfaces;
using SystematicsData.Models.Interfaces;

namespace SystematicsData.Harvester.Service.Strategies
{
    public class HarvesterStrategies : IHarvesterStrategies
    {
        private readonly IDictionary<string, IHarvesterActionStrategy> _strategies;

        public HarvesterStrategies(IOptions<AppSettings> appSettingsAccessor, AnnotationsClient client, IDocumentsRepository repository, ILogger<HarvesterStrategies> logger)
        {
            var strategiesFromConfig = appSettingsAccessor.Value.Strategies;
            _strategies = CreateStrategies(strategiesFromConfig, client, repository, logger);
        }

        public IDictionary<string, IHarvesterActionStrategy> GetStrategies()
        {
            return _strategies;
        }

        private IDictionary<string, IHarvesterActionStrategy> CreateStrategies(Dictionary<string, string> strategiesFromConfig, AnnotationsClient client, IDocumentsRepository repository, ILogger<HarvesterStrategies> logger)
        {
            var strategies = new Dictionary<string, IHarvesterActionStrategy>(StringComparer.OrdinalIgnoreCase);
            var myNamespace = GetCurrentNameSpace();

            foreach (var pair in strategiesFromConfig)
            {
                var type = Type.GetType($"{myNamespace}.{pair.Value}");

                strategies[pair.Key] = (IHarvesterActionStrategy)Activator.CreateInstance(type, repository, client, logger);
            }

            return strategies;
        }

        private string GetCurrentNameSpace()
        {
            return GetType().Namespace;
        }
    }
}
