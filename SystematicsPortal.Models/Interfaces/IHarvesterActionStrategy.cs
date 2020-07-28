using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SystematicsPortal.Models.Interfaces
{
    public interface IHarvesterActionStrategy
    {
        Task<IEnumerable<XElement>> GetDocumentsAsync (string resourceId, string itemTypeId, string itemId);
    }
}
