using System.Collections.Generic;
using System.Threading.Tasks;
using SystematicsPortal.Models.Entities.Access;
using SystematicsPortal.Models.Entities.Annotations;

namespace SystematicsPortal.Web.Services
{
    public interface IContentService
    {
        Task<ContentConfigurations> GetContent(string page);
    }
}
