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
        public async Task<RateInfoResult> ChartRequest(ChartInfo chart)
        {
            return await Task.Run(() => manager.ChartRequest(chart));
        }

        public class ChartPost
        {
            public string Symbol { get; set; }
            public ChartPeriod Period { get; set; }
            public IEnumerable<RateInfo> Rates { get; set; }
        }

        [HttpPost]
        public async Task ChartAdd([FromBody] ChartPost request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (!string.IsNullOrEmpty(request.Symbol))
                throw new ArgumentNullException(nameof(request.Symbol));
            if (request.Rates == null || request.Rates.Count() <= 0)
                throw new ArgumentNullException(nameof(request.Rates));

            await Task.Run(() => manager.ChartAdd(request.Symbol, request.Period, request.Rates));
        }

        [HttpPost]
        public async Task ChartUpdate([FromBody] ChartPost request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (!string.IsNullOrEmpty(request.Symbol))
                throw new ArgumentNullException(nameof(request.Symbol));
            if (request.Rates == null || request.Rates.Count() <= 0)
                throw new ArgumentNullException(nameof(request.Rates));

            await Task.Run(() => manager.ChartUpdate(request.Symbol, request.Period, request.Rates));
        }

        [HttpPost]
        public async Task ChartDelete([FromBody] ChartPost request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (!string.IsNullOrEmpty(request.Symbol))
                throw new ArgumentNullException(nameof(request.Symbol));
            if (request.Rates == null || request.Rates.Count() <= 0)
                throw new ArgumentNullException(nameof(request.Rates));

            await Task.Run(() => manager.ChartDelete(request.Symbol, request.Period, request.Rates));
        }

        [HttpGet]
        public async Task<List<TickRecord>> TicksRequest(TickRequest request)
        {
            return await Task.Run(() => manager.TicksRequest(request));
        }

        [HttpGet]
        public async Task<List<TickInfo>> TickInfoLast(string symbol, int codePage)
        {
            return await Task.Run(() => manager.TickInfoLast(symbol, codePage));
        }

        [HttpPost]
        public async Task<bool> HistoryCorrect(string symbol)
        {
            return await Task.Run(() => manager.HistoryCorrect(symbol));
        }
    }
}
