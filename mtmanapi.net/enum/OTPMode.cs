namespace rox.mt4.api
{
    /// <summary>
    /// One-Time password mode
    /// </summary>
    public enum OTPMode
    {
        /// <summary>
        /// Disabled
        /// </summary>
        Disabled = 0,

        /// <summary>
        /// Sha256 mode
        /// </summary>
        TotpSha256 = 1,
    }
}