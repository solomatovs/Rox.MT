namespace rox.mt4.api
{
    /// <summary>
    /// Backup mode
    /// </summary>
    public enum BackupMode
    {
        /// <summary>
        /// All backup
        /// </summary>
        ALL,
        /// <summary>
        /// Periodical backups
        /// </summary>
        PERIODICAL,
        /// <summary>
        /// Backups on startup
        /// </summary>
        STARTUP,
        /// <summary>
        /// Backups on delete
        /// </summary>
        DELETE
    };
}