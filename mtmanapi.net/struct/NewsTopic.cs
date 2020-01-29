using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NNewsTopic
    {
        public UInt32 key;                // news key
        public UInt32 time;               // news time
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] ctm;                // news source time ("yyyy/mm/dd hh:mm:ss")
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] topic;              // news topic
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] category;           // news category
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] keywords;           // news keywords
        public IntPtr body;               // body (if present)
        public Int32 bodylen;             // body length
        public Int32 readed;              // readed flag
        public Int32 priority;            // news priority: 0-general, 1-high
        public Int32 langid;              // news LANGID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
        public Int32[] reserved;
    }

    /// <summary>
    /// Object that represents news topic
    /// </summary>
    public class NewsTopic : MT4Model<NNewsTopic>, IDisposable
    {
        public NewsTopic(int codePage) : base(codePage) { }
        /// <summary>
        /// News key
        /// </summary>
        public UInt32 Key
        {
            get { return native.key; }
            set { native.key = value; }
        }

        /// <summary>
        /// News time
        /// </summary>
        internal DateTime Time
        {
            get { return native.time.ToDateTime(); }
            set { native.time = value.ToUInt(); }
        }

        /// <summary>
        /// News source time ("yyyy/mm/dd hh:mm:ss")
        /// </summary>
        //internal string Ctm
        //{
        //    get { return AnsiBytesToString(native.ctm); }
        //    set { native.ctm = StringToAnsiBytes(value, 32); }
        //}

        /// <summary>
        /// News topic
        /// </summary>
        public string Topic
        {
            get { return AnsiBytesToString(native.topic); }
            set { native.topic = StringToAnsiBytes(value, 256); }
        }

        /// <summary>
        /// News Category
        /// </summary>
        public string Category
        {
            get { return AnsiBytesToString(native.category); }
            set { native.category = StringToAnsiBytes(value, 64); }
        }

        /// <summary>
        /// News keywords
        /// </summary>
        public string Keywords
        {
            get { return AnsiBytesToString(native.keywords); }
            set { native.keywords = StringToAnsiBytes(value, 256); }
        }

        /// <summary>
        /// Body (if present)
        /// </summary>
        public string Body
        {
            get
            {
                if (native.bodylen > 0)
                {
                    var ret = new byte[native.bodylen];
                    try
                    {
                        Marshal.Copy(native.body, ret, 0, native.bodylen);
                        return AnsiBytesToString(ret);
                    }
                    catch (Exception)
                    {
                        return string.Empty;
                    }
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                if (native.body != IntPtr.Zero)
                {
                    BodyFree();
                    if (native.body != IntPtr.Zero)
                        throw new Exception(nameof(native.body));
                }

                if (value.Length <= 0)
                    return;

                var text = StringToAnsiBytes(value, value.Length);
                native.bodylen = text.Count();
                native.body = Marshal.AllocHGlobal(text.Count());
                Marshal.Copy(text, 0, native.body, text.Count());
            }
        }


        /// <summary>
        /// Readed flag
        /// </summary>
        internal Int32 Readed
        {
            get { return native.readed; }
        }

        /// <summary>
        /// News priority: 0-general, 1-high
        /// </summary>
        public Int32 Priority
        {
            get { return native.priority; }
            set { native.priority = value == 0 ? 0 : 1; }
        }

        /// <summary>
        /// News LANGID
        /// </summary>
        public Int32 LangId
        {
            get { return native.langid; }
            set { native.langid = value; }
        }

        /// <summary>
        /// Reserved
        /// </summary>
        internal Int32[] Reserved
        {
            get { return native.reserved; }
        }


        private void BodyFree()
        {
            if (native.body != IntPtr.Zero)
            {
                try
                {
                    var pointer = native.body;
                    Marshal.FreeHGlobal(pointer);
                    native.bodylen = 0;
                }
                catch { }
                finally
                {
                    native.body = IntPtr.Zero;
                    native.bodylen = 0;
                }
            }
        }

        public void Dispose()
        {
            BodyFree();
        }
    }
}