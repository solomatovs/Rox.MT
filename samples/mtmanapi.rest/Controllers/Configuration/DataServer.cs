using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpGet]
        public async Task<List<ConDataServer>> CfgRequestDataServer(int codePage)
        {
            return await Task.Run(() => manager.CfgRequestDataServer(codePage));
        }

        [HttpPost]
        public async Task CfgUpdateDataServer([FromBody] ConDataServer cfg, int pos)
        {
            await Task.Run(() => manager.CfgUpdateDataServer(cfg, pos));
        }

        [HttpPost]
        public async Task CfgDeleteDataServer(int pos)
        {
            await Task.Run(() => manager.CfgDeleteDataServer(pos));
        }

        [HttpPost]
        public async Task CfgShiftDataServer(int pos, int shift)
        {
            await Task.Run(() => manager.CfgShiftDataServer(pos, shift));
        }
    }
}
