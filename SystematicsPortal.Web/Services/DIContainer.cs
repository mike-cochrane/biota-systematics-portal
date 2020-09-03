using SystematicsPortal.Web.Views.Documents.Components.NameHyperlink;
using SystematicsPortal.Web.Views.Documents.Components.ReferenceHyperlink;
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
            {
                config.BaseAddress = new Uri(appSettings.AccessService.Url);
                config.DefaultRequestHeaders.Add("Accept", "application/xml");
            });
            services.AddHttpContextAccessor();

            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IDocumentsService, DocumentsService>();
            services.AddScoped<IContentService, ContentService>();

            services.AddScoped<IViewDefinitionsService>(container =>
            {
                return new ViewDefinitionsService();
            });
            services.AddScoped<ReferenceHyperlinkViewComponentSettings>(container =>
            {
                var baseUri = new Uri("Https://somereference");

                return new ReferenceHyperlinkViewComponentSettings(baseUri);
            });
            services.AddScoped<NameHyperlinkViewComponentSettings>(container =>
            {
                var baseUri = new Uri("Https://somename");

                return new NameHyperlinkViewComponentSettings(baseUri);
            });
        }
    }
}
