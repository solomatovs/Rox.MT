using System;

namespace rox.mt4.api
{
    public class MT4CreditOperation
    {
        public int Login { get; set; }
        public double Amount { get; set; }
        public string Comment { get; set; }
        public DateTime Expiration { get; set; }
    }
}
