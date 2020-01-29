using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NConLiveUpdate
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] company;                  // company
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] path;                     // path to LiveUpdate
        public Int32 version;                     // version
        public Int32 build;                       // build
        public Int32 maxconnect;                  // max. simultaneous connections
        public Int32 connections;                 // current connections (read only)
        public Int32 type;                        // type LIVE_UPDATE_*
        public Int32 enable;                      // enable
        public Int32 totalfiles;                  // total files count
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = (UnmanagedType)27)]
        public NLiveInfoFile[] files;           // files' configurations
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public Int32[] reserved;                  // reserved
        public Int32 next;                        // internal data
    }

    /// <summary>
    /// Object that represents live updates configuration
    /// </summary>
    public class ConLiveUpdate : MT4Model<NConLiveUpdate>
    {
        public ConLiveUpdate(int codePage) : base(codePage)
        {
            native.files = new NLiveInfoFile[128];
        }

        /// <summary>
        /// Company
        /// </summary>
        public string Company
        {
            get { return AnsiBytesToString(native.company); }
            set { native.company = StringToAnsiBytes(value, 128); }
        }

        /// <summary>
        /// Path to LiveUpdate
        /// </summary>
        public string Path
        {
            get { return AnsiBytesToString(native.path); }
            set { native.path = StringToAnsiBytes(value, 256); }
        }

        /// <summary>
        /// Version
        /// </summary>
        public Int32 Version
        {
            get { return native.version; }
            set { native.version = value; }
        }

        /// <summary>
        /// Build
        /// </summary>
        public Int32 Build
        {
            get { return native.build; }
            set { native.build = value; }
        }

        /// <summary>
        /// Max. simultaneous connections
        /// </summary>
        public Int32 MaxConnect
        {
            get { return native.maxconnect; }
            set { native.maxconnect = value; }
        }

        /// <summary>
        /// Current connections (read only)
        /// </summary>
        public Int32 Connections
        {
            get { return native.connections; }
        }

        /// <summary>
        /// Type LIVE_UPDATE_*
        /// </summary>
        public LiveUpdateType Type
        {
            get { return (LiveUpdateType) native.type; }
            set { native.type = (Int32) value; }
        }

        /// <summary>
        /// Enable
        /// </summary>
        public Int32 Enable
        {
            get { return native.enable; }
            set { native.enable = value; }
        }

        /// <summary>
        /// Total files
        /// </summary>
        public Int32 TotalFiles
        {
            get { return native.totalfiles; }
            set { native.totalfiles = value; }
        }

        /// <summary>
        /// Files configurations
        /// </summary>
        public IList<LiveInfoFile> Files
        {
            get { return native.files.ToEntities<NLiveInfoFile, LiveInfoFile>(count: TotalFiles, codePage: CodePage); }
            set { native.files = value.ToNatives<NLiveInfoFile, LiveInfoFile>(); }
        }

        /// <summary>
        /// Reserved
        /// </summary>
        protected Int32[] Reserved
        {
            get { return native.reserved; }
        }
    }
}