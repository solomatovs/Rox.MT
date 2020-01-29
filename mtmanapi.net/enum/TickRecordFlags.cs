using System;

namespace rox.mt4.api
{
    /// <summary>
    /// Tick record flag
    /// </summary>
    [Flags]
    public enum TickRecordFlags : sbyte
    {
        /// <summary>
        /// Raw
        /// </summary>
        RAW = 1,
        /// <summary>
        /// Normal
        /// </summary>
        NORMAL = 2,
        /// <summary>
        /// All
        /// </summary>
        ALL = RAW | NORMAL
    }
}