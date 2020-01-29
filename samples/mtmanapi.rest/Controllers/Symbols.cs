using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpPost]
        public async Task SymbolsRefresh()
        {
            await Task.Run(() => manager.SymbolsRefresh());
        }

        [HttpGet]
        public async Task<List<ConSymbol>> SymbolsGetAll(int codePage)
        {
            return await Task.Run(() => manager.SymbolsGetAll(codePage));
        }

        [HttpGet]
        public async Task<ConSymbol> SymbolGet(string symbol, int codePage)
        {
            return await Task.Run(() => manager.SymbolGet(symbol, codePage));
        }

        [HttpGet]
        public async Task<SymbolInfo> SymbolInfoGet(string symbol, int codePage)
        {
            return await Task.Run(() => manager.SymbolInfoGet(symbol, codePage));
        }

        #region pumping
        [HttpGet]
        public async Task<List<SymbolInfo>> SymbolInfoUpdated(int max_info)
        {
            return await Task.Run(() => manager.SymbolInfoUpdated(max_info));
        }
        #endregion

        [HttpGet]
        public async Task<List<ConSymbolGroup>> SymbolsGroupsGet(int codePage)
        {
            return await Task.Run(() => manager.SymbolsGroupsGet(codePage));
        }
        
        #region pumping
        [HttpPost]
        public async Task SymbolAdd(string symbol)
        {
            await Task.Run(() => manager.SymbolAdd(symbol));
        }

        [HttpPost]
        public async Task SymbolHide(string symbol)
        {
            await Task.Run(() => manager.SymbolHide(symbol));
        }
        #endregion

        [HttpPost]
        public async Task SymbolSendTick(string symbol, double bid, double ask)
        {
            await Task.Run(() => manager.SymbolSendTick(symbol, bid, ask));
        }

        [HttpPost]
        public async Task SymbolChange([FromBody] SymbolProperties prop)
        {
            await Task.Run(() => manager.SymbolChange(prop));
        }
    }
}
