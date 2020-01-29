using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NPluginInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] name;                    // plugin name
        public UInt32 version;                 // plugin version
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] copyright;               // plugin copyright
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public Int32[] reserved;               // reserved
    }

    /// <summary>
    /// Object that represents plugin information configuration
    /// </summary>
    public class PluginInfo : MT4Model<NPluginInfo>
    {
        public PluginInfo(int codePage) : base(codePage) { }
        public override string ToString()
        {
            return $"name: {Name} (version: {Version} ; copyright: {Copyright})";
        }
        /// <summary>
        /// Plugin name
        /// </summary>
        public string Name
        {
            get { return AnsiBytesToString(native.name); }
            set { native.name = StringToAnsiBytes(value, 128); }
        }

        /// <summary>
        /// Plugin version
        /// </summary>
        public UInt32 Version
        {
            get { return native.version; }
            set { native.version = value; }
        }

        /// <summary>
        /// Plugin copyright
        /// </summary>
        public string Copyright
        {
            get { return AnsiBytesToString(native.copyright); }
            set { native.copyright = StringToAnsiBytes(value, 128); }
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