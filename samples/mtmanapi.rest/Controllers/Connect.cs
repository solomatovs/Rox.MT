using System;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpGet]
        public bool IsConnected()
        {
            return manager.IsConnected();
        }

        [AllowAnonymous]
        [HttpPost]
        public string Login(MT4ConnectOption connect)
        {
            return tokenManager.GenerateNewToken(connect);
        }

        [HttpPost]
        public void Logout()
        {
            tokenManager.DeactivateCurrent(AuthorizationValues);
        }

        [HttpGet]
        public async Task Ping()
        {
            await Task.Run(() => manager.Ping());
        }

        [HttpPost]
        public async Task PasswordChange(string pass, bool is_investor)
        {
            await Task.Run(() => manager.PasswordChange(pass, is_investor));
        }

        [HttpGet]
        public async Task<ConManager> ManagerRights(int codePage)
        {
            return await Task.Run(() => manager.ManagerRights(codePage));
        }
    }
}