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
        public async Task<List<SymbolSummary>> SummaryGetAll(int codePage)
        {
            return await Task.Run(() => manager.SummaryGetAll(codePage));
        }

        [HttpGet]
        public async Task<SymbolSummary> SummaryGet(string symbol, int codePage)
        {
            return await Task.Run(() => manager.SummaryGet(symbol, codePage));
        }

        [HttpGet]
        public async Task<SymbolSummary> SummaryGetByCount(int symbol, int codePage)
        {
            return await Task.Run(() => manager.SummaryGetByCount(symbol, codePage));
        }

        [HttpGet]
        public async Task<SymbolSummary> SummaryGetByType(int securityType, int codePage)
        {
            return await Task.Run(() => manager.SummaryGetByType(securityType, codePage));
        }

        [HttpGet]
        public async Task<string> SummaryCurrency(int maxchars = 12)
        {
            return await Task.Run(() => manager.SummaryCurrency(maxchars));
        }
        #endregion
    }
}
