using System.Text;
using System.Linq;

namespace rox.mt4.api
{
    public class MT4Model<T> where T : struct
    {
        private const int defaultCodePage = 1252;
        private int codePage = defaultCodePage;
        public T native;

        public MT4Model(int codePage) : base()
        {
            this.CodePage = codePage;
        }
        public MT4Model(T native, int codePage) : this(codePage)
        {
            this.native = native;
        }

        public MT4Model(MT4Model<T> entity) : this(entity.native, entity.CodePage) { }

        public int CodePage
        {
            get { return codePage; }
            set { codePage = value <= 0 ? defaultCodePage : value; }
        }

        protected byte[] StringToAnsiBytes(string text, int length)
        {
            return text.GetBytesFromEncoding(length, Encoding.GetEncoding(CodePage));
        }

        protected string AnsiBytesToString(params byte[] text)
        {
            return text.GetStringFromEncoding(Encoding.GetEncoding(CodePage));
        }
    }
}