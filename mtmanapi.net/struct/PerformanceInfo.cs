using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NPerformanceInfo
    {
        public UInt32 ctm;
        public short users;                // online users
        public short cpu;                  // processor loading (%)
        public Int32 freemem;              // free memory (Kb)
        public Int32 network;              // network activity (Kb/s)
        public Int32 sockets;              // all open sockets in system
    }

    /// <summary>
    /// Object that represents performance information
    /// </summary>
    public class PerformanceInfo : MT4Model<NPerformanceInfo>
    {
        public PerformanceInfo() : base(0) { }
        /// <summary>
        /// Time
        /// </summary>
        public DateTime Ctm
        {
            get { return native.ctm.ToDateTime(); }
            set { native.ctm = value.ToUInt(); }
        }

        /// <summary>
        /// Online users
        /// </summary>
        public short Users
        {
            get { return native.users; }
            set { native.users = value; }
        }

        /// <summary>
        /// Processor loading (%)
        /// </summary>
        public short Cpu
        {
            get { return native.cpu; }
            set { native.cpu = value; }
        }

        /// <summary>
        /// Free memory (Kb)
        /// </summary>
        public Int32 FreeMem
        {
            get { return native.freemem; }
            set { native.freemem = value; }
        }

        /// <summary>
        /// Network activity (Kb/s)
        /// </summary>
        public Int32 Network
        {
            get { return native.network; }
            set { native.network = value; }
        }

        /// <summary>
        /// All open sockets in system
        /// </summary>
        public Int32 Sockets
        {
            get { return native.sockets; }
            set { native.sockets = value; }
        }
    };
}