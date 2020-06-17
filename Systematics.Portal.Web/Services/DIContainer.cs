using Annotations.Web.dScribe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Systematics.Portal.Web.Services
{
    public static class DIContainer
    {
        public static void RegisterDependencies(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddSingleton(new Api.Access.Client.Client(appSettings.AccessService.Url));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ISearchService, SearchService>();
        }
    }
}
