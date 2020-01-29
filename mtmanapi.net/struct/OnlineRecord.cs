using System;
using System.Net;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NOnlineRecord
    {
        public Int32 counter;
        public Int32 reserved;
        public Int32 login;
        public UInt32 ip;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] group;
    }

    public class OnlineRecord : MT4Model<NOnlineRecord>
    {
        public OnlineRecord(int codePage) : base(codePage) { }
        public override string ToString()
        {
            return $"online {Login} ({Group}) ; ip: {IPAddress} ; count connection: {ConnectionsCount}";
        }
        /// <summary>
        /// connections counter
        /// </summary>
        public Int32 ConnectionsCount
        {
            get { return native.counter; }
            set { native.counter = value; }
        }

        /// <summary>
        /// reserved
        /// </summary>
        public Int32 Reserved
        {
            get { return native.reserved; }
        }

        /// <summary>
        /// user login
        /// </summary>
        public Int32 Login
        {
            get { return native.login; }
            set { native.login = value; }
        }

        /// <summary>
        /// connection ip address
        /// </summary>
        public UInt32 IPAddress
        {
            get { return native.ip; }
            set { native.ip = value; }
        }

        /// <summary>
        /// user group
        /// </summary>
        public string Group
        {
            get { return AnsiBytesToString(native.group); }
            set { native.group = StringToAnsiBytes(value, 16); }
        }
    }
}