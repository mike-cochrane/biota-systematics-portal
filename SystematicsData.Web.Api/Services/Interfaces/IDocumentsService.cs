using System.Threading.Tasks;
using SystematicsData.Models.Entities.Access;

namespace SystematicsData.Web.Api.Services.Interfaces
{
    public interface IDocumentsService
    {
        Task<Document> GetDocument(string id);
    }
}
