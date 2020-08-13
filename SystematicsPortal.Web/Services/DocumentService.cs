using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystematicsData.Models.Entities.Access;
using SystematicsData.Web.Api.Client;
using SystematicsPortal.Web.Services.Interfaces;

namespace SystematicsPortal.Web.Services
{
    public class DocumentService : IDocumentService
    {
        public readonly Client _apiClient;

        public DocumentService(Client apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<Document> GetDocument(string id)
        {
            var documentXml = await _apiClient.GetDocument(id);

            return documentXml;
        }
    }
}
