using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NDailyReport
    {
        public Int32 login;
        public UInt32 ctm;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] group;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] bank;
        public double balancePrev;
        public double balance;
        public double deposit;
        public double credit;
        public double profitClosed;
        public double profit;
        public double equity;
        public double margin;
        public double marginFree;
        public Int32 next;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public Int32[] reserved;
    }

    /// <summary>
    /// Object that represents daily report
    /// </summary>
    public class DailyReport : MT4Model<NDailyReport>
    {
        public DailyReport(int codePage) : base(codePage) { }
        public double FreeMargin
        {
            get { return native.marginFree; }
            set { native.marginFree = value; }
        }

        public double Margin
        {
            get { return native.margin; }
            set { native.margin = value; }
        }

        public double Equity
        {
            get { return native.equity; }
            set { native.equity = value; }
        }

        public double Profit
        {
            get { return native.profit; }
            set { native.profit = value; }
        }

        public double ClosedProfit
        {
            get { return native.profitClosed; }
            set { native.profitClosed = value; }
        }

        public double Credit
        {
            get { return native.credit; }
            set { native.credit = value; }
        }

        public double Deposit
        {
            get { return native.deposit; }
            set { native.deposit = value; }
        }

        public double Balance
        {
            get { return native.balance; }
            set { native.balance = value; }
        }

        public double PreviousBalance
        {
            get { return native.balancePrev; }
            set { native.balancePrev = value; }
        }

        public string Bank
        {
            get { return AnsiBytesToString(native.bank); }
            set { native.bank = StringToAnsiBytes(value, 64); }
        }

        public string Group
        {
            get { return AnsiBytesToString(native.group); }
            set { native.group = StringToAnsiBytes(value, 16); }
        }

        public DateTime Time
        {
            get { return native.ctm.ToDateTime(); }
            set { native.ctm = value.ToUInt(); }
        }

        public Int32 Login
        {
            get { return native.login; }
            set { native.login = value; }
        }

        public Int32 Next
        {
            get { return native.next; }
        }

        public Int32[] Reserved
        {
            get { return native.reserved; }
        }
    }
}