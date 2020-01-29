using System;

namespace rox.mt4.api
{
    [Flags]
    public enum PumpingFlags
    {
        HIDE_TICKS = 1,
        HIDE_NEWS = 2,
        HIDE_MAIL = 4,
        SEND_FULL_NEWS = 8,
        HIDE_ONLINE = 32,
        HIDE_USERS = 64
    }
}
