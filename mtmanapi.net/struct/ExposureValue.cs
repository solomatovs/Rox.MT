using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NExposureValue
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] currency;
        public double clients;
        public double coverage;
    }

    /// <summary>
    /// Object that represents exposure value
    /// </summary>
    public class ExposureValue : MT4Model<NExposureValue>
    {
        public ExposureValue(int codePage) : base(codePage) { }
        /// <summary>
        /// Currency
        /// </summary>
        public string Currency
        {
            get { return AnsiBytesToString(native.currency); }
            set { native.currency = StringToAnsiBytes(value, 4); }
        }

        /// <summary>
        /// Clients volume
        /// </summary>
        public double Clients
        {
            get { return native.clients; }
            set { native.clients = value; }
        }

        /// <summary>
        /// Coverage volume
        /// </summary>
        public double Coverage
        {
            get { return native.coverage; }
            set { native.coverage = value; }
        }
    }
}