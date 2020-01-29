using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    /// <summary>
    /// Struct for ConSymbol class
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NConSymbol
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] symbol;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] description;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] source;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] currency;
        public Int32 type;
        public Int32 digits;
        public Int32 trade;
        public UInt32 backgroundColor;
        public Int32 count;
        public Int32 countOriginal;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public Int32[] external_unused;
        public Int32 realtime;
        public UInt32 starting;
        public UInt32 expiration;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = (UnmanagedType)27)]
        public NConSessions[] sessions;
        public Int32 profitMode;
        public Int32 profitModeReserved;
        public Int32 filter;
        public Int64 filterCounter;
        public double filterLimit;
        public Int32 filterSmoothing;
        public float filterReserved;
        public Int32 logging;
        public Int32 spread;
        public Int32 spreadBalance;
        public Int32 exeMode;
        public Int32 swapEnable;
        public Int32 swapType;
        public double swapLong;
        public double swapShort;
        public Int64 swapRollover3Days;
        public double contractSize;
        public double tickValue;
        public double tickSize;
        public Int32 stopsLevel;
        public Int32 gtcPendings;
        public Int64 marginMode;
        public double marginInitial;
        public double marginMaintenance;
        public double marginHedged;
        public double marginDivider;
        public double point;                       // point size-(1/(10^digits)
        public double multiply;                    // multiply 10^digits
        public double bid_tickvalue;               // tickvalue for bid
        public double ask_tickvalue;               // tickvalue for ask
        public Int32 longOnly;
        public Int32 instantMaxVolume;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] marginCurrency;
        public Int32 freezeLevel;
        public Int32 marginHedgedStrong;
        public UInt32 valueDate;
        public Int32 quotesDelay;
        public Int32 swapOpenPrice;
        public Int32 swapVariationMargin;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
        public Int32[] unused;
    }

    /// <summary>
    /// Object that represents symbol configuration
    /// </summary>
    public class ConSymbol : MT4Model<NConSymbol>
    {
        public ConSymbol(int codePage) : base(codePage)
        {
            native.sessions = new NConSessions[7];
        }

        public override string ToString()
        {
            return $"symbol: {Name} ({Currency} : {Description})";
        }
        /// <summary>
        /// Charge variation margin on rollover
        /// </summary>
        public Int32 SwapVariationMargin
        {
            get { return native.swapVariationMargin; }
            set { native.swapVariationMargin = value; }
        }

        /// <summary>
        /// Use open price at swaps calculation in SWAP_BY_INTEREST mode
        /// </summary>
        public Int32 SwapOpenPrice
        {
            get { return native.swapOpenPrice; }
            set { native.swapOpenPrice = value; }
        }

        /// <summary>
        /// quotes delay after session start
        /// </summary>
        public Int32 QuotesDelay
        {
            get { return native.quotesDelay; }
            set { native.quotesDelay = value; }
        }

        /// <summary>
        /// value date
        /// </summary>
        public DateTime ValueDate
        {
            get { return native.valueDate.ToDateTime(); }
            set { native.valueDate = value.ToUInt(); }
        }

        /// <summary>
        /// Strong hedged margin mode
        /// </summary>
        public Int32 MarginHedgedStrong
        {
            get { return native.marginHedgedStrong; }
            set { native.marginHedgedStrong = value; }
        }

        /// <summary>
        /// Modification freeze level
        /// </summary>
        public Int32 FreezeLevel
        {
            get { return native.freezeLevel; }
            set { native.freezeLevel = value; }
        }

        /// <summary>
        /// Currency of margin requirments
        /// </summary>
        public string MarginCurrency
        {
            get { return AnsiBytesToString(native.marginCurrency); }
            set { native.marginCurrency = StringToAnsiBytes(value, 12); }
        }

        /// <summary>
        /// Max. volume for Instant Execution
        /// </summary>
        public Int32 InstantMaxVolume
        {
            get { return native.instantMaxVolume; }
            set { native.instantMaxVolume = value; }
        }

        /// <summary>
        /// Allow only BUY positions
        /// </summary>
        public Int32 LongOnly
        {
            get { return native.longOnly; }
            set { native.longOnly = value; }
        }

        /// <summary>
        /// Point size-(1/(10^digits)
        /// </summary>
        public double Point
        {
            get { return native.point; }
            set { native.point = value; }
        }

        /// <summary>
        /// Multiply 10^digits
        /// </summary>
        public double Multiply
        {
            get { return native.multiply; }
            set { native.multiply = value; }
        }

        /// <summary>
        /// Tickvalue for bid
        /// </summary>
        public double BidTickValue
        {
            get { return native.bid_tickvalue; }
            set { native.bid_tickvalue = value; }
        }

        /// <summary>
        /// Tickvalue for ask
        /// </summary>
        public double AskTickValue
        {
            get { return native.ask_tickvalue; }
            set { native.ask_tickvalue = value; }
        }

        /// <summary>
        /// Margin divider
        /// </summary>
        public double MarginDivider
        {
            get { return native.marginDivider; }
            set { native.marginDivider = value; }
        }

        /// <summary>
        /// Hedged margin
        /// </summary>
        public double MarginHedged
        {
            get { return native.marginHedged; }
            set { native.marginHedged = value; }
        }

        /// <summary>
        /// Margin maintenance
        /// </summary>
        public double MarginMaintenance
        {
            get { return native.marginMaintenance; }
            set { native.marginMaintenance = value; }
        }

        /// <summary>
        /// initial margin
        /// </summary>
        public double MarginInitial
        {
            get { return native.marginInitial; }
            set { native.marginInitial = value; }
        }

        /// <summary>
        /// margin calculation mode
        /// </summary>
        public SymbolMarginCalculationMode MarginMode
        {
            get { return (SymbolMarginCalculationMode)native.marginMode; }
            set { native.marginMode = (Int64)value; }
        }

        /// <summary>
        /// GTC mode { ORDERS_DAILY, ORDERS_GTC, ORDERS_DAILY_NO_STOPS }
        /// </summary>
        public GtcMode GtcPendings
        {
            get { return (GtcMode)native.gtcPendings; }
            set { native.gtcPendings = (Int32)value; }
        }

        /// <summary>
        /// stops deviation value
        /// </summary>
        public Int32 StopsLevel
        {
            get { return native.stopsLevel; }
            set { native.stopsLevel = value; }
        }

        /// <summary>
        /// One tick size
        /// </summary>
        public double TickSize
        {
            get { return native.tickSize; }
            set { native.tickSize = value; }
        }

        /// <summary>
        /// One tick value
        /// </summary>
        public double TickValue
        {
            get { return native.tickValue; }
            set { native.tickValue = value; }
        }

        /// <summary>
        /// Contract size
        /// </summary>
        public double ContractSize
        {
            get { return native.contractSize; }
            set { native.contractSize = value; }
        }

        /// <summary>
        /// Triple rollover day 0-Sunday,1-Monday,2-Tuesday...
        /// </summary>
        public Int64 SwapRollover3Days
        {
            get { return native.swapRollover3Days; }
            set { native.swapRollover3Days = value; }
        }

        /// <summary>
        /// Swaps values for short postions
        /// </summary>
        public double SwapShort
        {
            get { return native.swapShort; }
            set { native.swapShort = value; }
        }

        /// <summary>
        /// Swaps values for long postions
        /// </summary>
        public double SwapLong
        {
            get { return native.swapLong; }
            set { native.swapLong = value; }
        }

        /// <summary>
        /// Swap type
        /// </summary>
        public SwapType SwapType
        {
            get { return (SwapType)native.swapType; }
            set { native.swapType = (Int32)value; }
        }

        /// <summary>
        /// Enable swaps
        /// </summary>
        public Int32 SwapsEnabled
        {
            get { return native.swapEnable; }
            set { native.swapEnable = value; }
        }

        /// <summary>
        /// Execution mode
        /// </summary>
        public SymbolExecutionMode Exemode
        {
            get { return (SymbolExecutionMode)native.exeMode; }
            set { native.exeMode = (Int32)value; }
        }

        /// <summary>
        /// Spread balance
        /// </summary>
        public Int32 SpreadBalance
        {
            get { return native.spreadBalance; }
            set { native.spreadBalance = value; }
        }

        /// <summary>
        /// Spread
        /// </summary>
        public Int32 Spread
        {
            get { return native.spread; }
            set { native.spread = value; }
        }

        /// <summary>
        /// Enable to log quotes
        /// </summary>
        public Int32 Logging
        {
            get { return native.logging; }
            set { native.logging = value; }
        }

        /// <summary>
        /// Smoothing
        /// </summary>
        public Int32 FilterSmoothing
        {
            get { return native.filterSmoothing; }
            set { native.filterSmoothing = value; }
        }

        /// <summary>
        /// Max. permissible deviation from last quote (percents)
        /// </summary>
        public double FilterLimit
        {
            get { return native.filterLimit; }
            set { native.filterLimit = value; }
        }

        /// <summary>
        /// Filtration level
        /// </summary>
        public Int64 FilterCounter
        {
            get { return native.filterCounter; }
            set { native.filterCounter = value; }
        }

        /// <summary>
        /// Filter value
        /// </summary>
        public Int32 Filter
        {
            get { return native.filter; }
            set { native.filter = value; }
        }

        /// <summary>
        /// Profit calculation mode
        /// </summary>
        public ProfitCalculationMode ProfitMode
        {
            get { return (ProfitCalculationMode)native.profitMode; }
            set { native.profitMode = (Int32)value; }
        }

        /// <summary>
        /// reserved
        /// </summary>
        public Int32 ProfitModeReserved
        {
            get { return native.profitModeReserved; }
        }

        /// <summary>
        /// Quote and trade sessions
        /// </summary>
        public List<ConSessions> Sessions
        {
            get { return native.sessions.ToEntities<NConSessions, ConSessions>(codePage: CodePage, count: 7); }
            set { native.sessions = value.ToNatives<NConSessions, ConSessions>(); }
        }

        /// <summary>
        /// Trades end date
        /// </summary>
        public DateTime Expiration
        {
            get { return native.expiration.ToDateTime(); }
            set { native.expiration = value.ToUInt(); }
        }

        /// <summary>
        /// Trades starting date
        /// </summary>
        public DateTime Starting
        {
            get { return native.starting.ToDateTime(); }
            set { native.starting = value.ToUInt(); }
        }

        /// <summary>
        /// Allow real time quotes
        /// </summary>
        public Int32 RealTime
        {
            get { return native.realtime; }
            set { native.realtime = value; }
        }

        /// <summary>
        /// Symbols index in market watch
        /// </summary>
        public Int32 CountOriginal
        {
            get { return native.countOriginal; }
            set { native.countOriginal = value; }
        }

        /// <summary>
        /// Symbols index position
        /// </summary>
        public Int32 Count
        {
            get { return native.count; }
            set { native.count = value; }
        }

        /// <summary>
        /// Background color
        /// </summary>
        public UInt32 BackgroundColor
        {
            get { return native.backgroundColor; }
            set { native.backgroundColor = value; }
        }

        /// <summary>
        /// Trade mode
        /// </summary>
        public TradeMode Trade
        {
            get { return (TradeMode)native.trade; }
            set { native.trade = (Int32)value; }
        }

        /// <summary>
        /// Security precision
        /// </summary>
        public Int32 Digits
        {
            get { return native.digits; }
            set { native.digits = value; }
        }

        /// <summary>
        /// Security group (see ConSymbolGroup)
        /// </summary>
        public Int32 Type
        {
            get { return native.type; }
            set { native.type = value; }
        }

        /// <summary>
        /// Currency
        /// </summary>
        public string Currency
        {
            get { return AnsiBytesToString(native.currency); }
            set { native.currency = StringToAnsiBytes(value, 12); }
        }

        /// <summary>
        /// Synonym
        /// </summary>
        public string Source
        {
            get { return AnsiBytesToString(native.source); }
            set { native.source = StringToAnsiBytes(value, 12); }
        }

        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            get { return AnsiBytesToString(native.description); }
            set { native.description = StringToAnsiBytes(value, 64); }
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get { return AnsiBytesToString(native.symbol); }
            set { native.symbol = StringToAnsiBytes(value, 12); }
        }
    }
}