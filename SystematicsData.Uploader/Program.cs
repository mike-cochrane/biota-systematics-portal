﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.IO;
using System.Threading.Tasks;
using SystematicsData.Data.Uploader.Classes;
using SystematicsData.Data.Uploader.Helpers;
using SystematicsData.Models.Interfaces;
using SystematicsData.Utility.Helpers;

namespace SystematicsData.Data.Uploader
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddUserSecrets<Program>(optional: true);

            IConfigurationRoot configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("NamesWeb");
            var settingsConfigurationSection = configuration.GetSection("AppSettings");
            AppSettings appSettings = settingsConfigurationSection.Get<AppSettings>();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, configuration, appSettings, connectionString);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var logger = serviceProvider.GetService<ILogger<Program>>();

            try
            {
                logger.LogInformation("SystematicsData.Data.Uploader - Started");
                logger.LogInformation("Machine: {MachineName}", Environment.MachineName);
                logger.LogInformation("Version: {Version}", AssemblyInfoHelper.GetInformationalVersion());
                logger.LogInformation("User Name: {UserName}", Environment.UserName);
                logger.LogInformation("Configuration - Connection String: {ConnectionString}", ConnectionStringHelper.ReplacePassword(connectionString, "*REMOVED*"));
                logger.LogInformation("Configuration - Source Folder Name: {SourceFolder}", appSettings.SourcePath);

                var results = await serviceProvider.GetService<Parser>().StoreFilesInDocumentStoreAsync();

                logger.LogInformation("SystematicsData.Data.Uploader process results:");

                foreach (var result in results)
                {
                    logger.LogInformation("File: {FileName}", result.FileName);
                    logger.LogInformation("Result: {UploadResult}", result.UploadResult);
                    logger.LogInformation("Message: {Message}", result.Message);
                }

                logger.LogInformation("SystematicsData.Data.Uploader - Finished");
            }
            catch (Exception ex)
            {
                logger.LogError("SystematicsData.Data.Uploader failed {exception}", ex.Message);
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
                options.UseSqlServer(connectionString), ServiceLifetime.Transient);

            services.AddTransient<IDocumentsRepository, DocumentsRepository>();

            services.AddTransient(x => new Parser(x.GetRequiredService<IDocumentsRepository>(), appSettings.SourcePath, x.GetRequiredService<ILogger<Parser>>()));
        }
    }
}
