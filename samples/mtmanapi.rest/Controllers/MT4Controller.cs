using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Primitives;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Produces("text/plain", "application/json")]
    public partial class MT4Controller : ControllerBase
    {
        private readonly ITokenManager tokenManager;
        private StringValues AuthorizationValues => HttpContext.Request.Headers["authorization"];
        private MT4Manager manager => tokenManager.MT4ManagerInTokerRequest(AuthorizationValues);

        public MT4Controller(ITokenManager tokenManager)
        {
            this.tokenManager = tokenManager;
        }

        [HttpGet]
        public object ConnectionInfo()
        {
            if (!manager.HasCredentials)
                throw new InvalidOperationException("connection to the MT4 server is not yet installed. Please use /login function");

            return manager.CredentialsInfo();
        }
    }

    internal static class Helper
    {
        public static string PathBuild(params string[] paths)
        {
            var path = string.Empty;
            try
            {
                path = Path.Combine(paths);
                // try directory
                path = Path.GetFullPath(path);
            }
            catch (ArgumentException)
            {
                var currentPath = Directory.GetCurrentDirectory();
                paths = paths.Prepend(currentPath).ToArray();
                path = Path.Combine(paths);
                path = Path.GetFullPath(path);
            }

            return path;
        }
    }
}
