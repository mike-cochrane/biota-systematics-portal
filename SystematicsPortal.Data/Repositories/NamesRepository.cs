using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystematicsPortal.Model.Interfaces;
using SystematicsPortal.Model.Models.Documents;

namespace SystematicsPortal.Data
{
    public class NamesRepository : INamesWebRepository
    {
        private readonly NamesWebContext _context;


        public NamesRepository(NamesWebContext context)
        {
            _context = context;
        }

        public NameDocumentDto GetDocument(Guid documentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NameDocumentDto> GetDocuments()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NameDocumentDto> GetDocuments(IEnumerable<Guid> documentIds)
        {
            throw new NotImplementedException();
        }

        public void InsertDocument(NameDocumentDto document)
        {
            throw new NotImplementedException();
        }

        public void UpdateDocument(NameDocumentDto document)
        {
            throw new NotImplementedException();
        }
    }
}
