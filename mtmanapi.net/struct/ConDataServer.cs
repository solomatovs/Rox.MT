using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NConDataServer
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] server;
        public UInt32 ip;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] description;
        public Int32 isproxy;
        public Int32 priority;
        public UInt32 loading;
        public UInt32 ip_internal;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] iswitness;
        public char reserved1;
        public Int32 reserved2;
        public Int32 next;
    }

    /// <summary>
    /// Object that represents data server configuration
    /// </summary>
    public class ConDataServer : MT4Model<NConDataServer>
    {
        public ConDataServer(int codePage) : base(codePage) { }
        /// <summary>
        /// Server address (server:ip)
        /// </summary>
        public string Server
        {
            get { return AnsiBytesToString(native.server); }
            set { native.server = StringToAnsiBytes(value, 64); }
        }

        /// <summary>
        /// Server IP
        /// </summary>
        public UInt32 Ip
        {
            get { return native.ip; }
            set { native.ip = value; }
        }

        /// <summary>
        /// Server description
        /// </summary>
        public string Description
        {
            get { return AnsiBytesToString(native.description); }
            set { native.description = StringToAnsiBytes(value, 64); }
        }

        /// <summary>
        /// Can server be proxy?
        /// </summary>
        private Int32 IsProxy
        {
            get { return native.isproxy; }
            set { native.isproxy = value; }
        }

        /// <summary>
        /// Priority: 0-7 base, 255-idle
        /// </summary>
        public Int32 Priority
        {
            get { return native.priority; }
            set
            {
                if (value < 0 || value > 255)
                {
                    throw new ArgumentException($"{nameof(Priority)} cannot be {value}. range avaliable 0 - 255");
                }
                native.priority = value;
            }
        }

        /// <summary>
        /// Server loading (UINT_MAX-server does not inform its loading)
        /// </summary>
        public UInt32 Loading
        {
            get { return native.loading; }
            // set { native.loading = value; }
        }

        /// <summary>
        /// Internal IP address   
        /// </summary>
        public UInt32 IpInternal
        {
            get { return native.ip_internal; }
            set { native.ip_internal = value; }
        }


        public string IsWitness
        {
            get { return AnsiBytesToString(native.iswitness); }
            set { native.iswitness = StringToAnsiBytes(value, 1); }
        }
    }
}