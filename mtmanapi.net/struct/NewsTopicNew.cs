using System;
using System.Text;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
    public struct NNewsTopicNew
    {
        public UInt32 key;                     // news key
        public UInt32 language;                // news language (WinAPI LANGID)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string subject;                 // news subject
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string category;                // news category
        public EnNewsFlags flags;                   // EnNewsFlags
        public IntPtr body;                    // body
        public UInt32 body_len;                // body length
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public UInt32[] languages_list;        // list of languages available for news
        public Int64 datetime;                // news time
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30*4)]
        public byte[] reserved;                // reserved
    }

    /// <summary>
    /// New news topic class
    /// </summary>
    public class NewsTopicNew : MT4Model<NNewsTopicNew>, IDisposable
    {
        public NewsTopicNew(int codePage) : base(codePage) { }

        private static Int32 MAX_NEWS_BODY_LENGTH = 15 * 1024 * 1024;
        public static Int32 MaxNewsBodySymbolLength(EnNewsFlags flags)
        {
            if (flags.HasFlag(EnNewsFlags.Mime))
            {
                return 400 * 1024;
            }
            return MAX_NEWS_BODY_LENGTH;
        }

        public override string ToString()
        {
            return $"lang: {Language} key: {Key} ({Category}): {Subject}";
        }

        /// <summary>
        /// News key
        /// </summary>
        public UInt32 Key
        {
            get { return native.key; }
            set { native.key = value; }
        }

        /// <summary>
        /// News language (WinAPI LANGID)
        /// </summary>
        public string Language
        {
            get { return LocaleMapper.LcidToLocaleNameInternal((Int32)native.language); }
            set { native.language = (UInt32)LocaleMapper.GetLcidForLocaleName(value); }
        }

        /// <summary>
        /// News subject
        /// </summary>
        public string Subject
        {
            get { return native.subject; }
            set { native.subject = value; }
            //get
            //{
            //    var codePage = LocaleMapper.LocaleNameToAnsiCodePage(Language);
            //    var sub = native.subject.GetStringFromEncoding(Encoding.UTF8/*GetEncoding(codePage)*/);
            //    return sub;
            //}
            //set
            //{
            //    var codePage = LocaleMapper.LocaleNameToAnsiCodePage(Language);
            //    native.subject = value.GetBytesFromEncoding(256, Encoding.UTF8/*.GetEncoding(codePage)*/);
            //}
        }

        /// <summary>
        /// News category
        /// </summary>
        public string Category
        {
            get { return native.category; }
            set { native.category = value; }
        }

        /// <summary>
        /// EnNewsFlags
        /// </summary>
        public EnNewsFlags Flags
        {
            get { return native.flags; }
            set { native.flags = value; }
        }

        /// <summary>
        /// News body
        /// </summary>
        //public string Body
        //{
        //    get
        //    {
        //        // var hasFlagMime = Flags.HasFlag(EnNewsFlags.Mime);
        //        // var encoding = hasFlagMime ? Encoding.UTF8 : Encoding.Unicode;
        //        //return native.body != 0 ? new IntPtr(native.body).ToStringUni((Int32)native.body_len) : string.Empty;
        //        return native.body != IntPtr.Zero ? native.body.ToStringUni((Int32)native.body_len) : string.Empty;
        //    }
        //    set
        //    {
        //        if (string.IsNullOrEmpty(value))
        //        {
        //            native.body_len = 0;
        //            return;
        //        }

        //        value = value.CorrectString(MaxNewsBodySymbolLength(Flags));
        //        native.body = value.StringToPointerUni();
        //        native.body_len = (UInt32)value.Length;
        //    }
        //}

        /// <summary>
        /// List of languages available for news
        /// </summary>
        public IList<string> LanguagesList
        {
            get
            {
                var list = new List<string>();
                foreach (var i in native.languages_list)
                {
                    if (i == 0)
                        break;

                    list.Add(LocaleMapper.LcidToLocaleNameInternal((Int32)i));
                }

                return list;
            }
            set
            {
                int i = 0;
                foreach(var l in value)
                {
                    if (i >= 32)
                        break;

                    native.languages_list[i] = (UInt32) LocaleMapper.GetLcidForLocaleName(l);
                    i++;
                }
            }
        }

        /// <summary>
        /// News time
        /// </summary>
        public DateTime DateTime
        {
            get { return native.datetime.ToDateTime(); }
            set { native.datetime = value.ToUInt(); }
        }

        /// <summary>
        /// Reserved
        /// </summary>
        protected byte[] Reserved
        {
            get { return native.reserved; }
        }

        public void Dispose()
        {
            //if (native.body != 0)
            if (native.body != IntPtr.Zero)
            {
                //var ptr = new IntPtr(native.body);
                //MT4Helper.Free(ref ptr);
                MT4Helper.Free(ref native.body);
                native.body_len = 0;
            }
        }
    }
}