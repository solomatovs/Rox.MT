using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NConGatewayRule
    {
        public Int32 enable;                       // enable flag 0 - disabled, 1 - enabled
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] name;                     // public name
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] request_symbol;          // symbol\symbols mask\symbols group name
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] request_group;           // group name or group mask
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public Int32[] request_reserved;         // reserved
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] exe_account_name;         // account name
        public Int32 exe_account_id;               // account public id
        public Int32 exe_max_deviation;            // max. devation
        public Int32 exe_max_profit_slippage;      // max profit slippage in pips
        public Int32 exe_max_profit_slippage_lots; // max profit slippage volume in lots
        public Int32 exe_max_losing_slippage;      // max losing slippage in pips
        public Int32 exe_max_losing_slippage_lots; // max losing slippage volume in lots
        public Int32 exe_account_pos;              // account current position
        public Int32 exe_volume_percent;           // coverage percentage
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 26)]
        public Int32[] exe_reserved;             // reserved
    }

    /// <summary>
    /// Object that represents gateway rule configuration
    /// </summary>
    public class ConGatewayRule : MT4Model<NConGatewayRule>
    {
        public ConGatewayRule(int codePage) : base(codePage) { }
        /// <summary>
        /// Enable flag 0 - disabled, 1 - enabled
        /// </summary>
        public Int32 Enable
        {
            get { return native.enable; }
            set { native.enable = value; }
        }

        /// <summary>
        /// Public name
        /// </summary>
        public string Name
        {
            get { return AnsiBytesToString(native.name); }
            set { native.name = StringToAnsiBytes(value, 64); }
        }

        /// <summary>
        /// Symbol\symbols mask\symbols group name
        /// </summary>
        public string RequestSymbol
        {
            get { return AnsiBytesToString(native.name); }
            set { native.name = StringToAnsiBytes(value, 128); }
        }

        /// <summary>
        /// Group name or group mask
        /// </summary>
        public string RequestGroup
        {
            get { return AnsiBytesToString(native.name); }
            set { native.name = StringToAnsiBytes(value, 128); }
        }

        /// <summary>
        /// Account name
        /// </summary>
        public string ExeAccountName
        {
            get { return AnsiBytesToString(native.name); }
            set { native.name = StringToAnsiBytes(value, 64); }
        }

        /// <summary>
        /// Account internal id
        /// </summary>
        public Int32 ExeAccountID
        {
            get { return native.exe_account_id; }
            set { native.exe_account_id = value; }
        }

        /// <summary>
        /// Max. devation
        /// </summary>
        public Int32 ExeMaxDeviation
        {
            get { return native.exe_max_deviation; }
            set { native.exe_max_deviation = value; }
        }

        /// <summary>
        /// Max profit slippage in pips
        /// </summary>
        public Int32 ExeMaxProfitSlippage
        {
            get { return native.exe_max_profit_slippage; }
            set { native.exe_max_profit_slippage = value; }
        }

        /// <summary>
        /// Max profit slippage volume in lots
        /// </summary>
        public Int32 ExeMaxProfitSlippageLots
        {
            get { return native.exe_max_profit_slippage_lots; }
            set { native.exe_max_profit_slippage_lots = value; }
        }

        /// <summary>
        /// Max losing slippage in pips
        /// </summary>
        public Int32 ExeMaxLosingSlippagev
        {
            get { return native.exe_max_losing_slippage; }
            set { native.exe_max_losing_slippage = value; }
        }

        /// <summary>
        /// Max losing slippage volume in lots
        /// </summary>
        public Int32 ExeMaxLosingSlippageLots
        {
            get { return native.exe_max_losing_slippage_lots; }
            set { native.exe_max_losing_slippage_lots = value; }
        }

        /// <summary>
        /// Account current position
        /// </summary>
        public Int32 ExeAccountPos
        {
            get { return native.exe_account_pos; }
            set { native.exe_account_pos = value; }
        }

        /// <summary>
        /// Coverage percentage
        /// </summary>
        public Int32 ExeVolumePercent
        {
            get { return native.exe_volume_percent; }
            set { native.exe_volume_percent = value; }
        }

        /// <summary>
        /// Reserved
        /// </summary>
        public Int32[] ExeReserved
        {
            get { return native.exe_reserved; }
        }
    }
}