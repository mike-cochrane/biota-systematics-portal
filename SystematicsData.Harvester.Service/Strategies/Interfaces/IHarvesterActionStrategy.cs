using System.Threading.Tasks;
using System.Xml.Linq;

namespace SystematicsData.Harvester.Service.Strategies.Interfaces
{
    public interface IHarvesterActionStrategy
    {
        Task<int> ApplyStrategyAsync(XElement item);
    }
}
