using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NLiveInfoFile
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] file;
        public Int32 size;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 36)]
        public byte[] hash;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public Int32[] reserve;
    }

    /// <summary>
    /// Object that represents files configuration
    /// </summary>
    public class LiveInfoFile : MT4Model<NLiveInfoFile>
    {
        public LiveInfoFile(int codePage) : base(codePage) { }
        /// <summary>
        /// File name
        /// </summary>
        public string File
        {
            get { return AnsiBytesToString(native.file); }
            set { native.file = StringToAnsiBytes(value, 256); }
        }

        /// <summary>
        /// File size
        /// </summary>
        public Int32 Size
        {
            get { return native.size; }
            set { native.size = value; }
        }

        /// <summary>
        /// File hash
        /// </summary>
        public string Hash
        {
            get { return AnsiBytesToString(native.hash); }
            set { native.hash = StringToAnsiBytes(value, 36); }
        }       
        
        /// <summary>
        /// Reserved
        /// </summary>
        protected Int32[] Reserved
        {
            get { return native.reserve; }
        }
    }
}