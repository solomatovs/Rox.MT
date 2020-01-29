using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Concurrent;

namespace rox.mt4.api
{
    public interface IRunMT4WrapperThreadSafe
    {
        void Run(MT4ConnectOption account, Action<MT4Manager> actionWithObject);
    }
    public class RunMT4WrapperThreadSafe : ConcurrentDictionary<MT4ConnectOption, IRunThreadSafe<MT4Manager>>, IRunMT4WrapperThreadSafe
    {
        private readonly Func<MT4Manager> creator;
        public RunMT4WrapperThreadSafe(Func<MT4Manager> creator)
        {
            this.creator = creator;
        }

        private bool TryGetMT4Manager(MT4ConnectOption key, out IRunThreadSafe<MT4Manager> value)
        {
            try
            {
                var hkey = Keys.First(p => p.login == key.login && p.password == key.password && p.server == key.server);
                value = this[hkey];
                return true;
            }
            catch
            {
                value = default(IRunThreadSafe<MT4Manager>);
                return false;
            }
        }

        public void Run(MT4ConnectOption connect, Action<MT4Manager> actionWithObject)
        {
            var watch = new Stopwatch(); watch.Start();

            IRunThreadSafe<MT4Manager> manager;
            while (!TryGetMT4Manager(connect, out manager))
            {
                // создаем нового менеджера
                var threadSafeManager = new RunActionThreadSafe<MT4Manager>(
                    creator: () =>
                    {
                        var newManager = creator.Invoke();
                        newManager.Communication(connect);
                        return newManager;
                    },
                    actionAfterInvoke: p => p.Dispose(),
                    leaveTheInTheQueue: runner => runner.Count <= 1);

                // проверка менеджера на работоспособность перед добавлением в очередь
                threadSafeManager.Run(p => p.Ping());

                // добавляем менеджера в словарь
                this.TryAdd(connect, threadSafeManager);
            }

            try
            {
                manager.Run(actionWithObject);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                watch.Stop();
            }
        }
    }
}