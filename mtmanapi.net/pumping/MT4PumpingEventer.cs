using System;

namespace rox.mt4.api
{
    //public class MT4PumpingEventer : MT4Manager
    //{
    //    public MT4PumpingEventer(MT4NativeOption options) : base(options)
    //    { }

    //    protected MTAPI_NOTIFY_FUNC PumpingCallback { get; set; }

    //    public IntPtr Destwnd { get; protected set; }
    //    public UInt32 Eventmsg { get; protected set; }
    //    public PumpingFlags Flags { get; protected set; }

    //    /// <summary>
    //    /// Переводит в режим пампинга
    //    /// Инициализирует все необходимые события
    //    /// </summary>
    //    /// <param name="flags"></param>
    //    /// <param name="param"></param>
    //    /// <returns></returns>
    //    public void PumpingSwitch(Action<PumpingNotificationCode> func, IntPtr destwnd, UInt32 eventmsg, PumpingFlags flags = 0)
    //    {
    //        PumpingCallback = new MTAPI_NOTIFY_FUNC(func);
    //        PumpingSwitch(PumpingCallback, destwnd, eventmsg, flags);
    //        Destwnd = destwnd;
    //        Eventmsg = eventmsg;
    //        Flags = flags;
    //    }

    //    public bool isStarted
    //    {
    //        get => (PumpingCallback != null && IsConnected());
    //    }

    //    public void ClearEvent()
    //    {

    //    }

    //    /// <summary>
    //    /// Производит перезапуск режима пампинга если ранее он был запущен
    //    /// Если не был запущен, то ничего не делает
    //    /// </summary>
    //    /// <returns></returns>
    //    public void Reset(Action preSwitch = null)
    //    {
    //        if (isStarted)
    //        {
    //            try
    //            {
    //                preSwitch?.Invoke();
    //                PumpingSwitch(Destwnd, Eventmsg, Flags);
    //            }
    //            catch(Exception e)
    //            {
    //                throw e;
    //            }
    //        }
    //    }

    //    protected virtual void ManagedPumpingCallback(PumpingNotificationCode code)
    //    {
    //    }
    //}
}