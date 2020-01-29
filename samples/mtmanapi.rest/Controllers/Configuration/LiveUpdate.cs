using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpGet]
        public async Task<List<ConLiveUpdate>> CfgRequestLiveUpdate(int codePage)
        {
            return await Task.Run(() => manager.CfgRequestLiveUpdate(codePage));
        }

        [HttpPost]
        public async Task CfgUpdateLiveUpdate([FromBody] ConLiveUpdate cfg)
        {
            await Task.Run(() => manager.CfgUpdateLiveUpdate(cfg));
        }

        [HttpPost]
        public async Task CfgDeleteLiveUpdate(int pos)
        {
            await Task.Run(() => manager.CfgDeleteLiveUpdate(pos));
        }

        [HttpPost]
        public async Task CfgShiftLiveUpdate(int pos, int shift)
        {
            await Task.Run(() => manager.CfgShiftLiveUpdate(pos, shift));
        }
    }
}
