using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NFeedDescription
    {
        public Int32 version;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] name;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] copyright;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] web;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] email;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] server;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] username;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] userpass;
        public Int32 modes;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] descriptio;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] module;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 54)]
        public Int32[] reserved;
    }

    /// <summary>
    /// Object that represents feed description
    /// </summary>
    public class FeedDescription : MT4Model<NFeedDescription>
    {
        public FeedDescription(int codePage) : base(codePage) { }
        /// <summary>
        /// Data source version
        /// </summary>
        public Int32 Version
        {
            get { return native.version; }
            set { native.version = value;}
        }

        /// <summary>
        /// Data source name
        /// </summary>
        public string Name
        {
            get { return AnsiBytesToString(native.name); }
            set { native.name = StringToAnsiBytes(value, 128); }
        }

        /// <summary>
        /// Copyright string
        /// </summary>
        public string Copyright
        {
            get { return AnsiBytesToString(native.name); }
            set { native.name = StringToAnsiBytes(value, 128); }
        }

        /// <summary>
        /// Data source web
        /// </summary>
        public string Web
        {
            get { return AnsiBytesToString(native.name); }
            set { native.name = StringToAnsiBytes(value, 128); }
        }

        /// <summary>
        /// Data source email
        /// </summary>
        public string Email
        {
            get { return AnsiBytesToString(native.name); }
            set { native.name = StringToAnsiBytes(value, 128); }
        }

        /// <summary>
        /// Feeder server
        /// </summary>
        public string Server
        {
            get { return AnsiBytesToString(native.name); }
            set { native.name = StringToAnsiBytes(value, 128); }
        }

        /// <summary>
        /// Default feeder name
        /// </summary>
        public string UserName
        {
            get { return AnsiBytesToString(native.name); }
            set { native.name = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// Default feeder password
        /// </summary>
        public string UserPass
        {
            get { return AnsiBytesToString(native.name); }
            set { native.name = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// Feeder modes (enum FeederModes)
        /// </summary>
        public FeederModes Modes
        {
            get { return (FeederModes)native.modes; }
            set { native.modes = (Int32) value; }
        }

        /// <summary>
        /// Feeder description
        /// </summary>
        public string Description
        {
            get { return AnsiBytesToString(native.name); }
            set { native.name = StringToAnsiBytes(value, 512); }
        }

        /// <summary>
        /// Reserved
        /// </summary>
        public string Module
        {
            get { return AnsiBytesToString(native.name); }
            set { native.name = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// Reserved
        /// </summary>
        internal Int32[] Reserved
        {
            get { return native.reserved; }
        }
    }
}