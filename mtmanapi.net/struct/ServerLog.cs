using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    public enum ServerLogCode
    {
        CmdEmpty = -1,
        CmdOK,
        CmdTrade,
        CmdLogin,
        CmdWarn,
        CmdErr,
        CmdAtt
    }

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NServerLog
    {
        public ServerLogCode code;                 // code
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        public byte[] time;              // time
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] ip;                // ip
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] message;           // message
    }

    /// <summary>
    /// Object that represents server log
    /// </summary>
    public class ServerLog : MT4Model<NServerLog>
    {
        public ServerLog(int codePage) : base(codePage) { }
        
        /// <summary>
        /// Code
        /// </summary>
        public ServerLogCode Code
        {
            get { return native.code; }
            set { native.code = value; }
        }

        /// <summary>
        /// Time
        /// </summary>
        public string Time
        {
            get { return AnsiBytesToString(native.time); }
            set { native.time = StringToAnsiBytes(value, 24); }
        }

        /// <summary>
        /// IP
        /// </summary>
        public string Ip
        {
            get { return AnsiBytesToString(native.ip); }
            set { native.ip = StringToAnsiBytes(value, 256); }
        }

        /// <summary>
        /// Message
        /// </summary>
        public string Message
        {
            get { return AnsiBytesToString(native.message); }
            set { native.message = StringToAnsiBytes(value, 512); }
        }
    }
}