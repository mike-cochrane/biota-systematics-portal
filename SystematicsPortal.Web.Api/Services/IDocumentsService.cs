using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystematicsPortal.Model.Models.DTOs;

namespace SystematicsPortal.Web.Api.Services
{
    public interface IDocumentsService
    {
        Task<Model.Models.Access.Document> GetDocument(string id);
    }
}
