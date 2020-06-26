using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;
using System.Threading.Tasks;
using SystematicsPortal.Data.Uploader.Classess;
using SystematicsPortal.Data.Uploader.Helpers;

namespace SystematicsPortal.Web.Api.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
                // Start!
                MainAsync(args).Wait();
        }

        private static async Task MainAsync(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            using (var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.WithProperty("CorrelationId", Guid.NewGuid())
                .CreateLogger())
            {
                try
                {
                    logger.Information("SystematicsPortal.Data.Uploader - Started");
                    logger.Information("Machine: {MachineName}", Environment.MachineName);
                    logger.Information("Version: {Version}", AssemblyInfoHelper.GetInformationalVersion());
                    logger.Information("User Name: {UserName}", Environment.UserName);

                    var connectionString = configuration.GetConnectionString("NamesWebConnectionString");
                    var settingsConfigurationSection = configuration.GetSection("AppSettings");
                    AppSettings appSettings = settingsConfigurationSection.Get<AppSettings>();


                    logger.Information("Configuration - Connection String: {ConnectionString}", ConnectionStringHelper.ReplacePassword(connectionString, "*REMOVED*"));
                    logger.Information("Configuration - Source Folder Name: {SourceFolder}", appSettings.SourcePath);

                    Parser parser = new Parser(logger, connectionString, appSettings.SourcePath);

                    var results = await parser.StoreFilesInDocumentStore();

                    logger.Information("SystematicsPortal.Data.Uploader process results:");


                    foreach (var result in results)
                    {
                        logger.Information("File: {FileName}", result.FileName);
                        logger.Information("Result: {UploadResult}", result.UploadResult);
                        logger.Information("Message: {Message}", result.Message);
                    }

                    logger.Information("SystematicsPortal.Data.Uploader - Finished");
                }
                catch (Exception exception)
                {
                    logger.Information("SystematicsPortal.Data.Uploader failed {exception}", exception.Message);
                }
            }
        }
    }
}
