namespace rox.mt4.api
{
    /// <summary>
    /// Group operation command type
    /// </summary>
    public enum GroupCommands : sbyte
    {
        /// <summary>
        /// Delete users
        /// </summary>
        DELETE,
        /// <summary>
        /// Enable users
        /// </summary>
        ENABLE,
        /// <summary>
        /// Disable users
        /// </summary>
        DISABLE,
        /// <summary>
        /// Change leverage
        /// </summary>
        LEVERAGE,
        /// <summary>
        /// Set group
        /// </summary>
        SETGROUP
    }
}