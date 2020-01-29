using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace rox.mt4.api
{
    // Pack 8 проверено
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NRequestInfo
    {
        public Int32 id;                      // request id
        public Int32 status;                  // request status
        public UInt32 time;                   // request time
        public Int32 manager;                 // manager processing request (if any)
        public Int32 login;                   // user login
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] group;                  // user group
        public double balance;                // user balance
        public double credit;                 // user credit
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public double[] prices;               // bid/ask
        public NTradeTransInfo trade;         // trade transaction
        public Int32 gw_volume;               // gateway order volume
        public Int32 gw_order;                // gateway order ticket
        public short gw_price;                // gateway order price deviation (pips) from request price
        public IntPtr prev;
        public IntPtr next;                   // (internal use)
    }

    /// <summary>
    /// Object that represents request info
    /// </summary>
    public class RequestInfo : MT4Model<NRequestInfo>
    {
        public RequestInfo(int codePage) : base(codePage)
        {
        }

        public override string ToString()
        {
            return $"request: {Id}, login: {Login}, status: {Status}, group: {Group}, time: {Time}, manager: {Manager}, balance: {Balance}, credit: {Credit}";
        }
        /// <summary>
        /// Request id
        /// </summary>
        public Int32 Id
        {
            get { return native.id; }
            set { native.id = value; }
        }

        /// <summary>
        /// Request status
        /// </summary>
        public TradeRequestStatus Status
        {
            get { return (TradeRequestStatus) native.status; }
            set { native.status = (byte)value; }
        }

        /// <summary>
        /// Request time
        /// </summary>
        public DateTimeOffset Time
        {
            get { return native.time.StandartTimeToDateTime(); }
            set { native.time = value.DateTimeToStandartTime(); }
        }

        /// <summary>
        /// Manager processing request (if any)
        /// </summary>
        public Int32 Manager
        {
            get { return native.manager; }
            set { native.manager = value; }
        }

        /// <summary>
        /// User login
        /// </summary>
        public Int32 Login
        {
            get { return native.login; }
            set { native.login = value; }
        }

        /// <summary>
        /// User group
        /// </summary>
        public string Group
        {
            get { return AnsiBytesToString(native.group); }
            set { native.group = StringToAnsiBytes(value, 16); }
        }

        /// <summary>
        /// User balance
        /// </summary>
        public double Balance
        {
            get { return native.balance; }
            set { native.balance = value; }
        }

        /// <summary>
        /// User credit
        /// </summary>
        public double Credit
        {
            get { return native.credit; }
            set { native.credit = value; }
        }

        /// <summary>
        /// Bid/Ask
        /// </summary>
        public IList<double> Prices
        {
            get { return native.prices; }
            set { native.prices = value.ToArray(); }
        }

        /// <summary>
        /// Trade transaction
        /// </summary>
        public TradeTransInfo Trade
        {
            get { return native.trade.ToEntity<NTradeTransInfo, TradeTransInfo>(codePage: CodePage); }
            set { native.trade = value.native; }
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
        /// Gateway order ticket
        /// </summary>
        public Int32 GwOrder
        {
            get { return native.gw_order; }
            set { native.gw_order = value; }
        }

        /// <summary>
        /// Gateway order price deviation (pips) from request price
        /// </summary>
        public short GwPrice
        {
            get { return native.gw_price; }
            set { native.gw_price = value; }
        }

        /// <summary>
        /// (internal use)
        /// </summary>
        protected IntPtr Prev
        {
            get { return native.prev; }
        }

        /// <summary>
        /// (internal use)
        /// </summary>
        protected IntPtr Next
        {
            get { return native.next; }
        }
    }
}