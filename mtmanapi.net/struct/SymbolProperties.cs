using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    public struct NSymbolProperties
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] symbol;
        public UInt32 color;
        public Int32 spread;
        public Int32 spreadBalance;
        public Int32 stopsLevel;
        public Int32 smoothing;
        public Int32 exeMode;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public Int32[] reserved;
    }

    public struct NSymbolPropertiesOld
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] symbol;
        public UInt32 color;
        public Int32 spread;
        public Int32 spreadBalance;
        public Int32 stopsLevel;
        public Int32 exeMode;
    }

    /// <summary>
    /// Object that represents symbol properties
    /// </summary>
    public class SymbolProperties : MT4Model<NSymbolProperties>
    {
        public SymbolProperties(int codePage) : base(codePage) { }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol
        {
            get { return AnsiBytesToString(native.symbol); }
            set { native.symbol = StringToAnsiBytes(value, 12); }
        }

        /// <summary>
        /// Symbol color
        /// </summary>
        public UInt32 Color
        {
            get { return native.color; }
            set { native.color = value; }
        }

        /// <summary>
        /// Symbol spread
        /// </summary>
        public Int32 Spread
        {
            get { return native.spread; }
            set { native.spread = value; }
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
        /// Stops level
        /// </summary>
        public Int32 StopsLevel
        {
            get { return native.stopsLevel; }
            set { native.stopsLevel = value; }
        }

        /// <summary>
        /// Smoothing
        /// </summary>
        public Int32 Smoothing
        {
            get { return native.smoothing; }
            set { native.smoothing = value; }
        }

        /// <summary>
        /// Execution mode
        /// </summary>
        public SymbolExecutionMode Exemode
        {
            get { return (SymbolExecutionMode) native.exeMode; }
            set { native.exeMode = (Int32) value; }
        }

        /// <summary>
        /// Reserved
        /// </summary>
        protected Int32[] Reserved
        {
            get { return native.reserved; }
            private set { native.reserved = value; }
        }
    }

    /// <summary>
    /// Object that represents symbol properties
    /// </summary>
    public class SymbolPropertiesOld : MT4Model<NSymbolPropertiesOld>
    {
        public SymbolPropertiesOld(int codePage) : base(codePage) { }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol
        {
            get { return AnsiBytesToString(native.symbol); }
            set { native.symbol = StringToAnsiBytes(value, 12); }
        }

        /// <summary>
        /// Symbol color
        /// </summary>
        public UInt32 Color
        {
            get { return native.color; }
            set { native.color = value; }
        }

        /// <summary>
        /// Symbol spread
        /// </summary>
        public Int32 Spread
        {
            get { return native.spread; }
            set { native.spread = value; }
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
        /// Stops level
        /// </summary>
        public Int32 StopsLevel
        {
            get { return native.stopsLevel; }
            set { native.stopsLevel = value; }
        }

        /// <summary>
        /// Execution mode
        /// </summary>
        public SymbolExecutionMode Exemode
        {
            get { return (SymbolExecutionMode)native.exeMode; }
            set { native.exeMode = (Int32)value; }
        }
    }
}