using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SystematicsPortal.Data;
using SystematicsPortal.Models.Interfaces;
using SystematicsPortal.Search.Tools.Models.Interfaces;
using SystematicsPortal.Web.Api.Infrastructure;

namespace SystematicsPortal.Web.Api.Services
{
    public static class DIContainer
    {
        public static void RegisterDependencies(this IServiceCollection services, AppSettings appSettings, string connectionString)
        {
            services.AddDbContext<NamesWebContext>(options =>
                options.UseSqlServer(connectionString, opt => opt.UseRowNumberForPaging()),
                ServiceLifetime.Scoped);

            services.AddScoped<IDocumentsRepository, DocumentsRepository>();
            services.AddScoped<IWebConfigurationRepository, WebConfigurationRepository>();

            services.AddScoped<ISolrConnection>(x =>
                new Search.Infrastructure.SolrConnection(appSettings.Solr.Url, appSettings.Solr.UserName,
                            appSettings.Solr.Password));

            services.AddScoped<ISearch, Search.Search>();
            services.AddScoped<IContentService, ContentService>();
            services.AddScoped<IDocumentsService, DocumentsService>();
            services.AddScoped<ISearchService, SearchService>();
        }
    }
}
