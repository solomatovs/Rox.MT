using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct NTradeTransInfo
    {
        public sbyte type;                // trade transaction type
        // public byte reserved;             // reserved
        public short cmd;                 // trade command
        public Int32 order;               // order
        public Int32 orderby;             // order by
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] symbol;             // trade symbol
        public Int32 volume;              // trade volume
        public double price;              // trade price
        public double sl;                 // stoploss
        public double tp;                 // takeprofit
        public Int32 ie_deviation;        // deviation on IE
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] comment;            // comment
        public UInt32 expiration;         // pending order expiration time
        public Int32 crc;                 // crc
    }

    /// <summary>
    /// Object that represents trade transaction info
    /// </summary>
    public class TradeTransInfo : MT4Model<NTradeTransInfo>
    {
        public TradeTransInfo(int codePage) : base(codePage) { }
        /// <summary>
        /// Trade transaction type
        /// </summary>
        public TradeTransactionType Type
        {
            get { return (TradeTransactionType) native.type; }
            set { native.type = (sbyte) value; }
        }

        /// <summary>
        ///Trade command
        /// </summary>
        public TradeCommand Cmd
        {
            get { return (TradeCommand) native.cmd; }
            set { native.cmd = (short) value; }
        }

        /// <summary>
        /// Order
        /// </summary>
        public Int32 Order
        {
            get { return native.order; }
            set { native.order = value; }
        }

        /// <summary>
        /// Login, in case of closing with opposite second order ticket
        /// </summary>
        public Int32 OrderBy
        {
            get { return native.orderby; }
            set { native.orderby = value; }
        }

        /// <summary>
        /// Trade symbol
        /// </summary>
        public string Symbol
        {
            get { return AnsiBytesToString(native.symbol); }
            set { native.symbol = StringToAnsiBytes(value, 12); }
        }

        /// <summary>
        /// Trade volume
        /// </summary>
        public Int32 Volume
        {
            get { return native.volume; }
            set { native.volume = value; }
        }

        /// <summary>
        /// Trade price(open, close), amount to deposit in case of balance operation
        /// </summary>
        public double Price
        {
            get { return native.price; }
            set { native.price = value; }
        }

        /// <summary>
        /// Stop Loss
        /// </summary>
        public double StopLoss
        {
            get { return native.sl; }
            set { native.sl = value; }
        }

        /// <summary>
        /// Take Profit
        /// </summary>
        public double TakeProfit
        {
            get { return native.tp; }
            set { native.tp = value; }
        }

        /// <summary>
        /// Deviation on IE
        /// </summary>
        public Int32 IeDeviation
        {
            get { return native.ie_deviation; }
            set { native.ie_deviation = value; }
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
        /// Pending order expiration time
        /// </summary>
        public DateTime Expiration
        {
            get { return native.expiration.ToDateTime(); }
            set { native.expiration = value.ToUInt(); }
        }

        /// <summary>
        /// Crc
        /// </summary>
        public Int32 Crc
        {
            get { return native.crc; }
            //set { native.crc = value; }
        }
    }

    public static class TradeTransInfoEx
    {
        public static TradeTransInfo ToTradeTransInfo(this MT4BalanceOperation operation, int codePage)
        {
            return new TradeTransInfo(codePage)
            {
                OrderBy = operation.Login,
                Price = operation.Amount,
                Comment = operation.Comment,
                Type = TradeTransactionType.BROKER_BALANCE,
                Cmd = TradeCommand.BALANCE
            };
        }
        public static TradeTransInfo ToTradeTransInfo(this MT4CreditOperation operation, int codePage)
        {
            return new TradeTransInfo(codePage)
            {
                OrderBy = operation.Login,
                Price = operation.Amount,
                Comment = operation.Comment,
                Type = TradeTransactionType.BROKER_BALANCE,
                Cmd = TradeCommand.CREDIT,
                Expiration = operation.Expiration
            };
        }
    }
}