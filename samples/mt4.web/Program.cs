using System;
using System.IO;
using EmbedIO;
using EmbedIO.Actions;
using Microsoft.Extensions.Configuration;

namespace rox.mt4.web
{
    using rox.mt4.api;
    using rox.mt4.rest;
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = Configuration(args);
            using var server = WebServer(configuration);
            server.RunAsync();
            Console.ReadKey(true);
        }

        private static IConfiguration Configuration(string[] args)
        {
            return new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile(
                    path: "app.json",
                    optional: false,
                    reloadOnChange: true
                )
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();
        }
        private static WebServer WebServer(IConfiguration c)
        {
            var web = new WebConfig(); c.GetSection("web").Bind(web);
            var mtmanapi = new MT4NativeOption(); c.GetSection("mtmanapi").Bind(mtmanapi);

            var server = new WebServer(o => o
                .WithUrlPrefix(web.Url)
                .WithMode(HttpListenerMode.EmbedIO))
                .WithLocalSessionManager()
                .WithModule(new WebSocketsMT4Server("/chat", new TokenManager(() => new MT4Manager(mtmanapi), web.Auth)))
                .WithModule(new WebSocketTerminalModule("/terminal"))
                .WithModule(new ActionModule("/", HttpVerbs.Any, ctx => ctx.SendDataAsync(new { Message = "Error" })));

            return server;
        }
    }
}
