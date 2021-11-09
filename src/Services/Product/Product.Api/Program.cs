using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Microsoft.Extensions.DependencyInjection;
using Product.Api;
using Common.Utilities.AppConfiguration;
using Product.Persistence.Database.Context;
using Product.Persistence.Database.WebHostingExtensions;
using Product.Persistense.Database.Configuration.Seed;

namespace Farming.Api
{
    public class Program
    {
        public static readonly string Namespace = typeof(Program).Namespace;
        public static readonly string AppName = Namespace.Substring(Namespace.LastIndexOf('.', Namespace.LastIndexOf('.') - 1) + 1);

        public static void Main(string[] args)
        {
            var enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configuration = AppConfigurations.Get(Directory.GetCurrentDirectory(), enviroment?.ToLower());
            Log.Information("Configuring web host ({ApplicationContext})...", AppName);
            var host = BuildWebHost(configuration, args);
            host.MigrateDbContext<ApplicationDbContext>((contex, services) =>
            {
                var logger = services.GetService<ILogger<ApplicationDbContext>>();
                new
                Seed().
                SeedAsync(contex, logger, configuration).Wait();
            });
            Log.Information("Starting web host ({ApplicationContext})...", AppName);
            host.RunAsync().Wait();
        }

        private static IWebHost BuildWebHost(IConfiguration configuration, string[] args) =>
         WebHost.CreateDefaultBuilder(args)
             .CaptureStartupErrors(false)
             .ConfigureAppConfiguration(x => x.AddConfiguration(configuration))
             .UseStartup<Startup>().UseKestrel(options => options.AddServerHeader = false)
             .UseContentRoot(Directory.GetCurrentDirectory())
             .Build();
        private static IConfiguration GetConfiguration(string enviroment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            if (!string.IsNullOrWhiteSpace(enviroment))
            {
                builder = builder.AddJsonFile($"appsettings.{enviroment}.json", optional: true, reloadOnChange: true);
            }

            builder.AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
