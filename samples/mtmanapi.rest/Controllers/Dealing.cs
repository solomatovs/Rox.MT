using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        [HttpPost]
        public void DealerSwitch()
        {
            throw new NotImplementedException();
            //MigrateCommunication(Manager, MT4DealerEventer);
            //if (MT4PumpingEventer.IsConnected())
            //    throw new InvalidOperationException($"before switching please log in. HttpGet - 'Communication'");

            //EventerInitializeFactory.Init(MT4DealerEventer);
            //await Task.Run(() => MT4DealerEventer.DealerSwitch(IntPtr.Zero, 0));
        }

        #region deling
        [HttpGet]
        public async Task<RequestInfo> DealerRequestGet(int codePage)
        {
            return await Task.Run(() => manager.DealerRequestGet(codePage));
        }

        [HttpPost]
        public async Task DealerSend([FromBody] RequestInfo info, bool requote, int mode)
        {
            await Task.Run(() => manager.DealerSend(info, requote, mode));
        }

        [HttpPost]
        public async Task DealerReject(int id)
        {
            await Task.Run(() => manager.DealerReject(id));
        }

        [HttpPost]
        public async Task DealerReset(int id)
        {
            await Task.Run(() => manager.DealerReset(id));
        }
        #endregion
    }
}
