using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NBackupInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] file;
        public Int32 size;
        public UInt32 time;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U4, SizeConst = 6)]
        public Int32[] reserved;
    }
    
    /// <summary>
    /// Object that represents backup information
    /// </summary>
    public class BackupInfo : MT4Model<NBackupInfo>
    {
        public BackupInfo(int codePage) : base(codePage) { }
        public string File
        {
            get { return AnsiBytesToString(native.file); }
            set { native.file = StringToAnsiBytes(value, 256); }
        }

        public Int32 Size
        {
            get { return native.size; }
            set { native.size = value; }
        }

        public DateTime Time
        {
            get { return native.time.ToDateTime(); }
            set { native.time = value.ToUInt(); }
        }

        protected Int32[] Reserved
        {
            get { return native.reserved; }
        }
    }
}