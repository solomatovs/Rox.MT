using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpGet]
        public async Task SrvRestart()
        {
            await Task.Run(() => manager.SrvRestart());
        }

        [HttpGet]
        public async Task SrvChartsSync()
        {
            await Task.Run(() => manager.SrvChartsSync());
        }

        [HttpGet]
        public async Task SrvLiveUpdateStart()
        {
            await Task.Run(() => manager.SrvLiveUpdateStart());
        }

        [HttpGet]
        public async Task<List<PerformanceInfo>> PerformanceRequest(DateTime from, int codePage)
        {
            return await Task.Run(() => manager.PerformanceRequest(from, codePage));
        }

        [HttpGet]
        public async Task<List<ServerLog>> JournalRequest(EnLogMode mode, DateTime from, DateTime to, string filter, int codePage)
        {
            return await Task.Run(() => manager.JournalRequest(mode, from, to, filter, codePage));
        }
        //[HttpGet]
        //public IActionResult JournalRequestFile(EnLogMode mode, DateTime from, DateTime to, string filter, int codePage)
        //{
        //    var bytes = manager.JournalRequestByteResult(mode, from, to, filter, codePage);

        //    return new FileContentResult(bytes, "text/plain")
        //    {
        //        FileDownloadName = "README.md",
        //        EnableRangeProcessing = true
        //    };
        //    //return await Task.Run(() => File(bytes, "text/plain", "journal.txt", true)); 
        //}

        [HttpGet]
        public async Task<DateTime> ServerTime()
        {
            return await Task.Run(() => manager.ServerTime());
        }
    }
}
