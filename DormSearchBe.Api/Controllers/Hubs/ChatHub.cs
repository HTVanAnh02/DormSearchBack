using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace DormSearchBe.Api.Controllers.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            var objId = Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
