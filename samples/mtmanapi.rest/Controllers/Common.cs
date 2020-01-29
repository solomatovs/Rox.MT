using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller : ControllerBase
    {
        [HttpGet]
        public string ErrorDescription(int code)
        {
            return manager.ErrorDescription((ResultCode)code);
        }

        [HttpPost]
        public string WorkingDirectory(params string[] paths)
        {
            var path = Helper.PathBuild(paths);

            manager.WorkingDirectory(path);

            return path;
        }

        [HttpPost]
        public void PumpingSwitch(PumpingFlags flags)
        {
            throw new NotImplementedException($"{nameof(PumpingSwitch)} not implemented");
            //manager.PumpingSwitch();
        }

        [HttpPost]
        public void PumpingSwitchEx(PumpingFlags flags)
        {
            //throw new NotImplementedException($"{nameof(PumpingSwitch)} not implemented");

            manager.PumpingSwitchEx(flags, null);
        }

        [HttpGet]
        public async Task<int> BytesSent()
        {
            return await Task.Run(() => manager.BytesSent());
        }

        [HttpGet]
        public async Task<int> BytesReceived()
        {
            return await Task.Run(() => manager.BytesReceived());
        }

        [HttpPost]
        public async Task LogsOut(int code, string source, string msg)
        {
            await Task.Run(() => manager.LogsOut(code, source, msg));
        }

        [HttpPost]
        public async Task LogsMode(EnLogMode mode)
        {
            await Task.Run(() => manager.LogsMode(mode));
        }

        [HttpGet]
        public async Task LicenseCheck(string license_name)
        {
            await Task.Run(() => manager.LicenseCheck(license_name));
        }
    }
}