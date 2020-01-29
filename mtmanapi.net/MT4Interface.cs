using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    public delegate T2 FuncRef<T, out T2>(ref T obj);
    public delegate T2 FuncRefArray<T, out T2>(ref T[] obj);
    public delegate T3 FuncRef<in T, T2, out T3>(T arg, ref T2 arg2);
    public delegate T4 FuncRef<T, T2, T3, out T4>(ref T arg, ref T2 arg2, ref T3 arg3);
    public delegate T5 FuncRef<in T, in T2, in T3, T4, out T5>(T arg, T2 arg2, T3 arg3, ref T4 arg4);
    public enum MT4Mode
    {
        request,
        pumping,
        pumpingEx,
        dealing
    }

    /// <summary>
    /// Класс Wrapper для работы с нативной mtmanapi.dll
    /// </summary>
    public class MT4Interface : NativeWrapper, IDisposable
    {
        protected MT4ConnectOption connectOption;
        protected MT4NativeOption options;
        protected MT4Mode mode;
        protected Action postLoginAction;
        protected IntPtr MTManAPI = IntPtr.Zero;
        private WSAData wsaStartuped = new WSAData();

        public string DllPath
        {
            get
            {
                if (MT4Helper.Is64BitProccess())
                    return this.options.dll64_path;
                else
                    return this.options.dll_path;
            }
        }

        public string LastServer
        {
            get => connectOption.server;
            protected set => connectOption.server = value;
        }
        public int LastLogin
        {
            get => connectOption.login;
            protected set => connectOption.login = value;
        }
        public string LastPassword
        {
            get => connectOption.password is null ? null : MT4Helper.Decrypt(connectOption.password);
            protected set => connectOption.password = MT4Helper.Encrypt(value ?? string.Empty);
        }
        public string LastKeyPath
        {
            get; protected set;
        }

        public bool HasCredentials
        {
            get { return !(LastLogin == 0 && string.IsNullOrWhiteSpace(LastServer)); }
        }

        public object CredentialsInfo()
        {
            return new { LastLogin, LastServer };
        }

        public MT4Interface(MT4NativeOption options)
        {
            this.options = options;
            this.connectOption = new MT4ConnectOption();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); // register page coding
            New();
        }

        private void New()
        {
            // производим отчистку нативных данных перед созданием новых
            Dispose();
            // стартуем сокеты
            WinsockStartup();

            // загружаем нативную mtmanapi.dll
            MTManAPI = MT4Helper.LoadLibrary(DllPath);
            var win32Error = Marshal.GetLastWin32Error();

            // Если не вышло загрузить, то кидаем исключение
            if (MTManAPI == IntPtr.Zero)
            {
                Dispose();
                throw new FileLoadException($"DLL not load native function 'LoadLibrary' in path '{DllPath}', current directory '{Directory.GetCurrentDirectory()}', errorWin32: {win32Error}");
            }
            else
            {
                try
                {
                    // библиотеку загрузили, уже хорошо. Теперь выбираем из нее две функции
                    mtManVersion = MTManAPI.GetFunctionAddress<MTManVersionDelegate>("MtManVersion");
                    mtManCreate = MTManAPI.GetFunctionAddress<MTManInterfaceDelegate>("MtManCreate");
                }
                catch (MT4FunctionNotFoundException e)
                {
                    // не полуилось выбрать функции. кидаем исключение и не создаем объект
                    Dispose();
                    throw e;
                }

                try
                {
                    // достаем версию mt4manapi.dll
                    var version = mtManVersion();
                    // создаем MT4 интерфейс
                    Create(version);
                    // инициализируем таблицу фиртуальных функций
                    InitVirtualTable();
                    // инициализируем делегаты (функции mt4manapi.dll) для .net
                    InitDelegate();
                }
                catch
                {
                    Dispose();
                    throw;
                }
            }
        }

        /// <summary>
        /// Тут освобождаем память, которая не подвластна всемогущему сборщику мусора
        /// Аминь, что бы все было сделано верно
        /// </summary>
        protected virtual void Disposing()
        {
            WinsockCleanup();
            // если был создан MT4 интерфейс, то необхоимо отчистить его
            if (CManagerInterface != IntPtr.Zero)
            {
                release(CManagerInterface);
                CManagerInterface = IntPtr.Zero;
            }
            if (MTManAPI != IntPtr.Zero)
            {
                // выгружаем библиотеку, если она загружена
                MT4Helper.FreeLibrary(MTManAPI);
                MTManAPI = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Стартует сокеты
        /// </summary>
        /// <returns></returns>
        private void WinsockStartup()
        {
            if (wsaStartuped.version == 0)
            {
                MT4Helper.WSAStartup(0x0202, ref wsaStartuped);
            }
        }

        /// <summary>
        /// Отчищает сокеты
        /// </summary>
        /// <returns></returns>
        private void WinsockCleanup()
        {
            if (wsaStartuped.version != 0)
            {
                _ = MT4Helper.WSACleanup();
                wsaStartuped = new WSAData();
            }
        }

        /// <summary>
        /// Создает MT4 CManagerInterface где расположены все функции mtmanapi.dll
        /// </summary>
        /// <param name="version"></param>
        private void Create(Int32 version)
        {
            mtManCreate(version, out CManagerInterface);
        }

        protected void ThrowIfModeIncorrect(string functionName, params MT4Mode[] modes)
        {
            if (!modes.Any(p => this.mode == p))
                throw new MT4RequestNotCorrespondException(functionName, this.mode, modes);
        }

        protected void ThrowIfModeNotPumping(string functionName)
        {
            ThrowIfModeIncorrect(functionName, MT4Mode.pumping, MT4Mode.pumpingEx);
        }
        protected void ThrowIfModeNotRequest(string functionName)
        {
            ThrowIfModeIncorrect(functionName, MT4Mode.request);
        }
        protected void ThrowIfModeNotDealing(string functionName)
        {
            ThrowIfModeIncorrect(functionName, MT4Mode.dealing);
        }
        protected void SetDefaultCodePageIfZero(ref int codePage)
        {
            if (codePage <= 0)
                codePage = options.codePage;
        }

        /// <summary>
        /// Преобразует результат нативного массива в .net массив
        /// </summary>
        /// <param name="pRequestResultArray"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        protected List<T> ToManagedList<T, TNative>(IntPtr pRequestResultArray, Int32 total, Func<IntPtr, T> newInitializer)
            where T : class
            where TNative : struct
        {
            var trades = new List<T>(total);
            if (pRequestResultArray == IntPtr.Zero)
                return trades;

            var size = this.SizeOf<TNative>();
            for (Int32 i = 0; i < total; i++)
            {
                IntPtr pItem = pRequestResultArray + i * size;
                trades.Add(newInitializer(pItem));
            }

            return trades;
        }

        protected TResult WrapperFunction<TResult>(Func<TResult> functorRequest)
        {
            return functorRequest.Invoke();
        }

        protected TResult WrapperFunction<TResult>(Func<IntPtr> functorRequest, Func<IntPtr, TResult> functorResult)
        {
            IntPtr pointer = IntPtr.Zero;
            try
            {
                var requestResult = functorRequest.Invoke();
                if (requestResult == IntPtr.Zero)
                {
                    PingIfRequestMode();
                    requestResult = functorRequest.Invoke();
                }

                return functorResult.Invoke(requestResult);
            }
            finally
            {
                memFree(CManagerInterface, pointer);
            }
        }

        /// <summary>
        /// Производит подключение к последнему серверу, который был запомнен
        /// </summary>
        internal void LastCommunicationn()
        {
            if (!string.IsNullOrEmpty(LastServer))
            {
                this.Connect(LastServer);
                if (LastLogin != 0 && !string.IsNullOrEmpty(LastPassword))
                {
                    this.Login(LastLogin, LastPassword);
                }
            }
        }

        /// <summary>
        /// Оболочка для функций у которых нужно проверить код возврата
        /// </summary>
        /// <param name="functor"></param>
        /// <param name="tocken"></param>
        /// <returns></returns>
        protected void WrapperFunction(Func<ResultCode> functor)
        {
            int tryCout = 0; int maxCount = options.max_try_request; int networkProblemExeptionCount = 0; int commonException = 0;
            while (tryCout < maxCount)
            {
                var result = functor.Invoke();
                tryCout++;

                try
                {
                    this.ThrowIfError(result);
                    break;
                }
                catch (MT4NoConnectionExeption e)
                {
                    if (tryCout >= maxCount)
                        throw e;

                    LastCommunicationn();
                    continue;
                }
                catch (MT4NetworkProblemExeption e)
                {
                    if (networkProblemExeptionCount > 0)
                        throw e;

                    networkProblemExeptionCount++;
                    LastCommunicationn();
                    continue;
                }
                catch (MT4CommonErrorExeption e)
                {
                    if (commonException > 0)
                        throw e;

                    //New();
                    commonException++;
                    LastCommunicationn();
                    continue;
                }
            }
        }

        protected T WrapperFunction<T, TNative>(FuncRef<TNative, ResultCode> functor, int codePage)
            where TNative : struct
            where T : MT4Model<TNative>
        {
            SetDefaultCodePageIfZero(ref codePage);
            var entity = MT4Helper.CreateMT4Model<TNative, T>(codePage);

            WrapperFunction(() => functor.Invoke(ref entity.native));

            return entity;
        }

        protected List<T> WrapperFunction<T, TNative>(Int32 countArray, FuncRefArray<TNative, ResultCode> functor, int codePage)
            where TNative : struct
            where T : MT4Model<TNative>
        {
            SetDefaultCodePageIfZero(ref codePage);
            var natives = new TNative[countArray];

            WrapperFunction(() => functor.Invoke(ref natives));

            return natives.ToEntities<TNative, T>(codePage);
        }

        protected List<T> WrapperFunction<T, TNative>(Int32 total, FuncRef<Int32, IntPtr> functor, int codePage)
            where TNative : struct
            where T : MT4Model<TNative>
        {
            SetDefaultCodePageIfZero(ref codePage);
            var tryCount = 0; int maxCount = 2;
            var ok = false;
            var result = new List<T>();
            while(!ok && tryCount < maxCount)
            {
                IntPtr pRequest = IntPtr.Zero;
                try
                {
                    pRequest = functor.Invoke(ref total);
                    if (pRequest == IntPtr.Zero)
                    {
                        PingIfRequestMode();
                        tryCount++;
                        continue;
                    }
                    result = ToManagedList<T, TNative>(pRequest, total, p => p.ToStruct<TNative>().ToEntity<TNative, T>(codePage));
                    if (result.Count <= 0)
                    {
                        PingIfRequestMode();
                        tryCount++;
                        continue;
                    }
                    ok = true;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    tryCount++;
                    memFree(CManagerInterface, pRequest);
                }
            }

            return result;
        }

        protected List<T> WrapperFunction<T, TNative>(FuncRef<Int32, IntPtr> functor, int codePage)
            where TNative : struct
            where T : MT4Model<TNative>
        {
            SetDefaultCodePageIfZero(ref codePage);
            var tryCount = 0; int maxCount = 2;
            var ok = false;
            var result = new List<T>();
            while (!ok && tryCount < maxCount)
            {
                Int32 total = 0;
                IntPtr pRequest = IntPtr.Zero;
                try
                {
                    pRequest = functor.Invoke(ref total);
                    if (pRequest == IntPtr.Zero)
                    {
                        PingIfRequestMode();
                        tryCount++;
                        continue;
                    }
                    result = ToManagedList<T, TNative>(pRequest, total, p => p.ToStruct<TNative>().ToEntity<TNative, T>(codePage));
                    if (result.Count <= 0)
                    {
                        PingIfRequestMode();
                        tryCount++;
                        continue;
                    }
                    ok = true;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    memFree(CManagerInterface, pRequest);
                }
            }

            return result;
        }

        protected byte[] WrapperFunctionByteResult<TNative>(FuncRef<Int32, IntPtr> functor, int codePage)
            where TNative : struct
        {
            SetDefaultCodePageIfZero(ref codePage);
            var tryCount = 0; int maxCount = 2;
            var ok = false;
            byte[] result = null;
            while (!ok && tryCount < maxCount)
            {
                Int32 total = 0;
                IntPtr pRequest = IntPtr.Zero;
                try
                {
                    pRequest = functor.Invoke(ref total);
                    if (pRequest == IntPtr.Zero)
                    {
                        PingIfRequestMode();
                        tryCount++;
                        continue;
                    }
                    result = pRequest.ToByteArray(total, MT4Helper.SizeOf<TNative>());
                    if (result.Count() <= 0)
                    {
                        PingIfRequestMode();
                        tryCount++;
                        continue;
                    }
                    ok = true;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    memFree(CManagerInterface, pRequest);
                }
            }

            return result;
        }

        /// <summary>
        /// Возвращает описание кода ошибки полученного от MT4 server
        /// </summary>
        /// <param name="code">код ошибки, который вернул MT4 server</param>
        /// <returns></returns>
        public string ErrorDescription(ResultCode code)
        {
            var stringPointer = errorDescription(CManagerInterface, code);
            var resultString = MT4Helper.StringToManaged(stringPointer);
            return resultString;
        }

        /// <summary>
        /// Назначает директорию для работы MT4 Manager
        /// Необходимо для сохранения и считывания файлов, необходимых менеджеру. к примеру symbols.raw
        /// </summary>
        public void WorkingDirectory(string path)
        {
            workingDirectory(CManagerInterface, path);
        }

        /// <summary>
        /// Устанавливает рабочую дерикторию для MT4 API записанную в настройках
        /// </summary>
        /// <param name="setting"></param>
        protected void WorkingDirectory(MT4NativeOption setting)
        {
            var directory = Directory.GetCurrentDirectory();
            if (!string.IsNullOrEmpty(setting?.working_directory))
            {
                if (Directory.Exists(setting.working_directory))
                {
                    directory = setting.working_directory;
                }
                else
                {
                    try
                    {
                        directory = Path.Combine(directory, setting.working_directory);
                    }
                    catch
                    {
                        directory = setting.working_directory;
                    }
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                }
            }

            WorkingDirectory(directory);
        }

        public void Connect(string server)
        {
            if (string.IsNullOrEmpty(server))
            {
                throw new ArgumentNullException(nameof(server));
            }

            Disconnect();
            WrapperFunction(() =>
            {
                ResultCode result = ResultCode.OK_NONE;
                var count = options.max_try_connect;
                for (var i = 0; i < count; i++)
                {
                    result = connect(CManagerInterface, server);
                    if (result != ResultCode.NO_CONNECTION)
                    {
                        break;
                    }
                }
                return result;
            });

            LastServer = server;
        }

        public void Disconnect()
        {
            WrapperFunction(() => disconnect(CManagerInterface));
            // LastServer = null;
        }

        public bool IsConnected()
        {
            ThrowIfModeNotPumping(nameof(IsConnected));

            return isConnected(CManagerInterface);
        }

        public void Login(int login, string password)
        {
            var login_b = LastLogin;
            var passowrd_b = LastPassword;

            LastLogin = 0;
            LastPassword = null;

            try
            {
                WrapperFunction(() => this.login(CManagerInterface, login, password));
                LastLogin = login;
                LastPassword = password;
                postLoginAction?.Invoke();
            }
            catch
            {
                LastLogin = login_b;
                LastPassword = passowrd_b;

                throw;
            }
        }

        public void Ping()
        {
            ThrowIfModeNotRequest(nameof(Ping));

            WrapperFunction(() => this.ping(CManagerInterface));
        }

        protected void PingIfRequestMode()
        {
            if (this.mode == MT4Mode.request)
                Ping();
        }

        protected bool IsPumpingMode()
        {
            return this.mode == MT4Mode.pumping || this.mode == MT4Mode.pumpingEx;
        }

        public void Dispose()
        {
            Disposing();
        }
    }
}