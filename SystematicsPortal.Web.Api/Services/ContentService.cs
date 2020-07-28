using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using SystematicsPortal.Models.Entities.Access;
using SystematicsPortal.Models.Interfaces;

namespace SystematicsPortal.Web.Api.Services
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
