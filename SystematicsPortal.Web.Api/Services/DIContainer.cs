﻿using Microsoft.EntityFrameworkCore;
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
                ServiceLifetime.Singleton);

            services.AddSingleton<IDocumentsRepository, DocumentsRepository>();
            services.AddSingleton<IWebConfigurationRepository, WebConfigurationRepository>();

            services.AddSingleton<ISolrConnection>(x =>
                new Search.Infrastructure.SolrConnection(appSettings.Solr.Url, appSettings.Solr.UserName,
                            appSettings.Solr.Password));

            services.AddSingleton<ISearch, Search.Search>();
            services.AddSingleton<IContentService, ContentService>();
            services.AddSingleton<IDocumentsService, DocumentsService>();
            services.AddSingleton<ISearchService, SearchService>();
        }
    }
}
