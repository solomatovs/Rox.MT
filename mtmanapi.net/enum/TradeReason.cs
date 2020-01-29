namespace rox.mt4.api
{
    /// <summary>
    /// Trade reason
    /// </summary>
    public enum TradeReason : byte
    {
        /// <summary>
        /// client terminal
        /// </summary>
        CLIENT = 0,
        /// <summary>
        /// expert
        /// </summary>
        EXPERT = 1,
        /// <summary>
        /// dealer
        /// </summary>
        DEALER = 2,
        /// <summary>
        /// signal
        /// </summary>
        SIGNAL = 3,
        /// <summary>
        /// gateway
        /// </summary>
        GATEWAY = 4,
        /// <summary>
        /// mobile terminal
        /// </summary>
        MOBILE = 5,
        /// <summary>
        /// Web terminal
        /// </summary>
        WEB = 6,
        /// <summary>
        /// API
        /// </summary>
        API = 7,
    }
}