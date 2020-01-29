using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NConHoliday
    {
        public Int32 year;                        // year
        public Int32 month;                       // month
        public Int32 day;                         // day
        public Int32 from;
        public Int32 to;                          // work time-from & to (minutes)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] symbol;                     // security name or symbol's group name or "All"
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] description;                // description
        public Int32 enable;                      // enable
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 13)]
        public Int32[] reserved;                  // reserved
        public Int32 next;                        // internal data
    }

    /// <summary>
    /// Object that represents holidays configuration
    /// </summary>
    public class ConHoliday : MT4Model<NConHoliday>
    {
        public ConHoliday(int codePage) : base(codePage) { }
        /// <summary>
        /// year
        /// </summary>
        public Int32 Year
        {
            get { return native.year; }
            set { native.year = value; }
        }

        /// <summary>
        /// Month
        /// </summary>
        public Int32 Month
        {
            get { return native.month; }
            set { native.month = value; }
        }

        /// <summary>
        /// Day
        /// </summary>
        public Int32 Day
        {
            get { return native.day; }
            set { native.day = value; }
        }

        /// <summary>
        /// Work time-from (minutes)
        /// </summary>
        public Int32 From
        {
            get { return native.from; }
            set { native.from = value; }
        }

        /// <summary>
        /// Work time-to (minutes)
        /// </summary>
        public Int32 To
        {
            get { return native.to; }
            set { native.to = value; }
        }

        /// <summary>
        /// Security name or symbol's group name or "All"
        /// </summary>
        public string Symbol
        {
            get { return AnsiBytesToString(native.symbol); }
            set { native.symbol = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            get { return AnsiBytesToString(native.description); }
            set { native.description = StringToAnsiBytes(value, 128); }
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
        /// Reserved
        /// </summary>
        protected Int32[] Reserved
        {
            get { return native.reserved; }
        }
    }
}