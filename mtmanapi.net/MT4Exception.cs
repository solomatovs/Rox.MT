using System;

namespace rox.mt4.api
{
    /// <summary>
    /// Базовый Exception при работе с rox.mt4.api
    /// </summary>
    public class MT4Exception : Exception
    {
        public MT4Exception() : base() { }
        public MT4Exception(string message) : base(message: message) { }
        public MT4Exception(string message, Exception innerException) : base(message: message, innerException: innerException) { }
    }

    public class MT4RequestNotCorrespondException : MT4Exception
    {
        public MT4RequestNotCorrespondException(string nameFunction, MT4Mode currentMode, params MT4Mode[] avaliableMode) : base($"'{nameFunction}' not correspond mode {currentMode}. To call the function, go to the mode {string.Join(", ", avaliableMode)}")
        { }
    }
    public class MT4FunctionNotFoundException : MT4Exception
    {
        public string NameFunction { get; }
        public MT4FunctionNotFoundException(string nameFunction) : base($"MT4 function '{nameFunction}' not found in dll")
        { }
    }
    /// <summary>
    /// Исключение вызывается в случае прихода ошибки по операции совершаемой на стороне МТ4 сервера
    /// МТ4 сервере возвращает код. отличный от нуля, который можно посмотреть в переменной code
    /// </summary>
    public class MT4ServerException : MT4Exception
    {
        /// <summary>
        /// Код ошибки, который вернул МТ4 сервер
        /// </summary>
        public ResultCode Code { get; }

        /// <summary>
        /// Конструктор принимает только текст ошибки от МТ4 сервера
        /// </summary>
        /// <param name="message"></param>
        public MT4ServerException(MT4Interface MT4Interface, ResultCode code) : base(MT4Interface.ErrorDescription(code)) { this.Code = code; }
        /// <summary>
        /// Конструктор принимает текст ошибки и исключение
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cause"></param>
        public MT4ServerException(MT4Interface MT4Interface, ResultCode code, Exception cause) : base(MT4Interface.ErrorDescription(code), cause) { this.Code = code; }
    }

    public class MT4CommonErrorExeption : MT4ServerException
    {
        public MT4CommonErrorExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.GENERAL_ERROR) { }
    }
    public class MT4InvalidDataExeption : MT4ServerException
    {
        public MT4InvalidDataExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.INVALID_DATA) { }
    }
    public class MT4TechProblemExeption : MT4ServerException
    {
        public MT4TechProblemExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TECH_PROBLEM) { }
    }
    public class MT4OldVersionExeption : MT4ServerException
    {
        public MT4OldVersionExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.OLD_VERSION) { }
    }
    public class MT4NoConnectionExeption : MT4ServerException
    {
        public MT4NoConnectionExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.NO_CONNECTION) { }
    }
    public class MT4NotEnoughRightsExeption : MT4ServerException
    {
        public MT4NotEnoughRightsExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.NOT_ENOUGH_RIGHTS) { }
    }
    public class MT4TooFrequentExeption : MT4ServerException
    {
        public MT4TooFrequentExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TOO_FREQUENT) { }
    }
    public class MT4MalfunctionExeption : MT4ServerException
    {
        public MT4MalfunctionExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.MALFUNCTION) { }
    }
    public class MT4GenerateKeyExeption : MT4ServerException
    {
        public MT4GenerateKeyExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.GENERATE_KEY) { }
    }
    public class MT4SecuritySessionExeption : MT4ServerException
    {
        public MT4SecuritySessionExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.SECURITY_SESSION) { }
    }
    public class MT4AccountDisabledExeption : MT4ServerException
    {
        public MT4AccountDisabledExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.ACCOUNT_DISABLED) { }
    }
    public class MT4BadAccountInfoExeption : MT4ServerException
    {
        public MT4BadAccountInfoExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.BAD_ACCOUNT_INFO) { }
    }
    public class MT4PublicKeyMissingExeption : MT4ServerException
    {
        public MT4PublicKeyMissingExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.PUBLIC_KEY_MISSING) { }
    }
    public class MT4TradeTimeoutExeption : MT4ServerException
    {
        public MT4TradeTimeoutExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TRADE_TIMEOUT) { }
    }
    public class MT4TradeBadPricesExeption : MT4ServerException
    {
        public MT4TradeBadPricesExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TRADE_BAD_PRICES) { }
    }
    public class MT4TradeBadStopsExeption : MT4ServerException
    {
        public MT4TradeBadStopsExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TRADE_BAD_STOPS) { }
    }
    public class MT4TradeBadVolumeExeption : MT4ServerException
    {
        public MT4TradeBadVolumeExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TRADE_BAD_VOLUME) { }
    }
    public class MT4TradeMarketClosedExeption : MT4ServerException
    {
        public MT4TradeMarketClosedExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TRADE_MARKET_CLOSED) { }
    }
    public class MT4TradeDisableExeption : MT4ServerException
    {
        public MT4TradeDisableExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TRADE_DISABLE) { }
    }
    public class MT4TradeNoMoneyExeption : MT4ServerException
    {
        public MT4TradeNoMoneyExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TRADE_NO_MONEY) { }
    }
    public class MT4TradePriceChangedExeption : MT4ServerException
    {
        public MT4TradePriceChangedExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TRADE_PRICE_CHANGED) { }
    }
    public class MT4TradeOffquotesExeption : MT4ServerException
    {
        public MT4TradeOffquotesExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TRADE_OFFQUOTES) { }
    }
    public class MT4TradeBrokerBusyExeption : MT4ServerException
    {
        public MT4TradeBrokerBusyExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TRADE_BROKER_BUSY) { }
    }
    public class MT4TradeRequoteExeption : MT4ServerException
    {
        public MT4TradeRequoteExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TRADE_REQUOTE) { }
    }
    public class MT4TradeOrderLockedExeption : MT4ServerException
    {
        public MT4TradeOrderLockedExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TRADE_ORDER_LOCKED) { }
    }
    public class MT4TradeLongOnlyExeption : MT4ServerException
    {
        public MT4TradeLongOnlyExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TRADE_LONG_ONLY) { }
    }
    public class MT4TradeTooManyReqExeption : MT4ServerException
    {
        public MT4TradeTooManyReqExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TRADE_TOO_MANY_REQ) { }
    }
    public class MT4TradeAcceptedExeption : MT4ServerException
    {
        public MT4TradeAcceptedExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TRADE_ACCEPTED) { }
    }
    public class MT4TradeProcessExeption : MT4ServerException
    {
        public MT4TradeProcessExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TRADE_PROCESS) { }
    }
    public class MT4TradeUserCancelExeption : MT4ServerException
    {
        public MT4TradeUserCancelExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TRADE_USER_CANCEL) { }
    }
    public class MT4TradeRModifyDeniedExeption : MT4ServerException
    {
        public MT4TradeRModifyDeniedExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TRADE_MODIFY_DENIED) { }
    }
    public class MT4TradeContextBusyExeption : MT4ServerException
    {
        public MT4TradeContextBusyExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TRADE_CONTEXT_BUSY) { }
    }
    public class MT4TradeExpirationDeniedExeption : MT4ServerException
    {
        public MT4TradeExpirationDeniedExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TRADE_EXPIRATION_DENIED) { }
    }
    public class MT4TradeTooManyOrdersExeption : MT4ServerException
    {
        public MT4TradeTooManyOrdersExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TRADE_TOO_MANY_ORDERS) { }
    }
    public class MT4TradeHedgeProhibitedExeption : MT4ServerException
    {
        public MT4TradeHedgeProhibitedExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TRADE_HEDGE_PROHIBITED) { }
    }
    public class MT4TradeHedgeProhibitedByFifoExeption : MT4ServerException
    {
        public MT4TradeHedgeProhibitedByFifoExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.TRADE_PROHIBITED_BY_FIFO) { }
    }
    public class MT4NetworkProblemExeption : MT4ServerException
    {
        public MT4NetworkProblemExeption(MT4Interface MT4Interface) : base(MT4Interface, ResultCode.NETWORK_PROBLEM) { }
    }


    /// <summary>
    /// Статические методы для работы с исключениями в MT4 Wrapper
    /// </summary>
    public static class MT4ServerExceptionExtension
    {
        /// <summary>
        /// Преобразует код ответа от МТ4 сервера в исключение, если данный код носит харрактер ошибки
        /// В случае если код это не ошибка, то возвращает null
        /// В случае если был передан код ошибки, которого нет в enum ResultCode, то будет сгенерировано исключение базового типа MT4ServerException с данным кодом, а в сообщении исключения будет содержаться описание ошибки, которое вернул МТ4 сервер на данный код
        /// </summary>
        /// <param name="MT4Interface"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static MT4ServerException ToException(this MT4Interface MT4Interface, ResultCode code)
        {
            MT4ServerException exeption = null;

            switch (code)
            {
                case ResultCode.OK:
                case ResultCode.OK_NONE: exeption = null; break;

                case ResultCode.GENERAL_ERROR: exeption = new MT4CommonErrorExeption(MT4Interface); break;
                case ResultCode.INVALID_DATA: exeption = new MT4InvalidDataExeption(MT4Interface); break;
                case ResultCode.TECH_PROBLEM: exeption = new MT4TechProblemExeption(MT4Interface); break;
                case ResultCode.OLD_VERSION: exeption = new MT4OldVersionExeption(MT4Interface); break;
                case ResultCode.NO_CONNECTION: exeption = new MT4NoConnectionExeption(MT4Interface); break;
                case ResultCode.NOT_ENOUGH_RIGHTS: exeption = new MT4NotEnoughRightsExeption(MT4Interface); break;
                case ResultCode.TOO_FREQUENT: exeption = new MT4TooFrequentExeption(MT4Interface); break;
                case ResultCode.MALFUNCTION: exeption = new MT4MalfunctionExeption(MT4Interface); break;
                case ResultCode.GENERATE_KEY: exeption = new MT4GenerateKeyExeption(MT4Interface); break;
                case ResultCode.SECURITY_SESSION: exeption = new MT4SecuritySessionExeption(MT4Interface); break;
                case ResultCode.ACCOUNT_DISABLED: exeption = new MT4AccountDisabledExeption(MT4Interface); break;
                case ResultCode.BAD_ACCOUNT_INFO: exeption = new MT4BadAccountInfoExeption(MT4Interface); break;
                case ResultCode.PUBLIC_KEY_MISSING: exeption = new MT4PublicKeyMissingExeption(MT4Interface); break;
                case ResultCode.TRADE_TIMEOUT: exeption = new MT4TradeTimeoutExeption(MT4Interface); break;
                case ResultCode.TRADE_BAD_PRICES: exeption = new MT4TradeBadPricesExeption(MT4Interface); break;
                case ResultCode.TRADE_BAD_STOPS: exeption = new MT4TradeBadStopsExeption(MT4Interface); break;
                case ResultCode.TRADE_BAD_VOLUME: exeption = new MT4TradeBadVolumeExeption(MT4Interface); break;
                case ResultCode.TRADE_MARKET_CLOSED: exeption = new MT4TradeMarketClosedExeption(MT4Interface); break;
                case ResultCode.TRADE_DISABLE: exeption = new MT4TradeDisableExeption(MT4Interface); break;
                case ResultCode.TRADE_NO_MONEY: exeption = new MT4TradeNoMoneyExeption(MT4Interface); break;
                case ResultCode.TRADE_PRICE_CHANGED: exeption = new MT4TradePriceChangedExeption(MT4Interface); break;
                case ResultCode.TRADE_OFFQUOTES: exeption = new MT4TradeOffquotesExeption(MT4Interface); break;
                case ResultCode.TRADE_BROKER_BUSY: exeption = new MT4TradeContextBusyExeption(MT4Interface); break;
                case ResultCode.TRADE_REQUOTE: exeption = new MT4TradeRequoteExeption(MT4Interface); break;
                case ResultCode.TRADE_ORDER_LOCKED: exeption = new MT4TradeOrderLockedExeption(MT4Interface); break;
                case ResultCode.TRADE_LONG_ONLY: exeption = new MT4TradeLongOnlyExeption(MT4Interface); break;
                case ResultCode.TRADE_TOO_MANY_REQ: exeption = new MT4TradeTooManyReqExeption(MT4Interface); break;
                case ResultCode.TRADE_ACCEPTED: exeption = new MT4TradeAcceptedExeption(MT4Interface); break;
                case ResultCode.TRADE_PROCESS: exeption = new MT4TradeProcessExeption(MT4Interface); break;
                case ResultCode.TRADE_USER_CANCEL: exeption = new MT4TradeUserCancelExeption(MT4Interface); break;
                case ResultCode.TRADE_MODIFY_DENIED: exeption = new MT4TradeRModifyDeniedExeption(MT4Interface); break;
                case ResultCode.TRADE_CONTEXT_BUSY: exeption = new MT4TradeContextBusyExeption(MT4Interface); break;
                case ResultCode.TRADE_EXPIRATION_DENIED: exeption = new MT4TradeExpirationDeniedExeption(MT4Interface); break;
                case ResultCode.TRADE_TOO_MANY_ORDERS: exeption = new MT4TradeTooManyOrdersExeption(MT4Interface); break;
                case ResultCode.TRADE_HEDGE_PROHIBITED: exeption = new MT4TradeHedgeProhibitedExeption(MT4Interface); break;
                case ResultCode.TRADE_PROHIBITED_BY_FIFO: exeption = new MT4TradeHedgeProhibitedByFifoExeption(MT4Interface); break;
                case ResultCode.NETWORK_PROBLEM: exeption = new MT4NetworkProblemExeption(MT4Interface); break;

                default: exeption = new MT4ServerException(MT4Interface, code); break;
            }

            return exeption;
        }

        /// <summary>
        /// Выбрасывает исключение в случае если переданный код является ошибкой
        /// </summary>
        /// <param name="MT4Interface"></param>
        /// <param name="code"></param>
        public static void ThrowIfError(this MT4Interface MT4Interface, ResultCode code)
        {
            var exception = MT4Interface.ToException(code);
            if (exception != null)
            {
                throw exception;
            }
        }
    }
}
