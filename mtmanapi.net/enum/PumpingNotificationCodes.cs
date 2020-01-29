namespace rox.mt4.api
{
    /// <summary>
    /// Pumping notification codes send in Pumping Mode
    /// </summary>
    public enum PumpingNotificationCode
    {
        /// <summary>
        /// Pumping started
        /// </summary>
        START_PUMPING = 0,
        /// <summary>
        /// Update symbols
        /// </summary>
        UPDATE_SYMBOLS,
        /// <summary>
        /// Update groups
        /// </summary>
        UPDATE_GROUPS,
        /// <summary>
        /// Update users
        /// </summary>
        UPDATE_USERS,
        /// <summary>
        /// Update online users
        /// </summary>
        UPDATE_ONLINE,
        /// <summary>
        /// Update bid/ask
        /// </summary>
        UPDATE_BIDASK,
        /// <summary>
        /// Update news
        /// </summary>
        UPDATE_NEWS,
        /// <summary>
        /// Update news body
        /// </summary>
        UPDATE_NEWS_BODY,
        /// <summary>
        /// Update mails
        /// </summary>
        UPDATE_MAIL,
        /// <summary>
        /// Update trades
        /// </summary>
        UPDATE_TRADES,
        /// <summary>
        /// Update trade requests
        /// </summary>
        UPDATE_REQUESTS,
        /// <summary>
        /// Update server plugins
        /// </summary>
        UPDATE_PLUGINS,
        /// <summary>
        /// New order for activation (sl/sp/stopout)
        /// </summary>
        UPDATE_ACTIVATION,
        /// <summary>
        /// New margin calls
        /// </summary>
        UPDATE_MARGINCALL,
        /// <summary>
        /// Pumping stopped
        /// </summary>
        STOP_PUMPING,
        /// <summary>
        /// Ping
        /// </summary>
        PING,
        /// <summary>
        /// Update news in new format (NewsTopicNew structure)
        /// </summary>
        UPDATE_NEWS_NEW
    }
}