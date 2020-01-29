using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NConSymbolGroup
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] name;                     // group name
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] description;              // group description
    }

    /// <summary>
    /// Object that represents symbol group configuration
    /// </summary>
    public class ConSymbolGroup : MT4Model<NConSymbolGroup>
    {
        public ConSymbolGroup(int codePage) : base(codePage) { }

        public static Int32 MAX_SEC_GROUP = 32;
        /// <summary>
        /// Group name
        /// </summary>
        public string Name
        {
            get { return AnsiBytesToString(native.name); }
            set { native.name = StringToAnsiBytes(value, 16); }
        }

        /// <summary>
        /// Group description
        /// </summary>
        public string Description
        {
            get { return AnsiBytesToString(native.description); }
            set { native.description = StringToAnsiBytes(value, 64); }
        }
    }
}