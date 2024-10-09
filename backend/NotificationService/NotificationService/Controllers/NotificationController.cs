using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NotificationService.Hubs;
using NotificationService.DTOs;

namespace NotificationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendNotification([FromBody] MessageDto messageDto)
        {
            if (ModelState.IsValid)
            {
                await _hubContext.Clients.User(messageDto.UserId).SendAsync("ReceiveNotification", messageDto.Message);
                return Ok(new { Status = "Notification sent successfully" });
            }
            return BadRequest("Invalid input.");
        }
    }
}
