using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    public static class TradeRecordExtensions
    {
        public static double FullProfit(this TradeRecord p)
        {
            return (p.Profit + p.Storage + p.Commission);
        }
    }
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NTradeRecord
    {
        public Int32 order;
        public Int32 login;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] symbol;
        public Int32 digits;
        public Int32 cmd;
        public Int32 volume;
        public UInt32 open_time;
        public Int32 state;
        public double open_price;
        public double sl;
        public double tp;
        public UInt32 close_time;
        public Int32 gw_volume;
        public UInt32 expiration;
        [MarshalAs(UnmanagedType.I1)]
        public byte reason;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] conv_reserv;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.R8)]
        public double[] conv_rates;
        public double commission;
        public double commission_agent;
        public double storage;
        public double close_price;
        public double profit;
        public double taxes;
        public Int32 magic;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] comment;
        public Int32 gw_order;
        public Int32 activation;
        public short gw_open_price;
        public short gw_close_price;
        public double margin_rate;
        public UInt32 timestamp;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
        public Int32[] api_data;
        public Int32 next;
    }

    public class TradeRecord : MT4Model<NTradeRecord>
    {
        public TradeRecord(int codePage) : base(codePage) { }
        /// <summary>
        /// Order ticket
        /// </summary>
        public Int32 Order
        {
            get { return native.order; }
            set { native.order = value; }
        }

        /// <summary>
        /// Owner's login
        /// </summary>
        public Int32 Login
        {
            get { return native.login; }
            set { native.login = value; }
        }

        /// <summary>
        /// Security
        /// </summary>
        public string Symbol
        {
            get { return AnsiBytesToString(native.symbol); }
            set { native.symbol = StringToAnsiBytes(value, 12); }
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
        /// Trade command
        /// </summary>
        public TradeCommand Cmd
        {
            get { return (TradeCommand)native.cmd; }
            set { native.cmd = (Int32)value; }
        }

        /// <summary>
        /// Volume
        /// </summary>
        public Int32 Volume
        {
            get { return native.volume; }
            set { native.volume = value; }
        }

        /// <summary>
        /// Open time
        /// </summary>
        public DateTime OpenTime
        {
            get { return native.open_time.ToDateTime(); }
            set { native.open_time = value.ToUInt(); }
        }

        /// <summary>
        /// Reserved
        /// </summary>
        public TradeState State
        {
            get { return (TradeState)native.state; }
            set { native.state = (Int32)value; }
        }

        /// <summary>
        /// Open price
        /// </summary>
        public double OpenPrice
        {
            get { return native.open_price; }
            set { native.open_price = value; }
        }

        /// <summary>
        /// Stop loss
        /// </summary>
        public double StopLoss
        {
            get { return native.sl; }
            set { native.sl = value; }
        }

        /// <summary>
        /// Take profit
        /// </summary>
        public double TakeProfit
        {
            get { return native.tp; }
            set { native.tp = value; }
        }

        /// <summary>
        /// Close time
        /// </summary>
        public DateTime CloseTime
        {
            get { return native.close_time.ToDateTime(); }
            set { native.close_time = value.ToUInt(); }
        }

        public bool IsClosed()
        {
            return native.close_time != 0;
        }

        /// <summary>
        /// Gateway order volume
        /// </summary>
        public Int32 GwVolume
        {
            get { return native.gw_volume; }
            set { native.gw_volume = value; }
        }

        /// <summary>
        /// Pending order's expiration time
        /// </summary>
        public DateTime Expiration
        {
            get { return native.expiration.ToDateTime(); }
            set { native.expiration = value.ToUInt(); }
        }

        /// <summary>
        /// Trade reason
        /// </summary>
        public TradeReason Reason
        {
            get { return (TradeReason)native.reason; }
            set { native.reason = (byte)value; }
        }

        /// <summary>
        /// Convertation rates from profit currency to group deposit currency
        /// (first element-for open time, second element-for close time)
        /// </summary>
        public IList<double> ConvRates
        {
            get { return native.conv_rates; }
            set { native.conv_rates = value?.ToArray(); }
        }

        /// <summary>
        /// Commission
        /// </summary>
        public double Commission
        {
            get { return native.commission ; }
            set { native.commission = value; }
        }

        /// <summary>
        /// Agent commission
        /// </summary>
        public double CommissionAgent
        {
            get { return native.commission_agent; }
            set { native.commission_agent = value; }
        }

        /// <summary>
        /// Order swaps
        /// </summary>
        public double Storage
        {
            get { return native.storage; }
            set { native.storage = value; }
        }

        /// <summary>
        /// Close price
        /// </summary>
        public double ClosePrice
        {
            get { return native.close_price; }
            set { native.close_price = value; }
        }

        /// <summary>
        /// Profit
        /// </summary>
        public double Profit
        {
            get { return native.profit; }
            set { native.profit = value; }
        }

        /// <summary>
        /// Taxes
        /// </summary>
        public double Taxes
        {
            get { return native.taxes; }
            set { native.taxes = value; }
        }

        /// <summary>
        /// Special value used by client experts
        /// </summary>
        public Int32 Magic
        {
            get { return native.magic; }
            set { native.magic = value; }
        }

        /// <summary>
        /// Comment
        /// </summary>
        public string Comment
        {
            get { return AnsiBytesToString(native.comment); }
            set { native.comment = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// Gateway order ticket
        /// </summary>
        public Int32 GwOrder
        {
            get { return native.gw_order; }
            set { native.gw_order = value; }
        }

        /// <summary>
        /// used by MT Manager
        /// </summary>
        public ActivationType Activation
        {
            get { return (ActivationType) native.activation; }
            set { native.activation = (Int32) value; }
        }

        /// <summary>
        /// Gateway order price deviation (pips) from order open price
        /// </summary>
        public short GwOpenPrice
        {
            get { return native.gw_open_price; }
            set { native.gw_open_price = value; }
        }

        /// <summary>
        /// Gateway order price deviation (pips) from order close price
        /// </summary>
        public short GwClosePrice
        {
            get { return native.gw_close_price; }
            set { native.gw_close_price = value; }
        }

        /// <summary>
        /// Margin convertation rate (rate of convertation from margin currency to deposit one)
        /// </summary>
        public double MarginRate
        {
            get { return native.margin_rate; }
            set { native.margin_rate = value; }
        }

        /// <summary>
        /// Timestamp when traderecord was requested
        /// </summary>
        public DateTime Timestamp
        {
            get { return native.timestamp.ToDateTime(); }
            set { native.timestamp = value.ToUInt(); }
        }

        /// <summary>
        /// This field stores user data of Manager API
        /// </summary>
        protected IList<Int32> ApiData
        {
            get { return native.api_data; }
            set { native.api_data = value?.ToArray(); }
        }

        /// <summary>
        /// Next struct
        /// </summary>
        protected Int32 Next
        {
            get { return native.next; }
            set { native.next = value; }
        }

        public override string ToString()
        {
            return $"Ticket: {Order}; Login: {Login}; Cmd: {Cmd}; Open Time: {OpenTime}; Open Price: {OpenPrice}; ; Close Time: {CloseTime}; Close Price: {ClosePrice}; Commission: {Commission}; Swaps: {Storage}; Profit: {Profit}; Comment: {Comment}";
        }
    }
}