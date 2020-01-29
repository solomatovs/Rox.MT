using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    /// <summary>
    /// Struct for ConGroup class
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NConGroup
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] group;
        public Int32 enable;
        public Int32 timeout;
        public Int32 otpMode;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] company;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] signature;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] supportPage;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] smtp_server;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] smtp_login;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] smtp_password;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] support_email;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] templates;
        public Int32 copies;
        public Int32 reports;
        public Int32 default_leverage;
        public double default_deposit;
        public Int32 maxsecurities;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = (UnmanagedType) 27)]
        public NConGroupSec[] secgroups;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = (UnmanagedType) 27)]
        public NConGroupMargin[] secmargins;
        public Int32 secmargins_total;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] currency;
        public double credit;
        public Int32 margin_call;
        public Int32 margin_mode;
        public Int32 margin_stopout;
        public double interestrate;
        public Int32 use_swap;
        public Int32 news;
        public Int32 rights;
        public Int32 check_ie_prices;
        public Int32 maxpositions;
        public Int32 close_reopen;
        public Int32 hedge_prohibited;
        public Int32 close_fifo;
        public Int32 hedgeLargeLeg;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public Int32[] unused_rights;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] securities_hash;
        public Int32 margin_type;
        public Int32 archive_period;
        public Int32 archive_max_balance;
        public Int32 stopout_skip_hedged;
        public Int32 archive_pending_period;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public UInt32[] news_languages;
        public UInt32 news_languages_total;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
        public Int32[] reserved;
    }

    /// <summary>
    /// 
    /// </summary>
    public class ConGroup : MT4Model<NConGroup>
    {
        /// <summary>
        /// Max security groups
        /// </summary>
        public static readonly Int32 MAX_SECURITY_GROUPS = 32;
        /// <summary>
        /// Max groups for margin settings on security groups
        /// </summary>
        public static readonly Int32 MAX_SECURITY_GROUPS_MARGIN = 128;

        public ConGroup(int codePage) : base(codePage)
        {
            native.secgroups = new NConGroupSec[MAX_SECURITY_GROUPS];
            native.secmargins = new NConGroupMargin[MAX_SECURITY_GROUPS_MARGIN];
        }

        /// <summary>
        /// Group name
        /// </summary>
        public string Name
        {
            get { return AnsiBytesToString(native.group); }
            set { native.group = StringToAnsiBytes(value, 16); }
        }

        /// <summary>
        /// Enable group
        /// </summary>
        public Int32 Enabled
        {
            get { return native.enable; }
            set { native.enable = value; }
        }

        /// <summary>
        /// Trade confirmation timeout (seconds)
        /// </summary>
        public Int32 Timeout
        {
            get { return native.timeout; }
            set { native.timeout = value; }
        }

        /// <summary>
        /// One-time password mode
        /// </summary>
        public OTPMode OtpMode
        {
            get { return (OTPMode)native.otpMode; }
            set { native.otpMode = (Int32)value; }
        }

        /// <summary>
        /// Company name
        /// </summary>
        public string Company
        {
            get { return AnsiBytesToString(native.company); }
            set { native.company = StringToAnsiBytes(value, 128); }
        }

        /// <summary>
        /// Statements signature
        /// </summary>
        public string Signature
        {
            get { return AnsiBytesToString(native.signature); }
            set { native.signature = StringToAnsiBytes(value, 128); }
        }

        /// <summary>
        /// Company support page
        /// </summary>
        public string SupportPage
        {
            get { return AnsiBytesToString(native.supportPage); }
            set { native.supportPage = StringToAnsiBytes(value, 128); }
        }

        /// <summary>
        /// Statements SMTP server
        /// </summary>
        public string SmtpServer
        {
            get { return AnsiBytesToString(native.smtp_server); }
            set { native.smtp_server = StringToAnsiBytes(value, 64); }
        }

        /// <summary>
        /// Statements SMTP login
        /// </summary>
        public string SmtpLogin
        {
            get { return AnsiBytesToString(native.smtp_login); }
            set { native.smtp_login = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// Statements SMTP password
        /// </summary>
        public string SmtpPassword
        {
            get { return AnsiBytesToString(native.smtp_password); }
            set { native.smtp_password = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// Support email
        /// </summary>
        public string SupportEmail
        {
            get { return AnsiBytesToString(native.support_email); }
            set { native.support_email = StringToAnsiBytes(value, 64); }
        }

        /// <summary>
        /// Path to directory with custom templates
        /// </summary>
        public string Templates
        {
            get { return AnsiBytesToString(native.templates); }
            set { native.templates = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// Copy statements on support email
        /// </summary>
        public Int32 Copies
        {
            get { return native.copies; }
            set { native.copies = value; }
        }

        /// <summary>
        /// Enable statements
        /// </summary>
        public Int32 Reports
        {
            get { return native.reports; }
            set { native.reports = value; }
        }

        /// <summary>
        /// Default leverage (user don't specify leverage himself)
        /// </summary>
        public Int32 DefaultLeverage
        {
            get { return native.default_leverage; }
            set { native.default_leverage = value; }
        }

        /// <summary>
        /// Default deposit  (user don't specify balance  himself)
        /// </summary>
        public double DefaultDeposit
        {
            get { return native.default_deposit; }
            set { native.default_deposit = value; }
        }

        /// <summary>
        /// Maximum simultaneous securities
        /// </summary>
        public Int32 MaxSecurities
        {
            get { return native.maxsecurities; }
        }

        /// <summary>
        /// Security group settings
        /// </summary>
        public List<ConGroupSec> SecGroups
        {
            get { return native.secgroups.ToEntities<NConGroupSec, ConGroupSec>(count: MAX_SECURITY_GROUPS, codePage: CodePage); }
            set { native.secgroups = value.Take(MAX_SECURITY_GROUPS).ToNatives<NConGroupSec, ConGroupSec>(); native.maxsecurities = value.Take(MAX_SECURITY_GROUPS).Count(); }
        }

        /// <summary>
        /// Special securities settings
        /// </summary>
        public List<ConGroupMargin> SecMargins
        {
            get { return native.secmargins.ToEntities<NConGroupMargin, ConGroupMargin>(count: MAX_SECURITY_GROUPS_MARGIN, codePage: CodePage); }
            set { native.secmargins = value.Take(MAX_SECURITY_GROUPS_MARGIN).ToNatives<NConGroupMargin, ConGroupMargin>(); native.secmargins_total = value.Take(MAX_SECURITY_GROUPS_MARGIN).Count(); }
        }

        /// <summary>
        /// Count of special securities settings
        /// </summary>
        public Int32 SecMarginsTotal
        {
            get { return native.secmargins_total; }
        }

        /// <summary>
        /// Deposit currency
        /// </summary>
        public string Currency
        {
            get { return AnsiBytesToString(native.currency); }
            set { native.currency = StringToAnsiBytes(value, 12); }
        }

        /// <summary>
        /// Virtual credit
        /// </summary>
        public double Credit
        {
            get { return native.credit; }
            set { native.credit = value; }
        }

        /// <summary>
        /// Margin call level (percents)
        /// </summary>
        public Int32 MarginCall
        {
            get { return native.margin_call; }
            set { native.margin_call = value; }
        }

        /// <summary>
        /// Margin mode-MARGIN_DONT_USE,MARGIN_USE_ALL,MARGIN_USE_PROFIT,MARGIN_USE_LOSS
        /// </summary>
        public MarginCalculationMode MarginMode
        {
            get { return (MarginCalculationMode)native.margin_mode; }
            set { native.margin_mode = (Int32)value; }
        }

        /// <summary>
        /// Stop out level
        /// </summary>
        public Int32 MarginStopout
        {
            get { return native.margin_stopout; }
            set { native.margin_stopout = value; }
        }

        /// <summary>
        /// Annual interest rate (percents)
        /// </summary>
        public double InterestRate
        {
            get { return native.interestrate; }
            set { native.interestrate = value; }
        }

        /// <summary>
        /// Use rollovers and interestrate
        /// </summary>
        public Int32 UseSwap
        {
            get { return native.use_swap; }
            set { native.use_swap = value; }
        }

        /// <summary>
        /// News mode
        /// </summary>
        public NewsMode News
        {
            get { return (NewsMode)native.news; }
            set { native.news = (Int32)value; }
        }

        /// <summary>
        /// Rights bit mask-ALLOW_FLAG_EMAIL
        /// </summary>
        public GroupRights Rights
        {
            get { return (GroupRights)native.rights; }
            set { native.rights = (Int32)value; }
        }

        /// <summary>
        /// Check IE prices on requests
        /// </summary>
        public Int32 CheckIePrices
        {
            get { return native.check_ie_prices; }
            set { native.check_ie_prices = value; }
        }

        /// <summary>
        /// Maximum orders and open positions
        /// </summary>
        public Int32 MaxPositions
        {
            get { return native.maxpositions; }
            set { native.maxpositions = value; }
        }

        /// <summary>
        /// Partial close mode (if !=0 original position will be fully closed and remain position will be fully reopened)
        /// </summary>
        public Int32 CloseReopen
        {
            get { return native.close_reopen; }
            set { native.close_reopen = value; }
        }

        /// <summary>
        /// Hedge prohibition flag
        /// </summary>
        public Int32 HedgeProhibited
        {
            get { return native.hedge_prohibited; }
            set { native.hedge_prohibited = value; }
        }

        /// <summary>
        /// FIFO rule 
        /// </summary>
        public Int32 CloseFifo
        {
            get { return native.close_fifo; }
            set { native.close_fifo = value; }
        }

        /// <summary>
        /// Use large leg margin for hedged positions
        /// </summary>
        public Int32 HedgeLargeLeg
        {
            get { return native.hedgeLargeLeg; }
            set { native.hedgeLargeLeg = value; }
        }

        /// <summary>
        /// reserved
        /// </summary>
        public Int32[] UnsignedRights
        {
            get { return native.unused_rights; }
        }

        /// <summary>
        /// Internal data
        /// </summary>
        public string SecuritiesHash
        {
            get { return AnsiBytesToString(native.securities_hash); }
            set { native.securities_hash = StringToAnsiBytes(value, 16); }
        }

        /// <summary>
        /// Margin controlling type { MARGIN_TYPE_PERCENT,  MARGIN_TYPE_CURRENCY }
        /// </summary>
        public MarginControllingType MarginType
        {
            get { return (MarginControllingType)native.margin_type; }
            set { native.margin_type = (Int32)value; }
        }

        /// <summary>
        /// Inactivity period after which account moves to archive base (in days)
        /// </summary>
        public Int32 ArchivePeriod
        {
            get { return native.archive_period; }
            set { native.archive_period = value; }
        }

        /// <summary>
        /// Maxumum balance of accounts to move in archive base
        /// </summary>
        public Int32 ArchiveMaxBalance
        {
            get { return native.archive_max_balance; }
            set { native.archive_max_balance = value; }
        }

        /// <summary>
        /// Skip fully hedged accounts when checking for stopout
        /// </summary>
        public Int32 StopOutSkipHedged
        {
            get { return native.stopout_skip_hedged; }
            set { native.stopout_skip_hedged = value; }
        }

        /// <summary>
        /// Pendings clean period
        /// </summary>
        public Int32 ArchivePendingPeriod
        {
            get { return native.archive_pending_period; }
            set { native.archive_pending_period = value; }
        }

        /// <summary>
        /// LANGID array
        /// </summary>
        public UInt32[] NewsLanguages
        {
            get { return native.news_languages; }
        }

        /// <summary>
        /// News languages total
        /// </summary>
        protected UInt32 NewsLanguagesTotal
        {
            get { return native.news_languages_total; }
            set { native.news_languages_total = value; }
        }

        /// <summary>
        /// Reserved
        /// </summary>
        protected List<Int32> Reserved
        {
            get { return native.reserved.ToList(); }
        }

        public override string ToString()
        {
            return $"{Name} {Currency}";
        }
    }
}