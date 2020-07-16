using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.IO;
using System.Threading.Tasks;
using SystematicsPortal.Data;
using SystematicsPortal.Data.Harvester.Classes;
using SystematicsPortal.Data.Harvester.Clients;
using SystematicsPortal.Data.Harvester.Helpers;
using SystematicsPortal.Data.Harvester.Services;
using SystematicsPortal.Models.Interfaces;
using SystematicsPortal.Utility.Helpers;
using Topshelf;

namespace SystematicsPortal.Web.Api.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MainAsync(args).Wait();

            }
            catch (Exception e)
            {

                throw;
            }
        }

        private static async Task MainAsync(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("NamesWeb");
            var settingsConfigurationSection = configuration.GetSection("AppSettings");
            AppSettings appSettings = settingsConfigurationSection.Get<AppSettings>();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, configuration, appSettings, connectionString);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var logger = serviceProvider.GetService<ILogger<Program>>();

            var client = serviceProvider.GetService<AnnotationsClient>();



            try
            {
                logger.LogInformation("SystematicsPortal.Data.Harvester - Started");
                logger.LogInformation("Machine: {MachineName}", Environment.MachineName);
                logger.LogInformation("Version: {Version}", AssemblyInfoHelper.GetInformationalVersion());
                logger.LogInformation("User Name: {UserName}", Environment.UserName);
                logger.LogInformation("Configuration - Connection String: {ConnectionString}", ConnectionStringHelper.ReplacePassword(connectionString, "*REMOVED*"));
                logger.LogInformation("Configuration - Source Folder Name: {SourceFolder}", appSettings.SourcePath);

                ConfigureService(client);


                logger.LogInformation("SystematicsPortal.Data.Harvester process results:");



                logger.LogInformation("SystematicsPortal.Data.Harvester - Finished");
            }
            catch (Exception exception)
            {
                logger.LogError("SystematicsPortal.Data.Harvester failed {exception}", exception.Message);
            }
        }

        private static void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration, AppSettings appSettings, string connectionString)
        {
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.WithProperty("CorrelationId", Guid.NewGuid())
                .CreateLogger();

            services.AddLogging(conf => conf.AddSerilog(logger));

            services.AddDbContext<NamesWebContext>(options =>
                options.UseSqlServer(connectionString, opt => opt.UseRowNumberForPaging()),
                ServiceLifetime.Transient);

            services.AddTransient<IDocumentsRepository, DocumentsRepository>();

            services.AddTransient(x =>
            new AnnotationsClient(x.GetRequiredService<IDocumentsRepository>(), appSettings.ContentService.Url, x.GetRequiredService<ILogger<AnnotationsClient>>()));

            services.AddTransient<Parser>(x =>
            new Parser(x.GetRequiredService<IDocumentsRepository>(), appSettings.SourcePath, x.GetRequiredService<ILogger<Parser>>()));
        }
    
        private static void ConfigureService(AnnotationsClient client)
        {
                HostFactory.Run(configure =>
                {
                    configure.Service<HarvesterService>(service =>
                    {
                        service.ConstructUsing(s => new HarvesterService(client));
                        service.WhenStarted(s => s.StartAsync());
                        service.WhenStopped(s => s.Stop());
                    });
                    //Setup Account that window service use to run.  
                    configure.RunAsLocalSystem();
                    configure.SetServiceName("SystematicsPortal.Data.Harvester");
                    configure.SetDisplayName("SystematicsPortal.Data.Harvester");
                    configure.SetDescription("Harvester that receives messages and proceed to update documents in SOLR and Document Store");
                });
        }
    }
}
