using System;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace rox.mt4.api
{
    public interface IRunThreadSafe<T>
        where T : class
    {
        /// <summary>
        /// Run action in ThreadSafe
        /// </summary>
        /// <param name="actionWithObject"></param>
        void Run(Action<T> actionWithObject);
        /// <summary>
        /// Count T on current moment (ThreadSafe)
        /// </summary>
        int Count { get; }
    }

    /// <summary>
    /// Запускает задачи для разных экземпляров данного объекта в зависимости от логики в методе 'createNewObject'
    /// Содержит в себе потокобезопасную очередь
    /// Объекты добавляются в очередь только тогда, когда не удалось из нее забрать объект
    /// Объекты удаляются из очереди только если метод 'createNewObject' вернул true
    /// Для того, что бы объект не был удален из очереди, необходимо что бы метод 'createNewObject' вернул false
    /// </summary>
    /// <typeparam name="T">Объект с которым будет производиться действие </typeparam>
    public class RunActionThreadSafe<T> : ConcurrentQueue<T>, IRunThreadSafe<T> where T : class
    {
        private readonly Func<T> creator;
        private readonly Action<T> actionAfterInvoke;
        private readonly Func<IRunThreadSafe<T>, bool> leaveTheInTheQueue;

        public RunActionThreadSafe(Func<T> creator)
        {
            this.creator = creator;
            this.leaveTheInTheQueue = runner => false;
        }
        public RunActionThreadSafe(Func<T> creator, Action<T> actionAfterInvoke) : this(creator)
        {
            this.actionAfterInvoke = actionAfterInvoke;
        }
        public RunActionThreadSafe(Func<T> creator, Action<T> actionAfterInvoke, Func<IRunThreadSafe<T>, bool> leaveTheInTheQueue) : this(creator, actionAfterInvoke)
        {
            this.leaveTheInTheQueue = leaveTheInTheQueue;
        }

        public void Run(Action<T> actionWithObject)
        {
            var watch = new Stopwatch(); watch.Start();

            var createNewObjectResult = false;
            T entity;
            while (!(createNewObjectResult = leaveTheInTheQueue(this) ? TryPeek(out entity) : TryDequeue(out entity)))
            {
                this.Enqueue(creator.Invoke());
            }

            try
            {
                actionWithObject.Invoke(entity);
            }
            finally
            {
                watch.Restart();
                if (!createNewObjectResult)
                {
                    actionAfterInvoke?.Invoke(entity);
                }
            }
        }
    }
}
