using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NPluginCfg
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] name;                    // parameter name
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] value;                   // parameter value
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public Int32[] reserved;               // reserved
    }

    /// <summary>
    /// Object that represents plugin parameter configuration
    /// </summary>
    public class PluginCfg : MT4Model<NPluginCfg>
    {
        public PluginCfg(int codePage) : base(codePage) { }
        public override string ToString()
        {
            return $"param: {Name}; value: {Value}";
        }
        /// <summary>
        /// parameter name
        /// </summary>
        public string Name
        {
            get { return AnsiBytesToString(native.name); }
            set { native.name = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// Parameter value
        /// </summary>
        public string Value
        {
            get { return AnsiBytesToString(native.value); }
            set { native.value = StringToAnsiBytes(value, 128); }
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