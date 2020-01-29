using System;
using System.Net;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NConCommon
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] owner;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] name;
        public UInt32 address;
        public Int32 port;
        public UInt32 timeout;
        public Int32 typeOfDemo;
        public Int32 timeOfDemo;
        public Int32 daylightCorrection;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] internalValue;
        public Int32 timezone;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] timesync;
        public Int32 minClient;
        public Int32 minApi;
        public UInt32 feederTimeout;
        public Int32 keepEmails;
        public Int32 endHour;
        public Int32 endMinute;
        public Int32 optimizationTime;
        public Int32 optimizationLastTime;
        public Int32 optimization_counter;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public Int32[] optimization_unused;
        public Int32 antiflood;
        public Int32 floodcontrol;
        public Int32 liveupdateMode;
        public Int32 lastOrder;
        public Int32 lastLogin;
        public Int32 lostLogin;
        public Int32 rolloversMode;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] pathDatabase;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] pathHistory;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] pathLog;
        public UInt32 overnightLastDay;
        public UInt32 overnightLastTime;
        public UInt32 overnightPrevTime;
        public UInt32 overmonthLastMonth;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] adapters;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public UInt32[] bindAddresses;
        public short serverVersion;
        public short serverBuild;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public UInt32[] webAddresses;
        public Int32 statementMode;
        public Int32 monthlyStatementMode;
        public Int32 keepticks;
        public Int32 statementWeekend;
        public UInt32 lastActivate;
        public UInt32 stopLast;
        public Int32 stopDelay;
        public Int32 stopReason;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] accountUrl;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public Int32[] reserved;
    }

    /// <summary>
    /// Object that represents common configuration
    /// </summary>
    public class ConCommon : MT4Model<NConCommon>
    {
        public ConCommon(int codePage) : base(codePage) { }
        /// <summary>
        /// Servers owner (include version and build)
        /// </summary>
        public string Owner
        {
            get { return AnsiBytesToString(native.owner); }
            set { native.owner = StringToAnsiBytes(value, 128); }
        }

        /// <summary>
        /// Server name
        /// </summary>
        public string Name
        {
            get { return AnsiBytesToString(native.name); }
            set { native.name = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// IP address assigned to the server
        /// </summary>
        public UInt32 Address
        {
            get { return native.address; }
            set { native.address = value; }
        }

        /// <summary>
        /// Port
        /// </summary>
        public Int32 Port
        {
            get { return native.port; }
            set { native.port = value; }
        }

        /// <summary>
        /// Sockets timeout
        /// </summary>
        public UInt32 Timeout
        {
            get { return native.timeout; }
            set { native.timeout = value; }
        }

        /// <summary>
        /// Demo-accounts type (DEMO_DISABLED, DEMO_PROLONG, DEMO_FIXED)
        /// </summary>
        public DemoAccountsType TypeOfDemo
        {
            get { return (DemoAccountsType)native.typeOfDemo; }
            set { native.typeOfDemo = (Int32) value; }
        }

        /// <summary>
        /// Demo-account living time
        /// </summary>
        public Int32 TimeOfDemo
        {
            get { return native.timeOfDemo; }
            set { native.timeOfDemo = value; }
        }

        /// <summary>
        /// Allow daylight correction
        /// </summary>
        public Int32 DayLightCorrection
        {
            get { return native.daylightCorrection; }
            set { native.daylightCorrection = value; }
        }

        /// <summary>
        /// reserved
        /// </summary>
        public string Internal
        {
            get { return AnsiBytesToString(native.internalValue); }
        }

        /// <summary>
        /// Time zone
        /// 0 - GMT
        /// -1 = GMT-1
        /// 1 = GMT+1
        /// </summary>
        public Int32 TimeZone
        {
            get { return native.timezone; }
            set { native.timezone = value; }
        }

        /// <summary>
        /// Time synchronization server address
        /// </summary>
        public string TimeSync
        {
            get { return AnsiBytesToString(native.timesync); }
            set { native.timesync = StringToAnsiBytes(value, 64); }
        }

        /// <summary>
        /// Minimal authorized client version
        /// </summary>
        public Int32 MinClient
        {
            get { return native.minClient; }
            set { native.minClient = value; }
        }

        /// <summary>
        /// Minimal authorized client version
        /// </summary>
        public Int32 MinApi
        {
            get { return native.minApi; }
            set { native.minApi = value; }
        }

        /// <summary>
        /// Data feed switch timeout
        /// </summary>
        public UInt32 FeederTimeout
        {
            get { return native.feederTimeout; }
            set { native.feederTimeout = value; }
        }

        /// <summary>
        /// Internal mail keep period
        /// </summary>
        public Int32 KeepEmails
        {
            get { return native.keepEmails; }
            set { native.keepEmails = value; }
        }

        /// <summary>
        /// End of day time-hour
        /// </summary>
        public Int32 EndHour
        {
            get { return native.endHour; }
            set { native.endHour = value; }
        }


        /// <summary>
        /// End of day time-minute
        /// </summary>
        public Int32 EndMinute
        {
            get { return native.endMinute; }
            set { native.endMinute = value; }
        }


        /// <summary>
        /// Optimization start time (minutes)
        /// </summary>
        public Int32 OptimizationTime
        {
            get { return native.optimizationTime; }
            set { native.optimizationTime = value; }
        }


        /// <summary>
        /// Optimization last time
        /// </summary>
        public Int32 OptimizationLastTime
        {
            get { return native.optimizationLastTime; }
            set { native.optimizationLastTime = value; }
        }

        /// <summary>
        /// Internal variable   
        /// </summary>
        public Int32 OptimizationCounter
        {
            get { return native.optimization_counter; }
            set { native.optimization_counter = value; }
        }

        /// <summary>
        /// Reserved for future use
        /// </summary>
        protected Int32[] OptimizationUnused
        {
            get { return native.optimization_unused; }
        }

        /// <summary>
        /// Enable antiflood control
        /// </summary>
        public Int32 AntiFlood
        {
            get { return native.antiflood; }
            set { native.antiflood = value; }
        }

        /// <summary>
        /// Max. antiflood connections
        /// </summary>
        public Int32 FloodControl
        {
            get { return native.floodcontrol; }
            set { native.floodcontrol = value; }
        }

        /// <summary>
        /// LiveUpdate mode (LIVE_UPDATE_NO,LIVE_UPDATE_ALL,LIVE_UPDATE_NO_SERVER)
        /// </summary>
        public LiveUpdateMode LiveUpdateMode
        {
            get { return (LiveUpdateMode) native.liveupdateMode; }
            set { native.liveupdateMode = (Int32) value; }
        }

        /// <summary>
        /// Last order's ticket (read only)
        /// </summary>
        public Int32 LastOrder
        {
            get { return native.lastOrder; }
        }

        /// <summary>
        /// Last account's number (read only)
        /// </summary>
        public Int32 LastLogin
        {
            get { return native.lastLogin; }
        }

        /// <summary>
        /// Lost commission's login (read only)
        /// </summary>
        public Int32 LostLogin
        {
            get { return native.lostLogin; }
        }

        /// <summary>
        /// Rollover mode (ROLLOVER_NORMAL,ROLLOVER_REOPEN_BY_CLOSE_PRICE,ROLLOVER_REOPEN_BY_BID)
        /// </summary>
        public RolloverMode RolloversMode
        {
            get { return (RolloverMode) native.rolloversMode; }
            set { native.rolloversMode = (Int32) value; }
        }

        /// <summary>
        /// Path to databases
        /// </summary>
        public string PathDatabase
        {
            get { return AnsiBytesToString(native.pathDatabase); }
            set { native.pathDatabase = StringToAnsiBytes(value, 256); }
        }

        /// <summary>
        /// Path to history bases
        /// </summary>
        public string PathHistory
        {
            get { return AnsiBytesToString(native.pathHistory); }
            set { native.pathHistory = StringToAnsiBytes(value, 256); }
        }

        /// <summary>
        /// Path to log
        /// </summary>
        public string PathLog
        {
            get { return AnsiBytesToString(native.pathLog); }
            set { native.pathLog = StringToAnsiBytes(value, 256); }
        }

        /// <summary>
        /// Day of last overnight
        /// </summary>
        public DateTime OverNightLastDay
        {
            get { return native.overnightLastDay.ToDateTime(); }
            set { native.overnightLastDay = value.ToUInt(); }
        }

        /// <summary>
        /// Time of last overnight
        /// </summary>
        public DateTime OverNightLastTime
        {
            get { return native.overnightLastTime.ToDateTime(); }
            set { native.overnightLastTime = value.ToUInt(); }
        }

        /// <summary>
        /// Time of next to last overnight
        /// </summary>
        public DateTime OverNightPrevTime
        {
            get { return native.overnightPrevTime.ToDateTime(); }
            set { native.overnightPrevTime = value.ToUInt(); }
        }

        /// <summary>
        /// Month of last report
        /// </summary>
        public DateTime OverMonthLastMonth
        {
            get { return native.overmonthLastMonth.ToDateTime(); }
            set { native.overmonthLastMonth = value.ToUInt(); }
        }

        /// <summary>
        /// Network adapters list (read-only)
        /// </summary>
        public string Adapters
        {
            get { return AnsiBytesToString(native.adapters); }
        }

        /// <summary>
        /// Array of avaible IP addresses
        /// </summary>
        public UInt32[] BindAdresses
        {
            get { return native.bindAddresses; }
            set { native.bindAddresses = value; }
        }

        /// <summary>
        /// Server version
        /// </summary>
        public short ServerVersion
        {
            get { return native.serverVersion; }
            set { native.serverVersion = value; }
        }

        /// <summary>
        /// Server build
        /// </summary>
        public short ServerBuild
        {
            get { return native.serverBuild; }
            set { native.serverBuild = value; }
        }

        /// <summary>
        /// Web services access list (comma separated IP addresses)
        /// </summary>
        public UInt32[] WebAdresses
        {
            get { return native.webAddresses; }
            set { native.webAddresses = value; }
        }

        /// <summary>
        /// Statement generation time (STATEMENT_END_DAY,STATEMENT_START_DAY)
        /// </summary>
        public StatementMode StatementMode
        {
            get { return (StatementMode) native.statementMode; }
            set { native.statementMode = (Int32) value; }
        }

        /// <summary>
        /// Monthly statement generation day (MONTHLY_STATEMENT_END_MONTH,MONTHLY_STATEMENT_START_MONTH)
        /// </summary>
        public MonthlyStatementMode MonthlyStateMode
        {
            get { return (MonthlyStatementMode) native.monthlyStatementMode; }
            set { native.monthlyStatementMode = (Int32) value; }
        }

        /// <summary>
        /// Ticks keep period
        /// </summary>
        public Int32 KeepTicks
        {
            get { return native.keepticks; }
            set { native.keepticks = value; }
        }

        /// <summary>
        /// Generate statements at weekends
        /// </summary>
        public Int32 StatementWeekend
        {
            get { return native.statementWeekend; }
            set { native.statementWeekend = value; }
        }

        /// <summary>
        /// Last activation Datetime
        /// </summary>
        public DateTime LastActivate
        {
            get { return native.lastActivate.ToDateTime(); }
            set { native.lastActivate = value.ToUInt(); }
        }

        /// <summary>
        /// Last stop Datetime
        /// </summary>
        public DateTime StopLast
        {
            get { return native.stopLast.ToDateTime(); }
            set { native.stopLast = value.ToUInt(); }
        }

        /// <summary>
        /// Last stop delay
        /// </summary>
        public Int32 StopDelay
        {
            get { return native.stopDelay; }
            set { native.stopDelay = value; }
        }

        /// <summary>
        /// Last stop reason
        /// </summary>
        public Int32 StopReason
        {
            get { return native.stopReason; }
            set { native.stopReason = value; }
        }

        /// <summary>
        /// Account allocation URL
        /// </summary>
        public string AccountUrl
        {
            get { return AnsiBytesToString(native.accountUrl); }
            set { native.accountUrl = StringToAnsiBytes(value, 128); }
        }

        /// <summary>
        /// Reserved
        /// </summary>
        protected Int32[] Reserved
        {
            get { return native.reserved; }
        }
    }
}