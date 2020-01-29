using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace rox.mt4.rest
{
    using rox.mt4.api;
    public class Program
    {
        public static void Main(string[] args)
        {
            var platformString = MT4Helper.Is64BitProccess() == true ? "x64" : "x86";
            System.Console.WriteLine($"Platform {platformString}");

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
