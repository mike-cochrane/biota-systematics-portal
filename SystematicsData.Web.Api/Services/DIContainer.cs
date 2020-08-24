using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SystematicsData.Data;
using SystematicsData.Data.Interfaces;
using SystematicsData.Search.Models.Interfaces;
using SystematicsData.Web.Api.Infrastructure;
using SystematicsData.Web.Api.Services.Interfaces;

namespace SystematicsData.Web.Api.Services
{
    public static class DIContainer
    {
        public static void RegisterDependencies(this IServiceCollection services, AppSettings appSettings, string connectionString)
        {
            services.AddDbContext<NamesWebContext>(options =>
                options.UseSqlServer(connectionString), ServiceLifetime.Scoped);

            services.AddScoped<IDocumentsRepository, DocumentsRepository>();
            services.AddScoped<IWebConfigurationRepository, WebConfigurationRepository>();

            services.AddSingleton<ISolrConnection>(x =>
                new Search.Infrastructure.SolrConnection(appSettings.Solr.Url, appSettings.Solr.UserName, appSettings.Solr.Password));

            services.AddSingleton<ISearch, Search.Search>();
            services.AddScoped<IContentService, ContentService>();
            services.AddScoped<IDocumentsService, DocumentsService>();
            services.AddScoped<ISearchService, SearchService>();
        }
    }
}
