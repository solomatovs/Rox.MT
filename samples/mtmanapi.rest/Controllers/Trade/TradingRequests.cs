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
        public async Task<List<RequestInfo>> RequestsGet(int codePage)
        {
            return await Task.Run(() => manager.RequestsGet(codePage));
        }

        [HttpGet]
        public async Task<RequestInfo> RequestInfoGet(int pos, int codePage)
        {
            return await Task.Run(() => manager.RequestInfoGet(pos, codePage));
        }
        #endregion
    }
}
