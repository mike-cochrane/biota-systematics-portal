using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SystematicsData.Models.Interfaces
{
    public interface IDocumentsRepository
    {
        Task<Entities.Access.Document> GetDocumentAsync(Guid documentId);
        IEnumerable<Entities.Access.Document> GetDocuments();
        IEnumerable<Entities.Access.Document> GetDocuments(IEnumerable<Guid> documentIds);
        Task InsertDocument(Entities.Database.Document document);
        void UpdateDocument(Entities.Access.Document document);
        Task<int> WriteDocuments(IEnumerable<XElement> documentsList);
    }
}
