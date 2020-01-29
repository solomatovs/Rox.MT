using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NConFeeder
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] name;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] file;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] server;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] login;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] pass;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] keywords;
        public Int32 enable;
        public Int32 mode;
        public Int32 timeout;
        public Int32 timeout_reconnect;
        public Int32 timeout_sleep;
        public Int32 attemps_sleep;
        public Int32 news_langid;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        public Int32[] unused;
    }

    /// <summary>
    /// Object that represents feeder configuration
    /// </summary>
    public class ConFeeder : MT4Model<NConFeeder>
    {
        public ConFeeder(int codePage) : base(codePage) { }
        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get { return AnsiBytesToString(native.name); }
            set { native.name = StringToAnsiBytes(value, 64); }
        }

        /// <summary>
        /// DataFeed filename
        /// </summary>
        public string File
        {
            get { return AnsiBytesToString(native.file); }
            set { native.file = StringToAnsiBytes(value, 256); }
        }

        /// <summary>
        /// Server address
        /// </summary>
        public string Server
        {
            get { return AnsiBytesToString(native.server); }
            set { native.server = StringToAnsiBytes(value, 64); }
        }

        /// <summary>
        /// DataFeed login
        /// </summary>
        public string Login
        {
            get { return AnsiBytesToString(native.login); }
            set { native.login = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// DataFeed password
        /// </summary>
        public string Pass
        {
            get { return AnsiBytesToString(native.pass); }
            set { native.pass = StringToAnsiBytes(value, 32); }
        }

        /// <summary>
        /// Keywords (news filtration)
        /// </summary>
        public string Keywords
        {
            get { return AnsiBytesToString(native.keywords); }
            set { native.keywords = StringToAnsiBytes(value, 256); }
        }

        /// <summary>
        /// Enable feeder
        /// </summary>
        public Int32 Enable
        {
            get { return native.enable; }
            set { native.enable = value; }
        }

        /// <summary>
        /// Datafeed mode-enumeration FEED_QUOTES, FEED_NEWS, FEED_QUOTESNEWS
        /// </summary>
        public DataFeedMode Mode
        {
            get { return (DataFeedMode)native.mode; }
            set { native.mode = (Int32) value; }
        }

        /// <summary>
        /// Max. freeze time (default ~120 sec.)
        /// </summary>
        public Int32 Timeout
        {
            get { return native.timeout; }
            set { native.timeout = value; }
        }

        /// <summary>
        /// Reconnect timeout before attemps_sleep connect attempts (default ~ 5  sec)
        /// </summary>
        public Int32 TimeoutReconnect
        {
            get { return native.timeout_reconnect; }
            set { native.timeout_reconnect = value; }
        }

        /// <summary>
        /// Reconnect timeout after attemps_sleep connect attempts  (default ~ 60 sec)
        /// </summary>
        public Int32 TimeoutSleep
        {
            get { return native.timeout_sleep; }
            set { native.timeout_sleep = value; }
        }

        /// <summary>
        /// Reconnect count (see timeout_reconnect and timeout_sleep)
        /// </summary>
        public Int32 AttempsSleep
        {
            get { return native.attemps_sleep; }
            set { native.attemps_sleep = value; }
        }

        /// <summary>
        /// News language id
        /// </summary>
        public Int32 NewsLangId
        {
            get { return native.news_langid; }
            set { native.news_langid = value; }
        }

        /// <summary>
        /// Unused
        /// </summary>
        protected Int32[] Unused
        {
            get { return native.unused; }
        }
    }
}