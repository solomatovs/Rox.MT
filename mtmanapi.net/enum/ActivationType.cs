namespace rox.mt4.api
{
    /// <summary>
    /// Activation type
    /// </summary>
    public enum ActivationType
    {
        /// <summary>
        /// None
        /// </summary>
        NONE = 0,
        /// <summary>
        /// Stop Loss
        /// </summary>
        SL,
        /// <summary>
        /// Take Profit
        /// </summary>
        TP,
        /// <summary>
        /// Pending order activation
        /// </summary>
        PENDING,
        /// <summary>
        /// Stopout
        /// </summary>
        STOPOUT,
        /// <summary>
        /// SL rollback
        /// </summary>
        SL_ROLLBACK = -SL,
        /// <summary>
        /// TP rollback
        /// </summary>
        TP_ROLLBACK = -TP,
        /// <summary>
        /// Pending rollback
        /// </summary>
        PENDING_ROLLBACK = -PENDING,
        /// <summary>
        /// Stopout rollback
        /// </summary>
        STOPOUT_ROLLBACK = -STOPOUT
    }
}