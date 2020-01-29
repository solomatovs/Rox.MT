using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NUserRecord
    {
        public Int32 login;                         // login
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] group;                      // group
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] password;                   // password
        public Int32 enable;                        // enable
        public Int32 enable_change_password;        // allow to change password
        public Int32 enable_read_only;              // allow to open/positions (TRUE-may not trade)
        public Int32 enable_otp;                    // allow to use one-time password
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I4)]
        public Int32[] enable_reserved;             // for future use
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] password_investor;          // read-only mode password
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] password_phone;             // phone password
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] name;                       // name
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] country;                    // country
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] city;                       // city
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] state;                      // state
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] zipcode;                    // zipcode
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 96)]
        public byte[] address;                    // address
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] lead_source;                // lead source
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] phone;                      // phone
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] email;                      // email
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] comment;                    // comment
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] id;                         // SSN (IRD)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] status;                     // status
        public UInt32 regdate;                    // registration date
        public UInt32 lastdate;                   // last coonection time
        public Int32 leverage;                      // leverage
        public Int32 agent_account;                 // agent account
        public UInt32 timestamp;                  // timestamp
        public UInt64 last_ip;                     // Last ip address login connection
        //public Int32 last_ip_unused;
        public double balance;                    // balance
        public double prevmonthbalance;           // previous month balance
        public double prevbalance;                // previous day balance
        public double credit;                     // credit
        public double interestrate;               // accumulated interest rate
        public double taxes;                      // taxes
        public double prevmonthequity;            // previous month equity
        public double prevequity;                 // previous day equity
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.R8)]
        public double[] reserved2;                // for future use
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] otp_secret;                 // one-time password secret
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 240)]
        public byte[] secure_reserved;            // secure data reserved
        public Int32 send_reports;                  // enable send reports by email
        public UInt32 mqid;                       // MQ client identificator
        public UInt32 user_color;                 // color got to client (used by MT Manager)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public byte[] unused;                     // for future use
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] api_data;                   // for API usage
    }

    /// <summary>
    /// Object that represents user record
    /// </summary>
    public class UserRecord : MT4Model<NUserRecord>
    {
        public UserRecord(int codePage) : base(codePage) { }
        public override string ToString()
        {
            return $"{Login} ({Group}); {Name}";
        }
        /// <summary>
        /// Account number
        /// </summary>
        public Int32 Login
        {
            get { return native.login; }
            set { native.login = value; }
        }

        /// <summary>
        /// Group user belongs to
        /// </summary>
        public string Group
        {
            get { return AnsiBytesToString(native.group); }
            set { native.group = StringToAnsiBytes(value, 16); }
        }

        /// <summary>
        /// User password
        /// </summary>
        public string Password
        {
            get { return AnsiBytesToString(native.password); }
            set { native.password = StringToAnsiBytes(value, 16); }
        }

        /// <summary>
        /// Enable
        /// </summary>
        public Int32 Enable
        {
            get { return native.enable; }
            set { native.enable = value; }
        }

        /// <summary>
        /// Allow to change password
        /// </summary>
        public Int32 EnableChangePassword
        {
            get { return native.enable_change_password; }
            set { native.enable_change_password = value; }
        }

        /// <summary>
        /// Allow to open/positions (1 - may not trade)
        /// </summary>
        public Int32 EnableReadOnly
        {
            get { return native.enable_read_only; }
            set { native.enable_read_only = value; }
        }

        /// <summary>
        /// Allow to use one-time password
        /// </summary>
        public Int32 EnableOTP
        {
            get { return native.enable_otp; }
            set { native.enable_otp = value; }
        }

        /// <summary>
        /// Read-only mode password
        /// </summary>
        public string PasswordInvestor
        {
            get { return AnsiBytesToString(native.password_investor); }
            set { native.password_investor = StringToAnsiBytes(value, 16); }
        }

        /// <summary>
        /// Phone password
        /// </summary>
        public string PasswordPhone
        {
            get { return AnsiBytesToString(native.password_phone); }
            set { native.password_phone = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get => AnsiBytesToString(native.name);
            set => native.name = StringToAnsiBytes(value, 128);
        }

        /// <summary>
        /// Country
        /// </summary>
        public string Country
        {
            get { return AnsiBytesToString(native.country); }
            set { native.country = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// City
        /// </summary>
        public string City
        {
            get { return AnsiBytesToString(native.city); }
            set { native.city = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// State
        /// </summary>
        public string State
        {
            get { return AnsiBytesToString(native.state); }
            set { native.state = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// ZipCode, PostCode
        /// </summary>
        public string ZipCode
        {
            get { return AnsiBytesToString(native.zipcode); }
            set { native.zipcode = StringToAnsiBytes(value, 16); }
        }

        /// <summary>
        /// Address
        /// </summary>
        public string Address
        {
            get { return AnsiBytesToString(native.address); }
            set { native.address = StringToAnsiBytes(value, 96); }
        }

        /// <summary>
        /// lead source
        /// </summary>
        public string LeadSource
        {
            get { return AnsiBytesToString(native.lead_source); }
            set { native.lead_source = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// Phone
        /// </summary>
        public string Phone
        {
            get { return AnsiBytesToString(native.phone); }
            set { native.phone = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// Email
        /// </summary>
        public string Email
        {
            get { return AnsiBytesToString(native.email); }
            set { native.email = StringToAnsiBytes(value, 48); }
        }

        /// <summary>
        /// Comment
        /// </summary>
        public string Comment
        {
            get { return AnsiBytesToString(native.comment); }
            set { native.comment = StringToAnsiBytes(value, 64); }
        }

        /// <summary>
        /// SSN (IRD)
        /// </summary>
        public string Id
        {
            get { return AnsiBytesToString(native.id); }
            set { native.id = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// Status
        /// </summary>
        public string Status
        {
            get { return AnsiBytesToString(native.status); }
            set { native.status = StringToAnsiBytes(value, 16); }
        }

        /// <summary>
        /// Registration date
        /// </summary>
        public DateTime Regdate
        {
            get { return native.regdate.ToDateTime(); }
            set { native.regdate = value.ToUInt(); }
        }

        /// <summary>
        /// Last coonection time
        /// </summary>
        public DateTime LastDate
        {
            get { return native.lastdate.ToDateTime(); }
            set { native.lastdate = value.ToUInt(); }
        }

        /// <summary>
        /// Leverage
        /// </summary>
        public Int32 Leverage
        {
            get { return native.leverage; }
            set { native.leverage = value; }
        }

        /// <summary>
        /// Agent account
        /// </summary>
        public Int32 AgentAccount
        {
            get { return native.agent_account; }
            set { native.agent_account = value; }
        }

        /// <summary>
        /// Timestamp wher UserRecord was requested
        /// </summary>
        public DateTime Timestamp
        {
            get { return native.timestamp.ToDateTime(); }
            set { native.timestamp = value.ToUInt(); }
        }

        /// <summary>
        /// Last visit ip
        /// </summary>
        public UInt64 LastIp
        {
            get { return native.last_ip; }
            set { native.last_ip = value; }
        }

        /// <summary>
        /// Balance
        /// </summary>
        public double Balance
        {
            get { return native.balance; }
            set { native.balance = value; }
        }

        /// <summary>
        /// Previous month balance
        /// </summary>
        public double PrevMonthBalance
        {
            get { return native.prevmonthbalance; }
            set { native.prevmonthbalance = value; }
        }

        /// <summary>
        /// Previous day balance
        /// </summary>
        public double PrevBalance
        {
            get { return native.prevbalance; }
            set { native.prevbalance = value; }
        }

        /// <summary>
        /// Credit
        /// </summary>
        public double Credit
        {
            get { return native.credit; }
            set { native.credit = value; }
        }

        /// <summary>
        /// Accumulated interest rate
        /// </summary>
        public double InterestRate
        {
            get { return native.interestrate; }
            set { native.interestrate = value; }
        }

        /// <summary>
        /// Taxes
        /// </summary>
        public double Taxes
        {
            get { return native.taxes; }
            set { native.taxes = value; }
        }

        /// <summary>
        /// Previous month equity
        /// </summary>
        public double PrevMonthEquity
        {
            get { return native.prevmonthequity; }
            set { native.prevmonthequity = value; }
        }

        /// <summary>
        /// Previous day equity
        /// </summary>
        public double PrevEquity
        {
            get { return native.prevequity; }
            set { native.prevequity = value; }
        }

        /// <summary>
        /// Public key
        /// </summary>
        protected double[] Reserved2
        {
            get { return native.reserved2; }
        }

        /// <summary>
        /// One-time password secret
        /// </summary>
        public string OTPSecret
        {
            get { return AnsiBytesToString(native.otp_secret); }
            set { native.otp_secret = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// Reserved for secured
        /// </summary>
        internal string SecureReserved
        {
            get { return AnsiBytesToString(native.secure_reserved); }
        }

        /// <summary>
        /// Enable send reports by email
        /// </summary>
        public Int32 SendReports
        {
            get { return native.send_reports; }
            set { native.send_reports = value; }
        }

        /// <summary>
        /// MQ client identificator
        /// </summary>
        public UInt32 Mqid
        {
            get { return native.mqid; }
            set { native.mqid = value; }
        }

        /// <summary>
        /// Color got to client (used by MT Manager)
        /// </summary>
        public UInt32 UserColor
        {
            get { return native.user_color; }
            set { native.user_color = value; }
        }

        /// <summary>
        /// For future use
        /// </summary>
        protected string Unused
        {
            get { return AnsiBytesToString(native.unused); }
        }

        /// <summary>
        /// This field stores user data of Manager API
        /// </summary>
        protected string ApiData
        {
            get { return AnsiBytesToString(native.api_data); }
        }
    }
}