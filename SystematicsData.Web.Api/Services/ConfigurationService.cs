using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using SystematicsData.Data.Interfaces;
using SystematicsData.Models.Entities.Access;
using SystematicsData.Web.Api.Services.Interfaces;

namespace SystematicsData.Web.Api.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IWebConfigurationRepository _configurationRepository;

        private readonly ILogger<ConfigurationService> _logger;

        public ConfigurationService(IWebConfigurationRepository configurationRepository, ILogger<ConfigurationService> logger)
        {
            _configurationRepository = configurationRepository;

            _logger = logger;
        }

        public async Task<ViewDefinitionDto> GetViewDefinitionAsync(string documentClass)
        {
            return await _configurationRepository.GetViewDefinitionAsync(documentClass);
        }
    }
}
