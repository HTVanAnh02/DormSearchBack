using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using DormSearchBe.Api.Hubs;
using DormSearchBe.Application.IService;
using DormSearchBe.Application.Helpers;
using DormSearchBe.Infrastructure.Exceptions;
using DormSearchBe.Infrastructure.Settings;
using System.Security.Claims;
using DormSearchBe.Domain.Dto.Notification;

namespace DormSearchBe.Api.Controllers.RealTime
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly INotificationService _notificationService;

        public NotificationController(IHubContext<NotificationHub> hubContext,INotificationService notificationService)
        {
            _hubContext = hubContext;
            _notificationService = notificationService;
        }
        [HttpGet("GetNotificationByUser")]
        public async Task<IActionResult> GetNotificationByUser([FromQuery] CommonListQuery query)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", "Hello");
            var objId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (objId == null)
            {
                throw new ApiException(HttpStatusCode.FORBIDDEN, HttpStatusMessages.Forbidden);
            }
            return Ok(_notificationService.Items(query,Guid.Parse(objId)));
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendNotification(NotificationDto dto)
        {
            var objId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (objId == null)
            {
                throw new ApiException(HttpStatusCode.FORBIDDEN, HttpStatusMessages.Forbidden);
            }
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", "Hello");
            dto.UserId= Guid.Parse(objId);
            _notificationService.Create(dto);
            return Ok();
        }
    }
}
