using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpGet]
        public async Task<ConCommon> CfgRequestCommon(int codePage)
        {
            return await Task.Run(() => manager.CfgRequestCommon(codePage));
        }

        [HttpPost]
        public async Task CfgUpdateCommon([FromBody] ConCommon common)
        {
            await Task.Run(() => manager.CfgUpdateCommon(common));
        }

        [HttpPost]
        public async Task<ConCommon> ManagerCommon(int codePage)
        {
            return await Task.Run(() => manager.ManagerCommon(codePage));
        }
    }
}
