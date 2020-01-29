using System.Collections.Generic;
using rox.mt4.api;

namespace Cashback
{
    class CashbackOption
    {
        public MT4ConnectOption mt4 { get; set; }
        public MT4NativeOption native { get; set; }
        public string DepositCommentRegex { get; set; } = @"^D#";
        public string Comment { get; set; } = "cashback";
        public double Percent { get; set; } = 10;
        public IDictionary<string, double> Max { get; set; } = new Dictionary<string, double>();
        public IList<int> Logins { get; set; }
    }
}
