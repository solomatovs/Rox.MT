namespace rox.mt4.api
{
    /// <summary>
    /// Trade request status
    /// </summary>
    public enum TradeRequestStatus : byte
    {
        /// <summary>
        /// Empty
        /// </summary>
        EMPTY,
        /// <summary>
        /// Request
        /// </summary>
        REQUEST,
        /// <summary>
        /// Locked
        /// </summary>
        LOCKED,
        /// <summary>
        /// Answered
        /// </summary>
        ANSWERED,
        /// <summary>
        /// Reseted
        /// </summary>
        RESETED,
        /// <summary>
        /// Cancelled
        /// </summary>
        CANCELED
    }
}