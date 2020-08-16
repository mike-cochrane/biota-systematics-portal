using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
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
                opts.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                opts.Filters.Add<SerilogLoggingActionFilter>();
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
