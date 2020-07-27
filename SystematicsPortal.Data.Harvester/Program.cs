using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using SystematicsPortal.Data;
using SystematicsPortal.Data.Harvester.Classes;
using SystematicsPortal.Data.Harvester.Clients;
using SystematicsPortal.Data.Harvester.Consumers;
using SystematicsPortal.Data.Harvester.Helpers;
using SystematicsPortal.Data.Harvester.Services;
using SystematicsPortal.Models.Interfaces;
using SystematicsPortal.Utility.Helpers;
using Topshelf;

namespace SystematicsPortal.Web.Api.Demo
{
    class Program
    {
        static int Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddUserSecrets(typeof(Program).Assembly, optional: true)
                .Build();

            var services = new ServiceCollection();
            var settingsConfigurationSection = configuration.GetSection("AppSettings");
            var appSettings = settingsConfigurationSection.Get<AppSettings>();
            var namesWebConnectionString = configuration.GetConnectionString("NamesWeb");
            ConfigureServices(services, configuration, appSettings, namesWebConnectionString);
            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<Program>>();

            logger.LogInformation("SystematicsPortal.Data.Harvester - Started");
            logger.LogInformation("Machine: {MachineName}", Environment.MachineName);
            logger.LogInformation("Version: {Version}", AssemblyInfoHelper.GetInformationalVersion());
            logger.LogInformation("User Name: {UserName}", Environment.UserName);

            try
            {
                var client = serviceProvider.GetService<AnnotationsClient>();
                var repository = serviceProvider.GetRequiredService<IDocumentsRepository>();
                var harvesterLogger = serviceProvider.GetService<ILogger<HarvesterService>>();

                var busControl = Bus.Factory.CreateUsingRabbitMq(config =>
                {
                    config.Host("DEV-MQ-01", "/", host =>
                    {
                        host.Username("names_user");
                        host.Password("names");
                    });

                    config.ReceiveEndpoint("systematicsportal.web.queue", endpoint =>
                    {
                        endpoint.Consumer<ItemSavedConsumer>();
                        endpoint.Consumer<NotePublishedConsumer>();
                    });
                });

                logger.LogInformation("{Action} - Names Web Connection String: {ConnectionString}", "Configuration", ConnectionStringHelper.ReplacePassword(namesWebConnectionString, "*REMOVED*"));
                logger.LogInformation("{Action} - Source Folder Name: {SourceFolder}", "Configuration", appSettings.SourcePath);
                logger.LogInformation("{Action} - RabbitMq - Host: {RabbitMqHost}", "Configuration", appSettings.RabbitMq.Host);
                logger.LogInformation("{Action} - RabbitMq - VirtualHost: {RabbitMqVirtualHost}", "Configuration", appSettings.RabbitMq.VirtualHost);
                logger.LogInformation("{Action} - RabbitMq - User Name: {RabbitMqUsername}", "Configuration", appSettings.RabbitMq.Username);

                ConfigureService(repository, client, busControl, harvesterLogger);

                logger.LogInformation("SystematicsPortal.Data.Harvester process results:");

                logger.LogInformation("SystematicsPortal.Data.Harvester - Finished");

                return 0;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                return -1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration, AppSettings appSettings, string connectionString)
        {
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.WithProperty("CorrelationId", Guid.NewGuid())
                .CreateLogger();
            Log.Logger = logger;

            services.AddLogging(configure => configure.AddSerilog(logger, dispose: true));

            services.AddDbContext<NamesWebContext>(options =>
                options.UseSqlServer(connectionString, opt => opt.UseRowNumberForPaging()),
                ServiceLifetime.Transient);

            services.AddTransient<IDocumentsRepository, DocumentsRepository>();
            services.AddTransient(x => new AnnotationsClient(x.GetRequiredService<IDocumentsRepository>(), appSettings.ContentService.Url, x.GetRequiredService<ILogger<AnnotationsClient>>()));
            services.AddTransient(x => new Parser(x.GetRequiredService<IDocumentsRepository>(), appSettings.SourcePath, x.GetRequiredService<ILogger<Parser>>()));
        }

        private IDictionary<string, IHarvesterActionStrategy> CreateStrategies(Dictionary<string, string> strategiesFromConfig, AnnotationsClient client)
        {

            var strategies = new Dictionary<string, IHarvesterActionStrategy>
                                   (StringComparer.OrdinalIgnoreCase);

            foreach (var pair in strategiesFromConfig)
            {
                Type t = Type.GetType(pair.Value);
                IHarvesterActionStrategy fieldReceiver;

                switch (pair.Key)
                {
                    case "C7EA0FE3-40A4-453A-BBB8-9F1AAF6673D7|B3A06D22-A314-40A3-8BD7-346907561112":
                        fieldReceiver = new FieldConfigurationStrategy(client, null);
                        break;
                    case "C7EA0FE3-40A4-453A-BBB8-9F1AAF6673D7|299B3954-6119-4265-AD5E-799CB7F53DE6":
                        fieldReceiver = new StaticContentStrategy(client, null);
                        break;
                    default:
                        fieldReceiver = null;
                        break;
                }

                strategies[pair.Value] = fieldReceiver;

            }
            return strategies;
        }
      
        private static void ConfigureService(IDocumentsRepository repository, AnnotationsClient client, IBusControl busControl, ILogger<HarvesterService> logger)
        {
            HostFactory.Run(configure =>
            {
                configure.Service<HarvesterService>(service =>
                {
                    service.ConstructUsing(s => new HarvesterService(repository, client, busControl, null, logger));
                    service.WhenStarted(async s => await s.StartAsync());
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
