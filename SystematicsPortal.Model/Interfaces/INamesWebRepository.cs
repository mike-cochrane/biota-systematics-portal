using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystematicsPortal.Data.dbmodels;
using SystematicsPortal.Model.Models.Documents;
using SystematicsPortal.Model.Models.DTOs;

namespace SystematicsPortal.Model.Interfaces
{
    public interface INamesWebRepository
    {
        Task<DocumentDto> GetDocument(Guid documentId);

        IEnumerable<Data.dbmodels.Document> GetDocuments();

        IEnumerable<Data.dbmodels.Document> GetDocuments(IEnumerable<Guid> documentIds);

        void InsertDocument(Data.dbmodels.Document document);

        void UpdateDocument(Data.dbmodels.Document document);
    }
}
