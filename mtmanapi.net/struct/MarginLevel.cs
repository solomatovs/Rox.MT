using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NMarginLevel
    {
        public Int32 login;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] group;
        public Int32 leverage;
        public Int32 updated;
        public double balance;
        public double equity;
        public Int32 volume;
        public double margin;
        public double marginFree;
        public double marginLevel;
        public Int32 marginType;
        public Int32 levelType;
    }

    /// <summary>
    /// Object that represents margin level
    /// </summary>
    public class MarginLevel : MT4Model<NMarginLevel>
    {
        public MarginLevel(int codePage) : base(codePage) { }
        /// <summary>
        /// User login
        /// </summary>
        public Int32 Login
        {
            get { return native.login; }
            set { native.login = value; }
        }

        /// <summary>
        /// User group
        /// </summary>
        public string Group
        {
            get { return AnsiBytesToString(native.group); }
            set { native.group = StringToAnsiBytes(value, 16); }
        }

        /// <summary>
        /// User leverage
        /// </summary>
        public Int32 Leverage
        {
            get { return native.leverage; }
            set { native.leverage = value; }
        }

        /// <summary>
        /// (internal)
        /// </summary>
        protected Int32 Updated
        {
            get { return native.updated; }
        }

        /// <summary>
        /// Balance + Credit
        /// </summary>
        public double Balance
        {
            get { return native.balance; }
            set { native.balance = value; }
        }

        /// <summary>
        /// Equity
        /// </summary>
        public double Equity
        {
            get { return native.equity; }
            set { native.equity = value; }
        }

        /// <summary>
        /// Lots
        /// </summary>
        public Int32 Volume
        {
            get { return native.volume; }
            set { native.volume =  value; }
        }

        /// <summary>
        /// Margin requirements
        /// </summary>
        public double Margin
        {
            get { return native.margin; }
            set { native.margin = value; }
        }

        /// <summary>
        /// Free margin
        /// </summary>
        public double MarginFree
        {
            get { return native.marginFree; }
            set { native.marginFree = value; }
        }

        /// <summary>
        /// Margin level
        /// </summary>
        public double Level
        {
            get { return native.marginLevel; }
            set { native.marginLevel = value; }
        }

        /// <summary>
        /// Margin controlling type (percent/currency)
        /// </summary>
        public MarginControllingType MarginType
        {
            get { return (MarginControllingType) native.marginType; }
            set { native.marginType =(Int32) value; }
        }

        /// <summary>
        /// Level type(ok/margincall/stopout)
        /// </summary>
        public MarginLevelType LevelType
        {
            get { return (MarginLevelType) native.levelType; }
            set { native.levelType = (Int32) value; }
        }

        public override string ToString()
        {
            return $"{Login} ({Group}) ; margin: {Margin} ; equity: {Equity} ; balance: {Balance} ; margin free {MarginFree} ; volume: {Volume} ; level: {Level} ({LevelType}) ; type: {MarginType}";
        }
    }
}