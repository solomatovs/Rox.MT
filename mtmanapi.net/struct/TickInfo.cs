using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NTickInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] symbol;
        public UInt32 ctm;
        public double bid;
        public double ask;
    }

    /// <summary>
    /// Object that represents tick info
    /// </summary>
    public class TickInfo : MT4Model<NTickInfo>
    {
        public TickInfo(int codePage) : base(codePage) { }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol
        {
            get { return AnsiBytesToString(native.symbol); }
            set { native.symbol = StringToAnsiBytes(value, 12); }
        }

        /// <summary>
        /// Tick time
        /// </summary>
        public DateTime Time
        {
            get { return native.ctm.ToDateTime(); }
            set { native.ctm = value.ToUInt(); }
        }

        /// <summary>
        /// Ask price
        /// </summary>
        public double Ask
        {
            get { return native.ask; }
            set { native.ask = value; }
        }

        /// <summary>
        /// Bid price
        /// </summary>
        public double Bid
        {
            get { return native.bid; }
            set { native.bid = value; }
        }
    }
}