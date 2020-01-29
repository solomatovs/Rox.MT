using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NConSync
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] server;                 // name (address
        public Int32 unusedport;              // port
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] login;                  // for future use-login
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] password;               // for future use=password
        public Int32 enable;                  // enable sychronization
        public Int32 mode;                    // synchronization mode: HB_ADD,HB_UPDATE,HB_INSERT
        public UInt32 from;                   // synchronization range (<0-whole chart)
        public UInt32 to;                     // synchronization range (<0-whole chart)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public byte[] securities;             // symbols list
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
        public Int32[] reserved;              // reserverd
        public Int32 next;                      // public (do not use)
    }

    /// <summary>
    /// Object that represents synchronization configuration
    /// </summary>
    public class ConSync : MT4Model<NConSync>
    {
        public ConSync(int codePage) : base(codePage) { }
        /// <summary>
        /// Name (address)
        /// </summary>
        public string Server
        {
            get { return AnsiBytesToString(native.server); }
            set { native.server = StringToAnsiBytes(value, 64); }
        }

        /// <summary>
        /// Port
        /// </summary>
        public Int32 UnusedPort
        {
            get { return native.unusedport; }
            set { native.unusedport = value; }
        }

        /// <summary>
        /// For future use-login
        /// </summary>
        public string Login
        {
            get { return AnsiBytesToString(native.login); }
            set { native.login = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// For future use=password
        /// </summary>
        public string Password
        {
            get { return AnsiBytesToString(native.password); }
            set { native.password = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// Enable sychronization
        /// </summary>
        public Int32 Enable
        {
            get { return native.enable; }
            set { native.enable = value; }
        }

        /// <summary>
        /// Synchronization mode: HB_ADD,HB_UPDATE,HB_INSERT
        /// </summary>
        public SynchronizationMode Mode
        {
            get { return (SynchronizationMode) native.mode; }
            set { native.mode = (Int32) value; }
        }

        /// <summary>
        /// Synchronization range (0-whole chart)
        /// </summary>
        public DateTime From
        {
            get { return native.from.ToDateTime(); }
            set { native.from = value.ToUInt(); }
        }

        /// <summary>
        /// Synchronization range (0-whole chart)
        /// </summary>
        public DateTime To
        {
            get { return native.to.ToDateTime(); }
            set { native.to = value.ToUInt(); }
        }

        /// <summary>
        /// Symbols list
        /// </summary>
        public string Securities
        {
            get { return AnsiBytesToString(native.securities); }
            set { native.securities = StringToAnsiBytes(value, 1024); }
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