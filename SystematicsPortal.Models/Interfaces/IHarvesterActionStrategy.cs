using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SystematicsPortal.Models.Interfaces
{
    public interface IHarvesterActionStrategy
    {
        Task<int> ApplyStrategyAsync(XElement item);
    }
}
