namespace rox.mt4.api
{
    /// <summary>
    /// Auto closeout method
    /// </summary>
    public enum AutoCloseOutMethod
    {
        /// <summary>
        /// None
        /// </summary>
        None,
        /// <summary>
        ///High High
        /// </summary>
        HiHi,
        /// <summary>
        /// Low Low
        /// </summary>
        LoLo,
        /// <summary>
        /// High Low
        /// </summary>
        HiLo,
        /// <summary>
        /// Low High
        /// </summary>
        LoHi,
        /// <summary>
        /// First in First out
        /// </summary>
        FiFo,
        /// <summary>
        /// Last in First out
        /// </summary>
        LiFo,
        /// <summary>
        /// Intraday First in First out
        /// </summary>
        IntradayFiFo
    }
}