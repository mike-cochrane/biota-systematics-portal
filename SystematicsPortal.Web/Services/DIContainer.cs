using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SystematicsData.Web.Api.Client;
using SystematicsPortal.Web.Infrastructure;
using SystematicsPortal.Web.Services.Interfaces;

namespace SystematicsPortal.Web.Services
{
    public static class DIContainer
    {
        public static void RegisterDependencies(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddSingleton(new Client(appSettings.AccessService.Url));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ISearchService, SearchService>();
            services.AddSingleton<IContentService, ContentService>();
        }
    }
}
