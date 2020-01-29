using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpGet]
        public async Task<List<TradeRecord>> AdmTradesRequest(string group, bool open_only, int codePage)
        {
            return await Task.Run(() => manager.AdmTradesRequest(group, open_only == true ? 1 : 0, codePage));
        }

        [HttpPost]
        public async Task AdmTradesDelete([FromBody] IEnumerable<int> orders)
        {
            await Task.Run(() => manager.AdmTradesDelete(orders.ToArray()));
        }

        [HttpPost]
        public async Task AdmTradeRecordModify([FromBody] TradeRecord order)
        {
            await Task.Run(() => manager.AdmTradeRecordModify(order));
        }

        [HttpPost]
        public async Task<TradeTransInfo> TradeTransaction([FromBody] TradeTransInfo trade)
        {
            return await Task.Run(() => manager.TradeTransaction(trade));
        }

        [HttpGet]
        public async Task<List<TradeRecord>> TradesRequest(int codePage)
        {
            return await Task.Run(() => manager.TradesRequest(codePage));
        }

        [HttpGet]
        public async Task<List<TradeRecord>> TradeRecordsRequest(int codePage, params int[] orders)
        {
            return await Task.Run(() => manager.TradeRecordsRequest(orders, codePage));
        }

        [HttpGet]
        public async Task<List<TradeRecord>> TradesUserHistory(int login, DateTime from, DateTime to, int codePage)
        {
            return await Task.Run(() => manager.TradesUserHistory(login, from, to, codePage));
        }


        #region pumping
        [HttpGet]
        public async Task<List<TradeRecord>> TradesGet(int codePage)
        {
            return await Task.Run(() => manager.TradesGet(codePage));
        }

        [HttpGet]
        public async Task<TradeRecord> TradeRecordGet(int order, int codePage)
        {
            return await Task.Run(() => manager.TradeRecordGet(order, codePage));
        }

        [HttpGet]
        public async Task<List<TradeRecord>> TradesGetBySymbol(string symbol, int codePage)
        {
            return await Task.Run(() => manager.TradesGetBySymbol(symbol, codePage));
        }

        [HttpGet]
        public async Task<List<TradeRecord>> TradesGetByLogin(int login, string group, int codePage)
        {
            return await Task.Run(() => manager.TradesGetByLogin(login, group, codePage));
        }

        [HttpGet]
        public async Task<List<TradeRecord>> TradesGetByMarket(int codePage)
        {
            return await Task.Run(() => manager.TradesGetByMarket(codePage));
        }

        [HttpGet]
        public async Task TradeClearRollback(int order)
        {
            await Task.Run(() => manager.TradeClearRollback(order));
        }
        #endregion
    }
}