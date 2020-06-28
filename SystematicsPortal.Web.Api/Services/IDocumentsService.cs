using System.Threading.Tasks;

namespace SystematicsPortal.Web.Api.Services
{
    public interface IDocumentsService
    {
        Task<Model.Models.Access.Document> GetDocument(string id);
    }
}
