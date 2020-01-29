using System;
using System.Net;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using rox.mt4.api;
using System.Text.RegularExpressions;

namespace Cashback
{
    class MT4Cashback :  BackgroundService
    {
        private readonly ILogger logger;
        private readonly MT4Manager pumping;
        private readonly MT4Manager manager;
        private readonly IOptions<CashbackOption> option;
        private List<ConGroup> groups = new List<ConGroup>();

        public MT4Cashback(IOptions<CashbackOption> option, ILoggerFactory loggerFactory)
        {
            this.option = option;
            pumping = new MT4Manager(this.option.Value.native);
            manager = new MT4Manager(this.option.Value.native);
            
            logger = loggerFactory.CreateLogger<MT4Cashback>();
        }

        protected async override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.Register(() =>
            {
                logger.LogInformation("Stoping service...");
                pumping.Disconnect();
                logger.LogInformation("Stoped service");
            });

            pumping.PUMP_UPDATE_TRADES += (type, trade, param) =>
            {
                try
                {
                    if (trade.Cmd == TradeCommand.BALANCE)
                    {
                        logger.LogInformation(trade.ToString());
                        if (Regex.IsMatch(trade.Comment, option.Value.DepositCommentRegex))
                        {
                            if (option.Value.Logins != null && option.Value.Logins.Count > 0)
                            {
                                if (!option.Value.Logins.Contains(trade.Login))
                                {
                                    logger.LogInformation($"login: {trade.Login} is not allowed in settings");
                                    return;
                                }
                            }
                            var charged = trade.Profit * option.Value.Percent / 100;

                            var user = manager.UserRequest(trade.Login, codePage: 1251);
                            var group = groups.FirstOrDefault(p => p.Name == user.Group);
                            if (group != null)
                            {
                                var currency = group.Currency;
                                if (option.Value.Max.TryGetValue(currency, out double max))
                                {
                                    if (charged > max)
                                        charged = max;
                                }
                            }

                            if (charged > 0)
                                ChargeCashback(trade.Login, charged, string.Format(option.Value.Comment, trade.Order));
                            else
                                logger.LogWarning($"charged amount invalid: {charged}. order: {trade}");
                        }
                        else
                            logger.LogInformation($"non deposit operation. pattern: {option.Value.DepositCommentRegex}");
                    }
                }
                catch(Exception e)
                {
                    logger.LogError($"error unexpected: {e.Message}");
                }
            };

            pumping.PUMP_STOP_PUMPING += (param) =>
            {
                logger.LogInformation($"stoped pumping");

                if (!cancellationToken.IsCancellationRequested)
                    ConnectionLoop(cancellationToken);
            };

            ConnectionLoop(cancellationToken);
            await Task.CompletedTask;
        }

        public void ConnectionLoop(CancellationToken cancellationToken)
        {
            new Thread(() =>
            {
                var connected = false;
                while (!cancellationToken.IsCancellationRequested && !connected)
                {
                    try
                    {
                        logger.LogInformation($"try connect to {option.Value.mt4.server}...");
                        pumping.Connect(option.Value.mt4.server);
                        manager.Connect(option.Value.mt4.server);
                        logger.LogInformation($"connected to {option.Value.mt4.server}");

                        logger.LogInformation($"try logining from {option.Value.mt4.login}...");
                        pumping.Login(option.Value.mt4.login, option.Value.mt4.password);
                        manager.Login(option.Value.mt4.login, option.Value.mt4.password);
                        logger.LogInformation($"logining success");

                        pumping.SymbolsRefresh();
                        manager.SymbolsRefresh();

                        this.groups = manager.GroupsRequest();

                        logger.LogInformation($"switch to pumping mode...");
                        pumping.PumpingSwitchEx(flags: PumpingFlags.HIDE_TICKS, param: null);
                        logger.LogInformation($"pumping mode ok");
                        connected = true;
                    }
                    catch (Exception e)
                    {
                        logger.LogError($"common error: {e.Message}");
                        Thread.Sleep(TimeSpan.FromSeconds(3));
                    }
                }
            })
            { IsBackground = true }.Start();
        }

        public void ChargeCashback(int login, double amount, string comment)
        {
            var tra = manager.TradeTransaction(new MT4BalanceOperation
            {
                Login = login,
                Amount = amount,
                Comment = comment
            }.ToTradeTransInfo(1251));
        }
    }
}
