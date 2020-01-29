using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NBalanceDiff
    {
        public Int32 login;
        public double diff;
    }

    /// <summary>
    /// Object that represents balance difference
    /// </summary>
    public class BalanceDiff : MT4Model<NBalanceDiff>
    {
        public BalanceDiff(int codePage) : base(codePage) { }
        public BalanceDiff() : this(0) { }
        /// <summary>
        /// Account number
        /// </summary>
        public Int32 Login
        {
            get  { return native.login; }
            set { native.login = value; }
        }
    
        /// <summary>
        /// Difference
        /// </summary>
        public double Diff
        {
            get { return Math.Round(native.diff, 2); }
            set { native.diff = value; }
        }
    };
}