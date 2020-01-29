using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpGet]
        public async Task<ConBackup> CfgRequestBackup(int codePage)
        {
            return await Task.Run(() => manager.CfgRequestBackup(codePage));
        }

        [HttpPost]
        public async Task CfgUpdateBackup([FromBody] ConBackup cfg)
        {
            await Task.Run(() => manager.CfgUpdateBackup(cfg));
        }
    }
}
