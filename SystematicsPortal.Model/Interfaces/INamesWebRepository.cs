using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystematicsPortal.Data.dbmodels;
using SystematicsPortal.Model.Models.Documents;

namespace SystematicsPortal.Model.Interfaces
{
    public interface INamesWebRepository
    {
        NameDocumentDto GetDocument(Guid documentId);

        IEnumerable<NameDocumentDto> GetDocuments();

        IEnumerable<NameDocumentDto> GetDocuments(IEnumerable<Guid> documentIds);

        void InsertDocument(NameDocumentDto document);

        void UpdateDocument(NameDocumentDto document);
    }
}
