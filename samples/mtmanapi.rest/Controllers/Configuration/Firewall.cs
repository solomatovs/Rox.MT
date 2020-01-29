using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpGet]
        public async Task<List<ConAccess>> CfgRequestAccess(int codePage)
        {
            return await Task.Run(() => manager.CfgRequestAccess(codePage));
        }

        [HttpPost]
        public async Task CfgUpdateAccess([FromBody] ConAccess cfg, int pos)
        {
            await Task.Run(() => manager.CfgUpdateAccess(cfg, pos));
        }

        [HttpPost]
        public async Task CfgDeleteAccess(int pos)
        {
            await Task.Run(() => manager.CfgDeleteAccess(pos));
        }

        [HttpPost]
        public async Task CfgShiftAccess(int pos, int shift)
        {
            await Task.Run(() => manager.CfgShiftAccess(pos, shift));
        }
    }
}
