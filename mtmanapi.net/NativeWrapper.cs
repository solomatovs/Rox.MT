using System;
using System.Text;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    /// <summary>
    /// Содержит номера функций в библиотеки mt4manapi.dll
    /// </summary>
    public enum FunctionIndex
    {
        QueryInterface = 0,
        AddRef = 1,
        Release = 2,
        MemFree = 3,
        ErrorDescription = 4,
        WorkingDirectory = 5,
        Connect = 6,
        Disconnect = 7,
        IsConnected = 8,
        Login = 9,
        LoginSecured = 10,
        KeysSend = 11,
        Ping = 12,
        PasswordChange = 13,
        ManagerRights = 14,
        SrvRestart = 15,
        SrvChartsSync = 16,
        SrvLiveUpdateStart = 17,
        SrvFeedsRestart = 18,
        CfgRequestCommon = 19,
        CfgRequestTime = 20,
        CfgRequestBackup = 21,
        CfgRequestSymbolGroup = 22,
        CfgRequestAccess = 23,
        CfgRequestDataServer = 24,
        CfgRequestHoliday = 25,
        CfgRequestSymbol = 26,
        CfgRequestGroup = 27,
        CfgRequestManager = 28,
        CfgRequestFeeder = 29,
        CfgRequestLiveUpdate = 30,
        CfgRequestSync = 31,
        CfgRequestPlugin = 32,
        CfgUpdateCommon = 33,
        CfgUpdateAccess = 34,
        CfgUpdateDataServer = 35,
        CfgUpdateTime = 36,
        CfgUpdateHoliday = 37,
        CfgUpdateSymbol = 38,
        CfgUpdateSymbolGroup = 39,
        CfgUpdateGroup = 40,
        CfgUpdateManager = 41,
        CfgUpdateFeeder = 42,
        CfgUpdateBackup = 43,
        CfgUpdateLiveUpdate = 44,
        CfgUpdateSync = 45,
        CfgUpdatePlugin = 46,
        CfgDeleteAccess = 47,
        CfgDeleteDataServer = 48,
        CfgDeleteHoliday = 49,
        CfgDeleteSymbol = 50,
        CfgDeleteGroup = 51,
        CfgDeleteManager = 52,
        CfgDeleteFeeder = 53,
        CfgDeleteLiveUpdate = 54,
        CfgDeleteSync = 55,
        CfgShiftAccess = 56,
        CfgShiftDataServer = 57,
        CfgShiftHoliday = 58,
        CfgShiftSymbol = 59,
        CfgShiftGroup = 60,
        CfgShiftManager = 61,
        CfgShiftFeeder = 62,
        CfgShiftLiveUpdate = 63,
        CfgShiftSync = 64,
        CfgShiftPlugin = 65,
        SrvFeeders = 66,
        SrvFeederLog = 67,
        ChartRequestObsolete = 68,
        ChartAddObsolete = 69,
        ChartUpdateObsolete = 70,
        ChartDeleteObsolete = 71,
        PerformanceRequest = 72,
        BackupInfoUsers = 73,
        BackupInfoOrders = 74,
        BackupRequestUsers = 75,
        BackupRequestOrders = 76,
        BackupRestoreUsers = 77,
        BackupRestoreOrders = 78,
        AdmUsersRequest = 79,
        AdmTradesRequest = 80,
        AdmBalanceCheckObsolete = 81,
        AdmBalanceFix = 82,
        AdmTradesDelete = 83,
        AdmTradeRecordModify = 84,
        SymbolsRefresh = 85,
        SymbolsGetAll = 86,
        SymbolGet = 87,
        SymbolInfoGet = 88,
        SymbolAdd = 89,
        SymbolHide = 90,
        SymbolChangeObsolete = 91,
        SymbolSendTick = 92,
        GroupsRequest = 93,
        MailSend = 94,
        NewsSend = 95,
        JournalRequest = 96,
        UsersRequest = 97,
        UserRecordsRequest = 98,
        UserRecordNew = 99,
        UserRecordUpdate = 100,
        UsersGroupOp = 101,
        UserPasswordCheck = 102,
        UserPasswordSet = 103,
        OnlineRequest = 104,
        TradeTransaction = 105,
        TradesRequest = 106,
        TradeRecordsRequest = 107,
        TradesUserHistory = 108,
        TradeCheckStops = 109,
        ReportsRequest = 110,
        DailyReportsRequest = 111,
        ExternalCommand = 112,
        PluginUpdate = 113,
        PumpingSwitch = 114,
        GroupsGet = 115,
        GroupRecordGet = 116,
        SymbolInfoUpdated = 117,
        UsersGet = 118,
        UserRecordGet = 119,
        OnlineGet = 120,
        OnlineRecordGet = 121,
        TradesGet = 122,
        TradesGetBySymbol = 123,
        TradesGetByLogin = 124,
        TradesGetByMarket = 125,
        TradeRecordGet = 126,
        TradeClearRollback = 127,
        MarginsGet = 128,
        MarginLevelGet = 129,
        RequestsGet = 130,
        RequestInfoGet = 131,
        PluginsGet = 132,
        PluginParamGet = 133,
        MailLast = 134,
        NewsGet = 135,
        NewsTotal = 136,
        NewsTopicGet = 137,
        NewsBodyRequest = 138,
        NewsBodyGet = 139,
        DealerSwitch = 140,
        DealerRequestGet = 141,
        DealerSend = 142,
        DealerReject = 143,
        DealerReset = 144,
        TickInfoLast = 145,
        SymbolsGroupsGet = 146,
        ServerTime = 147,
        MailsRequest = 148,
        SummaryGetAll = 149,
        SummaryGet = 150,
        SummaryGetByCount = 151,
        SummaryGetByType = 152,
        SummaryCurrency = 153,
        ExposureGet = 154,
        ExposureValueGet = 155,
        MarginLevelRequest = 156,
        HistoryCorrect = 157,
        ChartRequest = 158,
        ChartAdd = 159,
        ChartUpdate = 160,
        ChartDelete = 161,
        TicksRequest = 162,
        PumpingSwitchEx = 163,
        UsersSyncStart = 164,
        UsersSyncRead = 165,
        UsersSnapshot = 166,
        TradesSyncStart = 167,
        TradesSyncRead = 168,
        TradesSnapshot = 169,
        DailySyncStart = 170,
        DailySyncRead = 171,
        TradeCalcProfit = 172,
        SymbolChange = 173,
        BytesSent = 174,
        BytesReceived = 175,
        ManagerCommon = 176,
        LogsOut = 177,
        LogsMode = 178,
        LicenseCheck = 179,
        CfgRequestGatewayAccount = 180,
        CfgRequestGatewayMarkup = 181,
        CfgRequestGatewayRule = 182,
        CfgUpdateGatewayAccount = 183,
        CfgUpdateGatewayMarkup = 184,
        CfgUpdateGatewayRule = 185,
        CfgDeleteGatewayAccount = 186,
        CfgDeleteGatewayMarkup = 187,
        CfgDeleteGatewayRule = 188,
        CfgShiftGatewayAccount = 189,
        CfgShiftGatewayMarkup = 190,
        CfgShiftGatewayRule = 191,
        AdmBalanceCheck = 192,
        NotificationsSend1 = 193,
        NotificationsSend2 = 194
    }

    /// <summary>
    /// Содержит сигнатуры функций mt4manapi.dll
    /// </summary>
    public class NativeWrapper
    {
        /// <summary>
        /// Table native function CManagerInterface
        /// </summary>
        protected IntPtr[] CVirtualTableEntry = new IntPtr[1];
        /// <summary>
        /// Pointer for native CManagerInterface
        /// </summary>
        protected IntPtr CManagerInterface = IntPtr.Zero;

        #region Delegate
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void MTAPI_NOTIFY_FUNC(PumpingNotificationCode code);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void MTAPI_NOTIFY_FUNC_EX(PumpingNotificationCode code, PumpingUpdateType type, IntPtr data, [MarshalAs(UnmanagedType.IUnknown)] object param);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate Int32 MTManVersionDelegate();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate Int32 MTManInterfaceDelegate(Int32 Version, out IntPtr Obj);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate Int32 QueryInterfaceDelegate(IntPtr Obj, IntPtr riid, IntPtr obj);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate Int32 AddRefDelegate(IntPtr Obj);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate Int32 ReleaseDelegate(IntPtr Obj);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate void MemFreeDelegate(IntPtr Obj, IntPtr ptr);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr ErrorDescriptionDelegate(IntPtr Obj, ResultCode code);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate void WorkingDirectoryDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string path);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode ConnectDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string server);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode DisconnectDelegate(IntPtr Obj);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate bool IsConnectedDelegate(IntPtr Obj);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode LoginDelegate(IntPtr Obj, Int32 login, [MarshalAs(UnmanagedType.LPStr)] string password);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode LoginSecuredDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string key_path);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode KeysSendDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string key_path);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode PingDelegate(IntPtr Obj);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode PasswordChangeDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string pass, Int32 is_investor);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode ManagerRightsDelegate(IntPtr Obj, out NConManager man);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode SrvRestartDelegate(IntPtr Obj);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode SrvChartsSyncDelegate(IntPtr Obj);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode SrvLiveUpdateStartDelegate(IntPtr Obj);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode SrvFeedsRestartDelegate(IntPtr Obj);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgRequestCommonDelegate(IntPtr Obj, out NConCommon cfg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgRequestTimeDelegate(IntPtr Obj, out NConTime cfg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgRequestBackupDelegate(IntPtr Obj, out NConBackup cfg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgRequestSymbolGroupDelegate(IntPtr Obj, [Out] NConSymbolGroup[] cfg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr CfgRequestAccessDelegate(IntPtr Obj, out Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr CfgRequestDataServerDelegate(IntPtr Obj, out Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr CfgRequestHolidayDelegate(IntPtr Obj, out Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr CfgRequestSymbolDelegate(IntPtr Obj, out Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr CfgRequestGroupDelegate(IntPtr Obj, out Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr CfgRequestManagerDelegate(IntPtr Obj, out Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr CfgRequestFeederDelegate(IntPtr Obj, out Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr CfgRequestLiveUpdateDelegate(IntPtr Obj, out Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr CfgRequestSyncDelegate(IntPtr Obj, out Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr CfgRequestPluginDelegate(IntPtr Obj, out Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgUpdateCommonDelegate(IntPtr Obj, ref NConCommon cfg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgUpdateAccessDelegate(IntPtr Obj, ref NConAccess cfg, Int32 pos);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgUpdateDataServerDelegate(IntPtr Obj, ref NConDataServer cfg, Int32 pos);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgUpdateTimeDelegate(IntPtr Obj, ref NConTime cfg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgUpdateHolidayDelegate(IntPtr Obj, ref NConHoliday cfg, Int32 pos);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgUpdateSymbolDelegate(IntPtr Obj, ref NConSymbol cfg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgUpdateSymbolGroupDelegate(IntPtr Obj, ref NConSymbolGroup cfg, Int32 pos);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgUpdateGroupDelegate(IntPtr Obj, ref NConGroup cfg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgUpdateManagerDelegate(IntPtr Obj, ref NConManager cfg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgUpdateFeederDelegate(IntPtr Obj, ref NConFeeder cfg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgUpdateBackupDelegate(IntPtr Obj, ref NConBackup cfg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgUpdateLiveUpdateDelegate(IntPtr Obj, ref NConLiveUpdate cfg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgUpdateSyncDelegate(IntPtr Obj, ref NConSync cfg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgUpdatePluginDelegate(IntPtr Obj, ref NConPlugin cfg, ref NPluginCfg parupd, Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgDeleteAccessDelegate(IntPtr Obj, Int32 pos);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgDeleteDataServerDelegate(IntPtr Obj, Int32 pos);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgDeleteHolidayDelegate(IntPtr Obj, Int32 pos);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgDeleteSymbolDelegate(IntPtr Obj, Int32 pos);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgDeleteGroupDelegate(IntPtr Obj, Int32 pos);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgDeleteManagerDelegate(IntPtr Obj, Int32 pos);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgDeleteFeederDelegate(IntPtr Obj, Int32 pos);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgDeleteLiveUpdateDelegate(IntPtr Obj, Int32 pos);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgDeleteSyncDelegate(IntPtr Obj, Int32 pos);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgShiftAccessDelegate(IntPtr Obj, Int32 pos, Int32 shift);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgShiftDataServerDelegate(IntPtr Obj, Int32 pos, Int32 shift);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgShiftHolidayDelegate(IntPtr Obj, Int32 pos, Int32 shift);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgShiftSymbolDelegate(IntPtr Obj, Int32 pos, Int32 shift);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgShiftGroupDelegate(IntPtr Obj, Int32 pos, Int32 shift);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgShiftManagerDelegate(IntPtr Obj, Int32 pos, Int32 shift);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgShiftFeederDelegate(IntPtr Obj, Int32 pos, Int32 shift);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgShiftLiveUpdateDelegate(IntPtr Obj, Int32 pos, Int32 shift);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgShiftSyncDelegate(IntPtr Obj, Int32 pos, Int32 shift);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgShiftPluginDelegate(IntPtr Obj, Int32 pos, Int32 shift);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr SrvFeedersDelegate(IntPtr Obj, out Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr SrvFeederLogDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string name, ref Int32 len);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr ChartRequestObsoleteDelegate(IntPtr Obj, out NChartInfo chart, uint timesign, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode ChartAddObsoleteDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string symbol, Int32 period, [In] NRateInfoOld[] rates, ref Int32 count);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode ChartUpdateObsoleteDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string symbol, Int32 period, [In] NRateInfoOld[] rates, ref Int32 count);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode ChartDeleteObsoleteDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string symbol, Int32 period, [In] NRateInfoOld[] rates, ref Int32 count);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr PerformanceRequestDelegate(IntPtr Obj, UInt32 from, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr BackupInfoUsersDelegate(IntPtr Obj, Int32 mode, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr BackupInfoOrdersDelegate(IntPtr Obj, Int32 mode, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr BackupRequestUsersDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string file, [MarshalAs(UnmanagedType.LPStr)] string request, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr BackupRequestOrdersDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string file, [MarshalAs(UnmanagedType.LPStr)] string request, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode BackupRestoreUsersDelegate(IntPtr Obj, [In] NUserRecord[] users, Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr BackupRestoreOrdersDelegate(IntPtr Obj, [In] NTradeRecord[] trades, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr AdmUsersRequestDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string group, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr AdmTradesRequestDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string group, Int32 open_only, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode AdmBalanceCheckObsoleteDelegate(IntPtr Obj, [In, Out] Int32[] logins, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode AdmBalanceFixDelegate(IntPtr Obj, [In] Int32[] logins, Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode AdmTradesDeleteDelegate(IntPtr Obj, [In] Int32[] orders, Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode AdmTradeRecordModifyDelegate(IntPtr Obj, ref NTradeRecord trade);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode SymbolsRefreshDelegate(IntPtr Obj);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr SymbolsGetAllDelegate(IntPtr Obj, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode SymbolGetDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string symbol, ref NConSymbol conSymbol);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode SymbolInfoGetDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string symbol, out NSymbolInfo si);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode SymbolAddDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string symbol);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode SymbolHideDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string symbol);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode SymbolChangeObsoleteDelegate(IntPtr Obj, ref NSymbolPropertiesOld prop);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode SymbolSendTickDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string symbol, double bid, double ask);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr GroupsRequestDelegate(IntPtr Obj, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode MailSendDelegate(IntPtr Obj, ref NMailBox mail, [In] Int32[] logins);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode NewsSendDelegate(IntPtr Obj, ref NNewsTopic news);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr JournalRequestDelegate(IntPtr Obj, EnLogMode mode, UInt32 from, UInt32 to, [MarshalAs(UnmanagedType.LPStr)] string filter, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr UsersRequestDelegate(IntPtr Obj, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr UserRecordsRequestDelegate(IntPtr Obj, [In] Int32[] logins, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode UserRecordNewDelegate(IntPtr Obj, ref NUserRecord user);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode UserRecordUpdateDelegate(IntPtr Obj, ref NUserRecord user);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode UsersGroupOpDelegate(IntPtr Obj, ref NGroupCommandInfo info, [In] Int32[] logins);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode UserPasswordCheckDelegate(IntPtr Obj, Int32 login, [MarshalAs(UnmanagedType.LPStr)] string password);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode UserPasswordSetDelegate(IntPtr Obj, Int32 login, [MarshalAs(UnmanagedType.LPStr)] string password, Int32 change_investor, Int32 clean_pubkey);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr OnlineRequestDelegate(IntPtr Obj, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode TradeTransactionDelegate(IntPtr Obj, ref NTradeTransInfo info);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr TradesRequestDelegate(IntPtr Obj, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr TradeRecordsRequestDelegate(IntPtr Obj, [In] Int32[] orders, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr TradesUserHistoryDelegate(IntPtr Obj, Int32 login, UInt32 from, UInt32 to, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode TradeCheckStopsDelegate(IntPtr Obj, ref NTradeTransInfo trade, double price);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr ReportsRequestDelegate(IntPtr Obj, ref NReportGroupRequest info, [In] Int32[] logins, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr DailyReportsRequestDelegate(IntPtr Obj, ref NDailyGroupRequest req, [In] Int32[] logins, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode ExternalCommandDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string data_in, Int32 size_in, [MarshalAs(UnmanagedType.LPStr)] ref string data_out, ref Int32 size_out);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode PluginUpdateDelegate(IntPtr Obj, ref NConPluginParam plugin);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode PumpingSwitchDelegate(IntPtr Obj, MTAPI_NOTIFY_FUNC pfnFunc, IntPtr destwnd, UInt32 eventmsg, PumpingFlags flags);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr GroupsGetDelegate(IntPtr Obj, Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode GroupRecordGetDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string name, ref NConGroup group);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate Int32 SymbolInfoUpdatedDelegate(IntPtr Obj, [Out] NSymbolInfo[] si, Int32 max_info);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr UsersGetDelegate(IntPtr Obj, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode UserRecordGetDelegate(IntPtr Obj, Int32 login, ref NUserRecord user);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr OnlineGetDelegate(IntPtr Obj, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode OnlineRecordGetDelegate(IntPtr Obj, Int32 login, ref NOnlineRecord user);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr TradesGetDelegate(IntPtr Obj, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr TradesGetBySymbolDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string symbol, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr TradesGetByLoginDelegate(IntPtr Obj, Int32 login, [MarshalAs(UnmanagedType.LPStr)] string group, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr TradesGetByMarketDelegate(IntPtr Obj, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode TradeRecordGetDelegate(IntPtr Obj, Int32 order, ref NTradeRecord trade);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode TradeClearRollbackDelegate(IntPtr Obj, Int32 order);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr MarginsGetDelegate(IntPtr Obj, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode MarginLevelGetDelegate(IntPtr Obj, Int32 login, [MarshalAs(UnmanagedType.LPStr)] string group, ref NMarginLevel margin);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr RequestsGetDelegate(IntPtr Obj, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode RequestInfoGetDelegate(IntPtr Obj, Int32 pos, ref NRequestInfo info);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr PluginsGetDelegate(IntPtr Obj, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode PluginParamGetDelegate(IntPtr Obj, Int32 pos, ref NConPluginParam plugin);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode MailLastDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] ref string path, ref Int32 length);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr NewsGetDelegate(IntPtr Obj, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate Int32 NewsTotalDelegate(IntPtr Obj);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode NewsTopicGetDelegate(IntPtr Obj, Int32 pos, ref NNewsTopic news);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate void NewsBodyRequestDelegate(IntPtr Obj, UInt32 key);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr NewsBodyGetDelegate(IntPtr Obj, UInt32 key);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode DealerSwitchDelegate(IntPtr Obj, MTAPI_NOTIFY_FUNC pfnFunc, IntPtr destwnd, UInt32 eventmsg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode DealerRequestGetDelegate(IntPtr Obj, ref NRequestInfo info);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode DealerSendDelegate(IntPtr Obj, ref NRequestInfo info, Int32 requote, Int32 mode);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode DealerRejectDelegate(IntPtr Obj, Int32 id);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode DealerResetDelegate(IntPtr Obj, Int32 id);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr TickInfoLastDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string symbol, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode SymbolsGroupsGetDelegate(IntPtr Obj, [Out] NConSymbolGroup[] grp);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate UInt32 ServerTimeDelegate(IntPtr Obj);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr MailsRequestDelegate(IntPtr Obj, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr SummaryGetAllDelegate(IntPtr Obj, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode SummaryGetDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string symbol, ref NSymbolSummary info);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode SummaryGetByCountDelegate(IntPtr Obj, Int32 symbol, ref NSymbolSummary info);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode SummaryGetByTypeDelegate(IntPtr Obj, Int32 sectype, ref NSymbolSummary info);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode SummaryCurrencyDelegate(IntPtr Obj, [In, Out] char[] cur, Int32 maxchars);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr ExposureGetDelegate(IntPtr Obj, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode ExposureValueGetDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string cur, ref NExposureValue info);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode MarginLevelRequestDelegate(IntPtr Obj, Int32 login, ref NMarginLevel level);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode HistoryCorrectDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string symbol, ref int updated);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr ChartRequestDelegate(IntPtr Obj, ref NChartInfo chart, ref UInt32 timesign, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode ChartAddDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string symbol, Int32 period, [In] NRateInfo[] rates, ref Int32 count);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode ChartUpdateDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string symbol, Int32 period, [In] NRateInfo[] rates, ref Int32 count);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode ChartDeleteDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string symbol, Int32 period, [In] NRateInfo[] rates, ref Int32 count);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr TicksRequestDelegate(IntPtr Obj, ref NTickRequest request, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode PumpingSwitchExDelegate(IntPtr Obj, MTAPI_NOTIFY_FUNC_EX pfnFunc, PumpingFlags flags, [MarshalAs(UnmanagedType.IUnknown)] object param);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode UsersSyncStartDelegate(IntPtr Obj, UInt32 timestamp);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr UsersSyncReadDelegate(IntPtr Obj, ref Int32 users_total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr UsersSnapshotDelegate(IntPtr Obj, ref Int32 users_total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode TradesSyncStartDelegate(IntPtr Obj, UInt32 timestamp);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr TradesSyncReadDelegate(IntPtr Obj, ref Int32 trades_total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr TradesSnapshotDelegate(IntPtr Obj, ref Int32 trades_total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode DailySyncStartDelegate(IntPtr Obj, UInt32 timestamp);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr DailySyncReadDelegate(IntPtr Obj, ref Int32 daily_total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode TradeCalcProfitDelegate(IntPtr Obj, ref NTradeRecord trade);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode SymbolChangeDelegate(IntPtr Obj, ref NSymbolProperties prop);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate Int32 BytesSentDelegate(IntPtr Obj);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate Int32 BytesReceivedDelegate(IntPtr Obj);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode ManagerCommonDelegate(IntPtr Obj, out NConCommon common);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate void LogsOutDelegate(IntPtr Obj, Int32 code, [MarshalAs(UnmanagedType.LPStr)] string source, [MarshalAs(UnmanagedType.LPStr)] string msg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate void LogsModeDelegate(IntPtr Obj, EnLogMode mode);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode LicenseCheckDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPStr)] string license_name);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr CfgRequestGatewayAccountDelegate(IntPtr Obj, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr CfgRequestGatewayMarkupDelegate(IntPtr Obj, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr CfgRequestGatewayRuleDelegate(IntPtr Obj, ref Int32 total);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgUpdateGatewayAccountDelegate(IntPtr Obj, ref NConGatewayAccount cfg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgUpdateGatewayMarkupDelegate(IntPtr Obj, ref NConGatewayMarkup cfg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgUpdateGatewayRuleDelegate(IntPtr Obj, ref NConGatewayRule cfg);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgDeleteGatewayAccountDelegate(IntPtr Obj, Int32 pos);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgDeleteGatewayMarkupDelegate(IntPtr Obj, Int32 pos);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgDeleteGatewayRuleDelegate(IntPtr Obj, Int32 pos);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgShiftGatewayAccountDelegate(IntPtr Obj, Int32 pos, Int32 shift);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgShiftGatewayMarkupDelegate(IntPtr Obj, Int32 pos, Int32 shift);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate ResultCode CfgShiftGatewayRuleDelegate(IntPtr Obj, Int32 pos, Int32 shift);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        protected delegate IntPtr AdmBalanceCheckDelegate(IntPtr Obj, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I4)] Int32[] logins, ref Int32 total);

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
        public struct message_s
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
            public string message_;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct message_byte
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2048)]
            public byte[] message_;
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        protected delegate int NotificationsSend1Delegate(
            IntPtr Obj,
            message_s metaquotes_ids,
            message_s message
        );

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        protected delegate int NotificationsSend2Delegate(
            IntPtr Obj,
            [In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I4)] Int32[] logins,
            [In] ref Int32 logins_total,
            [MarshalAs(UnmanagedType.LPArray)]
            byte[] message
        );
        #endregion

        #region MT4ManagerAPI
        protected MTManVersionDelegate mtManVersion;
        protected MTManInterfaceDelegate mtManCreate;
        protected QueryInterfaceDelegate queryInterface;
        protected AddRefDelegate addRef;
        protected ReleaseDelegate release;
        protected MemFreeDelegate memFree;
        protected ErrorDescriptionDelegate errorDescription;
        protected WorkingDirectoryDelegate workingDirectory;
        protected ConnectDelegate connect;
        protected DisconnectDelegate disconnect;
        protected IsConnectedDelegate isConnected;
        protected LoginDelegate login;
        protected LoginSecuredDelegate loginSecured;
        protected KeysSendDelegate keysSend;
        protected PingDelegate ping;
        protected PasswordChangeDelegate passwordChange;
        protected ManagerRightsDelegate managerRights;
        protected SrvRestartDelegate srvRestart;
        protected SrvChartsSyncDelegate srvChartsSync;
        protected SrvLiveUpdateStartDelegate srvLiveUpdateStart;
        protected SrvFeedsRestartDelegate srvFeedsRestart;
        protected CfgRequestCommonDelegate cfgRequestCommon;
        protected CfgRequestTimeDelegate cfgRequestTime;
        protected CfgRequestBackupDelegate cfgRequestBackup;
        protected CfgRequestSymbolGroupDelegate cfgRequestSymbolGroup;
        protected CfgRequestAccessDelegate cfgRequestAccess;
        protected CfgRequestDataServerDelegate cfgRequestDataServer;
        protected CfgRequestHolidayDelegate cfgRequestHoliday;
        protected CfgRequestSymbolDelegate cfgRequestSymbol;
        protected CfgRequestGroupDelegate cfgRequestGroup;
        protected CfgRequestManagerDelegate cfgRequestManager;
        protected CfgRequestFeederDelegate cfgRequestFeeder;
        protected CfgRequestLiveUpdateDelegate cfgRequestLiveUpdate;
        protected CfgRequestSyncDelegate cfgRequestSync;
        protected CfgRequestPluginDelegate cfgRequestPlugin;
        protected CfgUpdateCommonDelegate cfgUpdateCommon;
        protected CfgUpdateAccessDelegate cfgUpdateAccess;
        protected CfgUpdateDataServerDelegate cfgUpdateDataServer;
        protected CfgUpdateTimeDelegate cfgUpdateTime;
        protected CfgUpdateHolidayDelegate cfgUpdateHoliday;
        protected CfgUpdateSymbolDelegate cfgUpdateSymbol;
        protected CfgUpdateSymbolGroupDelegate cfgUpdateSymbolGroup;
        protected CfgUpdateGroupDelegate cfgUpdateGroup;
        protected CfgUpdateManagerDelegate cfgUpdateManager;
        protected CfgUpdateFeederDelegate cfgUpdateFeeder;
        protected CfgUpdateBackupDelegate cfgUpdateBackup;
        protected CfgUpdateLiveUpdateDelegate cfgUpdateLiveUpdate;
        protected CfgUpdateSyncDelegate cfgUpdateSync;
        protected CfgUpdatePluginDelegate cfgUpdatePlugin;
        protected CfgDeleteAccessDelegate cfgDeleteAccess;
        protected CfgDeleteDataServerDelegate cfgDeleteDataServer;
        protected CfgDeleteHolidayDelegate cfgDeleteHoliday;
        protected CfgDeleteSymbolDelegate cfgDeleteSymbol;
        protected CfgDeleteGroupDelegate cfgDeleteGroup;
        protected CfgDeleteManagerDelegate cfgDeleteManager;
        protected CfgDeleteFeederDelegate cfgDeleteFeeder;
        protected CfgDeleteLiveUpdateDelegate cfgDeleteLiveUpdate;
        protected CfgDeleteSyncDelegate cfgDeleteSync;
        protected CfgShiftAccessDelegate cfgShiftAccess;
        protected CfgShiftDataServerDelegate cfgShiftDataServer;
        protected CfgShiftHolidayDelegate cfgShiftHoliday;
        protected CfgShiftSymbolDelegate cfgShiftSymbol;
        protected CfgShiftGroupDelegate cfgShiftGroup;
        protected CfgShiftManagerDelegate cfgShiftManager;
        protected CfgShiftFeederDelegate cfgShiftFeeder;
        protected CfgShiftLiveUpdateDelegate cfgShiftLiveUpdate;
        protected CfgShiftSyncDelegate cfgShiftSync;
        protected CfgShiftPluginDelegate cfgShiftPlugin;
        protected SrvFeedersDelegate srvFeeders;
        protected SrvFeederLogDelegate srvFeederLog;
        protected ChartRequestObsoleteDelegate chartRequestObsolete;
        protected ChartAddObsoleteDelegate chartAddObsolete;
        protected ChartUpdateObsoleteDelegate chartUpdateObsolete;
        protected ChartDeleteObsoleteDelegate chartDeleteObsolete;
        protected PerformanceRequestDelegate performanceRequest;
        protected BackupInfoUsersDelegate backupInfoUsers;
        protected BackupInfoOrdersDelegate backupInfoOrders;
        protected BackupRequestUsersDelegate backupRequestUsers;
        protected BackupRequestOrdersDelegate backupRequestOrders;
        protected BackupRestoreUsersDelegate backupRestoreUsers;
        protected BackupRestoreOrdersDelegate backupRestoreOrders;
        protected AdmUsersRequestDelegate admUsersRequest;
        protected AdmTradesRequestDelegate admTradesRequest;
        protected AdmBalanceCheckObsoleteDelegate admBalanceCheckObsolete;
        protected AdmBalanceFixDelegate admBalanceFix;
        protected AdmTradesDeleteDelegate admTradesDelete;
        protected AdmTradeRecordModifyDelegate admTradeRecordModify;
        protected SymbolsRefreshDelegate symbolsRefresh;
        protected SymbolsGetAllDelegate symbolsGetAll;
        protected SymbolGetDelegate symbolGet;
        protected SymbolInfoGetDelegate symbolInfoGet;
        protected SymbolAddDelegate symbolAdd;
        protected SymbolHideDelegate symbolHide;
        protected SymbolChangeObsoleteDelegate symbolChangeObsolete;
        protected SymbolSendTickDelegate symbolSendTick;
        protected GroupsRequestDelegate groupsRequest;
        protected MailSendDelegate mailSend;
        protected NewsSendDelegate newsSend;
        protected JournalRequestDelegate journalRequest;
        protected UsersRequestDelegate usersRequest;
        protected UserRecordsRequestDelegate userRecordsRequest;
        protected UserRecordNewDelegate userRecordNew;
        protected UserRecordUpdateDelegate userRecordUpdate;
        protected UsersGroupOpDelegate usersGroupOp;
        protected UserPasswordCheckDelegate userPasswordCheck;
        protected UserPasswordSetDelegate userPasswordSet;
        protected OnlineRequestDelegate onlineRequest;
        protected TradeTransactionDelegate tradeTransaction;
        protected TradesRequestDelegate tradesRequest;
        protected TradeRecordsRequestDelegate tradeRecordsRequest;
        protected TradesUserHistoryDelegate tradesUserHistory;
        protected TradeCheckStopsDelegate tradeCheckStops;
        protected ReportsRequestDelegate reportsRequest;
        protected DailyReportsRequestDelegate dailyReportsRequest;
        protected ExternalCommandDelegate externalCommand;
        protected PluginUpdateDelegate pluginUpdate;
        protected PumpingSwitchDelegate pumpingSwitch;
        protected GroupsGetDelegate groupsGet;
        protected GroupRecordGetDelegate groupRecordGet;
        protected SymbolInfoUpdatedDelegate symbolInfoUpdated;
        protected UsersGetDelegate usersGet;
        protected UserRecordGetDelegate userRecordGet;
        protected OnlineGetDelegate onlineGet;
        protected OnlineRecordGetDelegate onlineRecordGet;
        protected TradesGetDelegate tradesGet;
        protected TradesGetBySymbolDelegate tradesGetBySymbol;
        protected TradesGetByLoginDelegate tradesGetByLogin;
        protected TradesGetByMarketDelegate tradesGetByMarket;
        protected TradeRecordGetDelegate tradeRecordGet;
        protected TradeClearRollbackDelegate tradeClearRollback;
        protected MarginsGetDelegate marginsGet;
        protected MarginLevelGetDelegate marginLevelGet;
        protected RequestsGetDelegate requestsGet;
        protected RequestInfoGetDelegate requestInfoGet;
        protected PluginsGetDelegate pluginsGet;
        protected PluginParamGetDelegate pluginParamGet;
        protected MailLastDelegate mailLast;
        protected NewsGetDelegate newsGet;
        protected NewsTotalDelegate newsTotal;
        protected NewsTopicGetDelegate newsTopicGet;
        protected NewsBodyRequestDelegate newsBodyRequest;
        protected NewsBodyGetDelegate newsBodyGet;
        protected DealerSwitchDelegate dealerSwitch;
        protected DealerRequestGetDelegate dealerRequestGet;
        protected DealerSendDelegate dealerSend;
        protected DealerRejectDelegate dealerReject;
        protected DealerResetDelegate dealerReset;
        protected TickInfoLastDelegate tickInfoLast;
        protected SymbolsGroupsGetDelegate symbolsGroupsGet;
        protected ServerTimeDelegate serverTime;
        protected MailsRequestDelegate mailsRequest;
        protected SummaryGetAllDelegate summaryGetAll;
        protected SummaryGetDelegate summaryGet;
        protected SummaryGetByCountDelegate summaryGetByCount;
        protected SummaryGetByTypeDelegate summaryGetByType;
        protected SummaryCurrencyDelegate summaryCurrency;
        protected ExposureGetDelegate exposureGet;
        protected ExposureValueGetDelegate exposureValueGet;
        protected MarginLevelRequestDelegate marginLevelRequest;
        protected HistoryCorrectDelegate historyCorrect;
        protected ChartRequestDelegate chartRequest;
        protected ChartAddDelegate chartAdd;
        protected ChartUpdateDelegate chartUpdate;
        protected ChartDeleteDelegate chartDelete;
        protected TicksRequestDelegate ticksRequest;
        protected PumpingSwitchExDelegate pumpingSwitchEx;
        protected UsersSyncStartDelegate usersSyncStart;
        protected UsersSyncReadDelegate usersSyncRead;
        protected UsersSnapshotDelegate usersSnapshot;
        protected TradesSyncStartDelegate tradesSyncStart;
        protected TradesSyncReadDelegate tradesSyncRead;
        protected TradesSnapshotDelegate tradesSnapshot;
        protected DailySyncStartDelegate dailySyncStart;
        protected DailySyncReadDelegate dailySyncRead;
        protected TradeCalcProfitDelegate tradeCalcProfit;
        protected SymbolChangeDelegate symbolChange;
        protected BytesSentDelegate bytesSent;
        protected BytesReceivedDelegate bytesReceived;
        protected ManagerCommonDelegate managerCommon;
        protected LogsOutDelegate logsOut;
        protected LogsModeDelegate logsMode;
        protected LicenseCheckDelegate licenseCheck;
        protected CfgRequestGatewayAccountDelegate cfgRequestGatewayAccount;
        protected CfgRequestGatewayMarkupDelegate cfgRequestGatewayMarkup;
        protected CfgRequestGatewayRuleDelegate cfgRequestGatewayRule;
        protected CfgUpdateGatewayAccountDelegate cfgUpdateGatewayAccount;
        protected CfgUpdateGatewayMarkupDelegate cfgUpdateGatewayMarkup;
        protected CfgUpdateGatewayRuleDelegate cfgUpdateGatewayRule;
        protected CfgDeleteGatewayAccountDelegate cfgDeleteGatewayAccount;
        protected CfgDeleteGatewayMarkupDelegate cfgDeleteGatewayMarkup;
        protected CfgDeleteGatewayRuleDelegate cfgDeleteGatewayRule;
        protected CfgShiftGatewayAccountDelegate cfgShiftGatewayAccount;
        protected CfgShiftGatewayMarkupDelegate cfgShiftGatewayMarkup;
        protected CfgShiftGatewayRuleDelegate cfgShiftGatewayRule;
        protected AdmBalanceCheckDelegate admBalanceCheck;
        protected NotificationsSend1Delegate notificationsSend1;
        protected NotificationsSend2Delegate notificationsSend2;
        #endregion
        /// <summary>
        /// Инициализируем делекаты для вызова нативных функций
        /// Каждый делегат будет содержать в себе адрес, к которому будет происходить обрабщение для вызова функций
        /// </summary>
        protected virtual void InitDelegate()
        {
            queryInterface = GetDelegate<QueryInterfaceDelegate>(FunctionIndex.QueryInterface);
            addRef = GetDelegate<AddRefDelegate>(FunctionIndex.AddRef);
            release = GetDelegate<ReleaseDelegate>(FunctionIndex.Release);
            memFree = GetDelegate<MemFreeDelegate>(FunctionIndex.MemFree);
            errorDescription = GetDelegate<ErrorDescriptionDelegate>(FunctionIndex.ErrorDescription);
            workingDirectory = GetDelegate<WorkingDirectoryDelegate>(FunctionIndex.WorkingDirectory);
            connect = GetDelegate<ConnectDelegate>(FunctionIndex.Connect);
            disconnect = GetDelegate<DisconnectDelegate>(FunctionIndex.Disconnect);
            isConnected = GetDelegate<IsConnectedDelegate>(FunctionIndex.IsConnected);
            login = GetDelegate<LoginDelegate>(FunctionIndex.Login);
            loginSecured = GetDelegate<LoginSecuredDelegate>(FunctionIndex.LoginSecured);
            keysSend = GetDelegate<KeysSendDelegate>(FunctionIndex.KeysSend);
            ping = GetDelegate<PingDelegate>(FunctionIndex.Ping);
            passwordChange = GetDelegate<PasswordChangeDelegate>(FunctionIndex.PasswordChange);
            managerRights = GetDelegate<ManagerRightsDelegate>(FunctionIndex.ManagerRights);
            srvRestart = GetDelegate<SrvRestartDelegate>(FunctionIndex.SrvRestart);
            srvChartsSync = GetDelegate<SrvChartsSyncDelegate>(FunctionIndex.SrvChartsSync);
            srvLiveUpdateStart = GetDelegate<SrvLiveUpdateStartDelegate>(FunctionIndex.SrvLiveUpdateStart);
            srvFeedsRestart = GetDelegate<SrvFeedsRestartDelegate>(FunctionIndex.SrvFeedsRestart);
            cfgRequestCommon = GetDelegate<CfgRequestCommonDelegate>(FunctionIndex.CfgRequestCommon);
            cfgRequestTime = GetDelegate<CfgRequestTimeDelegate>(FunctionIndex.CfgRequestTime);
            cfgRequestBackup = GetDelegate<CfgRequestBackupDelegate>(FunctionIndex.CfgRequestBackup);
            cfgRequestSymbolGroup = GetDelegate<CfgRequestSymbolGroupDelegate>(FunctionIndex.CfgRequestSymbolGroup);
            cfgRequestAccess = GetDelegate<CfgRequestAccessDelegate>(FunctionIndex.CfgRequestAccess);
            cfgRequestDataServer = GetDelegate<CfgRequestDataServerDelegate>(FunctionIndex.CfgRequestDataServer);
            cfgRequestHoliday = GetDelegate<CfgRequestHolidayDelegate>(FunctionIndex.CfgRequestHoliday);
            cfgRequestSymbol = GetDelegate<CfgRequestSymbolDelegate>(FunctionIndex.CfgRequestSymbol);
            cfgRequestGroup = GetDelegate<CfgRequestGroupDelegate>(FunctionIndex.CfgRequestGroup);
            cfgRequestManager = GetDelegate<CfgRequestManagerDelegate>(FunctionIndex.CfgRequestManager);
            cfgRequestFeeder = GetDelegate<CfgRequestFeederDelegate>(FunctionIndex.CfgRequestFeeder);
            cfgRequestLiveUpdate = GetDelegate<CfgRequestLiveUpdateDelegate>(FunctionIndex.CfgRequestLiveUpdate);
            cfgRequestSync = GetDelegate<CfgRequestSyncDelegate>(FunctionIndex.CfgRequestSync);
            cfgRequestPlugin = GetDelegate<CfgRequestPluginDelegate>(FunctionIndex.CfgRequestPlugin);
            cfgUpdateCommon = GetDelegate<CfgUpdateCommonDelegate>(FunctionIndex.CfgUpdateCommon);
            cfgUpdateAccess = GetDelegate<CfgUpdateAccessDelegate>(FunctionIndex.CfgUpdateAccess);
            cfgUpdateDataServer = GetDelegate<CfgUpdateDataServerDelegate>(FunctionIndex.CfgUpdateDataServer);
            cfgUpdateTime = GetDelegate<CfgUpdateTimeDelegate>(FunctionIndex.CfgUpdateTime);
            cfgUpdateHoliday = GetDelegate<CfgUpdateHolidayDelegate>(FunctionIndex.CfgUpdateHoliday);
            cfgUpdateSymbol = GetDelegate<CfgUpdateSymbolDelegate>(FunctionIndex.CfgUpdateSymbol);
            cfgUpdateSymbolGroup = GetDelegate<CfgUpdateSymbolGroupDelegate>(FunctionIndex.CfgUpdateSymbolGroup);
            cfgUpdateGroup = GetDelegate<CfgUpdateGroupDelegate>(FunctionIndex.CfgUpdateGroup);
            cfgUpdateManager = GetDelegate<CfgUpdateManagerDelegate>(FunctionIndex.CfgUpdateManager);
            cfgUpdateFeeder = GetDelegate<CfgUpdateFeederDelegate>(FunctionIndex.CfgUpdateFeeder);
            cfgUpdateBackup = GetDelegate<CfgUpdateBackupDelegate>(FunctionIndex.CfgUpdateBackup);
            cfgUpdateLiveUpdate = GetDelegate<CfgUpdateLiveUpdateDelegate>(FunctionIndex.CfgUpdateLiveUpdate);
            cfgUpdateSync = GetDelegate<CfgUpdateSyncDelegate>(FunctionIndex.CfgUpdateSync);
            cfgUpdatePlugin = GetDelegate<CfgUpdatePluginDelegate>(FunctionIndex.CfgUpdatePlugin);
            cfgDeleteAccess = GetDelegate<CfgDeleteAccessDelegate>(FunctionIndex.CfgDeleteAccess);
            cfgDeleteDataServer = GetDelegate<CfgDeleteDataServerDelegate>(FunctionIndex.CfgDeleteDataServer);
            cfgDeleteHoliday = GetDelegate<CfgDeleteHolidayDelegate>(FunctionIndex.CfgDeleteHoliday);
            cfgDeleteSymbol = GetDelegate<CfgDeleteSymbolDelegate>(FunctionIndex.CfgDeleteSymbol);
            cfgDeleteGroup = GetDelegate<CfgDeleteGroupDelegate>(FunctionIndex.CfgDeleteGroup);
            cfgDeleteManager = GetDelegate<CfgDeleteManagerDelegate>(FunctionIndex.CfgDeleteManager);
            cfgDeleteFeeder = GetDelegate<CfgDeleteFeederDelegate>(FunctionIndex.CfgDeleteFeeder);
            cfgDeleteLiveUpdate = GetDelegate<CfgDeleteLiveUpdateDelegate>(FunctionIndex.CfgDeleteLiveUpdate);
            cfgDeleteSync = GetDelegate<CfgDeleteSyncDelegate>(FunctionIndex.CfgDeleteSync);
            cfgShiftAccess = GetDelegate<CfgShiftAccessDelegate>(FunctionIndex.CfgShiftAccess);
            cfgShiftDataServer = GetDelegate<CfgShiftDataServerDelegate>(FunctionIndex.CfgShiftDataServer);
            cfgShiftHoliday = GetDelegate<CfgShiftHolidayDelegate>(FunctionIndex.CfgShiftHoliday);
            cfgShiftSymbol = GetDelegate<CfgShiftSymbolDelegate>(FunctionIndex.CfgShiftSymbol);
            cfgShiftGroup = GetDelegate<CfgShiftGroupDelegate>(FunctionIndex.CfgShiftGroup);
            cfgShiftManager = GetDelegate<CfgShiftManagerDelegate>(FunctionIndex.CfgShiftManager);
            cfgShiftFeeder = GetDelegate<CfgShiftFeederDelegate>(FunctionIndex.CfgShiftFeeder);
            cfgShiftLiveUpdate = GetDelegate<CfgShiftLiveUpdateDelegate>(FunctionIndex.CfgShiftLiveUpdate);
            cfgShiftSync = GetDelegate<CfgShiftSyncDelegate>(FunctionIndex.CfgShiftSync);
            cfgShiftPlugin = GetDelegate<CfgShiftPluginDelegate>(FunctionIndex.CfgShiftPlugin);
            srvFeeders = GetDelegate<SrvFeedersDelegate>(FunctionIndex.SrvFeeders);
            srvFeederLog = GetDelegate<SrvFeederLogDelegate>(FunctionIndex.SrvFeederLog);
            chartRequestObsolete = GetDelegate<ChartRequestObsoleteDelegate>(FunctionIndex.ChartRequestObsolete);
            chartAddObsolete = GetDelegate<ChartAddObsoleteDelegate>(FunctionIndex.ChartAddObsolete);
            chartUpdateObsolete = GetDelegate<ChartUpdateObsoleteDelegate>(FunctionIndex.ChartUpdateObsolete);
            chartDeleteObsolete = GetDelegate<ChartDeleteObsoleteDelegate>(FunctionIndex.ChartDeleteObsolete);
            performanceRequest = GetDelegate<PerformanceRequestDelegate>(FunctionIndex.PerformanceRequest);
            backupInfoUsers = GetDelegate<BackupInfoUsersDelegate>(FunctionIndex.BackupInfoUsers);
            backupInfoOrders = GetDelegate<BackupInfoOrdersDelegate>(FunctionIndex.BackupInfoOrders);
            backupRequestUsers = GetDelegate<BackupRequestUsersDelegate>(FunctionIndex.BackupRequestUsers);
            backupRequestOrders = GetDelegate<BackupRequestOrdersDelegate>(FunctionIndex.BackupRequestOrders);
            backupRestoreUsers = GetDelegate<BackupRestoreUsersDelegate>(FunctionIndex.BackupRestoreUsers);
            backupRestoreOrders = GetDelegate<BackupRestoreOrdersDelegate>(FunctionIndex.BackupRestoreOrders);
            admUsersRequest = GetDelegate<AdmUsersRequestDelegate>(FunctionIndex.AdmUsersRequest);
            admTradesRequest = GetDelegate<AdmTradesRequestDelegate>(FunctionIndex.AdmTradesRequest);
            admBalanceCheckObsolete = GetDelegate<AdmBalanceCheckObsoleteDelegate>(FunctionIndex.AdmBalanceCheckObsolete);
            admBalanceFix = GetDelegate<AdmBalanceFixDelegate>(FunctionIndex.AdmBalanceFix);
            admTradesDelete = GetDelegate<AdmTradesDeleteDelegate>(FunctionIndex.AdmTradesDelete);
            admTradeRecordModify = GetDelegate<AdmTradeRecordModifyDelegate>(FunctionIndex.AdmTradeRecordModify);
            symbolsRefresh = GetDelegate<SymbolsRefreshDelegate>(FunctionIndex.SymbolsRefresh);
            symbolsGetAll = GetDelegate<SymbolsGetAllDelegate>(FunctionIndex.SymbolsGetAll);
            symbolGet = GetDelegate<SymbolGetDelegate>(FunctionIndex.SymbolGet);
            symbolInfoGet = GetDelegate<SymbolInfoGetDelegate>(FunctionIndex.SymbolInfoGet);
            symbolAdd = GetDelegate<SymbolAddDelegate>(FunctionIndex.SymbolAdd);
            symbolHide = GetDelegate<SymbolHideDelegate>(FunctionIndex.SymbolHide);
            symbolChangeObsolete = GetDelegate<SymbolChangeObsoleteDelegate>(FunctionIndex.SymbolChangeObsolete);
            symbolSendTick = GetDelegate<SymbolSendTickDelegate>(FunctionIndex.SymbolSendTick);
            groupsRequest = GetDelegate<GroupsRequestDelegate>(FunctionIndex.GroupsRequest);
            mailSend = GetDelegate<MailSendDelegate>(FunctionIndex.MailSend);
            newsSend = GetDelegate<NewsSendDelegate>(FunctionIndex.NewsSend);
            journalRequest = GetDelegate<JournalRequestDelegate>(FunctionIndex.JournalRequest);
            usersRequest = GetDelegate<UsersRequestDelegate>(FunctionIndex.UsersRequest);
            userRecordsRequest = GetDelegate<UserRecordsRequestDelegate>(FunctionIndex.UserRecordsRequest);
            userRecordNew = GetDelegate<UserRecordNewDelegate>(FunctionIndex.UserRecordNew);
            userRecordUpdate = GetDelegate<UserRecordUpdateDelegate>(FunctionIndex.UserRecordUpdate);
            usersGroupOp = GetDelegate<UsersGroupOpDelegate>(FunctionIndex.UsersGroupOp);
            userPasswordCheck = GetDelegate<UserPasswordCheckDelegate>(FunctionIndex.UserPasswordCheck);
            userPasswordSet = GetDelegate<UserPasswordSetDelegate>(FunctionIndex.UserPasswordSet);
            onlineRequest = GetDelegate<OnlineRequestDelegate>(FunctionIndex.OnlineRequest);
            tradeTransaction = GetDelegate<TradeTransactionDelegate>(FunctionIndex.TradeTransaction);
            tradesRequest = GetDelegate<TradesRequestDelegate>(FunctionIndex.TradesRequest);
            tradeRecordsRequest = GetDelegate<TradeRecordsRequestDelegate>(FunctionIndex.TradeRecordsRequest);
            tradesUserHistory = GetDelegate<TradesUserHistoryDelegate>(FunctionIndex.TradesUserHistory);
            tradeCheckStops = GetDelegate<TradeCheckStopsDelegate>(FunctionIndex.TradeCheckStops);
            reportsRequest = GetDelegate<ReportsRequestDelegate>(FunctionIndex.ReportsRequest);
            dailyReportsRequest = GetDelegate<DailyReportsRequestDelegate>(FunctionIndex.DailyReportsRequest);
            externalCommand = GetDelegate<ExternalCommandDelegate>(FunctionIndex.ExternalCommand);
            pluginUpdate = GetDelegate<PluginUpdateDelegate>(FunctionIndex.PluginUpdate);
            pumpingSwitch = GetDelegate<PumpingSwitchDelegate>(FunctionIndex.PumpingSwitch);
            groupsGet = GetDelegate<GroupsGetDelegate>(FunctionIndex.GroupsGet);
            groupRecordGet = GetDelegate<GroupRecordGetDelegate>(FunctionIndex.GroupRecordGet);
            symbolInfoUpdated = GetDelegate<SymbolInfoUpdatedDelegate>(FunctionIndex.SymbolInfoUpdated);
            usersGet = GetDelegate<UsersGetDelegate>(FunctionIndex.UsersGet);
            userRecordGet = GetDelegate<UserRecordGetDelegate>(FunctionIndex.UserRecordGet);
            onlineGet = GetDelegate<OnlineGetDelegate>(FunctionIndex.OnlineGet);
            onlineRecordGet = GetDelegate<OnlineRecordGetDelegate>(FunctionIndex.OnlineRecordGet);
            tradesGet = GetDelegate<TradesGetDelegate>(FunctionIndex.TradesGet);
            tradesGetBySymbol = GetDelegate<TradesGetBySymbolDelegate>(FunctionIndex.TradesGetBySymbol);
            tradesGetByLogin = GetDelegate<TradesGetByLoginDelegate>(FunctionIndex.TradesGetByLogin);
            tradesGetByMarket = GetDelegate<TradesGetByMarketDelegate>(FunctionIndex.TradesGetByMarket);
            tradeRecordGet = GetDelegate<TradeRecordGetDelegate>(FunctionIndex.TradeRecordGet);
            tradeClearRollback = GetDelegate<TradeClearRollbackDelegate>(FunctionIndex.TradeClearRollback);
            marginsGet = GetDelegate<MarginsGetDelegate>(FunctionIndex.MarginsGet);
            marginLevelGet = GetDelegate<MarginLevelGetDelegate>(FunctionIndex.MarginLevelGet);
            requestsGet = GetDelegate<RequestsGetDelegate>(FunctionIndex.RequestsGet);
            requestInfoGet = GetDelegate<RequestInfoGetDelegate>(FunctionIndex.RequestInfoGet);
            pluginsGet = GetDelegate<PluginsGetDelegate>(FunctionIndex.PluginsGet);
            pluginParamGet = GetDelegate<PluginParamGetDelegate>(FunctionIndex.PluginParamGet);
            mailLast = GetDelegate<MailLastDelegate>(FunctionIndex.MailLast);
            newsGet = GetDelegate<NewsGetDelegate>(FunctionIndex.NewsGet);
            newsTotal = GetDelegate<NewsTotalDelegate>(FunctionIndex.NewsTotal);
            newsTopicGet = GetDelegate<NewsTopicGetDelegate>(FunctionIndex.NewsTopicGet);
            newsBodyRequest = GetDelegate<NewsBodyRequestDelegate>(FunctionIndex.NewsBodyRequest);
            newsBodyGet = GetDelegate<NewsBodyGetDelegate>(FunctionIndex.NewsBodyGet);
            dealerSwitch = GetDelegate<DealerSwitchDelegate>(FunctionIndex.DealerSwitch);
            dealerRequestGet = GetDelegate<DealerRequestGetDelegate>(FunctionIndex.DealerRequestGet);
            dealerSend = GetDelegate<DealerSendDelegate>(FunctionIndex.DealerSend);
            dealerReject = GetDelegate<DealerRejectDelegate>(FunctionIndex.DealerReject);
            dealerReset = GetDelegate<DealerResetDelegate>(FunctionIndex.DealerReset);
            tickInfoLast = GetDelegate<TickInfoLastDelegate>(FunctionIndex.TickInfoLast);
            symbolsGroupsGet = GetDelegate<SymbolsGroupsGetDelegate>(FunctionIndex.SymbolsGroupsGet);
            serverTime = GetDelegate<ServerTimeDelegate>(FunctionIndex.ServerTime);
            mailsRequest = GetDelegate<MailsRequestDelegate>(FunctionIndex.MailsRequest);
            summaryGetAll = GetDelegate<SummaryGetAllDelegate>(FunctionIndex.SummaryGetAll);
            summaryGet = GetDelegate<SummaryGetDelegate>(FunctionIndex.SummaryGet);
            summaryGetByCount = GetDelegate<SummaryGetByCountDelegate>(FunctionIndex.SummaryGetByCount);
            summaryGetByType = GetDelegate<SummaryGetByTypeDelegate>(FunctionIndex.SummaryGetByType);
            summaryCurrency = GetDelegate<SummaryCurrencyDelegate>(FunctionIndex.SummaryCurrency);
            exposureGet = GetDelegate<ExposureGetDelegate>(FunctionIndex.ExposureGet);
            exposureValueGet = GetDelegate<ExposureValueGetDelegate>(FunctionIndex.ExposureValueGet);
            marginLevelRequest = GetDelegate<MarginLevelRequestDelegate>(FunctionIndex.MarginLevelRequest);
            historyCorrect = GetDelegate<HistoryCorrectDelegate>(FunctionIndex.HistoryCorrect);
            chartRequest = GetDelegate<ChartRequestDelegate>(FunctionIndex.ChartRequest);
            chartAdd = GetDelegate<ChartAddDelegate>(FunctionIndex.ChartAdd);
            chartUpdate = GetDelegate<ChartUpdateDelegate>(FunctionIndex.ChartUpdate);
            chartDelete = GetDelegate<ChartDeleteDelegate>(FunctionIndex.ChartDelete);
            ticksRequest = GetDelegate<TicksRequestDelegate>(FunctionIndex.TicksRequest);
            pumpingSwitchEx = GetDelegate<PumpingSwitchExDelegate>(FunctionIndex.PumpingSwitchEx);
            usersSyncStart = GetDelegate<UsersSyncStartDelegate>(FunctionIndex.UsersSyncStart);
            usersSyncRead = GetDelegate<UsersSyncReadDelegate>(FunctionIndex.UsersSyncRead);
            usersSnapshot = GetDelegate<UsersSnapshotDelegate>(FunctionIndex.UsersSnapshot);
            tradesSyncStart = GetDelegate<TradesSyncStartDelegate>(FunctionIndex.TradesSyncStart);
            tradesSyncRead = GetDelegate<TradesSyncReadDelegate>(FunctionIndex.TradesSyncRead);
            tradesSnapshot = GetDelegate<TradesSnapshotDelegate>(FunctionIndex.TradesSnapshot);
            dailySyncStart = GetDelegate<DailySyncStartDelegate>(FunctionIndex.DailySyncStart);
            dailySyncRead = GetDelegate<DailySyncReadDelegate>(FunctionIndex.DailySyncRead);
            tradeCalcProfit = GetDelegate<TradeCalcProfitDelegate>(FunctionIndex.TradeCalcProfit);
            symbolChange = GetDelegate<SymbolChangeDelegate>(FunctionIndex.SymbolChange);
            bytesSent = GetDelegate<BytesSentDelegate>(FunctionIndex.BytesSent);
            bytesReceived = GetDelegate<BytesReceivedDelegate>(FunctionIndex.BytesReceived);
            managerCommon = GetDelegate<ManagerCommonDelegate>(FunctionIndex.ManagerCommon);
            logsOut = GetDelegate<LogsOutDelegate>(FunctionIndex.LogsOut);
            logsMode = GetDelegate<LogsModeDelegate>(FunctionIndex.LogsMode);
            licenseCheck = GetDelegate<LicenseCheckDelegate>(FunctionIndex.LicenseCheck);
            cfgRequestGatewayAccount = GetDelegate<CfgRequestGatewayAccountDelegate>(FunctionIndex.CfgRequestGatewayAccount);
            cfgRequestGatewayMarkup = GetDelegate<CfgRequestGatewayMarkupDelegate>(FunctionIndex.CfgRequestGatewayMarkup);
            cfgRequestGatewayRule = GetDelegate<CfgRequestGatewayRuleDelegate>(FunctionIndex.CfgRequestGatewayRule);
            cfgUpdateGatewayAccount = GetDelegate<CfgUpdateGatewayAccountDelegate>(FunctionIndex.CfgUpdateGatewayAccount);
            cfgUpdateGatewayMarkup = GetDelegate<CfgUpdateGatewayMarkupDelegate>(FunctionIndex.CfgUpdateGatewayMarkup);
            cfgUpdateGatewayRule = GetDelegate<CfgUpdateGatewayRuleDelegate>(FunctionIndex.CfgUpdateGatewayRule);
            cfgDeleteGatewayAccount = GetDelegate<CfgDeleteGatewayAccountDelegate>(FunctionIndex.CfgDeleteGatewayAccount);
            cfgDeleteGatewayMarkup = GetDelegate<CfgDeleteGatewayMarkupDelegate>(FunctionIndex.CfgDeleteGatewayMarkup);
            cfgDeleteGatewayRule = GetDelegate<CfgDeleteGatewayRuleDelegate>(FunctionIndex.CfgDeleteGatewayRule);
            cfgShiftGatewayAccount = GetDelegate<CfgShiftGatewayAccountDelegate>(FunctionIndex.CfgShiftGatewayAccount);
            cfgShiftGatewayMarkup = GetDelegate<CfgShiftGatewayMarkupDelegate>(FunctionIndex.CfgShiftGatewayMarkup);
            cfgShiftGatewayRule = GetDelegate<CfgShiftGatewayRuleDelegate>(FunctionIndex.CfgShiftGatewayRule);
            admBalanceCheck = GetDelegate<AdmBalanceCheckDelegate>(FunctionIndex.AdmBalanceCheck);
            notificationsSend1 = GetDelegate<NotificationsSend1Delegate>(FunctionIndex.NotificationsSend1);
            notificationsSend2 = GetDelegate<NotificationsSend2Delegate>(FunctionIndex.NotificationsSend2);
        }

        /// <summary>
        /// Инициализирует таблицу виртуальных функций нативной dll библиотеки.
        /// Идея в том, что для вызова функций, мы обращаемся по адресу к этой таблицы
        /// </summary>
        protected void InitVirtualTable()
        {
            Marshal.Copy(CManagerInterface, CVirtualTableEntry, 0, 1);
        }

        /// <summary>
        /// Возвращает указатель на функцию по ее номеру в таблице виртуальных функций
        /// </summary>
        /// <param name="number">номер функии</param>
        /// <returns></returns>
        protected IntPtr GetFunctionByNumber(FunctionIndex number)
        {
            IntPtr[] virtualTable = new IntPtr[(Int32)number + 1];
            Marshal.Copy(CVirtualTableEntry[0], virtualTable, 0, (Int32)number + 1);

            return virtualTable[(Int32)number];
        }

        /// <summary>
        /// По номеру возвращает делегат функции
        /// </summary>
        /// <typeparam name="TDelegate"></typeparam>
        /// <param name="index"></param>
        /// <returns></returns>
        protected TDelegate GetDelegate<TDelegate>(FunctionIndex index)
            where TDelegate : class
        {
            return Marshal.GetDelegateForFunctionPointer<TDelegate>(GetFunctionByNumber(index));
        }
    }
}