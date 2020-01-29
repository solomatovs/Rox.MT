using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NConGroupMargin
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] symbol;
        public double swap_long;
        public double swap_short;
        public double margin_divider;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public Int32[] reserved;
    }

    /// <summary>
    /// Object that represents group margin configuration
    /// </summary>
    public class ConGroupMargin : MT4Model<NConGroupMargin>
    {
        public ConGroupMargin(int codePage) : base(codePage) { }
        /// <summary>
        /// Security
        /// </summary>
        public string Symbol
        {
            get { return AnsiBytesToString(native.symbol); }
            set { native.symbol = StringToAnsiBytes(value, 12); }
        }

        /// <summary>
        /// Swap size for long positions
        /// </summary>
        public double LongSwap
        {
            get { return native.swap_long; }
            set { native.swap_long = value; }
        }

        /// <summary>
        /// Swap size for short positions
        /// </summary>
        public double ShortSwap
        {
            get { return native.swap_short; }
            set { native.swap_short = value; }
        }

        /// <summary>
        /// Margin divider
        /// </summary>
        public double MarginPercentage
        {
            get { return native.margin_divider; }
            set { native.margin_divider = value; }
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