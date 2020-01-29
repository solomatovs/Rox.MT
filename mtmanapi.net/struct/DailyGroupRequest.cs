using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NDailyGroupRequest
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] name;
        public UInt32 from;
        public UInt32 to;
        public Int32 total;
        public Int32 reserved;
    }

    /// <summary>
    /// Object that represents daily group request
    /// </summary>
    public class DailyGroupRequest : MT4Model<NDailyGroupRequest>
    {
        public DailyGroupRequest(int codePage) : base(codePage) { }
        /// <summary>
        ///Ggroup name
        /// </summary>
        public string Name
        {
            get { return AnsiBytesToString(native.name); }
            set { native.name = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// From
        /// </summary>
        public DateTime From
        {
            get { return native.from.ToDateTime(); }
            set { native.from = value.ToUInt(); }
        }

        /// <summary>
        /// To
        /// </summary>
        public DateTime To
        {
            get { return native.to.ToDateTime(); }
            set { native.to = value.ToUInt(); }
        }

        /// <summary>
        /// Total logins in request group
        /// </summary>
        internal Int32 Total
        {
            get { return native.total; }
            set { native.total = value; }
        }

        /// <summary>
        /// Reserved
        /// </summary>
        protected Int32 Reserved
        {
            get { return native.reserved; }
            set { native.reserved = value; }
        }
    }
}