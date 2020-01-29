namespace rox.mt4.api
{
    /// <summary>
    /// Trade state
    /// </summary>
    public enum TradeState
    {
        /// <summary>
        /// Open normal
        /// </summary>
        OPEN_NORMAL,
        /// <summary>
        /// Open remand
        /// </summary>
        OPEN_REMAND,
        /// <summary>
        /// Open restored
        /// </summary>
        OPEN_RESTORED,
        /// <summary>
        /// Close normal
        /// </summary>
        CLOSED_NORMAL,
        /// <summary>
        /// Closed part
        /// </summary>
        CLOSED_PART,
        /// <summary>
        /// Closed by
        /// </summary>
        CLOSED_BY,
        /// <summary>
        /// Deleted
        /// </summary>
        DELETED
    }
}