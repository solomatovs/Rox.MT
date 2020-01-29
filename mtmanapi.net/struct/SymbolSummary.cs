using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NSymbolSummary
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] symbol;             // symbol
        public Int32 count;               // symbol counter
        public Int32 digits;              // floating point digits
        public Int32 type;                // symbol type (symbol group index)
        public Int32 orders;              // number of client orders
        public Int64 buylots;             // buy volume
        public Int64 selllots;            // sell volume
        public double buyprice;           // average buy price
        public double sellprice;          // average sell price
        public double profit;             // clients profit
        public Int32 covorders;           // number of coverage orders
        public Int64 covbuylots;          // buy volume
        public Int64 covselllots;         // sell volume
        public double covbuyprice;        // average buy price
        public double covsellprice;       // average sell price
        public double covprofit;          // coverage profit
    }

    /// <summary>
    /// Object that represents symbol summary
    /// </summary>
    public class SymbolSummary : MT4Model<NSymbolSummary>
    {
        public SymbolSummary(int codePage) : base(codePage) { }
        /// <summary>
        /// Symbol (12 chars)
        /// </summary>
        public string Symbol
        {
            get { return AnsiBytesToString(native.symbol); }
            set { native.symbol = StringToAnsiBytes(value, 12); }
        }

        /// <summary>
        /// Symbol counter
        /// </summary>
        public Int32 Count
        {
            get { return native.count; }
            set { native.count = value; }
        }

        /// <summary>
        /// Floating point digits
        /// </summary>
        public Int32 Digits
        {
            get { return native.digits; }
            set { native.digits = value; }
        }

        /// <summary>
        /// Symbol type (symbol group index)
        /// </summary>
        public Int32 Type
        {
            get { return native.type; }
            set { native.type = value; }
        }

        /// <summary>
        /// Number of client orders
        /// </summary>
        public Int32 Orders
        {
            get { return native.orders; }
            set { native.orders = value; }
        }

        /// <summary>
        /// Buy volume
        /// </summary>
        public Int64 BuyLots
        {
            get { return native.buylots; }
            set { native.buylots = value; }
        }

        /// <summary>
        /// Sell volume
        /// </summary>
        public Int64 SellLots
        {
            get { return native.selllots; }
            set { native.selllots = value; }
        }

        /// <summary>
        /// Average buy price
        /// </summary>
        public double BuyPrice
        {
            get { return native.buyprice; }
            set { native.buyprice = value; }
        }

        /// <summary>
        /// Average sell price
        /// </summary>
        public double SellPrice
        {
            get { return native.sellprice; }
            set { native.sellprice = value; }
        }

        /// <summary>
        /// Clients profit
        /// </summary>
        public double Profit
        {
            get { return native.profit; }
            set { native.profit = value; }
        }

        /// <summary>
        /// Number of coverage orders
        /// </summary>
        public Int32 CovOrders
        {
            get { return native.covorders; }
            set { native.covorders = value; }
        }

        /// <summary>
        /// Buy volume
        /// </summary>
        public Int64 CovBuyLots
        {
            get { return native.covbuylots; }
            set { native.covbuylots = value; }
        }

        /// <summary>
        /// Sell volume
        /// </summary>
        public Int64 CovSellLots
        {
            get { return native.covselllots; }
            set { native.covselllots = value; }
        }

        /// <summary>
        /// Average buy price
        /// </summary>
        public double CovBuyPrice
        {
            get { return native.covbuyprice; }
            set { native.covbuyprice = value; }
        }

        /// <summary>
        /// Average sell price
        /// </summary>
        public double CovSellPrice
        {
            get { return native.covsellprice; }
            set { native.covsellprice = value; }
        }

        /// <summary>
        /// Coverage profit
        /// </summary>
        public double CovProfit
        {
            get { return native.covprofit; }
            set { native.covprofit = value; }
        }
    }
}