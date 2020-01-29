using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NConPlugin
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] file;                 // plugin file name
        public NPluginInfo info;            // plugin description
        public Int32 enabled;               // plugin enabled/disabled
        public Int32 configurable;          // is plugin configurable
        public Int32 manager_access;        // plugin can be accessed from manager terminal
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 62)]
        public Int32[] reserved;            // reserved
    }

    /// <summary>
    /// Object that represents plugin configuration
    /// </summary>
    public class ConPlugin : MT4Model<NConPlugin>
    {
        public ConPlugin(int codePage) : base(codePage)
        {
        }

        public override string ToString()
        {
            return $"plugin {File} ({Enabled}) {Info}";
        }
        /// <summary>
        /// Plugin file name
        /// </summary>
        public string File
        {
            get { return AnsiBytesToString(native.file); }
            set { native.file = StringToAnsiBytes(value, 256); }
        }

        /// <summary>
        /// Plugin description
        /// </summary>
        public PluginInfo Info
        {
            get { return native.info.ToEntity<NPluginInfo, PluginInfo>(codePage: CodePage); }
            set { native.info = value.native; }
        }

        /// <summary>
        /// Plugin enabled/disabled
        /// </summary>
        public Int32 Enabled
        {
            get { return native.enabled; }
            set { native.enabled = value; }
        }

        /// <summary>
        /// Is plugin configurable
        /// </summary>
        public Int32 Configurable
        {
            get { return native.configurable; }
            set { native.configurable = value; }
        }

        /// <summary>
        /// Plugin can be accessed from manager terminal
        /// </summary>
        public Int32 ManagerAccess
        {
            get { return native.manager_access; }
            set { native.manager_access = value; }
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