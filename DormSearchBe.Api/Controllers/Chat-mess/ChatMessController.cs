using DormSearchBe.Api.Controllers.Hubs;
using DormSearchBe.Application.IService;
using DormSearchBe.Domain.Dto.Messages;
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
        private readonly IMessagesService _messagesService;
        private static List<ChatMessageDto> _messageList = new List<ChatMessageDto>();

        public ChatMessController(IHubContext<ChatHub> hubContext,IMessagesService messagesService)
        {
            _hubContext = hubContext;
            _messagesService = messagesService;
        }
        [HttpGet("Chat_GroupById")]
        public IActionResult Chat_GroupById()
        {
            var objId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Ok(_messagesService.ChatGroupById(Guid.Parse(objId)));
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] MessageDto dto)
        {
            var objId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            dto.UserSend = Guid.Parse(objId);
            _messagesService.Send(dto);

            await _hubContext.Clients.All.SendAsync("ReceiveMessage");

            return Ok();
        }

        [HttpGet("messages/{id}")]
        public IActionResult GetMessages(Guid id)
        {
            var objId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(_messagesService.ItemsList(Guid.Parse(objId),id));
        }
    }
}
