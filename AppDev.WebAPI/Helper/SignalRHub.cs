using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace AppDev.WebAPI.Helper
{
    public class SignalRHub : Hub
    {
        public async Task SendMessage()
        {
            // Broadcast a message to all clients
            await Clients.All.SendAsync("ReceiveMessage");
        }
    }
}