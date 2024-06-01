using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace DormSearchBe.Api.Controllers.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("ReceiveMessage");
        }
    }
}
