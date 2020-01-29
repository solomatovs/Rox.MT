using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;

using rox.mt4.api;

namespace console
{
    class Program
    {
        public static void optionSet(out MT4NativeOption options, out MT4ConnectOption connect)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile(path: "app.json", optional: true, reloadOnChange: true)
                .AddJsonFile(path: "app.dev.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            options = new MT4NativeOption();
            connect = new MT4ConnectOption();
            configuration.GetSection("native").Bind(options);
            configuration.GetSection("mt4").Bind(connect);
        }

        static void Main(string[] args)
        {
            var options = new MT4NativeOption();
            var connect = new MT4ConnectOption();
            optionSet(out options, out connect);

            var manager = new MT4Manager(options);
            manager.Connect(connect.server);
            manager.Login(connect.login, connect.password);

            manager.PUMP_PING += (param) =>
            {
                Console.WriteLine($"{DateTime.Now} ping");
            };

            manager.PUMP_START_PUMPING += (param) =>
            {
                Console.WriteLine($"{DateTime.Now} start pumping");
            };

            manager.PUMP_STOP_PUMPING += (param) =>
            {
                Console.WriteLine($"{DateTime.Now} stop pumping"); 
            };

            manager.PUMP_UPDATE_ACTIVATION += (type, param) =>
            {
                foreach (var t in manager.TradesGet())
                {
                    Console.WriteLine($"{DateTime.Now} activation {t}");
                }
            };

            manager.PUMP_UPDATE_BIDASK += (param) =>
            {
                var infos = manager.SymbolInfoUpdated(10000);
                foreach (var info in infos)
                {
                    Console.WriteLine(info);
                }
            };

            manager.PUMP_UPDATE_GROUPS += (type, group, param) =>
            {
                Console.WriteLine($"{DateTime.Now} {type} group {group}");
            };

            manager.PUMP_UPDATE_MAIL += (type, news, param) =>
            {
                Console.WriteLine($"{type} mail {news}, param: {param}");
            };

            var newsKeys = new List<NewsTopicNew>();
            manager.PUMP_UPDATE_NEWS_NEW += (type, news, param) =>
            {
                Console.WriteLine(news);
            };

            manager.PUMP_UPDATE_NEWS_BODY += (type, param) =>
            {
                foreach (var n in newsKeys)
                {
                    var body = manager.NewsBodyGet(n.Key, n.Language);
                    Console.WriteLine(body);
                }
            };

            manager.PUMP_UPDATE_NEWS += (type, news, param) =>
            {
                Console.WriteLine($"update news: {news}");
            };

            manager.PUMP_UPDATE_MARGINCALL += (type, param) =>
            {
                foreach (var m in manager.MarginsGet())
                {
                    Console.WriteLine(m);
                }
            };

            manager.PUMP_UPDATE_ONLINE += (type, group, param) =>
            {
                foreach (var l in manager.OnlineGet())
                {
                    Console.WriteLine(l);
                }
            };

            manager.PUMP_UPDATE_PLUGINS += (type, param) =>
            {
                foreach (var p in manager.PluginsGet())
                {
                    Console.WriteLine(p);
                }
            };

            manager.PUMP_UPDATE_REQUESTS += (type, request, param) =>
            {
                Console.WriteLine(request);
                foreach (var p in manager.RequestsGet())
                {
                    //Console.WriteLine(p);
                }
            };

            manager.PUMP_UPDATE_SYMBOLS += (type, symbol, param) =>
            {
                Console.WriteLine(symbol);
                foreach (var p in manager.SymbolsGetAll())
                {
                    //Console.WriteLine(p);
                }
            };

            manager.PUMP_UPDATE_TRADES += (type, trade, param) =>
            {
                Console.WriteLine(trade);
                foreach (var p in manager.TradesGet())
                {
                    //Console.WriteLine(p);
                }
            };

            manager.PUMP_UPDATE_USERS += (type, user, param) => 
            {
                Console.WriteLine(user);
                foreach (var p in manager.UsersGet())
                {
                    //Console.WriteLine(p);
                }
            };

            manager.SymbolsRefresh();

            manager.PumpingSwitchEx(flags: 0, param: null);

            Console.WriteLine("ready");
            Console.ReadLine();
            Console.WriteLine("exit");
        }
    }
}
