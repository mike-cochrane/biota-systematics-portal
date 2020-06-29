using System.Threading.Tasks;
using SystematicsPortal.Models.Entities.Access;

namespace SystematicsPortal.Web.Api.Services
{
    public interface IDocumentsService
    {
        Task<Document> GetDocument(string id);
    }
}
