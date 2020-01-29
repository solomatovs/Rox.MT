namespace rox.mt4.api
{
    public enum EnErrLogTypes
    {
        CmdOK,                  // OK
        CmdTrade,               // trades only
        CmdLogin,               // logins only
        CmdWarn,                // warnings
        CmdErr,                 // errors
        CmdAtt                  // attention, important errors
    }
}