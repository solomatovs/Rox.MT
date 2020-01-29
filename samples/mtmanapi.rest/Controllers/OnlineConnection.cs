using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpGet]
        public async Task<List<OnlineRecord>> OnlineRequest(int codePage)
        {
            return await Task.Run(() => manager.OnlineRequest(codePage));
        }

        #region pumping
        [HttpGet]
        public async Task<List<OnlineRecord>> OnlineGet(int codePage)
        {
            return await Task.Run(() => manager.OnlineGet(codePage));
        }

        [HttpGet]
        public async Task<OnlineRecord> OnlineRecordGet(int login, int codePage)
        {
            return await Task.Run(() => manager.OnlineRecordGet(login, codePage));
        }
        #endregion
    }
}
