using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystematicsPortal.Model.Models.Database;
using SystematicsPortal.Model.Models.Documents;
using SystematicsPortal.Model.Models.DTOs;

namespace SystematicsPortal.Model.Interfaces
{
    public interface IDocumentsRepository
    {
        Task<Models.Access.Document> GetDocument(Guid documentId);

        IEnumerable<Models.Access.Document> GetDocuments();

        IEnumerable<Models.Access.Document> GetDocuments(IEnumerable<Guid> documentIds);

        void InsertDocument(Document document);

        void UpdateDocument(Models.Access.Document document);
    }
}
