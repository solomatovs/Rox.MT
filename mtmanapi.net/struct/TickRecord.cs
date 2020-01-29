using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NTickRecord
    {
        public UInt32 ctm;
        public double bid;
        public double ask;
        public Int32 datafeed;
        public byte flags;
    }

    /// <summary>
    /// Object that represents tick record
    /// </summary>
    public class TickRecord : MT4Model<NTickRecord>
    {
        public TickRecord() : base(0) { }
        /// <summary>
        /// Tick time
        /// </summary>
        public DateTime Time
        {
            get { return native.ctm.ToDateTime(); }
            set { native.ctm = value.ToUInt(); }
        }

        /// <summary>
        /// Bid
        /// </summary>
        public double Bid
        {
            get { return native.bid; }
            set { native.bid = value; }
        }

        /// <summary>
        /// Ask
        /// </summary>
        public double Ask
        {
            get { return native.ask; }
            set { native.ask = value; }
        }

        /// <summary>
        /// Index if datafeed
        /// </summary>
        public Int32 DataFeed
        {
            get { return native.datafeed; }
            set { native.datafeed = value; }
        }

        /// <summary>
        /// Type Tick: RAW, NORMAL, ALL (RAW and NORMAL)
        /// </summary>
        public TickRecordFlags Type
        {
            get { return (TickRecordFlags)native.flags; }
            set { native.flags = (byte)value; }
        }
    }
}