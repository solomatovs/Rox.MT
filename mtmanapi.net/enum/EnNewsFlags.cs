using System;

namespace rox.mt4.api
{
    /// <summary>
    /// News topic Flags
    /// </summary>
    [Flags]
    public enum EnNewsFlags : UInt32
    {
        /// <summary>
        /// Priority flag
        /// </summary>
        Priority = 1,
        /// <summary>
        /// Calendar item flag
        /// </summary>
        Calendar = 2,
        /// <summary>
        /// Mime news content
        /// </summary>
        Mime = 4,
        /// <summary>
        /// Allow Body for demo accounts
        /// </summary>
        AllowDemo = 8
    };
}