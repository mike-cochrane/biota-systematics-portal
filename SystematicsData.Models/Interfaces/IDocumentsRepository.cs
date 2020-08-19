﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsData.Models.Entities.Access;

namespace SystematicsData.Models.Interfaces
{
    public interface IDocumentsRepository
    {
        Task<Document> GetDocumentAsync(Guid documentId);

        IEnumerable<Document> GetDocuments();

        IEnumerable<Document> GetDocuments(IEnumerable<Guid> documentIds);

        Task InsertDocument(Entities.Database.Document document);

        void UpdateDocument(Document document);

        Task<int> WriteDocuments(IEnumerable<XElement> documentsList);
    }
}
