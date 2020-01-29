using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpGet]
        public async Task<List<ConGatewayAccount>> CfgRequestGatewayAccount(int codePage)
        {
            return await Task.Run(() => manager.CfgRequestGatewayAccount(codePage));
        }

        [HttpPost]
        public async Task CfgUpdateGatewayAccount([FromBody] ConGatewayAccount cfg)
        {
            await Task.Run(() => manager.CfgUpdateGatewayAccount(cfg));
        }

        [HttpPost]
        public async Task CfgDeleteGatewayAccount(int pos)
        {
            await Task.Run(() => manager.CfgDeleteGatewayAccount(pos));
        }

        [HttpPost]
        public async Task CfgShiftGatewayAccount(int pos, int shift)
        {
            await Task.Run(() => manager.CfgShiftGatewayAccount(pos, shift));
        }

        [HttpGet]
        public async Task<List<ConGatewayMarkup>> CfgRequestGatewayMarkup(int codePage)
        {
            return await Task.Run(() => manager.CfgRequestGatewayMarkup(codePage));
        }

        [HttpPost]
        public async Task CfgShiftGatewayMarkup(int pos, int shift)
        {
            await Task.Run(() => manager.CfgShiftGatewayMarkup(pos, shift));
        }

        [HttpPost]
        public async Task CfgUpdateGatewayMarkup([FromBody] ConGatewayMarkup cfg)
        {
            await Task.Run(() => manager.CfgUpdateGatewayMarkup(cfg));
        }

        [HttpPost]
        public async Task CfgDeleteGatewayMarkup(int pos)
        {
            await Task.Run(() => manager.CfgDeleteGatewayMarkup(pos));
        }

        [HttpGet]
        public async Task<List<ConGatewayRule>> CfgRequestGatewayRule(int codePage)
        {
            return await Task.Run(() => manager.CfgRequestGatewayRule(codePage));
        }

        [HttpPost]
        public async Task CfgShiftGatewayRule(int pos, int shift)
        {
            await Task.Run(() => manager.CfgShiftGatewayRule(pos, shift));
        }

        [HttpPost]
        public async Task CfgUpdateGatewayRule([FromBody] ConGatewayRule cfg)
        {
            await Task.Run(() => manager.CfgUpdateGatewayRule(cfg));
        }

        [HttpPost]
        public async Task CfgDeleteGatewayRule(int pos)
        {
            await Task.Run(() => manager.CfgDeleteGatewayRule(pos));
        }
    }
}
