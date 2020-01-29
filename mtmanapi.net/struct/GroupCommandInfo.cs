using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NGroupCommandInfo
    {
        public Int32 len;
        [MarshalAs(UnmanagedType.U1)]
        public byte command;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] newgroup;
        public Int32 leverage;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public Int32[] reserved;
    };

    /// <summary>
    /// Users group operation
    /// </summary>
    public class GroupCommandInfo : MT4Model<NGroupCommandInfo>
    {
        public GroupCommandInfo(int codePage) : base(codePage) { }
        /// <summary>
        /// length of users list
        /// </summary>
        public Int32 Length
        {
            get { return native.len; }
            set { native.len = value; }
        }

        /// <summary>
        /// group coommand
        /// </summary>
        public GroupCommands Command
        {
            get { return (GroupCommands) native.command; }
            set { native.command = (byte) value; }
        }

        /// <summary>
        /// new group
        /// </summary>
        public string NewGroup
        {
            get { return AnsiBytesToString(native.newgroup); }
            set { native.newgroup = StringToAnsiBytes(value, 16); }
        }

        /// <summary>
        /// new leverage
        /// </summary>
        public Int32 Leverage
        {
            get { return native.leverage; }
            set { native.leverage = value; }
        }

        /// <summary>
        /// Reserved
        /// </summary>
        protected Int32[] Reserved
        {
            get { return native.reserved; }
            set { native.reserved = value; }
        }
    }
}