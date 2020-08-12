using System.Threading.Tasks;
using SystematicsData.Models.Entities.Access;

namespace SystematicsData.Models.Interfaces
{
    public interface IWebConfigurationRepository
    {
        Task<ContentConfigurations> GetContentConfigurationsAsync(string page);
    }
}
