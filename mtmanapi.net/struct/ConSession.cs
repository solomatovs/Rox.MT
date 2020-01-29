using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NConSession
    {
		public short openHour;
        public short openMinute;
        public short closeHour;
        public short closeMinute;
        public Int32 open;
        public Int32 close;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I2)]
        public short[] align;
    }
    
    /// <summary>
    /// Symbol sessions configurations
    /// </summary>
    public class ConSession : MT4Model<NConSession>
    {
        public ConSession(int codePage) : base(codePage) { }
        public ConSession() : this(0) { }
        /// <summary>
        /// Session close time: minute
        /// </summary>
        public short CloseMinute
        {
            get { return native.closeMinute; }
            set { native.closeMinute = value; }
        }

        /// <summary>
        /// Session close time: hour
        /// </summary>
        public short CloseHour
        {
            get { return native.closeHour; }
            set { native.closeHour = value; }
        }

        /// <summary>
        /// Session open time: minute
        /// </summary>
        public short OpenMinute
        {
            get { return native.openMinute; }
            set { native.openMinute = value; }
        }

        /// <summary>
        /// Session open time: hour
        /// </summary>
        public short OpenHour
        {
            get { return native.openHour; }
            set { native.openHour = value; }
        }

        /// <summary>
        /// Internal data
        /// </summary>
        public Int32 Close
        {
            get { return native.close; }
        }

        /// <summary>
        /// Internal data
        /// </summary>
        public Int32 Open
        {
            get { return native.open; }
        }

        /// <summary>
        /// Internal data
        /// </summary>
        protected short[] Align
        {
            get { return native.align; }
        }
    }
}