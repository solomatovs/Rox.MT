using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NTickRequest
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] symbol;
        public UInt32 from;
        public UInt32 to;
        [MarshalAs(UnmanagedType.I1)]
        public byte flags;
    }

    /// <summary>
    /// Object that represents tick request
    /// </summary>
    public class TickRequest : MT4Model<NTickRequest>
    {
        public TickRequest(int codePage) : base(codePage) { }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol
        {
            get { return AnsiBytesToString(native.symbol); }
            set { native.symbol = StringToAnsiBytes(value, 12); }
        }

        /// <summary>
        /// Start of period
        /// </summary>
        public DateTime From
        {
            get { return native.from.ToDateTime(); }
            set { native.from = value.ToUInt(); }
        }

        /// <summary>
        /// End of period
        /// </summary>
        public DateTime To
        {
            get { return native.to.ToDateTime(); }
            set { native.to = value.ToUInt(); }

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