using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NConSessions
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = (UnmanagedType)27)]
        public NConSession[] quote;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = (UnmanagedType)27)]
        public NConSession[] trade;
        public Int32 quote_overnight;             // internal data
        public Int32 trade_overnight;             // internal data
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public Int32[] reserved;                  // reserved
    }

    /// <summary>
    /// Symbol sessions configurations
    /// </summary>
    public class ConSessions : MT4Model<NConSessions>
    {
        public ConSessions(int codePage) : base(codePage)
        {
            native.quote = new NConSession[3];
            native.trade = new NConSession[3];
        }
        public ConSessions() : this(0)
        {
        }
        /// <summary>
        /// Trade sessions
        /// </summary>
        public IList<ConSession> TradeSessions
        {
            get { return native.trade.ToEntities<NConSession, ConSession>(codePage: CodePage, count: 3); }
            set { native.trade = value.ToNatives<NConSession, ConSession>(); }
        }

        /// <summary>
        /// Quote sessions
        /// </summary>
        public IList<ConSession> QuoteSessions
        {
            get { return native.quote.ToEntities<NConSession, ConSession>(codePage: CodePage, count: 3); }
            set { native.quote = value.ToNatives<NConSession, ConSession>(); }
        }

        /// <summary>
        /// Internal data
        /// </summary>
        //public Int32 QuoteOvernight
        //{
        //    get { return native.quote_overnight; }
        //}

        /// <summary>
        /// Internal data
        /// </summary>
        //public Int32 TradeOvernight
        //{
        //    get { return native.trade_overnight; }
        //}
        
        /// <summary>
        /// Internal data
        /// </summary>
        //protected Int32[] Reserved
        //{
        //    get { return native.reserved; }
        //}
    }
}