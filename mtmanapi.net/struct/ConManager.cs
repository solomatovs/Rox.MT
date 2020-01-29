using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NConManager
    {
        public Int32 login;                       // login
        public Int32 manager;                     // right to add & change client records
        public Int32 money;                       // right to balance & credit management
        public Int32 online;                      // right to see online users
        public Int32 riskman;                     // right to use analyzer
        public Int32 broker;                      // right to deal
        public Int32 admin;                       // right to server administration
        public Int32 logs;                        // right to see logs
        public Int32 reports;                     // right to see reports
        public Int32 trades;                      // right to add/modify/delete trades
        public Int32 market_watch;                // right to change spread, spread balance, stop levels, execution mode and send quotes
        public Int32 email;                       // right to send public mail
        public Int32 user_details;                // right to see clients private data-name,country,address,phone,email etc.
        public Int32 see_trades;                  // right to see trades
        public Int32 news;                        // right to send news
        public Int32 plugins;                     // right to configure plugins
        public Int32 server_reports;              // right to receive server reports
        public Int32 techsupport;                 // right to access to technical support page
        public Int32 market;                      // right to access server applications market
        public Int32 notifications;               // right to push notifications
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public Int32[] unused;
        public Int32 ipfilter;                    // enable IP control
        public UInt32 ip_from;
        public UInt32 ip_to;                      // range of allowed IPs
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] mailbox;                    // name of mailbox for public mail
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public byte[] groups;                     // comma separated list of managed groups (allowed '*' wildcard)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = (UnmanagedType)27)]
        public NConManagerSec[] secgroups;        // manager rights for security groups
        public UInt32 exp_time;                   // public data
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] name;                       // manager name (read only)
        public Int32 info_depth;                  // maximum available data (in days) 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public Int32[] reserved;
    }

    /// <summary>
    /// Object that represents manager configuration
    /// </summary>
    public class ConManager : MT4Model<NConManager>
    {
        public ConManager(int codePage) : base(codePage)
        {
            native.secgroups = new NConManagerSec[32];
        }
        /// <summary>
        /// Login
        /// </summary>
        public Int32 Login
        {
            get { return native.login; }
            set { native.login = value; }
        }

        /// <summary>
        /// Right to add and change client records
        /// </summary>
        public Int32 ManagerRights
        {
            get { return native.manager; }
            set { native.manager = value; }
        }

        /// <summary>
        /// Right to balance and credit management
        /// </summary>
        public Int32 Money
        {
            get { return native.money; }
            set { native.money = value; }
        }

        /// <summary>
        /// Right to see online users
        /// </summary>
        public Int32 Online
        {
            get { return native.online; }
            set {  native.online = value; }
        }

        /// <summary>
        /// Right to use analyzer
        /// </summary>
        public Int32 Riskman
        {
            get { return native.riskman; }
            set { native.riskman = value; }
        }

        /// <summary>
        /// Right to deal
        /// </summary>
        public Int32 Broker
        {
            get { return native.broker; }
            set { native.broker = value; }
        }

        /// <summary>
        /// Right to server administration
        /// </summary>
        public Int32 Admin
        {
            get { return native.admin; }
            set { native.admin = value; }
        }

        /// <summary>
        /// Right to see logs
        /// </summary>
        public Int32 Logs
        {
            get { return native.logs; }
            set { native.logs = value; }
        }

        /// <summary>
        /// Right to see reports
        /// </summary>
        public Int32 Reports
        {
            get { return native.reports; }
            set { native.reports = value; }
        }

        /// <summary>
        /// Right to add/modify/delete trades
        /// </summary>
        public Int32 Trades
        {
            get { return native.trades; }
            set { native.trades = value; }
        }

        /// <summary>
        /// Right to change spread, spread balance, stop levels, execution mode and send quotes
        /// </summary>
        public Int32 MarketWatch
        {
            get { return native.market_watch; }
            set { native.market_watch = value; }
        }

        /// <summary>
        /// Right to send public mail
        /// </summary>
        public Int32 Email
        {
            get { return native.email; }
            set { native.email = value; }
        }

        /// <summary>
        /// Right to see clients private data-name,country,address,phone,email etc.
        /// </summary>
        public Int32 UserDetails
        {
            get { return native.user_details; }
            set { native.user_details = value; }
        }

        /// <summary>
        /// Right to see trades
        /// </summary>
        public Int32 SeeTrades
        {
            get { return native.see_trades; }
            set { native.see_trades = value; }
        }

        /// <summary>
        /// Right to send news
        /// </summary>
        public Int32 News
        {
            get { return native.news; }
            set { native.news = value; }
        }

        /// <summary>
        /// Right to configure plugins
        /// </summary>
        public Int32 Plugins
        {
            get { return native.plugins; }
            set { native.plugins = value; }
        }

        /// <summary>
        /// Right to receive server reports
        /// </summary>
        public Int32 ServerReports
        {
            get { return native.server_reports; }
            set { native.server_reports = value; }
        }

        /// <summary>
        /// Right to access to technical support page
        /// </summary>
        public Int32 TechSupport
        {
            get { return native.techsupport; }
            set { native.techsupport = value; }
        }

        /// <summary>
        /// Right to access server applications Market
        /// </summary>
        public Int32 Market
        {
            get { return native.market; }
            set { native.market = value; }
        }

        /// <summary>
        /// Right to push Notifications
        /// </summary>
        public Int32 Notifications
        {
            get { return native.notifications; }
            set { native.notifications = value; }
        }

        /// <summary>
        /// Unused
        /// </summary>
        protected Int32[] Unused
        {
            get { return native.unused; }
        }

        /// <summary>
        /// Enable IP control
        /// </summary>
        public Int32 IpFilter
        {
            get { return native.ipfilter; }
            set { native.ipfilter = value; }
        }

        /// <summary>
        /// range of allowed IPs
        /// </summary>
        public UInt32 IpFrom
        {
            get { return native.ip_from; }
            set { native.ip_from = value; }
        }

        /// <summary>
        /// range of allowed IPs
        /// </summary>
        public UInt32 IpTo
        {
            get { return native.ip_to; }
            set { native.ip_to = value; }
        }

        /// <summary>
        /// Name of mailbox for internal mail
        /// </summary>
        public string Mailbox
        {
            get { return AnsiBytesToString(native.mailbox); }
            set { native.mailbox = StringToAnsiBytes(value, 64); }
        }

        /// <summary>
        /// Comma separated list of managed groups (allowed '*' wildcard)
        /// </summary>
        public string Groups
        {
            get { return AnsiBytesToString(native.groups); }
            set { native.groups = StringToAnsiBytes(value, 1024); }
        }
        
        /// <summary>
        /// Manager rights for security groups
        /// </summary>
        public List<ConManagerSec> SecGroups
        {
            get { return native.secgroups.ToEntities<NConManagerSec, ConManagerSec>(codePage: CodePage, conditionToResult: n => n.enable == 1); }
            set { native.secgroups = value.ToNatives<NConManagerSec, ConManagerSec>(); }
        }

        /// <summary>
        /// Manager name (read only)
        /// </summary>
        public string Name
        {
            get { return AnsiBytesToString(native.name); }
        }

        /// <summary>
        /// Maximum available data (in days)
        /// </summary>
        public Int32 InfoDepth
        {
            get { return native.info_depth; }
            set { native.info_depth = value; }
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