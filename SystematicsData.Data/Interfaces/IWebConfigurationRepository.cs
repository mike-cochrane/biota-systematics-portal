using System.Threading.Tasks;
using SystematicsData.Models.Entities.Access;

namespace SystematicsData.Data.Interfaces
{
    public interface IWebConfigurationRepository
    {
        Task<ContentConfigurations> GetContentConfigurationsAsync(string page);

        Task<FieldGroupsDto> GetFieldGroupsAsync(string documentClass);
    }
}
