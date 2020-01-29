using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NChartInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] symbol;
        public Int32 period;
        public UInt32 start;
        public UInt32 end;
        public UInt32 timesign;
        public Int32 mode;
    }

    /// <summary>
    /// Request chart history struct
    /// </summary>
    public class ChartInfo : MT4Model<NChartInfo>
    {
        public ChartInfo(int codePage) : base(codePage) { }
        public string Symbol
        {
            get { return AnsiBytesToString(native.symbol); }
            set { native.symbol = StringToAnsiBytes(value, 12); }
        }

        public ChartPeriod Period
        {
            get { return (ChartPeriod)native.period; }
            set { native.period = (Int32)value; }
        }

        public DateTime Start
        {
            get { return native.start.ToDateTime(); }
            set { native.start = value.ToUInt(); }
        }

        public DateTime End
        {
            get { return native.end.ToDateTime(); }
            set { native.end = value.ToUInt(); }
        }

        public DateTime Timesign
        {
            get { return native.timesign.ToDateTime(); }
            set { native.timesign = value.ToUInt(); }
        }

        public ChartRequestMode Mode
        {
            get { return (ChartRequestMode)native.mode; }
            set { native.mode = (Int32) value; }
        }
    }
}