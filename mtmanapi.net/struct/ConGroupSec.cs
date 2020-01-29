using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NConGroupSec
    {
        public Int32 show;
        public Int32 trade;
        public Int32 execution;
        public Int32 unused;
        public double comm_base;
        public Int32 comm_type;
        public Int32 comm_lots;
        public double comm_agent;
        public Int32 comm_agent_type;
        public Int32 spread_diff;
        public Int32 lot_min;
        public Int32 lot_max;
        public Int32 lot_step;
        public Int32 ie_deviation;
        public Int32 confirmation;
        public Int32 trade_rights;
        public Int32 ie_quick_mode;
        public Int32 autocloseout_mode;
        public double comm_tax;
        public Int32 comm_agent_lots;
        public Int32 freemargin_mode;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public Int32[] reserved;
    }

    /// <summary>
    /// Security group configuration for client group
    /// </summary>
    public class ConGroupSec : MT4Model<NConGroupSec>
    {
        public ConGroupSec(int codePage) : base(codePage)
        {

        }

        public ConGroupSec() : this(0) { }
        /// <summary>
        /// Enable show for this group of securites
        /// </summary>
        public Int32 Show
        {
            get { return native.show; }
            set { native.show = value; }
        }

        /// <summary>
        /// Enable trade for this group of securites
        /// </summary>
        public Int32 Trade
        {
            get { return native.trade; }
            set { native.trade = value; }
        }

        /// <summary>
        /// Dealing mode-EXECUTION_MANUAL,EXECUTION_AUTO,EXECUTION_ACTIVITY
        /// </summary>
        public DealingMode Execution
        {
            get { return (DealingMode)native.execution; }
            set { native.execution = (Int32)value; }
        }

        /// <summary>
        /// Undocumented Features
        /// </summary>
        protected Int32 Unused
        {
            get { return native.unused; }
            set { native.unused = value; }
        }

        /// <summary>
        /// Standart commission
        /// </summary>
        public double CommBase
        {
            get { return native.comm_base; }
            set { native.comm_base = value; }
        }

        /// <summary>
        /// Commission type-COMM_TYPE_MONEY,COMM_TYPE_PIPS,COMM_TYPE_PERCENT
        /// </summary>
        public CommissionType CommType
        {
            get { return (CommissionType)native.comm_type; }
            set { native.comm_type = (Int32)value; }
        }

        /// <summary>
        /// Commission lots mode-COMMISSION_PER_LOT,COMMISSION_PER_DEAL
        /// </summary>
        public Int32 CommLots
        {
            get { return native.comm_lots; }
            set { native.comm_lots = value; }
        }

        /// <summary>
        /// Agent commission
        /// </summary>
        public double CommAgent
        {
            get { return native.comm_agent; }
            set { native.comm_agent = value; }
        }

        /// <summary>
        /// Agent commission mode-COMM_TYPE_MONEY, COMM_TYPE_PIPS
        /// </summary>
        public CommissionType CommAgentType
        {
            get { return (CommissionType)native.comm_agent_type; }
            set { native.comm_agent_type = (Int32)value; }
        }

        /// <summary>
        /// Agent commission per lot/per deal { COMMISSION_PER_LOT,COMMISSION_PER_DEAL }
        /// </summary>
        public CommissionLotsMode CommAgentLots
        {
            get { return (CommissionLotsMode)native.comm_agent_lots; }
            set { native.comm_agent_lots = (Int32)value; }
        }

        /// <summary>
        /// Commission taxes
        /// </summary>
        public double CommTax
        {
            get { return native.comm_tax; }
            set { native.comm_tax = value; }
        }

        /// <summary>
        /// Spread difference in compare with default security spread
        /// </summary>
        public Int32 SpreadDiff
        {
            get { return native.spread_diff; }
            set { native.spread_diff = value; }
        }

        /// <summary>
        /// allowed minimal lot values
        /// </summary>
        public Int32 LotMin
        {
            get { return native.lot_min; }
            set { native.lot_min = value; }
        }

        /// <summary>
        /// Allowed  maximal lot values
        /// </summary>
        public Int32 LotMax
        {
            get { return native.lot_max; }
            set { native.lot_max = value; }
        }

        /// <summary>
        /// Allowed step value, min 0.01 lot
        /// </summary>
        public Int32 LotStep
        {
            get { return native.lot_step; }
            set { native.lot_step = value; }
        }

        /// <summary>
        /// Maximum price deviation in Instant Execution mode
        /// </summary>
        public Int32 IeDeviation
        {
            get { return native.ie_deviation; }
            set { native.ie_deviation = value; }
        }

        /// <summary>
        /// Use confirmation in Request mode
        /// </summary>
        public Int32 Confirmation
        {
            get { return native.confirmation; }
            set { native.confirmation = value; }
        }

        /// <summary>
        /// Clients trade rights-bit mask see TRADE_DENY_NONE,TRADE_DENY_CLOSEBY,TRADE_DENY_MUCLOSEBY
        /// </summary>
        public ClientsTradeRights TradeRights
        {
            get { return (ClientsTradeRights)native.trade_rights; }
            set { native.trade_rights = (Int32)value; }
        }

        /// <summary>
        /// Do not resend request to the dealer when client uses deviation
        /// </summary>
        public Int32 IeQuickMode
        {
            get { return native.ie_quick_mode; }
            set { native.ie_quick_mode = value; }
        }

        /// <summary>
        /// Agent commission per lot/per deal { COMMISSION_PER_LOT,COMMISSION_PER_DEAL }
        /// </summary>
        public AutoCloseOutMethod AutoCloseOutMode
        {
            get { return (AutoCloseOutMethod)native.autocloseout_mode; }
            set { native.autocloseout_mode = (Int32)value; }
        }

        /// <summary>
        /// "soft" margin check
        /// </summary>
        public Int32 FreeMarginMode
        {
            get { return native.freemargin_mode; }
            set { native.freemargin_mode = value; }
        }

        /// <summary>
        /// Reserved
        /// </summary>
        protected Int32[] Reserved
        {
            get { return native.reserved; }
        }
    }
}