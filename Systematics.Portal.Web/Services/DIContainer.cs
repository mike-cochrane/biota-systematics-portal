using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Systematics.Portal.Web.Services
{
    public static class DIContainer
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ISearchService, SearchService>();
        }
    }
}
