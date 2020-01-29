using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpGet]
        public async Task<List<BackupInfo>> BackupInfoUsers(BackupMode mode, int codePage)
        {
            return await Task.Run(() => manager.BackupInfoUsers(mode, codePage));
        }

        [HttpGet]
        public async Task<List<BackupInfo>> BackupInfoOrders(BackupMode mode, int codePage)
        {
            return await Task.Run(() => manager.BackupInfoOrders(mode, codePage));
        }

        [HttpGet]
        public async Task<List<UserRecord>> BackupRequestUsers(string file, params string[] request)
        {
            return await Task.Run(() => manager.BackupRequestUsers(file, request));
        }

        [HttpGet]
        public async Task<List<TradeRecord>> BackupRequestOrders(string file, params string[] request)
        {
            return await Task.Run(() => manager.BackupRequestOrders(file, request));
        }

        [HttpPost]
        public async Task BackupRestoreUsers([FromBody] IEnumerable<UserRecord> users)
        {
            if (users == null)
                throw new ArgumentNullException(nameof(users));

            await Task.Run(() => manager.BackupRestoreUsers(users.ToArray()));
        }

        [HttpPost]
        public async Task<List<TradeRestoreResult>> BackupRestoreOrders(int codePage, params int[] orders)
        {
            if (orders == null || orders.Length <= 0)
                throw new ArgumentNullException(nameof(orders));

            return await Task.Run(() => manager.BackupRestoreOrders(orders, codePage));
        }
    }
}