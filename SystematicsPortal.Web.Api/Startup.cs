using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SystematicsPortal.Data;
using SystematicsPortal.Model.Interfaces;
using SystematicsPortal.Web.Api.Infrastructure;
using SystematicsPortal.Web.Api.Services;

namespace SystematicsPortal.Web.Api
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

            services.Configure<AppSettings>(appSettingsConfigurationSection);


            var connectionString = Configuration.GetConnectionString("NamesWebConnectionString");

            services.AddDbContext<NamesWebContext>(options =>
                options.UseSqlServer(connectionString, opt => opt.UseRowNumberForPaging()),
                ServiceLifetime.Transient);

            services.AddTransient<IDocumentsRepository, DocumentsRepository>();

            services.AddSingleton<ISearchService, SearchService>();

            services.AddScoped<IDocumentsService, DocumentsService>();



            services.AddControllers(opt=> opt.OutputFormatters.Add(new XmlSerializerOutputFormatter())).AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                   
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
