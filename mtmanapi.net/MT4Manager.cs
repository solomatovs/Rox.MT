using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace rox.mt4.api
{
    public delegate void BidAskDelegate(object param);
    public delegate void TradesDelegate(PumpingUpdateType type, TradeRecord trade, object param);
    public delegate void UsersDelegate(PumpingUpdateType type, UserRecord user, object param);
    public delegate void ConGroupDelegate(PumpingUpdateType type, ConGroup group, object param);
    public delegate void OnlineDelegate(PumpingUpdateType type, Int32 login, object param);
    public delegate void NewsBodyDelegate(PumpingUpdateType type, object param);
    public delegate void NewsDelegate(PumpingUpdateType type, NewsTopic newsTopic, object param);
    public delegate void NewsNewDelegate(PumpingUpdateType type, NewsTopicNew data, object param);
    public delegate void MailDelegate(PumpingUpdateType type, MailBox mail, object param);
    public delegate void PluginsDelegate(PumpingUpdateType type, object param);
    public delegate void ActivationDelegate(PumpingUpdateType type, object param);
    public delegate void MarginCallDelegate(PumpingUpdateType type, object param);
    public delegate void PumpingPingDelegate(object param);
    public delegate void StartPumpingDelegate(object param);
    public delegate void StopPumpingDelegate(object param);
    public delegate void RequestDelegate(PumpingUpdateType type, RequestInfo requestInfo, object param);
    public delegate void SymbolsDelegate(PumpingUpdateType type, ConSymbol symbol, object param);

    public class MT4Manager : MT4Interface
    {
        protected MTAPI_NOTIFY_FUNC pumpingCallback;
        protected MTAPI_NOTIFY_FUNC_EX pumpingCallbackEx;
        public event StartPumpingDelegate PUMP_START_PUMPING;
        public event SymbolsDelegate PUMP_UPDATE_SYMBOLS;
        public event ConGroupDelegate PUMP_UPDATE_GROUPS;
        public event UsersDelegate PUMP_UPDATE_USERS;
        public event OnlineDelegate PUMP_UPDATE_ONLINE;
        public event BidAskDelegate PUMP_UPDATE_BIDASK;
        public event NewsDelegate PUMP_UPDATE_NEWS;
        public event NewsBodyDelegate PUMP_UPDATE_NEWS_BODY;
        public event MailDelegate PUMP_UPDATE_MAIL;
        public event TradesDelegate PUMP_UPDATE_TRADES;
        public event RequestDelegate PUMP_UPDATE_REQUESTS;
        public event PluginsDelegate PUMP_UPDATE_PLUGINS;
        public event ActivationDelegate PUMP_UPDATE_ACTIVATION;
        public event StopPumpingDelegate PUMP_STOP_PUMPING;
        public event MarginCallDelegate PUMP_UPDATE_MARGINCALL;
        public event PumpingPingDelegate PUMP_PING;
        public event NewsNewDelegate PUMP_UPDATE_NEWS_NEW;

        public MT4Manager(MT4NativeOption options) : base(options)
        {
            WorkingDirectory(this.options);
        }

        public MT4Mode Mode => mode;

        public DateTime ServerTime()
        {
            ThrowIfModeNotRequest(nameof(ServerTime));

            return WrapperFunction(() => {
                var unixTime = serverTime(CManagerInterface);
                if (unixTime == 0)
                {
                    LastCommunicationn();
                    unixTime = serverTime(CManagerInterface);
                }

                return unixTime.ToDateTime();
            });
        }

        public void PasswordChange(string pass, bool is_investor)
        {
            ThrowIfModeNotRequest(nameof(PasswordChange));

            var boolValue = is_investor == true ? 1 : 0;
            WrapperFunction(() => passwordChange(CManagerInterface, pass, boolValue));
        }

        public ConManager ManagerRights(int codePage = 0)
        {
            SetDefaultCodePageIfZero(ref codePage);
            ThrowIfModeNotRequest(nameof(ManagerRights));

            return WrapperFunction<ConManager, NConManager>((ref NConManager native) => managerRights(CManagerInterface, out native), codePage);
        }

        public void SrvRestart()
        {
            ThrowIfModeNotRequest(nameof(SrvRestart));

            WrapperFunction(() => srvRestart(CManagerInterface));
        }

        public void SrvChartsSync()
        {
            ThrowIfModeNotRequest(nameof(SrvChartsSync));

            WrapperFunction(() => srvChartsSync(CManagerInterface));
        }

        public void SrvLiveUpdateStart()
        {
            ThrowIfModeNotRequest(nameof(SrvLiveUpdateStart));

            WrapperFunction(() => srvLiveUpdateStart(CManagerInterface));
        }

        public void SrvFeedsRestart()
        {
            ThrowIfModeNotRequest(nameof(SrvFeedsRestart));

            WrapperFunction(() => srvFeedsRestart(CManagerInterface));
        }

        public ConCommon CfgRequestCommon(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(CfgRequestCommon));
            return WrapperFunction<ConCommon, NConCommon>((ref NConCommon native) => cfgRequestCommon(CManagerInterface, out native), codePage);
        }

        public ConTime CfgRequestTime(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(CfgRequestTime));
            return WrapperFunction<ConTime, NConTime>((ref NConTime native) => cfgRequestTime(CManagerInterface, out native), codePage);
        }

        public ConBackup CfgRequestBackup(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(CfgRequestBackup));
            return WrapperFunction<ConBackup, NConBackup>((ref NConBackup native) => cfgRequestBackup(CManagerInterface, out native), codePage);
        }

        public List<ConSymbolGroup> CfgRequestSymbolGroup(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(CfgRequestSymbolGroup));
            return WrapperFunction<ConSymbolGroup, NConSymbolGroup>(ConSymbolGroup.MAX_SEC_GROUP, (ref NConSymbolGroup[] natives) => cfgRequestSymbolGroup(CManagerInterface, natives), codePage);
        }

        public List<ConAccess> CfgRequestAccess(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(CfgRequestAccess));
            return WrapperFunction<ConAccess, NConAccess>((ref int p) => cfgRequestAccess(CManagerInterface, out p), codePage);
        }

        public List<ConDataServer> CfgRequestDataServer(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(CfgRequestDataServer));
            return WrapperFunction<ConDataServer, NConDataServer>((ref int p) => cfgRequestDataServer(CManagerInterface, out p), codePage);
        }

        public List<ConHoliday> CfgRequestHoliday(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(CfgRequestHoliday));
            return WrapperFunction<ConHoliday, NConHoliday>((ref int p) => cfgRequestHoliday(CManagerInterface, out p), codePage);
        }

        public List<ConSymbol> CfgRequestSymbol(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(CfgRequestSymbol));
            return WrapperFunction<ConSymbol, NConSymbol>((ref int p) => cfgRequestSymbol(CManagerInterface, out p), codePage);
        }

        public List<ConGroup> CfgRequestGroup(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(CfgRequestGroup));
            return WrapperFunction<ConGroup, NConGroup>((ref int p) => cfgRequestGroup(CManagerInterface, out p), codePage);
        }

        public List<ConManager> CfgRequestManager(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(CfgRequestManager));
            return WrapperFunction<ConManager, NConManager>((ref int p) => cfgRequestManager(CManagerInterface, out p), codePage);
        }

        public List<ConFeeder> CfgRequestFeeder(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(CfgRequestFeeder));
            return WrapperFunction<ConFeeder, NConFeeder>((ref int p) => cfgRequestFeeder(CManagerInterface, out p), codePage);
        }

        public List<ConLiveUpdate> CfgRequestLiveUpdate(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(CfgRequestLiveUpdate));
            return WrapperFunction<ConLiveUpdate, NConLiveUpdate>((ref int p) => cfgRequestLiveUpdate(CManagerInterface, out p), codePage);
        }

        public List<ConSync> CfgRequestSync(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(CfgRequestSync));
            return WrapperFunction<ConSync, NConSync>((ref int p) => cfgRequestSync(CManagerInterface, out p), codePage);
        }

        public List<ConPluginParam> CfgRequestPlugin(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(CfgRequestPlugin));
            return WrapperFunction<ConPluginParam, NConPluginParam>((ref int p) => cfgRequestPlugin(CManagerInterface, out p), codePage);
        }

        public void CfgUpdateCommon(ConCommon cfg)
        {
            ThrowIfModeNotRequest(nameof(CfgUpdateCommon));

            WrapperFunction(() => cfgUpdateCommon(CManagerInterface, ref cfg.native));
        }

        public void CfgUpdateAccess(ConAccess cfg, int pos)
        {
            ThrowIfModeNotRequest(nameof(CfgUpdateAccess));

            WrapperFunction(() => cfgUpdateAccess(CManagerInterface, ref cfg.native, pos));
        }

        public void CfgUpdateDataServer(ConDataServer cfg, int pos)
        {
            ThrowIfModeNotRequest(nameof(CfgUpdateDataServer));

            WrapperFunction(() => cfgUpdateDataServer(CManagerInterface, ref cfg.native, pos));
        }

        public void CfgUpdateTime(ConTime cfg)
        {
            ThrowIfModeNotRequest(nameof(CfgUpdateTime));

            WrapperFunction(() => cfgUpdateTime(CManagerInterface, ref cfg.native));
        }

        public void CfgUpdateHoliday(ConHoliday cfg, int pos)
        {
            ThrowIfModeNotRequest(nameof(CfgUpdateHoliday));

            WrapperFunction(() => cfgUpdateHoliday(CManagerInterface, ref cfg.native, pos));
        }

        public void CfgUpdateSymbol(ConSymbol cfg)
        {
            ThrowIfModeNotRequest(nameof(CfgUpdateSymbol));

            WrapperFunction(() => cfgUpdateSymbol(CManagerInterface, ref cfg.native));
        }

        public void CfgUpdateSymbolGroup(ConSymbolGroup cfg, int pos)
        {
            ThrowIfModeNotRequest(nameof(CfgUpdateSymbolGroup));

            WrapperFunction(() => cfgUpdateSymbolGroup(CManagerInterface, ref cfg.native, pos));
        }

        public void CfgUpdateGroup(ConGroup cfg)
        {
            ThrowIfModeNotRequest(nameof(CfgUpdateGroup));

            WrapperFunction(() => cfgUpdateGroup(CManagerInterface, ref cfg.native));
        }

        public void CfgUpdateManager(ConManager cfg)
        {
            ThrowIfModeNotRequest(nameof(CfgUpdateManager));

            WrapperFunction(() => cfgUpdateManager(CManagerInterface, ref cfg.native));
        }

        public void CfgUpdateFeeder(ConFeeder cfg)
        {
            ThrowIfModeNotRequest(nameof(CfgUpdateFeeder));

            WrapperFunction(() => cfgUpdateFeeder(CManagerInterface, ref cfg.native));
        }

        public void CfgUpdateBackup(ConBackup cfg)
        {
            ThrowIfModeNotRequest(nameof(CfgUpdateBackup));

            WrapperFunction(() => cfgUpdateBackup(CManagerInterface, ref cfg.native));
        }

        public void CfgUpdateLiveUpdate(ConLiveUpdate cfg)
        {
            ThrowIfModeNotRequest(nameof(CfgUpdateLiveUpdate));

            WrapperFunction(() => cfgUpdateLiveUpdate(CManagerInterface, ref cfg.native));
        }

        public void CfgUpdateSync(ConSync cfg)
        {
            ThrowIfModeNotRequest(nameof(CfgUpdateSync));

            WrapperFunction(() => cfgUpdateSync(CManagerInterface, ref cfg.native));
        }

        public void CfgUpdatePlugin(ConPlugin cfg, PluginCfg parupd, int total)
        {
            ThrowIfModeNotRequest(nameof(CfgUpdatePlugin));

            WrapperFunction(() => cfgUpdatePlugin(CManagerInterface, ref cfg.native, ref parupd.native, total));
        }

        public void CfgDeleteAccess(int pos)
        {
            ThrowIfModeNotRequest(nameof(CfgDeleteAccess));
            WrapperFunction(() => cfgDeleteAccess(CManagerInterface, pos));
        }

        public void CfgDeleteDataServer(int pos)
        {
            ThrowIfModeNotRequest(nameof(CfgDeleteDataServer));
            WrapperFunction(() => cfgDeleteDataServer(CManagerInterface, pos));
        }

        public void CfgDeleteHoliday(int pos)
        {
            ThrowIfModeNotRequest(nameof(CfgDeleteHoliday));
            WrapperFunction(() => cfgDeleteHoliday(CManagerInterface, pos));
        }

        public void CfgDeleteSymbol(int pos)
        {
            ThrowIfModeNotRequest(nameof(CfgDeleteSymbol));
            WrapperFunction(() => cfgDeleteSymbol(CManagerInterface, pos));
        }

        public void CfgDeleteGroup(int pos)
        {
            ThrowIfModeNotRequest(nameof(CfgDeleteGroup));
            WrapperFunction(() => cfgDeleteGroup(CManagerInterface, pos));
        }

        public void CfgDeleteManager(int pos)
        {
            ThrowIfModeNotRequest(nameof(CfgDeleteManager));
            WrapperFunction(() => cfgDeleteManager(CManagerInterface, pos));
        }

        public void CfgDeleteFeeder(int pos)
        {
            ThrowIfModeNotRequest(nameof(CfgDeleteFeeder));
            WrapperFunction(() => cfgDeleteFeeder(CManagerInterface, pos));
        }

        public void CfgDeleteLiveUpdate(int pos)
        {
            ThrowIfModeNotRequest(nameof(CfgDeleteLiveUpdate));
            WrapperFunction(() => cfgDeleteLiveUpdate(CManagerInterface, pos));
        }

        public void CfgDeleteSync(int pos)
        {
            ThrowIfModeNotRequest(nameof(CfgDeleteSync));
            WrapperFunction(() => cfgDeleteSync(CManagerInterface, pos));
        }

        public void CfgShiftAccess(int pos, int shift)
        {
            ThrowIfModeNotRequest(nameof(CfgShiftAccess));
            WrapperFunction(() => cfgShiftAccess(CManagerInterface, pos, shift));
        }

        public void CfgShiftDataServer(int pos, int shift)
        {
            ThrowIfModeNotRequest(nameof(CfgShiftDataServer));
            WrapperFunction(() => cfgShiftDataServer(CManagerInterface, pos, shift));
        }

        public void CfgShiftHoliday(int pos, int shift)
        {
            ThrowIfModeNotRequest(nameof(CfgShiftHoliday));
            WrapperFunction(() => cfgShiftHoliday(CManagerInterface, pos, shift));
        }

        public void CfgShiftSymbol(int pos, int shift)
        {
            ThrowIfModeNotRequest(nameof(CfgShiftSymbol));
            WrapperFunction(() => cfgShiftSymbol(CManagerInterface, pos, shift));
        }

        public void CfgShiftGroup(int pos, int shift)
        {
            ThrowIfModeNotRequest(nameof(CfgShiftGroup));
            WrapperFunction(() => cfgShiftGroup(CManagerInterface, pos, shift));
        }
        public void CfgShiftManager(int pos, int shift)
        {
            ThrowIfModeNotRequest(nameof(CfgShiftManager));
            WrapperFunction(() => cfgShiftManager(CManagerInterface, pos, shift));
        }
        public void CfgShiftFeeder(int pos, int shift)
        {
            ThrowIfModeNotRequest(nameof(CfgShiftFeeder));
            WrapperFunction(() => cfgShiftFeeder(CManagerInterface, pos, shift));
        }
        public void CfgShiftLiveUpdate(int pos, int shift)
        {
            ThrowIfModeNotRequest(nameof(CfgShiftLiveUpdate));
            WrapperFunction(() => cfgShiftLiveUpdate(CManagerInterface, pos, shift));
        }
        public void CfgShiftSync(int pos, int shift)
        {
            ThrowIfModeNotRequest(nameof(CfgShiftSync));
            WrapperFunction(() => cfgShiftSync(CManagerInterface, pos, shift));
        }
        public void CfgShiftPlugin(int pos, int shift)
        {
            ThrowIfModeNotRequest(nameof(CfgShiftPlugin));
            WrapperFunction(() => cfgShiftPlugin(CManagerInterface, pos, shift));
        }

        public List<ServerFeed> SrvFeeders(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(SrvFeeders));
            return WrapperFunction<ServerFeed, NServerFeed>((ref int p) => srvFeeders(CManagerInterface, out p), codePage);
        }

        public string SrvFeederLog(string name)
        {
            ThrowIfModeNotRequest(nameof(SrvFeederLog));
            int total = name.Length;
            return WrapperFunction(() => srvFeederLog(CManagerInterface, name, ref total), (pointer) => { if (pointer != IntPtr.Zero) return Marshal.PtrToStringAnsi(pointer, total); else return string.Empty; });
        }

        protected RateInfoResult ChartRequestTeplate(ChartInfo chart, FuncRef<NChartInfo, uint, int, IntPtr> request)
        {
            if (chart == null)
                throw new ArgumentNullException(nameof(chart));
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var timeInt = (uint)0;
            var result = WrapperFunction<RateInfo, NRateInfo>((ref int p) =>
            {
               return request.Invoke(ref chart.native, ref timeInt, ref p);
            }, chart.CodePage);
            var timeSign = timeInt.ToDateTime();

            return new RateInfoResult {
                Info = result,
                Timesign = timeSign
            };
        }

        public RateInfoResult ChartRequest(ChartInfo chart)
        {
            ThrowIfModeNotRequest(nameof(ChartRequest));

            if (chart == null)
                throw new ArgumentNullException(nameof(chart));

            return ChartRequestTeplate(chart, (ref NChartInfo c, ref uint t, ref int count) => chartRequest(CManagerInterface, ref c, ref t, ref count));
        }

        public void ChartAdd(string symbol, ChartPeriod period, params RateInfo[] rates)
        {
            ThrowIfModeNotRequest(nameof(ChartAdd));

            if (symbol == null)
                throw new ArgumentNullException(nameof(symbol));
            if (rates == null && rates.Length <= 0)
                throw new ArgumentNullException(nameof(rates));

            var natives = rates.ToNatives<NRateInfo, RateInfo>();
            var count = natives.Length;
            WrapperFunction(() => chartAdd(CManagerInterface, symbol, (int)period, natives, ref count));
        }

        public void ChartUpdate(string symbol, ChartPeriod period, RateInfo[] rates)
        {
            ThrowIfModeNotRequest(nameof(ChartUpdate));

            if (symbol == null)
                throw new ArgumentNullException(nameof(symbol));
            if (rates == null && rates.Length <= 0)
                throw new ArgumentNullException(nameof(rates));

            var natives = rates.ToNatives<NRateInfo, RateInfo>();
            var count = natives.Length;
            WrapperFunction(() => chartUpdate(CManagerInterface, symbol, (int)period, natives, ref count));
        }

        public void ChartDelete(string symbol, ChartPeriod period, RateInfo[] rates)
        {
            ThrowIfModeNotRequest(nameof(ChartDelete));

            if (symbol == null)
                throw new ArgumentNullException(nameof(symbol));
            if (rates == null && rates.Length <= 0)
                throw new ArgumentNullException(nameof(rates));

            var natives = rates.ToNatives<NRateInfo, RateInfo>();
            var count = natives.Length;
            WrapperFunction(() => chartDelete(CManagerInterface, symbol, (int)period, natives, ref count));
        }

        public List<PerformanceInfo> PerformanceRequest(DateTime from, int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(PerformanceRequest));

            return WrapperFunction<PerformanceInfo, NPerformanceInfo>((ref int count) => performanceRequest(CManagerInterface, from.ToUInt(), ref count), codePage);
        }

        public List<BackupInfo> BackupInfoUsers(BackupMode mode, int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(BackupInfoUsers));
            return WrapperFunction<BackupInfo, NBackupInfo>((ref int total) => backupInfoUsers(CManagerInterface, (int)mode, ref total), codePage);
        }

        public List<BackupInfo> BackupInfoOrders(BackupMode mode, int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(BackupInfoOrders));
            return WrapperFunction<BackupInfo, NBackupInfo>((ref int total) => backupInfoOrders(CManagerInterface, (int)mode, ref total), codePage);
        }

        public List<UserRecord> BackupRequestUsers(string file, string request, int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(BackupRequestUsers));
            return WrapperFunction<UserRecord, NUserRecord>((ref int total) => backupRequestUsers(CManagerInterface, file, request, ref total), codePage);
        }

        public List<TradeRecord> BackupRequestOrders(string file, string request, int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(BackupRequestOrders));
            return WrapperFunction<TradeRecord, NTradeRecord>((ref int total) => backupRequestOrders(CManagerInterface, file, request, ref total), codePage);
        }

        public void BackupRestoreUsers(UserRecord[] users)
        {
            ThrowIfModeNotRequest(nameof(BackupRestoreUsers));

            if (users == null && users.Length <= 0)
                throw new ArgumentNullException(nameof(users));

            var natives = users.ToNatives<NUserRecord, UserRecord>();
            var count = natives.Length;
            WrapperFunction(() => backupRestoreUsers(CManagerInterface, natives, count));
        }

        public List<TradeRestoreResult> BackupRestoreOrders(TradeRecord[] trades, int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(BackupRestoreOrders));

            if (trades == null && trades.Length <= 0)
                throw new ArgumentNullException(nameof(trades));

            var natives = trades.ToNatives<NTradeRecord, TradeRecord>();
            var count = natives.Length;
            return WrapperFunction<TradeRestoreResult, NTradeRestoreResult>(count, (ref int total) => backupRestoreOrders(CManagerInterface, natives, ref total), codePage);
        }

        public List<UserRecord> AdmUsersRequest(string group, int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(AdmUsersRequest));
            return WrapperFunction<UserRecord, NUserRecord>((ref int count) => admUsersRequest(CManagerInterface, group, ref count), codePage);
        }

        public List<TradeRecord> AdmTradesRequest(string group, int open_only, int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(AdmTradesRequest));

            if (string.IsNullOrWhiteSpace(group))
                throw new ArgumentNullException(nameof(group), $"please enter the account group for 'AdmTradesRequest'");

            return WrapperFunction<TradeRecord, NTradeRecord>((ref int count) => admTradesRequest(CManagerInterface, group, open_only, ref count), codePage);
        }

        public void AdmBalanceFix(int[] logins)
        {
            ThrowIfModeNotRequest(nameof(AdmBalanceFix));
            var total = logins.Count();
            WrapperFunction(() => admBalanceFix(CManagerInterface, logins, total));
        }

        public void AdmTradesDelete(int[] orders)
        {
            ThrowIfModeNotRequest(nameof(AdmTradesDelete));

            if (orders == null || orders.Count() <= 0)
                throw new ArgumentNullException(nameof(orders), $"please enter 'orders' for delete orders");

            var total = orders.Count();
            WrapperFunction(() => admTradesDelete(CManagerInterface, orders, total));
        }

        public void AdmTradeRecordModify(TradeRecord order)
        {
            ThrowIfModeNotRequest(nameof(AdmTradeRecordModify));

            if (order == null)
                throw new ArgumentNullException(nameof(order), $"please enter 'order' for modify");

            WrapperFunction(() => admTradeRecordModify(CManagerInterface, ref order.native));
        }

        public void SymbolsRefresh()
        {
            ThrowIfModeNotRequest(nameof(SymbolsRefresh));
            WrapperFunction(() => symbolsRefresh(CManagerInterface));
        }

        public List<ConSymbol> SymbolsGetAll(int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(SymbolsGetAll));
            return WrapperFunction<ConSymbol, NConSymbol>((ref int count) => symbolsGetAll(CManagerInterface, ref count), codePage);
        }

        public ConSymbol SymbolGet(string symbol, int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(SymbolGet));
            return WrapperFunction<ConSymbol, NConSymbol>((ref NConSymbol conSymbol) => symbolGet(CManagerInterface, symbol, ref conSymbol), codePage);
        }

        public SymbolInfo SymbolInfoGet(string symbol, int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(SymbolInfoGet));
            return WrapperFunction<SymbolInfo, NSymbolInfo>((ref NSymbolInfo si) => symbolInfoGet(CManagerInterface, symbol, out si), codePage);
        }

        public void SymbolAdd(string symbol)
        {
            //ThrowIfModeNotPumping(nameof(SymbolAdd));
            WrapperFunction(() => symbolAdd(CManagerInterface, symbol));
        }

        public void SymbolHide(string symbol)
        {
            //ThrowIfModeNotPumping(nameof(SymbolHide));
            WrapperFunction(() => symbolHide(CManagerInterface, symbol));
        }

        public void SymbolSendTick(string symbol, double bid, double ask)
        {
            ThrowIfModeNotRequest(nameof(SymbolSendTick));

            WrapperFunction(() => symbolSendTick(CManagerInterface, symbol, bid, ask));
        }

        public List<ConGroup> GroupsRequest(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(GroupsRequest));
            return WrapperFunction<ConGroup, NConGroup>((ref int count) => groupsRequest(CManagerInterface, ref count), codePage);
        }

        public void MailSend(MailBox mail, IEnumerable<int> logins)
        {
            ThrowIfModeNotRequest(nameof(MailSend));

            if (mail == null)
                throw new ArgumentNullException(nameof(mail), $"please enter the 'MailBox'. Mailbox, you can specify in the body request");
            if (logins == null || logins.Count() <= 0)
                throw new ArgumentNullException(nameof(mail), $"please enter the 'logins' list to send e-mail messages. logins, you can specify in the query request");

            var loginsNative = logins.ToArray();
            mail.To = logins.Count();
            WrapperFunction(() => mailSend(CManagerInterface, ref mail.native, loginsNative));
        }

        public void NewsSend(NewsTopic news)
        {
            ThrowIfModeNotRequest(nameof(NewsSend));

            if (news == null)
                throw new ArgumentNullException(nameof(news), $"please enter the 'NewsTopic'. NewsTopic, you can specify in the body request");
            if (string.IsNullOrEmpty(news.Topic))
                throw new ArgumentException(nameof(news.Topic), $"please enter the 'Topic'. Topic, you can specify in the body request");

            var size = Marshal.SizeOf<NNewsTopic>();
            WrapperFunction(() => newsSend(CManagerInterface, ref news.native));
        }

        public List<ServerLog> JournalRequest(EnLogMode mode, DateTime from, DateTime to, string filter, int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(JournalRequest));
            return WrapperFunction<ServerLog, NServerLog>((ref int count) => journalRequest(CManagerInterface, mode, from.ToUInt(), to.ToUInt(), filter, ref count), codePage);
        }

        public byte[] JournalRequestByteResult(EnLogMode mode, DateTime from, DateTime to, string filter, int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(JournalRequest));
            return WrapperFunctionByteResult<NServerLog>((ref int count) => journalRequest(CManagerInterface, mode, from.ToUInt(), to.ToUInt(), filter, ref count), codePage);
        }

        public List<UserRecord> UsersRequest(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(UsersRequest));
            return WrapperFunction<UserRecord, NUserRecord>((ref int count) => usersRequest(CManagerInterface, ref count), codePage);
        }

        public List<UserRecord> UserRecordsRequest(IEnumerable<int> logins, int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(UserRecordsRequest));

            if (logins == null)
                throw new ArgumentNullException(nameof(logins));

            return WrapperFunction<UserRecord, NUserRecord>(logins.Count(), (ref int total) => userRecordsRequest(CManagerInterface, logins.ToArray(), ref total), codePage);
        }
        
        public UserRecord UserRecordNew(UserRecord user)
        {
            ThrowIfModeNotRequest(nameof(UserRecordNew));

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrWhiteSpace(user.Group))
                throw new ArgumentNullException(nameof(user.Group));

            WrapperFunction(() => userRecordNew(CManagerInterface, ref user.native));
            return user;
        }

        public void UserRecordUpdate(UserRecord user)
        {
            ThrowIfModeNotRequest(nameof(UserRecordUpdate));

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (user.Login <= 0)
                throw new ArgumentException(nameof(user.Login));

            WrapperFunction(() => userRecordUpdate(CManagerInterface, ref user.native));
        }

        public void UsersGroupOp(GroupCommandInfo info, int[] logins)
        {
            ThrowIfModeNotRequest(nameof(UsersGroupOp));

            if (info == null)
                throw new ArgumentNullException(nameof(info), $"pleae set group commang");

            if (logins == null || logins.Count() <= 0)
                throw new ArgumentNullException(nameof(logins), $"Argument 'logins' must not be  = {logins?.Count()}. pleae set at least 1 login in group command");

            // set count logins in group command
            info.Length = logins.Count();

            switch(info.Command)
            {
                case GroupCommands.LEVERAGE:
                    if (info.Leverage < Int32.MinValue || info.Leverage > Int32.MaxValue)
                        throw new ArgumentOutOfRangeException(nameof(info.Leverage), $"Argument '{info.Leverage}', can not be {info.Leverage}. Enter a value in the range of '> {Int32.MinValue}' and '< {Int32.MaxValue}");
                    break;
                case GroupCommands.SETGROUP:
                    if (string.IsNullOrWhiteSpace(info.NewGroup))
                        throw new ArgumentException(nameof(info.NewGroup), $"Argument '{nameof(info.NewGroup)}', can not be empty");
                    break;
            }

            WrapperFunction(() => usersGroupOp(CManagerInterface, ref info.native, logins));
        }
        
        public void UserPasswordCheck(int login, string password)
        {
            ThrowIfModeNotRequest(nameof(UserPasswordCheck));
            WrapperFunction(() => userPasswordCheck(CManagerInterface, login, password));
        }

        public void UserPasswordSet(int login, string password, bool change_investor = false, bool clean_pubkey = false)
        {
            ThrowIfModeNotRequest(nameof(UserPasswordSet));
            var changeInvestor = change_investor == true ? 1 : 0;
            var cleanPubkey = clean_pubkey == true ? 1 : 0;
            WrapperFunction(() => userPasswordSet(CManagerInterface, login, password, changeInvestor, cleanPubkey));
        }

        public List<OnlineRecord> OnlineRequest(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(OnlineRequest));
            return WrapperFunction<OnlineRecord, NOnlineRecord>((ref int count) => onlineRequest(CManagerInterface, ref count), codePage);
        }

        public TradeTransInfo TradeTransaction(TradeTransInfo trade)
        {
            ThrowIfModeNotRequest(nameof(TradeTransaction));

            WrapperFunction(() => tradeTransaction(CManagerInterface, ref trade.native));
            return trade;
        }

        protected void TradeTransInfoCheck(TradeTransInfo info)
        {
            switch (info.Type)
            {
                case TradeTransactionType.BROKER_BALANCE:
                    if (info.OrderBy <= 0)
                        throw new ArgumentException($"Transaction type '{info.Type}' required '{nameof(info.OrderBy)}' -> put your Account Number", nameof(info.OrderBy));
                    if (info.Cmd == TradeCommand.BALANCE || info.Cmd == TradeCommand.CREDIT)
                        throw new ArgumentException($"Transaction type '{info.Type}' required '{nameof(info.Cmd)}'", nameof(info.Cmd));
                    break;
            }
        }

        public List<TradeRecord> TradesRequest(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(TradesRequest));
            return WrapperFunction<TradeRecord, NTradeRecord>((ref int total) => tradesRequest(CManagerInterface, ref total), codePage);
        }

        public List<TradeRecord> TradeRecordsRequest(IEnumerable<int> orders, int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(TradeRecordsRequest));

            if (orders == null || orders.Count() <= 0)
                throw new ArgumentNullException(nameof(orders), $"must not be null");
            var count = orders.Count();

            return WrapperFunction<TradeRecord, NTradeRecord>(count, (ref int total) => tradeRecordsRequest(CManagerInterface, orders.ToArray(), ref count), codePage);
        }

        public List<TradeRecord> TradesUserHistory(int login, DateTime from, DateTime to, int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(TradesUserHistory));

            if (to == DateTime.MinValue)
                to =  DateTime.Now.AddDays(2);

            var fromInt = from.ToUInt();
            var toInt = to.ToUInt();

            return WrapperFunction<TradeRecord, NTradeRecord>((ref int total) => tradesUserHistory(CManagerInterface, login, fromInt, toInt, ref total), codePage);
        }

        public void TradeCheckStops(TradeTransInfo trade, double price)
        {
            ThrowIfModeNotRequest(nameof(TradeCheckStops));

            if (trade == null)
                throw new ArgumentNullException(nameof(trade), $"must not be null");

            WrapperFunction(() => tradeCheckStops(CManagerInterface, ref trade.native, price));
        }

        public List<TradeRecord> ReportsRequest(ReportGroupRequest reportRequest, int[] logins)
        {
            ThrowIfModeNotRequest(nameof(ReportsRequest));

            if (reportRequest == null)
                throw new ArgumentNullException(nameof(reportRequest), $"must not be null");
            if (logins == null || logins.Count() <= 0)
                throw new ArgumentNullException(nameof(logins), $"must not be null. Please set at least one login");

            reportRequest.Total = logins.Count();

            return WrapperFunction<TradeRecord, NTradeRecord>((ref int total) => reportsRequest(CManagerInterface, ref reportRequest.native, logins, ref total), reportRequest.CodePage);
        }

        public List<DailyReport> DailyReportsRequest(DailyGroupRequest req, int[] logins)
        {
            ThrowIfModeNotRequest(nameof(DailyReportsRequest));

            if (req == null)
                throw new ArgumentNullException(nameof(req), $"must not be null.");
            if (logins == null || logins.Count() <= 0)
                throw new ArgumentNullException(nameof(logins), $"must not be null. Please set at least one login");

            req.Total = logins.Count();

            return WrapperFunction<DailyReport, NDailyReport>((ref int total) => dailyReportsRequest(CManagerInterface, ref req.native, logins, ref total), req.CodePage);
        }

        public string ExternalCommand(string data_in)
        {
            ThrowIfModeNotRequest(nameof(ExternalCommand));

            if (string.IsNullOrEmpty(data_in))
                throw new ArgumentNullException(nameof(data_in), $"must not be null.");

            string data_out = string.Empty;
            var size_out = 0;
            WrapperFunction(() => externalCommand(CManagerInterface, data_in, data_in.Length, ref data_out, ref size_out));

            return data_out;
        }

        public void PluginUpdate(ConPluginParam plugin)
        {
            ThrowIfModeNotPumping(nameof(PluginUpdate));

            if (plugin == null)
                throw new ArgumentNullException(nameof(plugin), $"must not be null.");
            if (plugin.Plugin == null)
                throw new ArgumentNullException(nameof(plugin.Plugin), $"must not be null.");
            if (plugin.Parameters == null)
                throw new ArgumentNullException(nameof(plugin.Plugin), $"must not be null.");

            WrapperFunction(() => pluginUpdate(CManagerInterface, ref plugin.native));
        }

        public List<ConGroup> GroupsGet(int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(GroupsGet));
            return WrapperFunction<ConGroup, NConGroup>((ref int total) => groupsGet(CManagerInterface, total), codePage);
        }

        public ConGroup GroupRecordGet(string name, int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(GroupRecordGet));

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name), $"must not be null.");

            return WrapperFunction<ConGroup, NConGroup>((ref NConGroup native) => groupRecordGet(CManagerInterface, name, ref native), codePage);
        }

        public List<SymbolInfo> SymbolInfoUpdated(int max_info, int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(SymbolInfoUpdated));
            SetDefaultCodePageIfZero(ref codePage);

            var natives = new NSymbolInfo[max_info];
            var size = Marshal.SizeOf<NSymbolInfo>();
            var count = symbolInfoUpdated(CManagerInterface, natives, max_info);

            return natives.ToEntities<NSymbolInfo, SymbolInfo>(codePage: codePage, count: count);
        }

        public List<UserRecord> UsersGet(int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(UsersGet));
            return WrapperFunction<UserRecord, NUserRecord>((ref int total) => usersGet(CManagerInterface, ref total), codePage);
        }

        public UserRecord UserRecordGet(int login, int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(UserRecordGet));
            return WrapperFunction<UserRecord, NUserRecord>((ref NUserRecord native) => userRecordGet(CManagerInterface, login, ref native), codePage);
        }

        public List<OnlineRecord> OnlineGet(int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(OnlineGet));
            return WrapperFunction<OnlineRecord, NOnlineRecord>((ref int total) => onlineGet(CManagerInterface, ref total), codePage);
        }

        public OnlineRecord OnlineRecordGet(int login, int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(OnlineRecordGet));
            return WrapperFunction<OnlineRecord, NOnlineRecord>((ref NOnlineRecord native) => onlineRecordGet(CManagerInterface, login, ref native), codePage);
        }

        public List<TradeRecord> TradesGet(int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(TradesGet));
            return WrapperFunction<TradeRecord, NTradeRecord>((ref int total) => tradesGet(CManagerInterface, ref total), codePage);
        }

        public List<TradeRecord> TradesGetBySymbol(string symbol, int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(TradesGetBySymbol));
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentNullException(nameof(symbol), $"must not be null.");

            return WrapperFunction<TradeRecord, NTradeRecord>((ref int total) => tradesGetBySymbol(CManagerInterface, symbol, ref total), codePage);
        }

        public List<TradeRecord> TradesGetByLogin(int login, string group, int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(TradesGetByLogin));
            return WrapperFunction<TradeRecord, NTradeRecord>((ref int total) => tradesGetByLogin(CManagerInterface, login, group, ref total), codePage);
        }

        public List<TradeRecord> TradesGetByMarket(int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(TradesGetByMarket));
            return WrapperFunction<TradeRecord, NTradeRecord>((ref int total) => tradesGetByMarket(CManagerInterface, ref total), codePage);
        }

        public TradeRecord TradeRecordGet(int order, int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(TradeRecordGet));
            return WrapperFunction<TradeRecord, NTradeRecord>((ref NTradeRecord native) => tradeRecordGet(CManagerInterface, order, ref native), codePage);
        }

        public void TradeClearRollback(int order)
        {
            ThrowIfModeNotPumping(nameof(TradeClearRollback));
            WrapperFunction(() => tradeClearRollback(CManagerInterface, order));
        }

        public List<MarginLevel> MarginsGet(int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(MarginsGet));
            return WrapperFunction<MarginLevel, NMarginLevel>((ref int total) => marginsGet(CManagerInterface, ref total), codePage);
        }

        public MarginLevel MarginLevelGet(int login, string group, int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(MarginLevelGet));
            return WrapperFunction<MarginLevel, NMarginLevel>((ref NMarginLevel native) => marginLevelGet(CManagerInterface, login, group, ref native), codePage);
        }

        public List<RequestInfo> RequestsGet(int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(RequestsGet));
            return WrapperFunction<RequestInfo, NRequestInfo>((ref int total) => requestsGet(CManagerInterface, ref total), codePage);
        }

        public RequestInfo RequestInfoGet(int pos, int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(RequestInfoGet));
            return WrapperFunction<RequestInfo, NRequestInfo>((ref NRequestInfo native) => requestInfoGet(CManagerInterface, pos, ref native), codePage);
        }

        public List<ConPlugin> PluginsGet(int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(PluginsGet));
            return WrapperFunction<ConPlugin, NConPlugin>((ref int total) => pluginsGet(CManagerInterface, ref total), codePage);
        }

        public ConPluginParam PluginParamGet(int pos, int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(PluginParamGet));
            return WrapperFunction<ConPluginParam, NConPluginParam>((ref NConPluginParam native) => pluginParamGet(CManagerInterface, pos, ref native), codePage);
        }

        public string MailLast()
        {
            ThrowIfModeNotPumping(nameof(MailLast));
            var result = string.Empty;
            var length = 0;
            WrapperFunction(() => mailLast(CManagerInterface, ref result, ref length));
            return result;
        }

        public List<NewsTopic> NewsGet(int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(NewsGet));
            return WrapperFunction<NewsTopic, NNewsTopic>((ref int total) => newsGet(CManagerInterface, ref total), codePage);
        }

        public int NewsTotal()
        {
            ThrowIfModeNotPumping(nameof(NewsTotal));
            return newsTotal(CManagerInterface);
        }

        public NewsTopic NewsTopicGet(int pos, int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(NewsTopicGet));
            return WrapperFunction<NewsTopic, NNewsTopic>((ref NNewsTopic native) => newsTopicGet(CManagerInterface, pos, ref native), codePage);
        }

        public void NewsBodyRequest(UInt32 key)
        {
            ThrowIfModeNotPumping(nameof(NewsBodyRequest));
            newsBodyRequest(CManagerInterface, key);
        }

        protected IntPtr NewsBodyGet(UInt32 key)
        {
            ThrowIfModeNotPumping(nameof(NewsBodyGet));

            return newsBodyGet(CManagerInterface, key);
        }

        public string NewsBodyGet(UInt32 key, string languageName)
        {
            var bodyInt = NewsBodyGet(key);
            if (bodyInt == IntPtr.Zero)
                return string.Empty;

            var codePage = LocaleMapper.LocaleNameToAnsiCodePage(languageName);
            var encoding = System.Text.Encoding.GetEncoding(codePage);
            var strLen = bodyInt.Strlen();
            var bytes = bodyInt.ToByteArray(strLen);
            var body = encoding.GetString(bytes);
            memFree(CManagerInterface, bodyInt);
            return body;
        }

        public void DealerSwitch(MTAPI_NOTIFY_FUNC pfnFunc, IntPtr destwnd, UInt32 eventmsg)
        {
            if (pfnFunc == null)
                throw new ArgumentNullException(nameof(pfnFunc), $"Argument {pfnFunc} must not be null");

            this.postLoginAction = () =>
            {
                WrapperFunction(() => dealerSwitch(CManagerInterface, pfnFunc, destwnd, eventmsg));
                mode = MT4Mode.dealing;
            };
            this.postLoginAction?.Invoke();
        }

        public RequestInfo DealerRequestGet(int codePage = 0)
        {
            ThrowIfModeNotDealing(nameof(DealerRequestGet));
            return WrapperFunction<RequestInfo, NRequestInfo>((ref NRequestInfo native) => dealerRequestGet(CManagerInterface, ref native), codePage);
        }

        public void DealerSend(RequestInfo info, bool requote, int mode)
        {
            ThrowIfModeNotDealing(nameof(DealerSend));

            WrapperFunction(() => dealerSend(CManagerInterface, ref info.native, requote == true ? 1 : 0, mode));
        }

        public void DealerReject(int id)
        {
            ThrowIfModeNotDealing(nameof(DealerReject));
            WrapperFunction(() => dealerReject(CManagerInterface, id));
        }

        public void DealerReset(int id)
        {
            ThrowIfModeNotDealing(nameof(DealerReset));
            WrapperFunction(() => dealerReset(CManagerInterface, id));
        }

        public List<TickInfo> TickInfoLast(string symbol, int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(TickInfoLast));
            return WrapperFunction<TickInfo, NTickInfo>((ref int total) => tickInfoLast(CManagerInterface, symbol, ref total), codePage);
        }

        public List<ConSymbolGroup> SymbolsGroupsGet(int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(SymbolsGroupsGet));
            return WrapperFunction<ConSymbolGroup, NConSymbolGroup>(ConSymbolGroup.MAX_SEC_GROUP, (ref NConSymbolGroup[] natives) => symbolsGroupsGet(CManagerInterface, natives), codePage);
        }

        public List<MailBox> MailsRequest(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(MailsRequest));
            return WrapperFunction<MailBox, NMailBox>((ref int total) => mailsRequest(CManagerInterface, ref total), codePage);
        }

        public List<SymbolSummary> SummaryGetAll(int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(SummaryGetAll));
            return WrapperFunction<SymbolSummary, NSymbolSummary>((ref int total) => summaryGetAll(CManagerInterface, ref total), codePage);
        }

        public SymbolSummary SummaryGet(string symbol, int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(SummaryGet));
            return WrapperFunction<SymbolSummary, NSymbolSummary>((ref NSymbolSummary native) => summaryGet(CManagerInterface, symbol, ref native), codePage);
        }

        public SymbolSummary SummaryGetByCount(int symbol, int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(SummaryGetByCount));
            return WrapperFunction<SymbolSummary, NSymbolSummary>((ref NSymbolSummary native) => summaryGetByCount(CManagerInterface, symbol, ref native), codePage);
        }

        public SymbolSummary SummaryGetByType(int securityType, int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(SummaryGetByType));
            return WrapperFunction<SymbolSummary, NSymbolSummary>((ref NSymbolSummary native) => summaryGetByType(CManagerInterface, securityType, ref native), codePage);
        }

        public string SummaryCurrency(int maxchars = 12)
        {
            ThrowIfModeNotPumping(nameof(SummaryCurrency));
            var summary = new char[maxchars];
            WrapperFunction(() => summaryCurrency(CManagerInterface, summary, maxchars));
            
            return string.Join(string.Empty, summary.TakeWhile(p => p != '\0'));
        }

        public List<ExposureValue> ExposureGet(int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(ExposureGet));
            return WrapperFunction<ExposureValue, NExposureValue>((ref int total) => exposureGet(CManagerInterface, ref total), codePage);
        }

        public ExposureValue ExposureValueGet(string cur, int codePage = 0)
        {
            ThrowIfModeNotPumping(nameof(ExposureValueGet));
            return WrapperFunction<ExposureValue, NExposureValue>((ref NExposureValue native) => exposureValueGet(CManagerInterface, cur, ref native), codePage);
        }

        public MarginLevel MarginLevelRequest(int login, int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(MarginLevelRequest));
            return WrapperFunction<MarginLevel, NMarginLevel>((ref NMarginLevel native) => marginLevelRequest(CManagerInterface, login, ref native), codePage);
        }

        public bool HistoryCorrect(string symbol)
        {
            ThrowIfModeNotRequest(nameof(HistoryCorrect));
            int updated = 0;
            WrapperFunction(() => historyCorrect(CManagerInterface, symbol, ref updated));
            return updated == 1 ? true : false;
        }

        public List<TickRecord> TicksRequest(TickRequest request)
        {
            ThrowIfModeNotRequest(nameof(TicksRequest));

            return WrapperFunction<TickRecord, NTickRecord>((ref int total) => ticksRequest(CManagerInterface, ref request.native, ref total), request.CodePage);
        }

        public int[] UsersSnapshot()
        {
            ThrowIfModeNotRequest(nameof(UsersSnapshot));
            int total = 0;
            return WrapperFunction(() => usersSnapshot(CManagerInterface, ref total), (pointer) => pointer.ToArrayStruct<int>(total));
        }

        public int[] TradesSnapshot()
        {
            ThrowIfModeNotRequest(nameof(TradesSnapshot));
            int total = 0;
            return WrapperFunction(() => tradesSnapshot(CManagerInterface, ref total), (pointer) => pointer.ToArrayStruct<int>(total));
        }

        public void TradeCalcProfit(TradeRecord trade)
        {
            ThrowIfModeNotPumping(nameof(TradeCalcProfit));

            WrapperFunction(() => tradeCalcProfit(CManagerInterface, ref trade.native));
        }

        public void SymbolChange(SymbolProperties prop)
        {
            ThrowIfModeNotRequest(nameof(SymbolChange));

            WrapperFunction(() => symbolChange(CManagerInterface, ref prop.native));
        }

        public int BytesSent()
        {
            ThrowIfModeNotRequest(nameof(BytesSent));
            return WrapperFunction(() => bytesSent(CManagerInterface));
        }

        public int BytesReceived()
        {
            ThrowIfModeNotRequest(nameof(BytesReceived));
            return WrapperFunction(() => bytesReceived(CManagerInterface));
        }

        public ConCommon ManagerCommon(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(ManagerCommon));
            return WrapperFunction<ConCommon, NConCommon>((ref NConCommon native) => managerCommon(CManagerInterface, out native), codePage);
        }


        public void LogsOut(int code, string source, string msg)
        {
            ThrowIfModeNotRequest(nameof(LogsOut));
            logsOut(CManagerInterface, code, source, msg);
        }

        public void LogsMode(EnLogMode mode)
        {
            ThrowIfModeNotRequest(nameof(LogsMode));
            logsMode(CManagerInterface, mode);
        }

        public void LicenseCheck(string license_name)
        {
            ThrowIfModeNotRequest(nameof(LicenseCheck));
            WrapperFunction(() => licenseCheck(CManagerInterface, license_name));
        }

        public List<ConGatewayAccount> CfgRequestGatewayAccount(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(CfgRequestGatewayAccount));
            return WrapperFunction<ConGatewayAccount, NConGatewayAccount>((ref int total) => cfgRequestGatewayAccount(CManagerInterface, ref total), codePage);
        }
        public List<ConGatewayMarkup> CfgRequestGatewayMarkup(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(CfgRequestGatewayMarkup));
            return WrapperFunction<ConGatewayMarkup, NConGatewayMarkup>((ref int total) => cfgRequestGatewayMarkup(CManagerInterface, ref total), codePage);
        }
        public List<ConGatewayRule> CfgRequestGatewayRule(int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(CfgRequestGatewayRule));
            return WrapperFunction<ConGatewayRule, NConGatewayRule>((ref int total) => cfgRequestGatewayRule(CManagerInterface, ref total), codePage);
        }
        public void CfgUpdateGatewayAccount(ConGatewayAccount cfg)
        {
            ThrowIfModeNotRequest(nameof(CfgUpdateGatewayAccount));
            

            WrapperFunction(() => cfgUpdateGatewayAccount(CManagerInterface, ref cfg.native));
        }
        public void CfgUpdateGatewayMarkup(ConGatewayMarkup cfg)
        {
            ThrowIfModeNotRequest(nameof(CfgUpdateGatewayMarkup));
            

            WrapperFunction(() => cfgUpdateGatewayMarkup(CManagerInterface, ref cfg.native));
        }
        public void CfgUpdateGatewayRule(ConGatewayRule cfg)
        {
            ThrowIfModeNotRequest(nameof(CfgUpdateGatewayRule));
            

            WrapperFunction(() => cfgUpdateGatewayRule(CManagerInterface, ref cfg.native));
        }
        public void CfgDeleteGatewayAccount(int pos)
        {
            ThrowIfModeNotRequest(nameof(CfgDeleteGatewayAccount));

            WrapperFunction(() => cfgDeleteGatewayAccount(CManagerInterface, pos));
        }
        public void CfgDeleteGatewayMarkup(int pos)
        {
            ThrowIfModeNotRequest(nameof(CfgDeleteGatewayMarkup));

            WrapperFunction(() => cfgDeleteGatewayMarkup(CManagerInterface, pos));
        }
        public void CfgDeleteGatewayRule(int pos)
        {
            ThrowIfModeNotRequest(nameof(CfgDeleteGatewayRule));
            WrapperFunction(() => cfgDeleteGatewayRule(CManagerInterface, pos));
        }
        public void CfgShiftGatewayAccount(int pos, int shift)
        {
            ThrowIfModeNotRequest(nameof(CfgShiftGatewayAccount));
            WrapperFunction(() => cfgShiftGatewayAccount(CManagerInterface, pos, shift));
        }
        public void CfgShiftGatewayMarkup(int pos, int shift)
        {
            ThrowIfModeNotRequest(nameof(CfgShiftGatewayMarkup));
            WrapperFunction(() => cfgShiftGatewayMarkup(CManagerInterface, pos, shift));
        }
        public void CfgShiftGatewayRule(int pos, int shift)
        {
            ThrowIfModeNotRequest(nameof(CfgShiftGatewayRule));
            WrapperFunction(() => cfgShiftGatewayRule(CManagerInterface, pos, shift));
        }

        public List<BalanceDiff> AdmBalanceCheck(int[] logins, int codePage = 0)
        {
            ThrowIfModeNotRequest(nameof(AdmBalanceCheck));

            var total = logins.Length;
            return WrapperFunction(()
                => admBalanceCheck(CManagerInterface, logins, ref total),
      (pointer) => ToManagedList<BalanceDiff, NBalanceDiff>(pointer, total, (p)
                    => p.ToStruct<NBalanceDiff>().ToEntity<NBalanceDiff, BalanceDiff>(codePage)));
        }

        public int NotificationsSend(string metaquotes_ids, string message)
        {
            ThrowIfModeNotRequest(nameof(NotificationsSend));

            if (string.IsNullOrWhiteSpace(metaquotes_ids))
                throw new ArgumentNullException(nameof(metaquotes_ids), $"Argument 'metaquotes_ids' must not be null");

            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message), $"Argument 'message' must not be null");

            if (message.Length > 1024)
                throw new ArgumentException(nameof(message), $"Argument 'message' cannot be greater than 1024 characters");

            var metaquotes_ids_ = new message_s()
            {
                message_ = metaquotes_ids
            };
            var message_ = new message_s()
            {
                message_ = message
            };

            return WrapperFunction(() => notificationsSend1(CManagerInterface, metaquotes_ids_, message_));
        }

        public int NotificationsSend(int[] logins, string message)
        {
            ThrowIfModeNotRequest(nameof(NotificationsSend));

            if (logins == null || logins.Count() <= 0)
                throw new ArgumentNullException(nameof(logins), $"Argument 'logins' must not be null");

            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message), $"Argument 'message' must not be null");

            if (message.Length > 1024)
                throw new ArgumentException(nameof(message), $"Argument 'message' cannot be greater than 1024 characters");

            message = message + '\0';
            var logins_total = logins.Count();
            var text = new message_s()
            {
                message_ = message
            };
            var message_builder = new message_byte()
            {
                message_ = MT4Helper.GetBytesFromStringWithZero(System.Text.Encoding.Unicode, message, 2048)
            };

            var ptr = IntPtr.Zero;
            var ptr_to_ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.AllocHGlobal(sizeof(byte) * 2048);
                Marshal.Copy(message_builder.message_, 0, ptr, 2048);

                return WrapperFunction(() => notificationsSend2(CManagerInterface, logins, ref logins_total, message_builder.message_));
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
                // Marshal.FreeHGlobal(ptr_to_ptr);
            }
        }

        public void RequestSwitch()
        {
            // нет явного способа перейти в режим прямого подключения. Поэтому для сброса режима пампинга вызываю функцию ping
            Ping();
            mode = MT4Mode.request;
            this.postLoginAction = null;
            pumpingCallback = null;
            pumpingCallbackEx = null;
        }

        public MTAPI_NOTIFY_FUNC PumpingSwitch(Action<PumpingNotificationCode> func, IntPtr destwnd, UInt32 eventmsg, PumpingFlags flags)
        {
            var callBack = new MTAPI_NOTIFY_FUNC(func);
            this.postLoginAction = () =>
            {
                WrapperFunction(() => pumpingSwitch(CManagerInterface, callBack, destwnd, eventmsg, flags));
                mode = MT4Mode.pumping;
            };
            this.postLoginAction?.Invoke();
            return callBack;
        }

        public void PumpingSwitch(PumpingFlags flags)
        {
            pumpingCallback = PumpingSwitch(PumpingCallback, IntPtr.Zero, 0, flags);
        }

        public MTAPI_NOTIFY_FUNC_EX PumpingSwitchEx(Action<PumpingNotificationCode, PumpingUpdateType, IntPtr, object> func, PumpingFlags flags, object param)
        {
            var callBack = new MTAPI_NOTIFY_FUNC_EX(func);
            this.postLoginAction = () =>
            {
                WrapperFunction(() => pumpingSwitchEx(CManagerInterface, callBack, flags, param));
                mode = MT4Mode.pumpingEx;
            };
            this.postLoginAction();
            return callBack;
        }

        public void PumpingSwitchEx(PumpingFlags flags, object param)
        {
            pumpingCallbackEx = PumpingSwitchEx(PumpingExCallback, flags, param);
        }

        protected virtual void PumpingCallback(PumpingNotificationCode code)
        {
            int defaultCodePage = options.codePage;
            switch (code)
            {
                case PumpingNotificationCode.START_PUMPING:
                    PUMP_START_PUMPING?.Invoke(0);
                    break;
                case PumpingNotificationCode.UPDATE_SYMBOLS:
                    break;
                case PumpingNotificationCode.UPDATE_GROUPS:
                    break;
                case PumpingNotificationCode.UPDATE_USERS:
                    break;
                case PumpingNotificationCode.UPDATE_ONLINE:
                    PUMP_UPDATE_ONLINE?.Invoke(PumpingUpdateType.ADD, login: 0, param: 0);
                    break;
                case PumpingNotificationCode.UPDATE_BIDASK:
                    PUMP_UPDATE_BIDASK?.Invoke(0);
                    break;
                case PumpingNotificationCode.UPDATE_NEWS:
                    break;
                case PumpingNotificationCode.UPDATE_NEWS_BODY:
                    PUMP_UPDATE_NEWS_BODY?.Invoke(PumpingUpdateType.UPDATE, 0);
                    break;
                case PumpingNotificationCode.UPDATE_MAIL:
                    break;
                case PumpingNotificationCode.UPDATE_TRADES:
                    break;
                case PumpingNotificationCode.UPDATE_REQUESTS:
                    break;
                case PumpingNotificationCode.UPDATE_PLUGINS:
                    PUMP_UPDATE_PLUGINS?.Invoke(PumpingUpdateType.UPDATE, 0);
                    break;
                case PumpingNotificationCode.UPDATE_ACTIVATION:
                    PUMP_UPDATE_ACTIVATION?.Invoke(PumpingUpdateType.UPDATE, 0);
                    break;
                case PumpingNotificationCode.UPDATE_MARGINCALL:
                    PUMP_UPDATE_MARGINCALL?.Invoke(PumpingUpdateType.UPDATE, 0);
                    break;
                case PumpingNotificationCode.STOP_PUMPING:
                    PUMP_STOP_PUMPING?.Invoke(0);
                    break;
                case PumpingNotificationCode.PING:
                    PUMP_PING?.Invoke(0);
                    break;
                case PumpingNotificationCode.UPDATE_NEWS_NEW:
                    break;
            }
        }

        protected virtual void PumpingExCallback(PumpingNotificationCode code, PumpingUpdateType type, IntPtr data, object param)
        {
            int defaultCodePage = options.codePage;
            switch (code)
            {
                case PumpingNotificationCode.START_PUMPING:
                    PUMP_START_PUMPING?.Invoke(param);
                    break;
                case PumpingNotificationCode.UPDATE_SYMBOLS:
                    ConSymbol symbol = null;
                    if (data != IntPtr.Zero)
                    {
                        var nConSymbol = data.ToStruct<NConSymbol>();
                        symbol = nConSymbol.ToEntity<NConSymbol, ConSymbol>(defaultCodePage);
                        PUMP_UPDATE_SYMBOLS?.Invoke(type, symbol, param);
                    }
                    break;
                case PumpingNotificationCode.UPDATE_GROUPS:
                    ConGroup group = null;
                    if (data != IntPtr.Zero)
                    {
                        var nConGroup = data.ToStruct<NConGroup>();
                        group = nConGroup.ToEntity<NConGroup, ConGroup>(defaultCodePage);
                        PUMP_UPDATE_GROUPS?.Invoke(type, group, param);
                    }
                    break;
                case PumpingNotificationCode.UPDATE_USERS:
                    UserRecord user = null;
                    if (data != IntPtr.Zero)
                    {
                        var nUserRecord = data.ToStruct<NUserRecord>();
                        user = nUserRecord.ToEntity<NUserRecord, UserRecord>(defaultCodePage);
                        PUMP_UPDATE_USERS?.Invoke(type, user, param);
                    }
                    break;
                case PumpingNotificationCode.UPDATE_ONLINE:
                    var login = 0;
                    if (data != IntPtr.Zero)
                    {
                        login = data.ToInt();
                        PUMP_UPDATE_ONLINE?.Invoke(type, login, param);
                    }
                    break;
                case PumpingNotificationCode.UPDATE_BIDASK:
                    PUMP_UPDATE_BIDASK?.Invoke(param);
                    break;
                case PumpingNotificationCode.UPDATE_NEWS:
                    NewsTopic news = null;
                    if (data != IntPtr.Zero)
                    {
                        var nStruct = data.ToStruct<NNewsTopic>();
                        news = nStruct.ToEntity<NNewsTopic, NewsTopic>(defaultCodePage);
                        this.PUMP_UPDATE_NEWS?.Invoke(type, news, param);
                    }
                    break;
                case PumpingNotificationCode.UPDATE_NEWS_BODY:
                    PUMP_UPDATE_NEWS_BODY?.Invoke(type, param);
                    break;
                case PumpingNotificationCode.UPDATE_MAIL:
                    MailBox mail = null;
                    if (data != IntPtr.Zero)
                    {
                        var nStruct = data.ToStruct<NMailBox>();
                        mail = nStruct.ToEntity<NMailBox, MailBox>(defaultCodePage);
                        PUMP_UPDATE_MAIL?.Invoke(type, mail, param);
                    }
                    break;
                case PumpingNotificationCode.UPDATE_TRADES:
                    TradeRecord trade = null;
                    if (data != IntPtr.Zero)
                    {
                        var nTradeRecord = data.ToStruct<NTradeRecord>();
                        trade = nTradeRecord.ToEntity<NTradeRecord, TradeRecord>(defaultCodePage);
                        PUMP_UPDATE_TRADES?.Invoke(type, trade, param);
                   }
                    break;
                case PumpingNotificationCode.UPDATE_REQUESTS:
                    RequestInfo request = null;
                    if (data != IntPtr.Zero)
                    {
                        var nRequestInfo = data.ToStruct<NRequestInfo>();
                        request = nRequestInfo.ToEntity<NRequestInfo, RequestInfo>(defaultCodePage);
                        PUMP_UPDATE_REQUESTS?.Invoke(type, request, param);
                    }
                    break;
                case PumpingNotificationCode.UPDATE_PLUGINS:
                    PUMP_UPDATE_PLUGINS?.Invoke(type, param);
                    break;
                case PumpingNotificationCode.UPDATE_ACTIVATION:
                    PUMP_UPDATE_ACTIVATION?.Invoke(type, param);
                    break;
                case PumpingNotificationCode.UPDATE_MARGINCALL:
                    PUMP_UPDATE_MARGINCALL?.Invoke(type, param);
                    break;
                case PumpingNotificationCode.STOP_PUMPING:
                    PUMP_STOP_PUMPING?.Invoke(param);
                    break;
                case PumpingNotificationCode.PING:
                    PUMP_PING?.Invoke(param);
                    break;
                case PumpingNotificationCode.UPDATE_NEWS_NEW:
                    NewsTopicNew newsNew = null;
                    if (data != IntPtr.Zero)
                    {
                        var nRequestInfo = data.ToStruct<NNewsTopicNew>();
                        newsNew = nRequestInfo.ToEntity<NNewsTopicNew, NewsTopicNew>(defaultCodePage);
                        PUMP_UPDATE_NEWS_NEW?.Invoke(type, newsNew, param);
                    }
                    break;
            }
        }
    }
}