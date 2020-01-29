using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpGet]
        public async Task<List<ConSync>> CfgRequestSync(int codePage)
        {
            return await Task.Run(() => manager.CfgRequestSync(codePage));
        }

        [HttpPost]
        public async Task CfgUpdateSync([FromBody] ConSync cfg)
        {
            await Task.Run(() => manager.CfgUpdateSync(cfg));
        }

        [HttpPost]
        public async Task CfgDeleteSync(int pos)
        {
            await Task.Run(() => manager.CfgDeleteSync(pos));
        }

        [HttpPost]
        public async Task CfgShiftSync(int pos, int shift)
        {
            await Task.Run(() => manager.CfgShiftSync(pos, shift));
        }
    }
}
