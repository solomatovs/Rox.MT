using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpGet]
        public async Task<List<ConHoliday>> CfgRequestHoliday(int codePage)
        {
            return await Task.Run(() => manager.CfgRequestHoliday(codePage));
        }

        [HttpPost]
        public async Task CfgUpdateHoliday([FromBody] ConHoliday cfg, int pos)
        {
            await Task.Run(() => manager.CfgUpdateHoliday(cfg, pos));
        }

        [HttpPost]
        public async Task CfgDeleteHoliday(int pos)
        {
            await Task.Run(() => manager.CfgDeleteHoliday(pos));
        }

        [HttpPost]
        public async Task CfgShiftHoliday(int pos, int shift)
        {
            await Task.Run(() => manager.CfgShiftHoliday(pos, shift));
        }
    }
}
