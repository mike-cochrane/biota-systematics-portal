using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsPortal.Models.Entities.Annotations;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using SystematicsPortal.Web.Infrastructure;
using SystematicsPortal.Models.Entities.Access;

namespace SystematicsPortal.Web.Services
{
    public class ContentService : IContentService
    {
        private readonly Api.Client.Client _apiClient;


        public ContentService(Api.Client.Client apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<ContentConfigurations> GetContent()
        {
            return await _apiClient.GeContent();
        }
    }
}
