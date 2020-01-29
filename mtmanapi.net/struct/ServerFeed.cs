using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NServerFeed
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] file;                 // feeder file name
        public NFeedDescription feed;       // feeder description
    }

    /// <summary>
    /// Object that represents server feed
    /// </summary>
    public class ServerFeed : MT4Model<NServerFeed>
    {
        public ServerFeed(int codePage) : base(codePage) { }
        /// <summary>
        /// Feeder file name
        /// </summary>
        public string File
        {
            get { return AnsiBytesToString(native.file); }
            set { native.file = StringToAnsiBytes(value, 256); }
        }

        /// <summary>
        /// Feeder description
        /// </summary>
        public FeedDescription Feed
        {
            get { return native.feed.ToEntity<NFeedDescription, FeedDescription>(codePage: CodePage); }
            set { native.feed = value.native; }
        }
    }
}