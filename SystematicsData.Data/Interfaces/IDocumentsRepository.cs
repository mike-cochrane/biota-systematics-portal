using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsData.Models.Entities.Access;

namespace SystematicsData.Data.Interfaces
{
    public interface IDocumentsRepository
    {
        Task<DocumentDto> GetDocumentAsync(Guid documentId);

        IEnumerable<DocumentDto> GetDocuments();

        IEnumerable<DocumentDto> GetDocuments(IEnumerable<Guid> documentIds);

        Task InsertDocument(Models.Document document);

        void UpdateDocument(DocumentDto document);

        Task<int> WriteDocuments(IEnumerable<XElement> documentsList);
    }
}
