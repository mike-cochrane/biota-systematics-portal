using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.IO;
using System.Reflection;
using SystematicsData.Data;
using SystematicsData.Harvester.Service.Clients;
using SystematicsData.Harvester.Service.Consumers;
using SystematicsData.Harvester.Service.Helpers;
using SystematicsData.Harvester.Service.Services;
using SystematicsData.Harvester.Service.Strategies;
using SystematicsData.Harvester.Service.Strategies.Interfaces;
using SystematicsData.Models.Interfaces;
using SystematicsData.Utility.Helpers;
using Topshelf;

namespace SystematicsData.Harvester.Service
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddUserSecrets<Program>(optional: true)
                .Build();

            var services = new ServiceCollection();
            var settingsConfigurationSection = configuration.GetSection("AppSettings");
            var appSettings = settingsConfigurationSection.Get<AppSettings>();
            services.Configure<AppSettings>(settingsConfigurationSection);
            var namesWebConnectionString = configuration.GetConnectionString("NamesWeb");
            ConfigureServices(services, configuration, appSettings, namesWebConnectionString);
            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<Program>>();

            logger.LogInformation("SystematicsData.Harvester.Service - Started");
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
                    config.Host(appSettings.RabbitMq.Host, appSettings.RabbitMq.VirtualHost, host =>
                    {
                        host.Username(appSettings.RabbitMq.Username);
                        host.Password(appSettings.RabbitMq.Password);
                    });

                    config.ReceiveEndpoint("systematicsportal.web.queue", endpoint =>
                    {
                        var harvesterStrategies = serviceProvider.GetRequiredService<IHarvesterStrategies>();
                        var itemUpdatedConsumerLogger = serviceProvider.GetService<ILogger<ItemUpdatedConsumer>>();
                        var itemPublishedConsumerLogger = serviceProvider.GetService<ILogger<ItemPublishedConsumer>>();

                        endpoint.Consumer(() => new ItemUpdatedConsumer(harvesterStrategies, client, itemUpdatedConsumerLogger));
                        endpoint.Consumer(() => new ItemPublishedConsumer(harvesterStrategies, client, itemPublishedConsumerLogger));
                    });
                });

                logger.LogInformation("{Action} - Names Web Connection String: {ConnectionString}", "Configuration", ConnectionStringHelper.ReplacePassword(namesWebConnectionString, "*REMOVED*"));
                logger.LogInformation("{Action} - Source Folder Name: {SourceFolder}", "Configuration", appSettings.SourcePath);
                logger.LogInformation("{Action} - RabbitMq - Host: {RabbitMqHost}", "Configuration", appSettings.RabbitMq.Host);
                logger.LogInformation("{Action} - RabbitMq - Virtual Host: {RabbitMqVirtualHost}", "Configuration", appSettings.RabbitMq.VirtualHost);
                logger.LogInformation("{Action} - RabbitMq - User Name: {RabbitMqUsername}", "Configuration", appSettings.RabbitMq.Username);

                ConfigureService(busControl, harvesterLogger);

                logger.LogInformation("SystematicsData.Harvester.Service process results:");

                logger.LogInformation("SystematicsData.Harvester.Service - Finished");

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

            services.AddHttpClient<AnnotationsClient>(configureClient =>
                configureClient.BaseAddress = new Uri(appSettings.ContentService.Url));

            services.AddDbContext<NamesWebContext>(options =>
                options.UseSqlServer(connectionString),
                ServiceLifetime.Scoped);

            services.AddTransient<IDocumentsRepository, DocumentsRepository>();
            services.AddTransient<IHarvesterStrategies, HarvesterStrategies>();
        }

        private static void ConfigureService(IBusControl busControl, ILogger<HarvesterService> logger)
        {
            HostFactory.Run(configure =>
            {
                configure.Service<HarvesterService>(service =>
                {
                    service.ConstructUsing(s => new HarvesterService(busControl, logger));
                    service.WhenStarted(async s => await s.StartAsync());
                    service.WhenStopped(s => s.Stop());
                });

                //Setup Account that window service use to run.
                configure.RunAsLocalSystem();
                configure.SetServiceName("SystematicsData.Harvester.Service");
                configure.SetDisplayName("SystematicsData.Harvester.Service");
                configure.SetDescription("Harvester that receives messages and proceeds to update documents in SOLR and Document Store");
            });
        }
    }
}
