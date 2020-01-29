using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    public struct NConManagerSec
    {
        public Int32 internalValue;              // public data
        public Int32 enable;                     // enable
        public Int32 minimum_lots;               // min. lots
        public Int32 maximum_lots;               // max. lots
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public Int32[] unused;                   // reserved
    }

    /// <summary>
    /// Object that represents manager security configuration
    /// </summary>
    public class ConManagerSec : MT4Model<NConManagerSec>
    {
        public ConManagerSec(int codePage) : base(codePage) { }
        public ConManagerSec() : this(0) { }
        /// <summary>
        /// internal data
        /// </summary>
        protected Int32 Internal
        {
            get { return native.internalValue; }
            private set { native.internalValue = value; }
        }

        /// <summary>
        /// Enable
        /// </summary>
        public Int32 Enable
        {
            get { return native.enable; }
            set { native.enable = value; }
        }

        /// <summary>
        /// Min. lots
        /// </summary>
        public Int32 MinimumLots
        {
            get { return native.minimum_lots; }
            set { native.minimum_lots = value; }
        }

        /// <summary>
        /// Max. lots
        /// </summary>
        public Int32 MaximumLots
        {
            get { return native.maximum_lots; }
            set { native.maximum_lots = value; }
        }

        /// <summary>
        /// Unused
        /// </summary>
        protected Int32[] Unused
        {
            get { return native.unused; }
            private set { native.unused = value; }
        }
    };
}