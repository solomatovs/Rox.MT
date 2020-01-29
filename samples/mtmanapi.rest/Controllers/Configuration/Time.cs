using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpGet]
        public async Task<ConTime> CfgRequestTime(int codePage)
        {
            return await Task.Run(() => manager.CfgRequestTime(codePage));
        }

        [HttpPost]
        public async Task CfgUpdateTime([FromBody] ConTime cfg)
        {
            await Task.Run(() => manager.CfgUpdateTime(cfg));
        }
    }
}
