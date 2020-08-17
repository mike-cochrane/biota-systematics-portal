using Microsoft.Extensions.DependencyInjection;
using System;
using SystematicsData.Web.Api.Client;
using SystematicsData.Web.Api.Client.Interfaces;
using SystematicsPortal.Web.Infrastructure;
using SystematicsPortal.Web.Services.Interfaces;

namespace SystematicsPortal.Web.Services
{
    public static class DIContainer
    {
        public static void RegisterDependencies(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddHttpClient<ISystematicsDataClient, SystematicsDataClient>(config =>
                config.BaseAddress = new Uri(appSettings.AccessService.Url));
            services.AddHttpContextAccessor();

            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IContentService, ContentService>();
        }
    }
}
