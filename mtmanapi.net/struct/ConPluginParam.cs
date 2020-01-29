using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NConPluginParam
    {
        public NConPlugin plugin;               // plugin configuration
        public IntPtr param;                    // plugin parameters
        public Int32 total;                     // total plugin parameters
    }

    /// <summary>
    /// Object that represents plugin with parameters configuration
    /// </summary>
    public class ConPluginParam : MT4Model<NConPluginParam>, IDisposable
    {
        public ConPluginParam(int codePage) : base(codePage) { }
        public ConPluginParam() : this(0) { }
        public override string ToString()
        {
            var list = new List<string>();
            foreach(var p in Parameters)
            {
                list.Add(p.ToString());
            }

            return string.Join('\n', list);
        }

        /// <summary>
        /// Plugin configuration
        /// </summary>
        public ConPlugin Plugin
        {
            get { return native.plugin.ToEntity<NConPlugin, ConPlugin>(codePage: CodePage); }
            set { native.plugin = value.native; }
        }

        protected IntPtr parametrsPointer
        {
            get
            {
                
                return native.param;
            }
            set
            {
                native.param = value;
            }
        }

        /// <summary>
        /// Plugin parameters
        /// </summary>
        public List<PluginCfg> Parameters
        {
            get
            {
                return parametrsPointer.ToArrayStruct<NPluginCfg>(native.total).ToEntities<NPluginCfg, PluginCfg>(CodePage);
            }
            set
            {
                ParametersFree();
                parametrsPointer = value.ToNatives<NPluginCfg, PluginCfg>().ToPointer<NPluginCfg>();
                native.total = value.Count;
            }
        }

        protected void ParametersFree()
        {
            if (parametrsPointer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(parametrsPointer);
            }
        }

        public void Dispose()
        {
            ParametersFree();
        }
    };
}