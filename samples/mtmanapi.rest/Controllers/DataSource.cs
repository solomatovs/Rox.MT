using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpGet]
        public async Task<List<ServerFeed>> SrvFeeders(int codePage)
        {
            return await Task.Run(() => manager.SrvFeeders(codePage));
        }

        [HttpGet]
        public async Task<string> SrvFeederLog(string name)
        {
            return await Task.Run(() => manager.SrvFeederLog(name));
        }

        [HttpPost]
        public async Task SrvFeedsRestart()
        {
            await Task.Run(() => manager.SrvFeedsRestart());
        }
    }
}