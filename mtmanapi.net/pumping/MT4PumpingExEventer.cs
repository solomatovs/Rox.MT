using System;

namespace rox.mt4.api
{
    using rox.mt4.api;

    //public delegate void BidAskUpdatedDelegate();
    //public delegate void TradesUpdatedDelegate(TradeRecord trade);
    //public delegate void UsersUpdatedDelegate(UserRecord user);
    ////public delegate void UsersUpdatedDelegate(PumpingUpdateType type, UserRecord user);
    //public delegate void OnlineUpdatedDelegate(Int32 login);
    //public delegate void NewsBodyUpdatedDelegate();
    //public delegate void PluginsUpdatedDelegate();
    //public delegate void ActivationUpdatedDelegate();
    //public delegate void MarginCallUpdatedDelegate();
    //public delegate void PumpingPingDelegate();
    //public delegate void StartPumpingDelegate();
    //public delegate void StopPumpingDelegate();
    ////public delegate void NewsNewUpdatedDelegate(Int32 type, NewsTopicNew news);
    ////public delegate void MailUpdatedDelegage(Int32 type, MailBox message);
    //public delegate void SymbolsUpdatedDelegate(PumpingUpdateType type, ConSymbol symbol);
    ////public delegate void GroupsUpdatedDelegate(Int32 type, ConGroup group);
    ////public delegate void RequestsUpdatedDelegate(Int32 type, RequestInfo request);
    ////public delegate void NewsUpdatedDelegate(Int32 type, NewsTopic news);

    
    //public class MT4PumpingExEventer : MT4Manager
    //{
    //    public MT4PumpingExEventer(MT4NativeOption options) : base(options)
    //    {
    //    }

    //    protected MTAPI_NOTIFY_FUNC_EX PumpingCallbackEx { get; set; }


    //    /// <summary>
    //    /// Event rised when added new trade. Works only in extended pumping mode
    //    /// </summary>
    //    public event TradesUpdatedDelegate TradeOperationOpened;

    //    /// <summary>
    //    /// Event rised when trade changed. Works only in extended pumping mode
    //    /// </summary>
    //    public event TradesUpdatedDelegate TradeOperationUpdated;

    //    /// <summary>
    //    /// Event rised when trade closed. Works only in extended pumping mode
    //    /// </summary>
    //    public event TradesUpdatedDelegate TradeOperationClosed;

    //    /// <summary>
    //    /// Event rised when pending order deleted. Works only in extended pumping mode
    //    /// </summary>
    //    public event TradesUpdatedDelegate TradeOperationDeleted;

    //    /// <summary>
    //    /// Event rised when added new trade. Works only in extended pumping mode
    //    /// </summary>
    //    public event TradesUpdatedDelegate BalanceOperationCreated;

    //    /// <summary>
    //    /// Event rised when trade changed. Works only in extended pumping mode
    //    /// </summary>
    //    public event TradesUpdatedDelegate BalanceOperationUpdated;

    //    /// <summary>
    //    /// Event rised when pending order deleted. Works only in extended pumping mode
    //    /// </summary>
    //    public event TradesUpdatedDelegate BalanceOperationDeleted;
    //    /// <summary>
    //    /// Event rised when added new trade. Works only in extended pumping mode
    //    /// </summary>
    //    public event TradesUpdatedDelegate CreditOperationCreated;

    //    /// <summary>
    //    /// Event rised when trade changed. Works only in extended pumping mode
    //    /// </summary>
    //    public event TradesUpdatedDelegate CreditOperationUpdated;

    //    /// <summary>
    //    /// Event rised when pending order deleted. Works only in extended pumping mode
    //    /// </summary>
    //    public event TradesUpdatedDelegate CreditOperationDeleted;

    //    /// <summary>
    //    /// Event rised when pumping started. Works only in pumping mode
    //    /// </summary>
    //    public event StartPumpingDelegate PumpingStarted;

    //    /// <summary>
    //    /// Event rised when pumping stopped. Works only in pumping mode
    //    /// </summary>
    //    public event StopPumpingDelegate PumpingStopped;

    //    /// <summary>
    //    /// Событие вызываемое в случае обновления настроек символов
    //    /// </summary>
    //    public event SymbolsUpdatedDelegate SymbolsUpdated;

    //    /// <summary>
    //    /// Event rised when new quote received. Works only in extended pumping mode
    //    /// </summary>
    //    public event BidAskUpdatedDelegate BidAskUpdated;

    //    /// <summary>
    //    /// Event rised when online users updated. Works only in extended pumping mode
    //    /// </summary>
    //    public event OnlineUpdatedDelegate OnlineAdded;

    //    /// <summary>
    //    /// Удаление логина из онлайн пользователей
    //    /// </summary>
    //    public event OnlineUpdatedDelegate OnlineRemoved;

    //    /// <summary>
    //    /// Событие обновление данных по счету клиента
    //    /// </summary>
    //    public event UsersUpdatedDelegate UserUpdated;

    //    /// <summary>
    //    /// Событие создания нового счета клиента
    //    /// </summary>
    //    public event UsersUpdatedDelegate UserCreated;

    //    /// <summary>
    //    /// Событие закрытия счета (пока неизвестно как это)
    //    /// </summary>
    //    public event UsersUpdatedDelegate UserClosed;

    //    /// <summary>
    //    /// Событие обновления группы счета
    //    /// </summary>
    //    public event UsersUpdatedDelegate UserChangeGroup;

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public event PluginsUpdatedDelegate PluginsUpdated;

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public event ActivationUpdatedDelegate ActivationUpdated;

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public event MarginCallUpdatedDelegate MarginCallUpdated;

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public event PumpingPingDelegate PumpingPing;


    //    public PumpingFlags Flags { get; protected set; }
    //    public object Param { get; protected set; }

    //    public bool isStarted
    //    {
    //        get
    //        {
    //            return (PumpingCallbackEx != null && IsConnected());
    //        }
    //    }

    //    public void ClearEvent()
    //    {
    //        TradeOperationOpened = null;
    //        TradeOperationUpdated = null;
    //        TradeOperationClosed = null;
    //        TradeOperationDeleted = null;
    //        BalanceOperationCreated = null;
    //        BalanceOperationUpdated = null;
    //        BalanceOperationDeleted = null;
    //        CreditOperationCreated = null;
    //        CreditOperationUpdated = null;
    //        CreditOperationDeleted = null;
    //        PumpingStarted = null;
    //        PumpingStopped = null;
    //        SymbolsUpdated = null;
    //        BidAskUpdated = null;
    //        OnlineAdded = null;
    //        OnlineRemoved = null;
    //        UserUpdated = null;
    //        UserCreated = null;
    //        UserClosed = null;
    //        UserChangeGroup = null;
    //        PluginsUpdated = null;
    //        ActivationUpdated = null;
    //        MarginCallUpdated= null;
    //        PumpingPing = null;
    //    }

    //    ///// <summary>
    //    ///// Переводит в режим пампинга
    //    ///// Инициализирует все необходимые события
    //    ///// </summary>
    //    ///// <param name="flags"></param>
    //    //public void PumpingSwitchEx(PumpingFlags flags = 0, object param = null)
    //    //{
    //    //    PumpingCallbackEx = new MTAPI_NOTIFY_FUNC_EX(ManagedPumpingCallback);
    //    //    PumpingSwitchEx(PumpingCallbackEx, flags, param);
    //    //    Flags = flags;
    //    //    Param = param;
    //    //}

    //    ///// <summary>
    //    ///// Производит перезапуск режима пампинга если ранее он был запущен
    //    ///// Если небыл запущен, то ничего не делает
    //    ///// </summary>
    //    ///// <returns></returns>
    //    //public void Reset(Action preSwitch = null)
    //    //{
    //    //    if (isStarted)
    //    //    {
    //    //        preSwitch?.Invoke();
    //    //        //PumpingCallbackEx = Task.FromResult(new MTAPI_NOTIFY_FUNC_EX(ManagedPumpingCallback));
    //    //        PumpingSwitchEx(PumpingCallbackEx, Flags, Param);
    //    //    }
    //    //}

    //    ///// <summary>
    //    ///// Стартует режим расширенного пампинга, если старт еще не произведен
    //    ///// </summary>
    //    //public void PumpingSwitchExIfNotSwitched(MT4ConnectOption connection, PumpingFlags flags = 0, object param = null)
    //    //{
    //    //    if (!isStarted)
    //    //    {
    //    //        this.Communication(connection);
    //    //        PumpingSwitchEx(Flags, Param);
    //    //    }
    //    //}

    //    /// <summary>
    //    /// Функция обратного вызова в режиме пампинга. Срабатывает в случае если от МТ4 сервера пришло сообщение
    //    /// Функция генерирует ряд событий (Event) с которыми работает польователь использующий менеджера
    //    /// </summary>
    //    /// <param name="code">Код сообщения от МТ4 сервера</param>
    //    /// <param name="type">Тип сообщения</param>
    //    /// <param name="dataInt">Указатель на объект, который передает МТ4 сервер вместе с событием</param>
    //    /// <param name="paramInt">Указатель на параметры, которые передает МТ4 сервер вместе с объектом</param>
    //    protected virtual void ManagedPumpingCallback(PumpingNotificationCode code, PumpingUpdateType type, IntPtr dataInt, IntPtr paramInt)
    //    {
    //        switch (code)
    //        {
    //            case PumpingNotificationCode.START_PUMPING:
    //                PumpingStarted?.Invoke();
    //                break;
    //            case PumpingNotificationCode.UPDATE_SYMBOLS:
    //                if (dataInt != IntPtr.Zero)
    //                {
    //                    var data = dataInt.ToStruct<NConSymbol>();
    //                    var symbol = data.ToEntity<NConSymbol, ConSymbol>();
    //                    SymbolsUpdated?.Invoke(type, symbol);
    //                }
    //                break;
    //            case PumpingNotificationCode.UPDATE_GROUPS:
    //                if (dataInt != IntPtr.Zero)
    //                {
    //                    var data = dataInt.ToStruct<NUserRecord>();
    //                    var user = data.ToEntity<NUserRecord, UserRecord>();
    //                    UserChangeGroup?.Invoke(user);
    //                }
    //                break;
    //            case PumpingNotificationCode.UPDATE_USERS:
    //                if (dataInt != IntPtr.Zero)
    //                {
    //                    var data = dataInt.ToStruct<NUserRecord>();
    //                    var user = data.ToEntity<NUserRecord, UserRecord>();

    //                    switch (type)
    //                    {
    //                        case PumpingUpdateType.ADD:
    //                            UserCreated?.Invoke(user);
    //                            break;
    //                        case PumpingUpdateType.REMOVE:
    //                            UserClosed?.Invoke(user);
    //                            break;
    //                        case PumpingUpdateType.UPDATE:
    //                            UserUpdated?.Invoke(user);
    //                            break;
    //                        case PumpingUpdateType.CHANGE_GROUP:
    //                            UserChangeGroup?.Invoke(user);
    //                            break;
    //                    }
    //                }
    //                break;
    //            case PumpingNotificationCode.UPDATE_ONLINE:
    //                if (dataInt != IntPtr.Zero)
    //                {
    //                    var login = dataInt.ToInt();
    //                    switch (type)
    //                    {
    //                        case PumpingUpdateType.ADD:
    //                            OnlineAdded?.Invoke(login);
    //                            break;
    //                        case PumpingUpdateType.REMOVE:
    //                            OnlineRemoved?.Invoke(login);
    //                            break;
    //                        default:
    //                            break;
    //                    }
    //                }
    //                break;
    //            case PumpingNotificationCode.UPDATE_BIDASK:
    //                {
    //                    BidAskUpdated?.Invoke();
    //                    break;
    //                }
    //            case PumpingNotificationCode.UPDATE_NEWS:
    //                break;
    //            case PumpingNotificationCode.UPDATE_NEWS_BODY:
    //                break;
    //            case PumpingNotificationCode.UPDATE_MAIL:
    //                break;
    //            case PumpingNotificationCode.UPDATE_TRADES:
    //                if (dataInt != IntPtr.Zero)
    //                {
    //                    var data = dataInt.ToStruct<NTradeRecord>();
    //                    var trade = data.ToEntity<NTradeRecord, TradeRecord>();

    //                    switch (type)
    //                    {
    //                        case PumpingUpdateType.ADD:
    //                            switch (trade.Cmd)
    //                            {
    //                                case TradeCommand.BALANCE:
    //                                    BalanceOperationCreated?.Invoke(trade);
    //                                    break;
    //                                case TradeCommand.CREDIT:
    //                                    CreditOperationCreated?.Invoke(trade);
    //                                    break;
    //                                default: TradeOperationOpened?.Invoke(trade); break;
    //                            }
    //                            break;
    //                        case PumpingUpdateType.REMOVE:
    //                            switch (trade.Cmd)
    //                            {
    //                                case TradeCommand.BALANCE:
    //                                    BalanceOperationCreated?.Invoke(trade);
    //                                    break;
    //                                case TradeCommand.CREDIT:
    //                                    CreditOperationCreated?.Invoke(trade);
    //                                    break;
    //                                default: TradeOperationClosed?.Invoke(trade); break;
    //                            }
    //                            break;
    //                        case PumpingUpdateType.UPDATE:
    //                            switch (trade.Cmd)
    //                            {
    //                                case TradeCommand.BALANCE:
    //                                    if (trade.Login == 0)
    //                                        BalanceOperationDeleted?.Invoke(trade);
    //                                    else
    //                                        BalanceOperationUpdated?.Invoke(trade);
    //                                    break;
    //                                case TradeCommand.CREDIT:
    //                                    if (trade.Login == 0)
    //                                        CreditOperationDeleted?.Invoke(trade);
    //                                    else
    //                                        CreditOperationUpdated?.Invoke(trade);
    //                                    break;
    //                                default:
    //                                    if (trade.Login == 0)
    //                                        TradeOperationDeleted?.Invoke(trade);
    //                                    else
    //                                        TradeOperationUpdated?.Invoke(trade);
    //                                    break;
    //                            }
    //                            break;
    //                    }
    //                }
    //                break;
    //            case PumpingNotificationCode.UPDATE_REQUESTS:
    //                break;
    //            case PumpingNotificationCode.UPDATE_PLUGINS:
    //                {
    //                    PluginsUpdated?.Invoke();
    //                    break;
    //                }
    //            case PumpingNotificationCode.UPDATE_ACTIVATION:
    //                {
    //                    ActivationUpdated?.Invoke();
    //                    break;
    //                }
    //            case PumpingNotificationCode.UPDATE_MARGINCALL:
    //                {
    //                    MarginCallUpdated?.Invoke();
    //                    break;
    //                }
    //            case PumpingNotificationCode.STOP_PUMPING:
    //                {
    //                    PumpingStopped?.Invoke();
                            
    //                    break;
    //                }
    //            case PumpingNotificationCode.PING:
    //                {
    //                    PumpingPing?.Invoke();
    //                    break;
    //                }
    //            case PumpingNotificationCode.UPDATE_NEWS_NEW:
    //                if (dataInt != IntPtr.Zero)
    //                {
    //                }
    //                break;
    //        }
    //    }
    //}
}