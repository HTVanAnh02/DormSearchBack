using DormSearchBe.Api.Controllers.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DormSearchBe.Api.Controllers.Chat_mess
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMessController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private static List<ChatMessageDto> _messageList = new List<ChatMessageDto>();

        public ChatMessController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] ChatMessageDto messageDto)
        {
            var objId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            messageDto.Id = Guid.Parse(objId);
            _messageList.Add(messageDto);

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", messageDto.User, messageDto.Message);

            return Ok();
        }

        [HttpGet("messages")]
        public IActionResult GetMessages()
        {
            return Ok(_messageList);
        }
    }
}
