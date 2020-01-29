using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpGet]
        public async Task<List<UserRecord>> AdmUsersRequest(string groupsOrLogins, int codePage)
        {
            if (string.IsNullOrWhiteSpace(groupsOrLogins))
                throw new ArgumentNullException(nameof(groupsOrLogins), $"please enter the account group for 'AdmUsersRequest'");

            return await Task.Run(() => manager.AdmUsersRequest(groupsOrLogins, codePage));
        }

        [HttpGet]
        public async Task<List<BalanceDiff>> AdmBalanceCheck(int codePage, [FromQuery] [FromBody] params int[] logins)
        {
            if (logins == null || logins.Count() <= 0)
                throw new ArgumentNullException(nameof(logins), $"please enter 'logins' for check balance");

            return await Task.Run(() => manager.AdmBalanceCheck(logins, codePage));
        }

        [HttpPost]
        public async Task AdmBalanceFix([FromQuery] [FromBody] params int[] logins)
        {
            if (logins == null || logins.Count() <= 0)
                throw new ArgumentNullException(nameof(logins), $"please enter 'logins' for fix balance");

            await Task.Run(() => manager.AdmBalanceFix(logins));
        }

        [HttpGet]
        public async Task<List<UserRecord>> UsersRequest(int codePage)
        {
            return await Task.Run(() => manager.UsersRequest(codePage));
        }

        [HttpGet]
        public async Task<List<UserRecord>> UserRecordsRequest(int codePage, [FromQuery] [FromBody] params Int32[] logins)
        {
            if (logins == null || logins.Count() <= 0)
                throw new ArgumentNullException(nameof(logins), $"please enter 'logins' for request");

            return await Task.Run(() => manager.UserRecordsRequest(logins, codePage));
        }

        [HttpPost]
        public async Task<UserRecord> UserRecordNew([FromBody] UserRecord user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "please enter 'Group' and 'Name'");
            if (string.IsNullOrWhiteSpace(user.Group))
                throw new ArgumentNullException(nameof(user.Group), "please enter 'Group'");
            if (string.IsNullOrWhiteSpace(user.Name))
                throw new ArgumentNullException(nameof(user.Name), "please enter 'Name'");

            return await Task.Run(() => manager.UserRecordNew(user));
        }

        [HttpPost]
        public async Task<IEnumerable<KeyValuePair<UserRecord, string>>> UserRecordsNew([FromBody] params UserRecord[] users)
        {
            return await Task.Run(() => manager.UserRecordsNew(users));
        }

        [HttpPost]
        public async Task UserRecordUpdate([FromBody] UserRecord user)
        {
            //var login_key = "login";

            //if (user == null)
            //    throw new ArgumentNullException(nameof(user), $"Please enter '{login_key}'");
            
            //if (user.Login <= 0)
            //    throw new ArgumentNullException(login_key, $"Please enter '{login_key}' > 0");

            //var keys = HttpContext.Request.Query.Select(p => p.Key.ToLower()).ToList();
            //var type = typeof(UserRecord);
            //var props = type
            //    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            //    .Where(p => keys.Contains(p.Name.ToLower()))
            //    .ToList();

            //var record = manager.UserRequest(user.Login, user.CodePage);
            //if (record == null)
            //    throw new ArgumentNullException(login_key, $"Login {user.Login} not found");

            //foreach (var prop in props)
            //    prop.SetValue(record, prop.GetValue(user));

            await Task.Run(() => manager.UserRecordUpdate(user));
        }

        public class UserGroupOpRequest
        {
            public GroupCommandInfo Info { get; set; }
            public int[] Logins { get; set; }
        }
        [HttpPost]
        public async Task UsersGroupOp([FromBody] UserGroupOpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Info == null)
                throw new ArgumentNullException(nameof(request.Info));

            if (request.Logins == null || request.Logins.Count() <= 0)
                throw new ArgumentNullException(nameof(request.Logins));

            request.Info.Length = request.Logins.Count();

            await Task.Run(() => manager.UsersGroupOp(request.Info, request.Logins));
        }

        [HttpGet]
        public async Task UserPasswordCheck(int login, string password)
        {
            await Task.Run(() => manager.UserPasswordCheck(login, password));
        }

        [HttpPost]
        public async Task UserPasswordSet(int login, string password, bool change_investor = false, bool clean_pubkey = false)
        {
            await Task.Run(() => manager.UserPasswordSet(login, password, change_investor, clean_pubkey));
        }

        #region pumping
        [HttpGet]
        public async Task<List<UserRecord>> UsersGet(int codePage)
        {
            return await Task.Run(() => manager.UsersGet(codePage));
        }

        [HttpGet]
        public async Task<UserRecord> UserRecordGet(int login, int codePage)
        {
            return await Task.Run(() => manager.UserRecordGet(login, codePage));
        }
        #endregion

        [HttpGet]
        public async Task<int[]> UsersSnapshot()
        {
            return await Task.Run(() => manager.UsersSnapshot());
        }
    }
}