using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpPost]
        public async Task TradeCheckStops([FromBody] TradeTransInfo trade, double CheckPrice)
        {
            await Task.Run(() => manager.TradeCheckStops(trade, CheckPrice));
        }


        [HttpPost]
        public async Task TradeCalcProfit([FromBody] TradeRecord trade)
        {
            await Task.Run(() => manager.TradeCalcProfit(trade));
        }

        [HttpGet]
        public async Task<int[]> TradesSnapshot()
        {
            return await Task.Run(() => manager.TradesSnapshot());
        }
    }
}
