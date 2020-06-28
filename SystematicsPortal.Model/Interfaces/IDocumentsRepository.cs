using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsPortal.Model.Models.Database;

namespace SystematicsPortal.Model.Interfaces
{
    public interface IDocumentsRepository
    {
        Task<Models.Access.Document> GetDocument(Guid documentId);

        IEnumerable<Models.Access.Document> GetDocuments();

        IEnumerable<Models.Access.Document> GetDocuments(IEnumerable<Guid> documentIds);

        Task InsertDocument(Document document);

        void UpdateDocument(Models.Access.Document document);
        Task<int> WriteSerializedDocuments(Model.Models.Documents.Name.NameDocument[] names);
        Task<int> WriteDocuments(XDocument documents);
    }
}
