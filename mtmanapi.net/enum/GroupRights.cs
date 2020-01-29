using System;

namespace rox.mt4.api
{
    /// <summary>
    /// Group rights
    /// </summary>
    [Flags]
    public enum GroupRights
    {
        /// <summary>
        /// Email
        /// </summary>
        Email = 1,
        /// <summary>
        /// Trailing
        /// </summary>
        Trailing = 2,
        /// <summary>
        /// Advisor
        /// </summary>
        Advisor = 4,
        /// <summary>
        /// Expiration
        /// </summary>
        Expiration = 8,
        /// <summary>
        /// All signals
        /// </summary>
        SignalsAll = 16,
        /// <summary>
        /// Own signals
        /// </summary>
        SignalsOwn = 32,
        /// <summary>
        /// Risk warning
        /// </summary>
        RiskWarning = 64,
        /// <summary>
        /// Forced OTP usage
        /// </summary>
        AllowFlagForcedOtpUsage = 128,
    }
}