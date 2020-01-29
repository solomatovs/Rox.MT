using System;
using System.IO;
using System.Text;
using Xunit;
using Microsoft.Extensions.Configuration;

namespace rox.mt4.test
{
    using rox.mt4.api;

    public class UnitTest
    {
        readonly MT4NativeOption options;
        readonly MT4NativeOption native_incorrect_path;
        readonly MT4NativeOption native_not_library;
        readonly MT4NativeOption native_load_not_mtmanapi;
        readonly MT4ConnectOption connect;
        readonly MT4ConnectOption connect_incorrect_server;
        readonly MT4ConnectOption connect_incorrect_auth;

        public UnitTest()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", ".."))
                .AddJsonFile(
                    path: "secret.json",
                    optional: false,
                    reloadOnChange: true
                )
                .AddEnvironmentVariables()
                .Build();

            options =                       configuration.GetValue<MT4NativeOption>("native");
            native_incorrect_path =         configuration.GetValue<MT4NativeOption>("native_incorrect_path");
            native_not_library =            configuration.GetValue<MT4NativeOption>("native_not_library");
            native_load_not_mtmanapi =      configuration.GetValue<MT4NativeOption>("native_load_not_mtmanapi");
            connect =                       configuration.GetValue<MT4ConnectOption>("connect");
            connect_incorrect_server =      configuration.GetValue<MT4ConnectOption>("connect_incorrect_server");
            connect_incorrect_auth =        configuration.GetValue<MT4ConnectOption>("connect_incorrect_auth");
        }

        [Fact]
        public void Manager_is_not_null()
        {
            var manager = new MT4Manager(options);

            Assert.NotNull(manager);
        }

        [Fact]
        public void Manager_not_load_because_incorrect_path()
        {
            Assert.Throws<FileLoadException>(() => new MT4Manager(native_incorrect_path));
        }

        [Fact]
        public void Manager_not_load_because_not_library()
        {
            Assert.Throws<FileLoadException>(() => new MT4Manager(native_not_library));
        }

        [Fact]
        public void Manager_not_load_because_load_not_mtmanapi()
        {
            Assert.Throws<MT4FunctionNotFoundException>(() => new MT4Manager(native_load_not_mtmanapi));
        }

        [Fact]
        public void Connect_success()
        {
            var manager = new MT4Manager(options);
            var ex = Record.Exception(() => manager.Connect(connect.server));

            Assert.Null(ex);
        }

        [Fact]
        public void Connect_incorrect_server()
        {
            var manager = new MT4Manager(options);
            Assert.Throws<MT4NoConnectionExeption>(() => manager.Connect(connect_incorrect_server.server));
        }

        [Fact]
        public void Connect_incorrect_auth()
        {
            var manager = new MT4Manager(options);
            manager.Connect(connect.server);
            Assert.Throws<MT4BadAccountInfoExeption>(() => manager.Login(connect_incorrect_auth.login, connect_incorrect_auth.password));
        }

        [Fact]
        public void auto_reconnect_if_disconnected_in_request()
        {
            var manager = new MT4Manager(options);
            manager.Connect(connect.server);
            manager.Login(connect.login, connect.password);
            manager.Disconnect();

            var ex = Record.Exception(() => manager.SymbolsRefresh());
            Assert.Null(ex);
        }

        [Fact]
        public void network_problem_if_not_authorization_in_request()
        {
            var manager = new MT4Manager(options);
            manager.Connect(connect.server);

            Assert.Throws<MT4NetworkProblemExeption>(() => manager.SymbolsRefresh());
        }

        [Fact]
        public void mt4_no_connection_if_not_connected_in_request()
        {
            var manager = new MT4Manager(options);

            Assert.Throws<MT4NoConnectionExeption>(() => manager.SymbolsRefresh());
        }

        [Fact]
        public void auto_reconnect_if_disconnected_in_request_data()
        {
            var manager = new MT4Manager(options);
            manager.Connect(connect.server);
            manager.Login(connect.login, connect.password);
            manager.Disconnect();

            var ex = Record.Exception(() => manager.CfgRequestCommon(1251));
            Assert.Null(ex);
        }

        [Fact]
        public void network_problem_if_not_authorization_in_request_data()
        {
            var manager = new MT4Manager(options);
            manager.Connect(connect.server);

            Assert.Throws<MT4NetworkProblemExeption>(() => manager.CfgRequestCommon(1251));
        }

        [Fact]
        public void mt4_no_connection_if_not_connected_in_request_data()
        {
            var manager = new MT4Manager(options);

            Assert.Throws<MT4NoConnectionExeption>(() => manager.CfgRequestCommon(1251));
        }



        [Fact]
        public void auto_reconnect_if_disconnected_in_request_returned_array()
        {
            var manager = new MT4Manager(options);
            manager.Connect(connect.server);
            manager.Login(connect.login, connect.password);
            manager.Disconnect();

            Assert.NotEmpty(manager.TradesRequest(1251));
        }

        //[Fact]
        //public void network_problem_if_not_authorization_in_request_returned_array()
        //{
        //    var manager = new MT4Manager(options);
        //    manager.Connect(connect.server);

        //    Assert.Throws<MT4NetworkProblemExeption>(() => manager.TradesRequest());
        //}

        [Fact]
        public void mt4_no_connection_if_not_connected_in_request_returned_array()
        {
            var manager = new MT4Manager(options);

            Assert.Throws<MT4NoConnectionExeption>(() => manager.TradesRequest(1251));
        }


        //[Fact]
        //public void network_problem_if_not_authorization_in_ping()
        //{
        //    var manager = new MT4Manager(options);
        //    manager.Connect(connect.server);
        //    var time = manager.ServerTime();

        //    Assert.Throws<MT4NetworkProblemExeption>(() => manager.ServerTime());
        //}

        [Fact]
        public void mt4_no_connection_if_not_connected_in_ping()
        {
            var manager = new MT4Manager(options);

            Assert.Throws<MT4NoConnectionExeption>(() => manager.Ping());
        }

        [Fact]
        public void request_not_correspond_in_pumping()
        {
            var manager = new MT4Manager(options);
            manager.Connect(connect.server);
            manager.Login(connect.login, connect.password);
            manager.PumpingSwitch(code =>
            {

            }, IntPtr.Zero, 0, 0);

            
            Assert.Throws<MT4RequestNotCorrespondException>(() => manager.Ping());
        }

        [Fact]
        public void check_pumping_functions()
        {
            var manager = new MT4Manager(options);
            manager.Connect(connect.server);
            manager.Login(connect.login, connect.password);
            manager.PumpingSwitchEx(0, 0);

            var newsTotal = manager.NewsTotal();
            var news = manager.NewsGet(1251);
            var users = manager.GroupsGet(1251);

            Assert.True(true);
        }
    }
}
