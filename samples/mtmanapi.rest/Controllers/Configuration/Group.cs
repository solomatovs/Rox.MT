using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpGet]
        public async Task<List<ConGroup>> CfgRequestGroup(int codePage)
        {
            return await Task.Run(() => manager.CfgRequestGroup(codePage));
        }

        [HttpPost]
        public async Task CfgUpdateGroup([FromBody] ConGroup cfg)
        {
            await Task.Run(() => manager.CfgUpdateGroup(cfg));
        }

        [HttpPost]
        public async Task CfgDeleteGroup(int pos)
        {
            await Task.Run(() => manager.CfgDeleteGroup(pos));
        }

        [HttpPost]
        public async Task CfgShiftGroup(int pos, int shift)
        {
            await Task.Run(() => manager.CfgShiftGroup(pos, shift));
        }

        [HttpGet]
        public async Task<List<ConGroup>> GroupsRequest(int codePage)
        {
            return await Task.Run(() => manager.GroupsRequest(codePage));
        }

        [HttpGet]
        public async Task<List<ConGroup>> GroupsGet(int codePage)
        {
            return await Task.Run(() => manager.GroupsGet(codePage));
        }

        [HttpGet]
        public async Task<ConGroup> GroupRecordGet(string name, int codePage)
        {
            return await Task.Run(() => manager.GroupRecordGet(name, codePage));
        }
    }
}
