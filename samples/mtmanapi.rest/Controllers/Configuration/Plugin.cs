using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpGet]
        public async Task<List<ConPluginParam>> CfgRequestPlugin(int codePage)
        {
            return await Task.Run(() => manager.CfgRequestPlugin(codePage));
        }

        public class ModelForUpdatePlugin
        {
            public ConPlugin cfg;
            public PluginCfg parurd;
        }
        [HttpPost]
        public async Task CfgUpdatePlugin([FromBody] ModelForUpdatePlugin cfg, int total)
        {
            await Task.Run(() => manager.CfgUpdatePlugin(cfg.cfg, cfg.parurd, total));
        }

        [HttpPost]
        public async Task CfgShiftPlugin(int pos, int shift)
        {
            await Task.Run(() => manager.CfgShiftPlugin(pos, shift));
        }

        [HttpPost]
        public async Task PluginUpdate([FromBody] ConPluginParam plugin)
        {
            await Task.Run(() => manager.PluginUpdate(plugin));
        }

        [HttpGet]
        public async Task<List<ConPlugin>> PluginsGet(int codePage)
        {
            return await Task.Run(() => manager.PluginsGet(codePage));
        }

        [HttpGet]
        public async Task<ConPluginParam> PluginParamGet(int pos, int codePage)
        {
            return await Task.Run(() => manager.PluginParamGet(pos, codePage));
        }
    }
}
