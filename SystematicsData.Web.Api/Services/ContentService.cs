using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using SystematicsData.Data.Interfaces;
using SystematicsData.Models.Entities.Access;
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

    //public class ViewDefinition
    //{
    //    public string Class { get; set; }

    //    public List<Group> Groups { get; set; }

    //    public ViewDefinition()
    //    {
    //        Groups = new List<Group>();
    //    }
    //}

    //public class Group
    //{
    //    public string Name { get; set; }

    //    public string XPath { get; set; }

    //    public int Order { get; set; }

    //    public string Template { get; set; }

    //    public List<Label> Labels { get; set; }

    //    public List<Field> Fields { get; set; }
    //}

    //public class Field
    //{
    //    public string XPath { get; set; }

    //    public List<Label> Labels { get; set; }
    //}

    //public class Label
    //{
    //    public string Text { get; set; }

    //    public string Language { get; set; }
    //}
}
