using System.Collections.Generic;
using System.Threading.Tasks;
using SystematicsPortal.Models.Entities.Access;

namespace SystematicsPortal.Web.Api.Services
{
    public interface IContentService
    {
        Task<ContentConfigurations> GetContentAsync(string page);
    }
}
