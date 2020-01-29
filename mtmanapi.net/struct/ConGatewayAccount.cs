using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NConGatewayAccount
    {
        public Int32 enable;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] name;
        public Int32 id;
        public Int32 type;
        public Int32 login;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] address;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] password;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public Int32[] notify_logins;
        public Int32 flags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 23)]
        public Int32[] reserved;
    }

    /// <summary>
    /// Object that represents gateway account configuration
    /// </summary>
    public class ConGatewayAccount : MT4Model<NConGatewayAccount>
    {
        public ConGatewayAccount(int codePage) : base(codePage) { }
        /// <summary>
        /// Enable flag 0 - disabled, 1 - enabled
        /// </summary>
        public Int32 Enable
        {
            get { return native.enable; }
            set { native.enable = value; }
        }

        /// <summary>
        /// Public name
        /// </summary>
        public string Name
        {
            get { return AnsiBytesToString(native.name); }
            set { native.name = StringToAnsiBytes(value, 64); }
        }

        /// <summary>
        /// Internal id
        /// </summary>
        public Int32 ID
        {
            get { return native.id; }
            set { native.id = value; }
        }

        /// <summary>
        /// Type (obsolete)
        /// </summary>
        public Int32 Type
        {
            get { return native.type; }
            set { native.type = value; }
        }

        /// <summary>
        /// STP MT4 login
        /// </summary>
        public Int32 Login
        {
            get { return native.login; }
            set { native.login = value; }
        }

        /// <summary>
        /// MT4 server address
        /// </summary>
        public string Address
        {
            get { return AnsiBytesToString(native.address); }
            set { native.address = StringToAnsiBytes(value, 64); }
        }

        /// <summary>
        /// STP MT4 password
        /// </summary>
        public string Password
        {
            get { return AnsiBytesToString(native.password); }
            set { native.password = StringToAnsiBytes(value, 64); }
        }

        /// <summary>
        /// List of logins for internal email notification
        /// </summary>
        public Int32[] NotifyLogins
        {
            get { return native.notify_logins; }
            set { native.notify_logins = value; }
        }

        /// <summary>
        /// Flag fields
        /// </summary>
        public EnGatewayAccountFlags Flags
        {
            get { return (EnGatewayAccountFlags) native.flags; }
            set { native.enable = (Int32) value; }
        }

        /// <summary>
        /// Reserved
        /// </summary>
        public Int32[] Reserved
        {
            get { return native.reserved; }
        }
    }
}