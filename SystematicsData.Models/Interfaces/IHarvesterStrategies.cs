using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystematicsData.Models.Interfaces
{
    public interface IHarvesterStrategies
    {
        IDictionary<string, IHarvesterActionStrategy> GetStrategies();
    }
}
