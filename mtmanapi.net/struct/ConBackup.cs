using System;
using System.Runtime.InteropServices;

namespace rox.mt4.api
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct NConBackup
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] fullBackupPath;
        public Int32 fullBackupPeriod;
        public Int32 fullBackupStore;
        public UInt32 fullBackupLastTime;
        public Int16 fullBackupShift;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] externalPath;
        public Int32 archivePeriod;
        public Int32 archiveStore;
        public UInt32 archiveLastTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] exportSecurities;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] exportPath;
        public Int32 exportPeriod;
        public UInt32 exportLastTime;
        public Int32 watchRole;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] watchPassword;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        public byte[] watchOpposite;
        public Int32 watchIp;
        public byte archiveShift;
        public byte watchState;
        public byte watchFailover;
        public sbyte watchTimeout;
        public Int32 watchLogin;
        public UInt32 watchTimestamp;
    }

    /// <summary>
    /// Object that represents backup configuration
    /// </summary>
    public class ConBackup : MT4Model<NConBackup>
    {
        public ConBackup(int codePage) : base(codePage) { }
        /// <summary>
        /// Path to backup
        /// </summary>
        public string FullBackupPath
        {
            get { return AnsiBytesToString(native.fullBackupPath); }
            set { native.fullBackupPath = StringToAnsiBytes(value, 256); }
        }

        /// <summary>
        /// Full backup's period-BACKUP_1HOUR, BACKUP_4HOURS, BACKUP_1DAY
        /// </summary>
        public FullBackupExecutionPeriod FullBackupPeriod
        {
            get { return (FullBackupExecutionPeriod) native.fullBackupPeriod; }
            set { native.fullBackupPeriod = (Int32) value; }
        }

        /// <summary>
        /// Full backup's store time-BU_STORE_1MONTH, BU_STORE_3MONTHS, BU_STORE_6MONTHS,BU_STORE_1YEAR
        /// </summary>
        public FullBackupStorePeriod FullBackupStore
        {
            get { return (FullBackupStorePeriod) native.fullBackupStore; }
            set { native.fullBackupStore = (Int32) value; }
        }

        /// <summary>
        /// Full backup's last execution time
        /// </summary>
        public DateTime FullBackupLastTime
        {
            get { return native.fullBackupLastTime.ToDateTime();  }
            set { native.fullBackupLastTime = value.ToUInt(); }
        }

        /// <summary>
        /// Full backup timeshift in minutes
        /// </summary>
        public short FullBackupShift
        {
            get { return native.fullBackupShift; }
            set { native.fullBackupShift = value; }
        }

        /// <summary>
        /// Path to external processing directory
        /// </summary>
        public string ExternalPath
        {
            get { return AnsiBytesToString(native.externalPath); }
            set { native.externalPath = StringToAnsiBytes(value, 256); }
        }

        /// <summary>
        /// Period of archive backup-ARC_BACKUP_5MIN, ARC_BACKUP_15MIN, ARC_BACKUP_30MIN, ARC_BACKUP_1HOUR
        /// </summary>
        public ArchiveBackupExecutionPeriod ArchivePeriod
        {
            get { return (ArchiveBackupExecutionPeriod) native.archivePeriod; }
            set { native.archivePeriod = (Int32) value; }
        }

        /// <summary>
        /// Archive backup's store time-ARC_STORE_1WEEK, ARC_STORE_2WEEKS, ARC_STORE_1MONTH, ARC_STORE_3MONTH, ARC_STORE_6MONTH
        /// </summary>
        public ArchiveBackupStorePeriod ArchiveStore
        {
            get { return (ArchiveBackupStorePeriod) native.archiveStore; }
            set { native.archiveStore = (Int32) value; }
        }

        /// <summary>
        /// Archive backup's last execution time
        /// </summary>
        public DateTime ArchiveLastTime
        {
            get { return native.archiveLastTime.ToDateTime(); }
            set { native.archiveLastTime = value.ToUInt(); }
        }

        /// <summary>
        /// Comma separated list of exported securities
        /// </summary>
        public string ExportSecurities
        {
            get { return AnsiBytesToString(native.exportSecurities); }
            set { native.exportSecurities = StringToAnsiBytes(value, 512); }
        }

        /// <summary>
        /// Path to export script
        /// </summary>
        public string ExportPath
        {
            get { return AnsiBytesToString(native.exportPath); }
            set { native.exportPath = StringToAnsiBytes(value, 256); }
        }

        /// <summary>
        /// Export period-enumeration EXPORT_1MIN, EXPORT_5MIN, EXPORT_15MIN, EXPORT_30MIN,EXPORT_1HOUR
        /// </summary>
        public ExportExecutionPeriod ExportPeriod
        {
            get { return (ExportExecutionPeriod) native.exportPeriod; }
            set { native.exportPeriod = (Int32)value; }
        }

        /// <summary>
        /// Export's last execution time
        /// </summary>
        public DateTime ExportLastTime
        {
            get { return native.exportLastTime.ToDateTime(); }
            set { native.exportLastTime = value.ToUInt(); }
        }

        /// <summary>
        /// Server role { WATCH_STAND_ALONE, WATCH_MASTER, WATCH_SLAVE }
        /// </summary>
        public ServerRole WatchRole
        {
            get { return (ServerRole)native.watchRole; }
            set { native.watchRole = (Int32) value; }
        }

        /// <summary>
        /// Slave server password
        /// </summary>
        public string WatchPassword
        {
            get { return AnsiBytesToString(native.watchPassword); }
            set { native.watchPassword = StringToAnsiBytes(value, 16); }
        }

        /// <summary>
        /// Opposite server IP address and port
        /// </summary>
        public string WatchOpposite
        {
            get { return AnsiBytesToString(native.watchOpposite); }
            set { native.watchOpposite = StringToAnsiBytes(value, 24); }
        }

        /// <summary>
        /// Shift of archive backup time in minutes
        /// </summary>
        public byte ArchiveShift
        {
            get { return native.archiveShift; }
            set { native.archiveShift = value; }
        }

        /// <summary>
        /// Watch dog state
        /// </summary>
        public byte WatchState
        {
            get { return native.watchState; }
            set { native.watchState = value; }
        }

        /// <summary>
        /// Watch dog failover mode
        /// </summary>
        public byte WatchFailover
        {
            get { return native.watchFailover; }
            set { native.watchFailover = value; }
        }

        /// <summary>
        /// Watch dog timeout
        /// </summary>
        public sbyte WatchTimeout
        {
            get { return native.watchTimeout; }
            set { native.watchTimeout = value; }
        }

        /// <summary>
        /// Watch dog login
        /// </summary>
        public Int32 WatchLogin
        {
            get { return native.watchLogin; }
            set { native.watchLogin = value; }
        }

        /// <summary>
        /// Watch dog timestamp
        /// </summary>
        public DateTime WatchTimestamp
        {
            get { return native.watchTimestamp.ToDateTime(); }
            set { native.watchTimestamp = value.ToUInt(); }
        }
    }
}