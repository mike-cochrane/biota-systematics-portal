using System.Threading.Tasks;
using SystematicsData.Models.Entities.Access;

namespace SystematicsData.Web.Api.Services.Interfaces
{
    public interface IConfigurationService
    {
        Task<ViewDefinitionDto> GetViewDefinitionAsync(string documentClass);
    }
}
