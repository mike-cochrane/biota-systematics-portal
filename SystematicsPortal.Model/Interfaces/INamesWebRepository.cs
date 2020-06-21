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
        NameDocument GetDocument(Guid documentId);

        IEnumerable<NameDocument> GetDocuments();

        IEnumerable<NameDocument> GetDocuments(IEnumerable<Guid> documentIds);

        void InsertDocument(NameDocument document);

        void UpdateDocument(NameDocument document);
    }
}
