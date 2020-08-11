using System.Collections.Generic;

namespace SystematicsData.Harvester.Service.Strategies.Interfaces
{
    public interface IHarvesterStrategies
    {
        IDictionary<string, IHarvesterActionStrategy> GetStrategies();
    }
}
