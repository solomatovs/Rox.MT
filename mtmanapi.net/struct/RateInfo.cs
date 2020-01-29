using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NRateInfo
    {
        public UInt32 ctm;
        public Int32 open;
        public Int32 high;
        public Int32 low;
        public Int32 close;
        public double vol;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NRateInfoOld
    {
        public UInt32 ctm;
        public Int32 open;
        public Int16 high;
        public Int16 low;
        public Int16 close;
        public double vol;
    }

    /// <summary>
    /// Object that represents bar/candle
    /// </summary>
    public class RateInfo : MT4Model<NRateInfo>
    {
        public RateInfo(int codePage) : base(codePage) { }
        public RateInfo() : this(0) { }
        
        /// <summary>
        /// Rate time
        /// </summary>
        public DateTime Ctm
        {
            get { return native.ctm.ToDateTime(); }
            set { native.ctm = value.ToUInt(); }
        }

        /// <summary>
        /// Open price
        /// example: Open = 11987, then price = 119.87
        /// </summary>
        public Int32 Open
        {
            get { return native.open; }
            set { native.open = value; }
        }

        /// <summary>
        /// High shift from open
        /// </summary>
        public Int32 High
        {
            get { return native.high; }
            set { native.high = value; }
        }

        /// <summary>
        /// Low shift from open
        /// </summary>
        public Int32 Low
        {
            get { return native.low; }
            set { native.low = value; }
        }

        /// <summary>
        /// Close shift from open
        /// </summary>
        public Int32 Close
        {
            get { return native.close; }
            set { native.close = value; }
        }

        /// <summary>
        /// Volume
        /// </summary>
        public double Volume
        {
            get { return native.vol; }
            set { native.vol = value; }
        }
    }

    /// <summary>
    /// Object that represents bar/candle
    /// </summary>
    public class RateInfoOld : MT4Model<NRateInfoOld>
    {
        public RateInfoOld() : base(0) { }
        /// <summary>
        /// Rate time
        /// </summary>
        public DateTime Ctm
        {
            get { return native.ctm.ToDateTime(); }
            set { native.ctm = value.ToUInt(); }
        }

        /// <summary>
        /// Open price
        /// example: Open = 11987, then price = 119.87
        /// </summary>
        public Int32 Open
        {
            get { return native.open; }
            set { native.open = value; }
        }

        /// <summary>
        /// High shift from open
        /// </summary>
        public Int16 High
        {
            get { return native.high; }
            set { native.high = value; }
        }

        /// <summary>
        /// Low shift from open
        /// </summary>
        public Int16 Low
        {
            get { return native.low; }
            set { native.low = value; }
        }

        /// <summary>
        /// Close shift from open
        /// </summary>
        public Int16 Close
        {
            get { return native.close; }
            set { native.close = value; }
        }

        /// <summary>
        /// Volume
        /// </summary>
        public double Volume
        {
            get { return native.vol; }
            set { native.vol = value; }
        }
    }

    public class RateInfoResult
    {
        public List<RateInfo> Info { get; set; }
        public DateTime Timesign { get; set; }
    }
}