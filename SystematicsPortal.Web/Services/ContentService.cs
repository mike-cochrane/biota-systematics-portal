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

namespace SystematicsPortal.Web.Services
{
    public class ContentService : IContentService
    {
        private readonly string _apiContentUrl;


        public ContentService(IOptions<AppSettings> appSettings)
        {
            var appsettingsObject = appSettings.Value;

            _apiContentUrl = appsettingsObject.ContentService.Url;
        }
    }
}
