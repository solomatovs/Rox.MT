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
        public async Task<List<ExposureValue>> ExposureGet(int codePage)
        {
            return await Task.Run(() => manager.ExposureGet(codePage));
        }

        [HttpGet]
        public async Task<ExposureValue> ExposureValueGet(string cur, int codePage)
        {
            return await Task.Run(() => manager.ExposureValueGet(cur, codePage));
        }
        #endregion
    }
}
