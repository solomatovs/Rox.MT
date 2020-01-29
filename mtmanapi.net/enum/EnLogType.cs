namespace rox.mt4.api
{
    public enum EnLogType
    {
        STANDARD = 0,    // all except logins
        LOGINS = 1,    // logins only
        TRADES = 2,    // trades only
        ERRORS = 3,    // errors
        FULL = 4,    // full log
                              //---
        UPDATER = 16,   // live update
        SENDMAIL = 17,   // send mail
        FAILOVER = 18    // failover
    }
}