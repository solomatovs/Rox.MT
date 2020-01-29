using System.Threading.Tasks;
using EmbedIO.WebSockets;

namespace rox.mt4.web
{
    using rox.mt4.rest;
    public class WebSocketsMT4Server : WebSocketModule
    {
        ITokenManager manager;
        public WebSocketsMT4Server(string urlPath, ITokenManager manager) : base(urlPath, true)
        {
            this.manager = manager;
        }

        protected override Task OnMessageReceivedAsync(IWebSocketContext context, byte[] rxBuffer, IWebSocketReceiveResult rxResult) => 
            SendToOthersAsync(context, Encoding.GetString(rxBuffer));

        protected override Task OnClientConnectedAsync(IWebSocketContext context) => Task.WhenAll(
            SendAsync(context, "Welcome to the chat room!"),
            SendToOthersAsync(context, "Someone joined the chat room.")
        );

        protected override Task OnClientDisconnectedAsync(IWebSocketContext context) => 
            SendToOthersAsync(context, "Someone left the chat room.");

        private Task SendToOthersAsync(IWebSocketContext context, string payload) => 
            BroadcastAsync(payload, c => c != context);
    }
}
