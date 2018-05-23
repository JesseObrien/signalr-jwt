using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace sigtest.Hubs
{
    [Authorize]
    public class NotificationHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("SocketAction", Context.ConnectionId, "joined");
        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {
            await Clients.All.SendAsync("SocketAction", Context.ConnectionId, "left");
        }

        public async Task NotifyUser(string userId, string message)
        {
            await Clients.All.SendAsync("Notify", Context.User.Identity.Name, message);
        }
    }
}