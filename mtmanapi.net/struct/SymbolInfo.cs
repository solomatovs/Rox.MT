using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NSymbolInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] symbol;
        public Int32 digits;
        public Int32 count;
        public Int32 visible;
        public Int32 type;
        public double point;
        public Int32 spread;
        public Int32 spreadBalance;
        public Int32 direction;
        public Int32 updateFlag;
        public UInt32 lastTime;
        public double bid;
        public double ask;
        public double high;
        public double low;
        public double commission;
        public Int64 commissionType;
    }

    /// <summary>
    /// Object that represents symbol info
    /// </summary>
    public class SymbolInfo : MT4Model<NSymbolInfo>
    {
        public SymbolInfo(int codePage) : base(codePage) { }
        public override string ToString()
        {
            return $"Symbol: {Symbol}; Time: {LastTime}; Ask: {Ask}; Bid: {Bid}; Spread: {Spread}; Digits: {Digits}; Commission type: {CommissionType}; Commission: {Commission}";
        }
        /// <summary>
        /// Symbol name
        /// </summary>
        public string Symbol
        {
            get { return AnsiBytesToString(native.symbol); }
            set { native.symbol = StringToAnsiBytes(value, 12); }
        }

        /// <summary>
        /// Floating point digits
        /// </summary>
        public Int32 Digits
        {
            get { return native.digits; }
            set { native.digits = value; }
        }

        /// <summary>
        /// Symbol counter
        /// </summary>
        public Int32 Count
        {
            get { return native.count; }
            set { native.count = value; }
        }

        /// <summary>
        /// Visibility
        /// </summary>
        public Int32 Visible
        {
            get { return native.visible; }
            set { native.visible = value; }
        }

        /// <summary>
        /// Symbol type (symbols group index)
        /// </summary>
        public Int32 Type
        {
            get { return native.type; }
            set { native.type = value; }
        }

        /// <summary>
        /// Symbol point=1/pow(10,digits)
        /// </summary>
        public double Point
        {
            get { return native.point; }
            set { native.point = value; }
        }

        /// <summary>
        /// Symbol spread
        /// </summary>
        public Int32 Spread
        {
            get { return native.spread; }
            set { native.spread = value; }
        }

        /// <summary>
        /// Spread balance
        /// </summary>
        public Int32 SpreadBalance
        {
            get { return native.spreadBalance; }
            set { native.spreadBalance = value; }
        }

        /// <summary>
        /// Direction
        /// </summary>
        public SymbolPriceDirection Direction
        {
            get { return (SymbolPriceDirection) native.direction; }
            set { native.direction = (Int32) value; }
        }

        /// <summary>
        /// Update flag
        /// </summary>
        public Int32 UpdateFlag
        {
            get { return native.updateFlag; }
            set { native.updateFlag = value; }
        }

        /// <summary>
        /// Last tick time
        /// </summary>
        public DateTime LastTime
        {
            get { return native.lastTime.ToDateTime(); }
            set { native.lastTime = value.ToUInt(); }
        }

        /// <summary>
        /// Bid
        /// </summary>
        public double Bid
        {
            get { return native.bid; }
            set { native.bid = value; }
        }

        /// <summary>
        /// Ask
        /// </summary>
        public double Ask
        {
            get { return native.ask; }
            set { native.ask = value; }
        }

        /// <summary>
        /// High
        /// </summary>
        public double High
        {
            get { return native.high; }
            set { native.high = value; }
        }

        /// <summary>
        /// Low
        /// </summary>
        public double Low
        {
            get { return native.low; }
            set { native.low = value; }
        }

        /// <summary>
        /// Commission
        /// </summary>
        public double Commission
        {
            get { return Math.Round(native.commission, 8); }
            set { native.commission = value; }
        }

        /// <summary>
        /// Commission type  
        /// </summary>
        public CommissionType CommissionType
        {
            get { return (CommissionType)native.commissionType; }
            set { native.commissionType = (Int64)value; }
        }
    }
}