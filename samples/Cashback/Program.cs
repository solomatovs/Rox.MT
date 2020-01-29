using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cashback
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var host = new HostBuilder()

                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddEnvironmentVariables();
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    config.AddJsonFile("appsettings.dev.json", optional: true, reloadOnChange: true);
                    config.AddCommandLine(args);
                })
                .ConfigureLogging(logging =>
                {
                    logging.AddConsole(c =>
                    {
                        c.Format = Microsoft.Extensions.Logging.Console.ConsoleLoggerFormat.Default;
                    });
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddOptions();

                    services.Configure<CashbackOption>(option =>   hostContext.Configuration.Bind(option));
                    // services.Configure<MT4ConnectOption>(option =>  hostContext.Configuration.GetSection("mt4").Bind(option));

                    services.AddHostedService<MT4Cashback>();
                })
                .Build();

            using (host)
            {
                Console.WriteLine("Starting!");
                await host.StartAsync();

                Console.WriteLine("Started! Press ctrl+c to stop.");
                await host.WaitForShutdownAsync();

                Console.WriteLine("Stopping!");

                await host.StopAsync();
                Console.WriteLine("Stopped!");
            }
        }
    }

}
