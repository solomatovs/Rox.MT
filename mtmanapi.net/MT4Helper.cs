using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Globalization;


namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct WSAData
    {
        public short version;
        public short highVersion;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 257)]
        public string description;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string systemStatus;
        public short maxSockets;
        public short maxUdpDg;
        public IntPtr vendorInfo;
    }

    public static class MT4Helper
    {
        #region Win32Function
        [DllImport("Kernel32")]
        public static extern Int64 LocalAlloc(Int32 uFlags, UIntPtr sizetdwBytes);
        [DllImport("Kernel32")]
        public static extern IntPtr GetProcAddress(IntPtr handle, string funcname);
        [DllImport("kernel32", CharSet = CharSet.Ansi, BestFitMapping = false, SetLastError = true)]
        public static extern IntPtr LoadLibrary(string funcname);
        [DllImport("Kernel32", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr FreeLibrary(IntPtr handle);
        [DllImport("Ws2_32.dll", SetLastError = true)]
        internal static extern Int32 WSAStartup(Int16 wVersionRequested, ref WSAData lpWSAData);
        [DllImport("Ws2_32.dll", SetLastError = true)]
        internal static extern int WSACleanup();
        #endregion


        public static string CorrectString(this string value, Int32 countChar)
        {
            if (value == null)
            {
                value = string.Empty;
            }
            if (value.Length > countChar)
            {
                value = value.Substring(0, countChar);
            }

            return value;
        }

        public static T CreateMT4Model<TNative, T>(int codePage)
            where TNative : struct
            where T : MT4Model<TNative>
        {
            return Activator.CreateInstance(typeof(T), new object[] { codePage }) as T;
        }

        public static T ToEntity<TNative, T>(this TNative native, int codePage)
            where TNative : struct
            where T : MT4Model<TNative>
        {
            var entity = CreateMT4Model<TNative, T>(codePage);
            entity.native = native;
            return entity;
        }

        public static List<T> ToEntities<TNative, T>(this TNative[] natives, int codePage, Func<Int32, bool> conditionFirstToResult = null, Func<TNative, bool> conditionToResult = null)
            where TNative : struct
            where T : MT4Model<TNative>
        {
            var i = 0;
            var entities = new List<T>();
            foreach (var item in natives)
            {
                if ((!conditionFirstToResult?.Invoke(i)) ?? false)
                {
                    break;
                }

                if (conditionToResult?.Invoke(item) ?? true)
                {
                    entities.Add(item.ToEntity<TNative, T>(codePage));
                }
                i++;
            }
            return entities;
        }

        public static List<T> ToEntities<TNative, T>(this TNative[] natives, Int32 count, int codePage)
            where TNative : struct
            where T : MT4Model<TNative>
        {
            if (count < 0)
                throw new ArgumentException(nameof(count), $"argument 'count' can't be < 0. but the argument is '{count}'");

            return natives.ToEntities<TNative, T>(codePage, i => i < count);
        }

        public static TNative[] ToNatives<TNative, T>(this IEnumerable<T> entities)
            where TNative : struct
            where T : MT4Model<TNative>
        {
            var count = entities.Count();
            var natives = new TNative[count];
            Int32 i = 0;
            foreach (var entity in entities)
            {
                natives[i] = entity.native;
            }

            return natives;
        }

        public static bool Is64BitProccess()
        {
#if NET45
            return Environment.Is64BitProcess;
#else
            return IntPtr.Size == 8 ? true : false;
#endif
        }

        public static T GetFunctionAddress<T>(this IntPtr dllModule, string functionName)
            where T : class
        {
            IntPtr address = GetProcAddress(dllModule, functionName);
            if (address == IntPtr.Zero)
                throw new MT4FunctionNotFoundException(functionName);

            return Marshal.GetDelegateForFunctionPointer<T>(address);
        }

        public static string StringToManaged(this IntPtr nativeString)
        {
            return Marshal.PtrToStringAnsi(nativeString);
        }

        public static T ToStruct<T>(this IntPtr pStruct) where T : struct
        {
            return Marshal.PtrToStructure<T>(pStruct);
        }

        public static Int32 ToInt(this IntPtr pInt)
        {
            return Marshal.ReadInt32(pInt);
        }

        public static Int32 SizeOf<T>()
        {
            return Marshal.SizeOf<T>();
        }

        public static Int32 SizeOf<T>(this object entity)
        {
            return SizeOf<T>();
        }
        
        public static T ToStruct<T>(this byte[] data, int startIndex = 0) where T : struct
        {
            var size = SizeOf<T>();
            var ptPoit = Marshal.AllocHGlobal(size);
            Marshal.Copy(data, startIndex, ptPoit, size);
            var x = ToStruct<T>(ptPoit);
            Free(ref ptPoit);
            return x;
        }

        public static T[] ToArrayStruct<T>(this IntPtr pStruct, Int32 countElement) where T : struct
        {
            var size = SizeOf<T>();
            var result = new T[countElement];
            for (Int32 i = 0; i < countElement; i++)
            {
                result[i] = ((IntPtr)(pStruct + i * size)).ToStruct<T>();
            }

            return result;
        }

        public static byte[] ToByteArray(this IntPtr pStruct, Int32 countElement, int size)
        {
            return pStruct.ToByteArray(countElement * size);
        }

        public static byte[] ToByteArray(this IntPtr pStruct, int size)
        {
            var result = new byte[size];
            Marshal.Copy(pStruct, result, 0, size);
            return result;
        }

        public static string ToStringUni(this IntPtr pString, [Optional] Int32? len)
        {
            if (len == null)
            {
                return Marshal.PtrToStringUni(pString);
            }
            else
                return Marshal.PtrToStringUni(pString, len ?? 0);
        }

        public static IntPtr StringToPointerAnsi(this string value)
        {
            return Marshal.StringToHGlobalAnsi(value);
        }

        public static IntPtr StringToPointerUni(this string value)
        {
            return Marshal.StringToHGlobalUni(value);
        }

        public static void Free(ref IntPtr point)
        {
            Marshal.FreeHGlobal(point);
            point = IntPtr.Zero;
        }

        public static IntPtr ToPointer<T>(this IEnumerable<T> entities)
            where T : struct
        {
            var count = entities.Count();
            Int32 size = SizeOf<T>();

            IntPtr pointer = Marshal.AllocHGlobal(size * count);
            Int32 i = 0;
            foreach(var entity in entities)
            {
                Marshal.StructureToPtr(entity, pointer + (i * size), true);
                i++;
            }
            
            return pointer;
        }
        public static DateTime ToDateTime(this UInt32 unixtime)
        {
            return DateTimeOffset.FromUnixTimeSeconds(unixtime).UtcDateTime;
        }
        public static DateTime ToDateTime(this Int64 unixtime)
        {
            return DateTimeOffset.FromUnixTimeSeconds(unixtime).UtcDateTime;
        }

        public static DateTimeOffset StandartTimeToDateTime(this UInt32 standartTime)
        {
            var pt = (standartTime * 1.6777216);
            var p = Math.Truncate(pt);
            var t = (pt - p) * 1000;
            var dateTimeOffset = new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
            dateTimeOffset = dateTimeOffset.AddSeconds(p).AddMilliseconds(t);
            return dateTimeOffset;
        }

        public static UInt32 DateTimeToStandartTime(this DateTimeOffset time)
        {
            return (UInt32)Math.Truncate(time.Second / 1.6777216);
        }

        public static long ToLong(this DateTimeOffset DotNetTime)
        {
            if (DotNetTime == DateTimeOffset.MinValue || DotNetTime <= DateTimeOffset.Parse("1970.01.01 00:00:00")) return long.MinValue;
            if (DotNetTime == DateTimeOffset.MaxValue || DotNetTime >= DateTimeOffset.Parse("2038.01.19 03:14:07")) return Int32.MaxValue;

            return DotNetTime.ToUnixTimeSeconds();
        }

        public static UInt32 ToUInt(this DateTime DotNetTime)
        {
            if (DotNetTime == DateTimeOffset.MinValue || DotNetTime <= DateTimeOffset.Parse("1970.01.01 00:00:00")) return UInt32.MinValue;
            if (DotNetTime == DateTimeOffset.MaxValue || DotNetTime >= DateTimeOffset.Parse("2038.01.19 03:14:07")) return UInt32.MaxValue;
            
            return (UInt32)(new DateTimeOffset(DotNetTime.Year, DotNetTime.Month, DotNetTime.Day, DotNetTime.Hour, DotNetTime.Minute, DotNetTime.Second, TimeSpan.Zero)).ToUnixTimeSeconds();
        }

        public static string Encrypt(string password)     //процедура "Шифрование". используем шифр Виженера.
        {
            string key = "vtyzpjdenbujhm";
            string all = @"`1234567890-=~!@#$%^&*()_+qwertyuiop[]QWERTYUIOP{}asdfghjkl;'\ASDFGHJKL:""|ZXCVBNM<>?zxcvbnm,./№ёЁйцукенгшщзхъЙЦУКЕНГШЩЗХЪфывапролджэФЫВАПРОЛДЖЭячсмитьбюЯЧСМИТЬБЮ";//все символы, которые могут быть использовани при вводе пароляя
            string st; int center;                           //объявление новых переменных.
            string leftSlice, rightSlice, cPass = "";

            if (key.Length > password.Length)               //если длина строки пароля (ключа для входа в программу и для шифрования)>длины строки пароля (какого-либо сайта и т.д.),
            {
                key = key.Substring(0, password.Length);    //то переменная key обрежется и станет равной длинне пароля 
            }
            else                                            // Иначе повторять ключ (ключключключклю), пока не станет равным длинне пароля
                for (int i = 0; key.Length < password.Length; i++)
                {
                    key = key + key.Substring(i, 1);
                }
            //основной цикл шифрования
            for (int i = 0; i < password.Length; i++)
            {//находим центр строки all (центр - это будущий первый символ строки со сдвигом)
                center = all.IndexOf(key.Substring(i, 1));
                leftSlice = all.Substring(center); //берем левую часть будущей строки со сдвигом
                rightSlice = all.Substring(0, center);// затем правую
                st = leftSlice + rightSlice;// формируем строку со сдвигом
                center = all.IndexOf(password.Substring(i, 1));// теперь в переменную center запишем индекс очередного символа шифруемой строки
                cPass += st.Substring(center, 1);    //поскольку индексы символа из строки со сдвигом и из обычной строки совпадают, то нужный нам символ берется по такому же индексу
            }

            return cPass;
        }

        public static string Decrypt(string password)        //процедура "Расшифрование"
        {
            string key = "vtyzpjdenbujhm";
            // строка all содержит все символы, которые можно вводить с русской и англ раскладки клавиатуры
            string all = @"`1234567890-=~!@#$%^&*()_+qwertyuiop[]QWERTYUIOP{}asdfghjkl;'\ASDFGHJKL:""|ZXCVBNM<>?zxcvbnm,./№ёЁйцукенгшщзхъЙЦУКЕНГШЩЗХЪфывапролджэФЫВАПРОЛДЖЭячсмитьбюЯЧСМИТЬБЮ";
            //строка st со сдвигом по ключу (в качестве ключа используем наш пароль для входа)
            string st; int center; // центр указывает на индекс символа, до которого идет сдвиг по ключу.
            string leftSlice, rightSlice, cPass = ""; //leftSlice, rightSlice - правый срез, левый срез. из них составляется строка со сдвигом st. 

            //если пароль короче ключа - обрезаем ключ
            if (key.Length > password.Length)
            {
                key = key.Substring(0, password.Length);
            }
            //Иначе повторяем ключ, пока он не примет длинну пароля.
            else
                for (int i = 0; key.Length < password.Length; i++)
                {
                    key = key + key.Substring(i, 1);
                }
            // основной цикл расшифрования.
            for (int i = 0; i < password.Length; i++)
            {
                //находим центр строки all (центр - это будущий первый символ строки со сдвигом)
                center = all.IndexOf(key.Substring(i, 1));
                leftSlice = all.Substring(center); //берем левую часть будущей строки со сдвигом
                rightSlice = all.Substring(0, center);// затем правую
                st = leftSlice + rightSlice; // формируем строку со сдвигом
                center = st.IndexOf(password.Substring(i, 1)); // теперь в переменную center запишем индекс очередного символа расшифроввываемой строки
                cPass += all.Substring(center, 1); //поскольку индексы символа из строки со сдвигом и из обычной строки совпадают, то нужный нам символ берется по такому же индексу
            }
            return cPass; //возвращаем расшифрованный пароль.
        }

        public static byte[] GetBytesFromStringWithZero(Encoding encoding, string str, int length = 0)
        {
            int len = encoding.GetByteCount(str) + encoding.GetByteCount("\0");
            if (length != 0)
                len = length;

            byte[] bytes = new byte[len];
            encoding.GetBytes(str, 0, str.Length, bytes, 0);
            return bytes;
        }

        public static byte[] GetBytesFromEncoding(this string text, int length, Encoding encoding)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            var source_bytes = encoding.GetBytes(text);
            var charCount = encoding.GetByteCount(text);
            var byteInChar = (int)charCount / text.Length;
            var target_bytes = new byte[length * byteInChar];

            for (int i = 0; i < source_bytes.Count(); i++)
            {
                target_bytes[i*byteInChar] = source_bytes[i];
            }
            return target_bytes;
        }

        public static string GetStringFromEncoding(this byte[] text, Encoding encoding)
        {
            if (text == null || text.Length <= 0)
                return string.Empty;

            if (text[0] == 0)
                return string.Empty;

            int l = 0;
            var charCount = encoding.GetCharCount(text);
            var byteInChar = (int)text.Length / charCount;
            for (l = 0; l < text.Count(); l += byteInChar)
            {
                if (text[l] == 0)
                    break;
            }
            var source_bytes = text.Where((b, i) => i < l).ToArray();
            return encoding.GetString(source_bytes);
        }
    }


    internal static class LocaleMapper
    {
        private const string ApiWinKernel32 = "kernel32.dll";

        private const int LOCALE_NAME_MAX_LENGTH = 85;
        private const int ERROR_INVALID_PARAMETER = 0x57;
        private const uint LOCALE_IDEFAULTANSICODEPAGE = 0x00001004;
        private const uint LOCALE_RETURN_NUMBER = 0x20000000;

        [DllImport(ApiWinKernel32, SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern int GetLocaleInfoEx(string lpLocaleName, uint LCType, [Out] out uint lpLCData, int cchData);

        [DllImport(ApiWinKernel32, SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern int LCIDToLocaleName(uint Locale, StringBuilder lpName, int cchName, int dwFlags);

        [DllImport(ApiWinKernel32, SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern uint LocaleNameToLCID(string lpName, uint dwFlags);


        public static string LcidToLocaleNameInternal(int lcid)
        {
            var localeName = new StringBuilder(LOCALE_NAME_MAX_LENGTH);
            int length = LCIDToLocaleName(unchecked((uint)lcid), localeName, LOCALE_NAME_MAX_LENGTH, 0);

            if (length != 0)
            {
                return localeName.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public static int LocaleNameToAnsiCodePage(string localeName)
        {
            uint ansiCodePage;
            if (GetLocaleInfoEx(localeName, LOCALE_RETURN_NUMBER | LOCALE_IDEFAULTANSICODEPAGE, out ansiCodePage, sizeof(uint)) != 0)
            {
                return unchecked((int)ansiCodePage);
            }
            else
            {
                return 0;
            }
        }

        public static int Strlen(this IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                return 0;
            }

            int length = 0;
            byte pStr;
            do
            {
                pStr = Marshal.ReadByte(ptr + (length * sizeof(byte)));
                length++;
            }
            while (pStr != 0);

            return length;
        }

        public static int GetLcidForLocaleName(string localeName)
        {
            Debug.Assert(localeName != null, "Locale name should never be null");

            uint lcid = LocaleNameToLCID(localeName, 0);
            if (lcid != 0)
            {
                return unchecked((int)lcid);
            }
            else
            {
                return 0;
            }
        }
    }
}