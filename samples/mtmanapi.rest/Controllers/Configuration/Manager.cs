using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpGet]
        public async Task<List<ConManager>> CfgRequestManager(int codePage)
        {
            return await Task.Run(() => manager.CfgRequestManager(codePage));
        }

        [HttpPost]
        public async Task CfgUpdateManager([FromBody] ConManager cfg)
        {
            await Task.Run(() => manager.CfgUpdateManager(cfg));
        }

        [HttpPost]
        public async Task CfgDeleteManager(int pos)
        {
            await Task.Run(() => manager.CfgDeleteManager(pos));
        }

        [HttpPost]
        public async Task CfgShiftManager(int pos, int shift)
        {
            await Task.Run(() => manager.CfgShiftManager(pos, shift));
        }
    }
}
