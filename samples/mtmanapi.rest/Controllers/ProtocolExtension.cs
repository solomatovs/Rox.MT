using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    public partial class MT4Controller
    {
        [HttpPost]
        public async Task<string> ExternalCommand(string data_in)
        {
            return await Task.Run(() => manager.ExternalCommand(data_in));
        }
    }
}
