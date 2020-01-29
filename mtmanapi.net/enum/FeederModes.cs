namespace rox.mt4.api
{
    /// <summary>
    /// Feeder mode
    /// </summary>
    public enum FeederModes
    {
        /// <summary>
        /// Only quotes
        /// </summary>
        OnlyQuotes = 0,
        /// <summary>
        /// Only news
        /// </summary>
        OnlyNews = 1,
        /// <summary>
        /// Quotes and news
        /// </summary>
        QuotesAndNews = 2,
        /// <summary>
        /// Quotes or news
        /// </summary>
        QuotesOrNews = 3
    }
}
