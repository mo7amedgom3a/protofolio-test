using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NotificationService.Hubs;
using NotificationService.DTOs;
using NotificationService.Services; // Assuming you have a service layer
using NotificationService.Interfaces;
namespace NotificationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly INotificationService _notificationService; // Assuming you have a service interface

        public NotificationController(IHubContext<NotificationHub> hubContext, INotificationService notificationService)
        {
            _hubContext = hubContext;
            _notificationService = notificationService;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetNotificationsByUserIdAsync(string userId)
        {
            var notifications = await _notificationService.GetUserNotificationsAsync(userId);
            if (notifications == null)
            {
                return NotFound();
            }
            return Ok(notifications);
        }
    }
}
