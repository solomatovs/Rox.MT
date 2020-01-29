using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NReportGroupRequest
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] name;
        public UInt32 from;
        public UInt32 to;
        public Int32 total;
    }

    /// <summary>
    /// Reports request
    /// </summary>
    public class ReportGroupRequest : MT4Model<NReportGroupRequest>
    {
        public ReportGroupRequest(int codePage) : base(codePage) { }
        /// <summary>
        /// Request group name
        /// </summary>
        public string Name
        {
            get { return AnsiBytesToString(native.name); }
            set { native.name = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// DateTime from
        /// </summary>
        public DateTime From
        {
            get { return native.from.ToDateTime(); }
            set { native.from = value.ToUInt(); }
        }

        /// <summary>
        /// DateTime to
        /// </summary>
        public DateTime To
        {
            get { return native.to.ToDateTime(); }
            set { native.to = value.ToUInt(); }
        }

        /// <summary>
        /// total logins in request group
        /// </summary>
        internal Int32 Total
        {
            get { return native.total; }
            set { native.total = value; }
        }
    }
}