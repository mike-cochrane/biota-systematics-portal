using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SystematicsPortal.Web.Infrastructure;

namespace SystematicsPortal.Web.Services
{
    public static class DIContainer
    {
        public static void RegisterDependencies(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddSingleton(new Api.Client.Client(appSettings.AccessService.Url));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ISearchService, SearchService>();
            services.AddSingleton<IContentService, ContentService>();

        }
    }
}
