using System;

namespace rox.mt4.api
{
    /// <summary>
    /// Базовые настройки MT4 Wrapper
    /// </summary>
    public class MT4NativeOption
    {
        public string dll_path { get; set; }
        public string dll64_path { get; set; }
        public string working_directory { get; set; }
        public int max_try_connect { get; set; } = 1;
        public int max_try_request { get; set; } = 1;
        public int codePage { get; set; } = 1251;
    }

    /// <summary>
    /// Настройки коннекта к МТ4 серверу
    /// </summary>
    public class MT4ConnectOption
    {
        public Int32 login { get; set; }
        public string password { get; set; }
        public string server { get; set; }
    }
}