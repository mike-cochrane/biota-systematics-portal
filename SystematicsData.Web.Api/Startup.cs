using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Net;
using SystematicsData.Models.Infrastructure.Exceptions;
using SystematicsData.Web.Api.Filters;
using SystematicsData.Web.Api.Helpers;
using SystematicsData.Web.Api.Infrastructure;
using SystematicsData.Web.Api.Services;

namespace SystematicsData.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();

            var appSettingsConfigurationSection = Configuration.GetSection("AppSettings");
            AppSettings appSettings = appSettingsConfigurationSection.Get<AppSettings>();
            services.Configure<AppSettings>(appSettingsConfigurationSection);

            var connectionString = Configuration.GetConnectionString("NamesWeb");

            services.RegisterDependencies(appSettings, connectionString);

            services.AddControllers(opts =>
            {
                opts.Filters.Add<SerilogLoggingActionFilter>();
            })
                .AddNewtonsoftJson()
                .AddXmlSerializerFormatters();

            services.AddProblemDetails(config =>
            {
                config.MapToStatusCode<NotFoundException>((int)HttpStatusCode.NotFound);
                config.IncludeExceptionDetails = (ctx, ex) =>
                {
                    var env = ctx.RequestServices.GetRequiredService<IHostEnvironment>();

                    return env.IsDevelopment();
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseProblemDetails();
            app.UseSerilogRequestLogging(opts => opts.EnrichDiagnosticContext = LogHelper.EnrichFromRequest);
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
