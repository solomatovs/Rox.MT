using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NConGatewayMarkup
    {
        public Int32 enable;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] source;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] symbol;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] account_name;
        public Int32 account_id;
        public Int32 bid_markup;
        public Int32 ask_markup;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public Int32[] reserved;
    }

    /// <summary>
    /// Object that represents gateway markup configuration
    /// </summary>
    public class ConGatewayMarkup : MT4Model<NConGatewayMarkup>
    {
        public ConGatewayMarkup(int codePage) : base(codePage) { }
        /// <summary>
        /// Enable flag 0 - disabled, 1 - enabled
        /// </summary>
        public Int32 Enable
        {
            get { return native.enable; }
            set { native.enable = value; }
        }

        /// <summary>
        /// Source symbol\symbols mask\symbols group name
        /// </summary>
        public string Source
        {
            get { return AnsiBytesToString(native.source); }
            set { native.source = StringToAnsiBytes(value, 128); }
        }

        /// <summary>
        /// Local symbol name
        /// </summary>
        public string Symbol
        {
            get { return AnsiBytesToString(native.symbol); }
            set { native.symbol = StringToAnsiBytes(value, 12); }
        }

        /// <summary>
        /// Account name (obsolete)
        /// </summary>
        public string AccountName
        {
            get { return AnsiBytesToString(native.account_name); }
            set { native.account_name = StringToAnsiBytes(value, 64); }
        }

        /// <summary>
        /// Account internal id (obsolete)
        /// </summary>
        public Int32 AccountID
        {
            get { return native.account_id; }
            set { native.account_id = value; }
        }

        /// <summary>
        /// Bid markup in pips
        /// </summary>
        public Int32 BidMarkup
        {
            get { return native.bid_markup; }
            set { native.bid_markup = value; }
        }

        /// <summary>
        /// Ask markup in pips
        /// </summary>
        public Int32 AskMarkup
        {
            get { return native.ask_markup; }
            set { native.ask_markup = value; }
        }

        /// <summary>
        /// Reserved
        /// </summary>
        public Int32[] Reserved
        {
            get { return native.reserved; }
        }
    }
}