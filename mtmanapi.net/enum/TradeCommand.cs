namespace rox.mt4.api
{
    /// <summary>
    /// Trade command type
    /// </summary>
    public enum TradeCommand
    {
        BUY = 0,
        SELL = 1,
        BUY_LIMIT = 2,
        SELL_LIMIT = 3,
        BUY_STOP = 4,
        SELL_STOP = 5,
        BALANCE = 6,
        CREDIT = 7
    }
}