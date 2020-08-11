using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using SystematicsData.Models.Entities.Access;
using SystematicsData.Models.Interfaces;
using SystematicsData.Web.Api.Services.Interfaces;

namespace SystematicsData.Web.Api.Services
{
    public class ContentService : IContentService
    {
        private readonly IWebConfigurationRepository _contentRepository;
        private readonly ILogger<ContentService> _logger;
        
        public ContentService(IWebConfigurationRepository contentRepository, ILogger<ContentService> logger)
        {
            _contentRepository = contentRepository;
            _logger = logger;
        }
        
        public async Task<ContentConfigurations> GetContentAsync(string page)
        {
            return await _contentRepository.GetContentConfigurationsAsync(page);
        }
    }
}
