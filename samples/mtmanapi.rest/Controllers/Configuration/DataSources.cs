using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpGet]
        public async Task<IList<ConFeeder>> CfgRequestFeeder(int codePage)
        {
            return await Task.Run(() => manager.CfgRequestFeeder(codePage));
        }

        [HttpPost]
        public async Task CfgUpdateFeeder([FromBody] ConFeeder cfg)
        {
            await Task.Run(() => manager.CfgUpdateFeeder(cfg));
        }

        [HttpPost]
        public async Task CfgDeleteFeeder(int pos)
        {
            await Task.Run(() => manager.CfgDeleteFeeder(pos));
        }

        [HttpPost]
        public async Task CfgShiftFeeder(int pos, int shift)
        {
            await Task.Run(() => manager.CfgShiftFeeder(pos, shift));
        }
    }
}
