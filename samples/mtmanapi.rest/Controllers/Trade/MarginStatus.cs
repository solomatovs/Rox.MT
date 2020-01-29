using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        #region pumping
        [HttpGet]
        public async Task<List<MarginLevel>> MarginsGet(int codePage)
        {
            return await Task.Run(() => manager.MarginsGet(codePage));
        }

        [HttpGet]
        public async Task<MarginLevel> MarginLevelGet(int login, string group, int codePage)
        {
            return await Task.Run(() => manager.MarginLevelGet(login, group, codePage));
        }
        #endregion

        [HttpGet]
        public async Task<MarginLevel> MarginLevelRequest(int login, int codePage)
        {
            return await Task.Run(() => manager.MarginLevelRequest(login, codePage));
        }
    }
}
