using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpGet]
        public async Task<List<ConSymbol>> CfgRequestSymbol(int codePage)
        {
            return await Task.Run(() => manager.CfgRequestSymbol(codePage));
        }

        [HttpPost]
        public async Task CfgUpdateSymbol([FromBody] ConSymbol cfg)
        {
            await Task.Run(() => manager.CfgUpdateSymbol(cfg));
        }

        [HttpPost]
        public async Task CfgDeleteSymbol(int pos)
        {
            await Task.Run(() => manager.CfgDeleteSymbol(pos));
        }

        [HttpPost]
        public async Task CfgShiftSymbol(int pos, int shift)
        {
            await Task.Run(() => manager.CfgShiftSymbol(pos, shift));
        }

        [HttpGet]
        public async Task<List<ConSymbolGroup>> CfgRequestSymbolGroup(int codePage)
        {
            return await Task.Run(() => manager.CfgRequestSymbolGroup(codePage));
        }

        [HttpPost]
        public async Task CfgUpdateSymbolGroup([FromBody] ConSymbolGroup cfg, int pos)
        {
            await Task.Run(() => manager.CfgUpdateSymbolGroup(cfg, pos));
        }
    }
}
