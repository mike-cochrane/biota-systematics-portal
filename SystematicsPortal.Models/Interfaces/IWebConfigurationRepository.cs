using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystematicsPortal.Models.Entities.Access;

namespace SystematicsPortal.Models.Interfaces
{
    public interface IWebConfigurationRepository
    {
        Task<ContentConfigurations> GetContentConfigurationsAsync(string page);
    }
}
