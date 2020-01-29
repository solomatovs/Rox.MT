using System;

namespace rox.mt4.api
{
    /// <summary>
    /// Pumping Mode Flags to be used
	/// when calling PumpingSwitchEx method
    /// </summary>
    [Flags]
    public enum PumpingMode
    {
        //--- user flags
        /// <summary>
        /// No flags
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        /// do not send ticks
        /// </summary>
        HIDETICKS = 1,

        /// <summary>
        /// do not send news
        /// </summary>     
        HIDENEWS = 2,

        /// <summary>
        /// do not send mails
        /// </summary> 
        HIDEMAIL = 4,

        /// <summary>
        /// send news body with news header in pumping mode
        /// </summary> 
        SENDFULLNEWS = 8,

        /// <summary>
        /// reserved
        /// </summary> 
        RESERVED = 16,

        //--- manager flags

        /// <summary>
        /// do not send online users table
        /// </summary> 
        HIDEONLINE = 32,

        /// <summary>
        /// do not send users table
        /// </summary> 
        HIDEUSERS = 64
    }
}