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
        public class ReportGroupRequestPost
        {
            public ReportGroupRequest ReportRequest { get; set; }
            public IEnumerable<int> Logins { get; set; }
        }
        [HttpGet]
        public async Task<List<TradeRecord>> ReportsRequest([FromQuery] ReportGroupRequestPost request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (request.Logins == null || request.Logins.Count() <= 0)
                throw new ArgumentNullException(nameof(request.Logins));

            return await Task.Run(() => manager.ReportsRequest(request.ReportRequest, request.Logins));
        }

        public class DailyGroupRequestPost
        {
            public DailyGroupRequest Req { get; set; }
            public IEnumerable<int> Logins { get; set; }
        }

        [HttpGet]
        public async Task<List<DailyReport>> DailyReportsRequest([FromQuery] DailyGroupRequestPost request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (request.Logins == null || request.Logins.Count() <= 0)
                throw new ArgumentNullException(nameof(request.Logins));

            return await Task.Run(() => manager.DailyReportsRequest(request.Req, request.Logins));
        }
    }
}
