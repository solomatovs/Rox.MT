using System;
using System.Runtime.InteropServices;
using System.Linq;
using System.Collections.Generic;

namespace rox.mt4.api
{
    using rox.mt4.api;

    public enum ResultProccesing
    {
        Success,
        Failed,
        Warning
    }

    public static class MT4Extensions
    {
        public static void Communication(this MT4Manager manager, MT4ConnectOption connection)
        {
            manager.Connect(connection.server);
            manager.Login(connection.login, connection.password);
        }

        public static bool CheckConnection(this MT4Manager manager)
        {
            var result = manager.IsConnected();
            if (!result) return result;

            try
            {
                manager.Ping();
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public static List<TradeRecord> ReportsRequest(this MT4Manager manager, ReportGroupRequest reportRequest, Int32 login)
        {
            return manager.ReportsRequest(reportRequest, new Int32[] { login });
        }

        public static List<TradeRecord> ReportsRequest(this MT4Manager manager, ReportGroupRequest reportRequest, IEnumerable<Int32> logins)
        {
            return manager.ReportsRequest(reportRequest, logins.ToArray());
        }

        public static List<DailyReport> DailyReportsRequest(this MT4Manager manager, DailyGroupRequest req, IEnumerable<Int32> logins)
        {
            return manager.DailyReportsRequest(req, logins.ToArray());
        }

        public static List<DailyReport> DailyReportsRequest(this MT4Manager manager, DailyGroupRequest req, Int32 login)
        {
            return manager.DailyReportsRequest(req, new Int32[] { login });
        }

        /// <summary>
        /// Возвращает информацию по запрошенному ордеру
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static TradeRecord TradeRequest(this MT4Manager mt4, Int32 order, int codePage)
        {
            return (mt4.TradeRecordsRequest(new Int32[] { order }, codePage)).FirstOrDefault();
        }

        /// <summary>
        /// Возвращает данные о пользователе по его номеру счета
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public static UserRecord UserRequest(this MT4Manager mt4, Int32 login, int codePage)
        {
            return (mt4.UserRecordsRequest(codePage, new Int32[] { login })).FirstOrDefault();
        }

        public static List<UserRecord> UserRecordsRequest(this MT4Manager mt4, int codePage, params Int32[] logins)
        {
            return mt4.UserRecordsRequest(logins.ToArray(), codePage);
        }

        public static List<UserRecord> BackupRequestUsers(this MT4Manager mt4, string file, IEnumerable<Int32> logins)
        {
            var request = string.Join(",", logins);
            return mt4.BackupRequestUsers(file, request);
        }

        public static List<UserRecord> BackupRequestUsers(this MT4Manager mt4, string file, Int32[] logins)
        {
            var request = string.Join(",", logins);
            return mt4.BackupRequestUsers(file, request);
        }

        public static List<UserRecord> BackupRequestUsers(this MT4Manager mt4, string file, Int32 login)
        {
            return mt4.BackupRequestUsers(file, new Int32[] { login });
        }

        public static List<UserRecord> BackupRequestUsers(this MT4Manager mt4, string file, IEnumerable<string> groups)
        {
            var request = string.Join(",", groups);
            return mt4.BackupRequestUsers(file, request);
        }

        public static List<UserRecord> BackupRequestUsers(this MT4Manager mt4, string file, string[] groups)
        {
            var request = string.Join(",", groups);
            return mt4.BackupRequestUsers(file, request);
        }

        public static List<UserRecord> BackupRequestUsers(this MT4Manager mt4, string file, string group)
        {
            return mt4.BackupRequestUsers(file, new string[] { group });
        }


        public static List<TradeRecord> BackupRequestOrders(this MT4Manager mt4, string file, IEnumerable<Int32> logins)
        {
            var request = string.Join(",", logins);
            return mt4.BackupRequestOrders(file, request);
        }

        public static List<TradeRecord> BackupRequestOrders(this MT4Manager mt4, string file, Int32[] logins)
        {
            var request = string.Join(",", logins);
            return mt4.BackupRequestOrders(file, request);
        }

        public static List<TradeRecord> BackupRequestOrders(this MT4Manager mt4, string file, Int32 login)
        {
            return mt4.BackupRequestOrders(file, new Int32[] { login });
        }

        public static List<TradeRecord> BackupRequestOrders(this MT4Manager mt4, string file, IEnumerable<string> groups)
        {
            var request = string.Join(",", groups);
            return mt4.BackupRequestOrders(file, request);
        }

        public static List<TradeRecord> BackupRequestOrders(this MT4Manager mt4, string file, string[] groups)
        {
            var request = string.Join(",", groups);
            return mt4.BackupRequestOrders(file, request);
        }

        public static List<TradeRecord> BackupRequestOrders(this MT4Manager mt4, string file, string group)
        {
            return mt4.BackupRequestOrders(file, new string[] { group });
        }

        public static void BackupRestoreUsers(this MT4Manager mt4, IEnumerable<Int32> logins, int codePage)
        {
            var users = new List<UserRecord>();
            foreach (var item in logins)
            {
                users.Add(new UserRecord(codePage) { Login = item });
            }
            mt4.BackupRestoreUsers(users.ToArray());
        }

        //public static void BackupRestoreUsers(this MT4Manager mt4, Int32[] logins)
        //{
        //    mt4.BackupRestoreUsers(logins.ToList());
        //}

        public static void BackupRestoreUsers(this MT4Manager mt4, Int32 login, int codePage)
        {
            mt4.BackupRestoreUsers(new Int32[]{ login }, codePage);
        }

        public static List<TradeRestoreResult> BackupRestoreOrders(this MT4Manager mt4, IEnumerable<Int32> tickets, int codePage)
        {
            var orders = new List<TradeRecord>();
            foreach (var item in tickets)
            {
                orders.Add(new TradeRecord(codePage) { Order = item });
            }
            return mt4.BackupRestoreOrders(orders.ToArray(), codePage);
        }

        //public static void BackupRestoreOrders(this MT4Manager mt4, Int32[] tickets)
        //{
        //    mt4.BackupRestoreOrders(tickets.ToList());
        //}

        public static List<TradeRestoreResult> BackupRestoreOrders(this MT4Manager mt4, Int32 ticket, int codePage)
        {
            return mt4.BackupRestoreOrders(new Int32[] { ticket }, codePage);
        }

        public static void UsersGroupOp(this MT4Manager mt4, GroupCommandInfo info, IEnumerable<int> logins)
        {
            mt4.UsersGroupOp(info, logins.ToArray());
        }

        public static void ChartDelete(this MT4Manager mt4, string symbol, ChartPeriod period, IEnumerable<RateInfo> rates)
        {
            mt4.ChartDelete(symbol, period, rates.ToArray());
        }

        public static void ChartAdd(this MT4Manager mt4, string symbol, ChartPeriod period, IEnumerable<RateInfo> rates)
        {
            mt4.ChartAdd(symbol, period, rates.ToArray());
        }

        public static void ChartUpdate(this MT4Manager mt4, string symbol, ChartPeriod period, IEnumerable<RateInfo> rates)
        {
            mt4.ChartUpdate(symbol, period, rates.ToArray());
        }
        /// <summary>
        /// Производит реконнект к серверу
        /// Функция используется в асинхронном режиме
        /// </summary>
        public static void ReconnectOnServer(this MT4Manager mt4Service, MT4ConnectOption setting)
        {
            while (true)
            {
                try
                {
                    mt4Service.Connect(setting.server);
                    mt4Service.Login(setting.login, setting.password);

                    if (!mt4Service.CheckConnection()) continue;
                    break;
                }
                catch (MT4NetworkProblemExeption) { }
                catch (MT4NoConnectionExeption) { }
                catch (MT4CommonErrorExeption) { }
            }
        }

        /// <summary>
        /// Добавляет балансовую операцию на счет
        /// </summary>
        /// <param name="mt4"></param>
        /// <param name="operation">Операция, которую необходимо добавить</param>
        /// <param name="tocken"></param>
        /// <returns></returns>
        public static void BalanceOperation(this MT4Manager mt4, MT4BalanceOperation operation, int codePage)
        {
            var transeInfo = operation.ToTradeTransInfo(codePage);
            transeInfo = mt4.TradeTransaction(transeInfo);
        }

        public static void BalanceOperation(this MT4Manager mt4, int login, double amount, int codePage, [Optional] string comment)
        {
            var operation = new MT4BalanceOperation()
            {
                Login = login,
                Amount = amount,
                Comment = comment
            };
            mt4.BalanceOperation(operation, codePage);
        }

        /// <summary>
        /// Добавляет кредитную операцию на счет
        /// </summary>
        /// <param name="mt4"></param>
        /// <param name="operation">Операцию, которую необходимо добавить</param>
        /// <param name="tocken"></param>
        /// <returns></returns>
        public static void CreditOperation(this MT4Manager mt4, MT4CreditOperation operation, int codePage)
        {
            var transeInfo = operation.ToTradeTransInfo(codePage);
            transeInfo = mt4.TradeTransaction(transeInfo);
        }

        public static void CreditOperation(this MT4Manager mt4, int login, double amount, int codePage, [Optional] string comment, [Optional] DateTime expiration)
        {
            var operation = new MT4CreditOperation()
            {
                Login = login,
                Amount = amount,
                Comment = comment,
                Expiration = expiration == DateTime.MinValue ? mt4.ServerTime().AddMonths(50) : expiration
            };
            mt4.CreditOperation(operation, codePage);
        }

        /// <summary>
        /// Создает на сервере указанные счета с указанными параметрами на счете
        /// </summary>
        /// <param name="users">Список счетов для создания</param>
        /// <returns></returns>
        public static IEnumerable<KeyValuePair<UserRecord, string>> UserRecordsNew(this MT4Manager mt4, IEnumerable<UserRecord> users)
        {
            if (users != null && users.Count() > 0)
            {
                var success = new Dictionary<UserRecord, string>();
                var failed = new Dictionary<UserRecord, string>();
                foreach (var user in users)
                {
                    try
                    {
                        var newUser = mt4.UserRecordNew(user);
                        success.Add(newUser, "ok");
                    }
                    catch(Exception e)
                    {
                        failed.Add(user, e.Message);
                    }
                }

                return success.Union(failed);
            }
            else
            {
                return null;
            }
        }
    }
}