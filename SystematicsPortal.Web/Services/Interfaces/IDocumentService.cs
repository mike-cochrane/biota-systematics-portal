using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystematicsData.Models.Entities.Access;

namespace SystematicsPortal.Web.Services.Interfaces
{
    public interface IDocumentService
    {
        Task<Document> GetDocument(string id);
    }
}
