using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NTradeRestoreResult
    {
        public Int32 order;
        public sbyte res;
    }

    /// <summary>
    /// Object that represents trade restore result
    /// </summary>
    public class TradeRestoreResult : MT4Model<NTradeRestoreResult>
    {
        public TradeRestoreResult(int codePage) : base(codePage) { }
        /// <summary>
        /// Order
        /// </summary>
        public Int32 Order
        {
            get { return native.order; }
            set { native.order = value; }
        }

        /// <summary>
        /// Restore result:
        /// RET_OK_NONE     - order restored
        /// RET_ERROR       - error restoring order
        /// </summary>
        public ResultCode Res
        {
            get { return (ResultCode) native.res; }
            set { native.res = (sbyte)value; }
        }
    }
}