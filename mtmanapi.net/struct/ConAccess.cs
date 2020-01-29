using System;
using System.Text;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NConAccess
    {
        public Int32 action;
        public UInt32 from;
        public UInt32 to;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] comment;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
        public Int32[] reserved;
    }

    /// <summary>
    /// Object that represents access configuration
    /// </summary>
    public class ConAccess : MT4Model<NConAccess>
    {
        public ConAccess(int codePage) : base(codePage) { }
        /// <summary>
        /// Type of action (FW_BLOCK,FW_PERMIT)
        /// </summary>
        public AccessActionType Action
        {
            get { return (AccessActionType) native.action; }
            set { native.action = (Int32) value; }
        }

        /// <summary>
        /// From addresses
        /// </summary>
        public UInt32 From
        {
            get { return native.from; }
            set { native.from = value; }
        }

        /// <summary>
        /// To addresses
        /// </summary>
        public UInt32 To
        {
            get { return native.to; }
            set { native.to = value; }
        }

        /// <summary>
        /// Comment
        /// </summary>
        public string Comment
        {
            get { return AnsiBytesToString(native.comment); }
            set { native.comment = StringToAnsiBytes(value, 12); }
        }
    }
}