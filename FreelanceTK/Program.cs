using FreelanceTK.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;
using System.Threading.Tasks;

namespace FreelanceTK
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            await MigrateDatabases(scope);
            await SeedData(scope);
            await host.RunAsync();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, builder) =>
            {
                builder.AddEnvironmentVariables();

                if (!context.HostingEnvironment.IsProduction())
                {
                    builder.AddJsonFile($"identityconfig.{context.HostingEnvironment.EnvironmentName}.json", optional: true)
                           .AddJsonFile($"emailConfig.{context.HostingEnvironment.EnvironmentName}.json", optional: true)
                           .AddJsonFile($"serilogconfig.{context.HostingEnvironment.EnvironmentName}.json", optional: true);
                }
                else
                {
                    LoadProductionConfigs(builder);
                }
            })
             .UseSerilog((context, configuration) =>
             {
                 configuration.Enrich.FromLogContext().ReadFrom.Configuration(context.Configuration);
             })
             .ConfigureWebHostDefaults(webBuilder =>
             {
                 webBuilder.UseStartup<Startup>();
             });

        private static void LoadProductionConfigs(IConfigurationBuilder builder)
        {
            var files = Directory.GetFiles("/config", "*.json", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                builder.AddJsonFile(file);
            }
        }


        private static async Task SeedData(IServiceScope scope)
        {
            DataSeeder dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
            await dataSeeder.SeedData();
        }

        private static async Task MigrateDatabases(IServiceScope scope)
        {
            var databaseMigrator = scope.ServiceProvider.GetRequiredService<DatabaseMigrator>();
            await databaseMigrator.MigrateAsync();
        }

    }
}
