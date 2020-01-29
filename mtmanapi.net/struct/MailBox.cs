using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NMailBox
    {
        public UInt32 time;               // receive time
        public Int32 sender;              // mail sender (login)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] from;               // mail sender (name)
        public Int32 to;                  // mail recipient
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] subject;            // mail sumbect
        public Int32 readed;              // readed flag
        public IntPtr body;              // pointer to mail body
        public Int32 bodylen;             // mail body length
        public ushort build_min;           // minimum build
        public ushort build_max;           // maximum build
        public Int32 reserved;            // reserved
    }

    /// <summary>
    /// Object that represents mailbox
    /// </summary>
    public class MailBox : MT4Model<NMailBox>, IDisposable
    {
        public MailBox(int codePage) : base(codePage) { }
        public MailBox() : this(0) { }
        /// <summary>
        /// Receive time
        /// </summary>
        public DateTime Time
        {
            get { return native.time.ToDateTime(); }
            set { native.time = value.ToUInt(); }
        }

        /// <summary>
        /// Mail sender (login)
        /// </summary>
        public Int32 Sender
        {
            get { return native.sender; }
            set { native.sender = value; }
        }

        /// <summary>
        /// Mail sender (name)
        /// </summary>
        public string From
        {
            get { return AnsiBytesToString(native.from); }
            set { native.from = StringToAnsiBytes(value, 64); }
        }

        /// <summary>
        /// Mail recipient
        /// </summary>
        internal Int32 To
        {
            get { return native.to; }
            set { native.to = value; }
        }

        /// <summary>
        /// Mail sumbect
        /// </summary>
        public string Subject
        {
            get { return AnsiBytesToString(native.subject); }
            set { native.subject = StringToAnsiBytes(value, 128); }
        }

        /// <summary>
        /// Readed flag
        /// </summary>
        public Int32 Readed
        {
            get { return native.readed; }
        }

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
        /// Minimum build
        /// </summary>
        public ushort BuildMin
        {
            get { return native.build_min; }
            set { native.build_min = value; }
        }

        /// <summary>
        /// Maximum build
        /// </summary>
        public ushort BuildMax
        {
            get { return native.build_max; }
            set { native.build_max = value; }
        }

        /// <summary>
        /// Reserved
        /// </summary>
        internal Int32 Reserved
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

        public override string ToString()
        {
            return $"{Time} {Sender} {Subject} {Body}";
        }
    }
}