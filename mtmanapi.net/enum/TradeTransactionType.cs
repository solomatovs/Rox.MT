namespace rox.mt4.api
{
    /// <summary>
    /// Trade transaction type
    /// </summary>
    public enum TradeTransactionType : byte
    {
        /// <summary>
        /// Prices requets
        /// </summary>
        PRICES_GET,
        /// <summary>
        /// Requote
        /// </summary>
        PRICES_REQUOTE,
        /// <summary>
        /// Open order (Instant Execution)
        /// </summary>
        ORDER_IE_OPEN = 64,
        /// <summary>
        /// Open order (Request Execution)
        /// </summary>
        ORDER_REQUEST_OPEN,
        /// <summary>
        /// Open order (Market Execution)
        /// </summary>
        ORDER_MARKET_OPEN,
        /// <summary>
        /// Open pending order
        /// </summary>
        ORDER_PENDING_OPEN,
        /// <summary>
        /// Close order (Instant Execution)
        /// </summary>
        ORDER_IE_CLOSE,
        /// <summary>
        /// Close order (Request Execution)
        /// </summary>
        ORDER_REQUEST_CLOSE,
        /// <summary>
        /// Close order (Market Execution)
        /// </summary>
        ORDER_MARKET_CLOSE,
        /// <summary>
        /// Modify pending order
        /// </summary>
        ORDER_MODIFY,
        /// <summary>
        /// Delete pending order
        /// </summary>
        ORDER_DELETE,
        /// <summary>
        /// Close order by order
        /// </summary>
        ORDER_CLOSE_BY,
        /// <summary>
        /// Close all orders by symbol
        /// </summary>
        ORDER_CLOSE_ALL,
        /// <summary>
        /// Open order
        /// </summary>
        BROKER_ORDER_OPEN,
        /// <summary>
        /// Close order
        /// </summary>
        BROKER_ORDER_CLOSE,
        /// <summary>
        /// Delete order (ANY OPEN ORDER!!!)
        /// </summary>
        BROKER_ORDER_DELETE,
        /// <summary>
        /// Close order by order
        /// </summary>
        BROKER_ORDER_CLOSE_BY,
        /// <summary>
        /// Close all orders by symbol
        /// </summary>
        BROKER_ORDER_CLOSE_ALL,
        /// <summary>
        /// Modify open price, stoploss, takeprofit etc. of order
        /// </summary>
        BROKER_ORDER_MODIFY,
        /// <summary>
        /// Activate pending order
        /// </summary>
        BROKER_ORDER_ACTIVATE,
        /// <summary>
        /// Modify comment of order
        /// </summary>
        BROKER_ORDER_COMMENT,
        /// <summary>
        /// Balance credit
        /// </summary>
        BROKER_BALANCE
    }
}