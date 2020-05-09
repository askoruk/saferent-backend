using Microsoft.AspNetCore.Mvc;
using SafeRent.BusinessLogic.Services.Interfaces;
using SafeRent.DataAccess.Models;

namespace SafeRent.Controllers
{
    [Route("[controller]")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]Notification notification)
        {
            _notificationService.Add(notification);
            return Ok();
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Notification> Get(int id)
        {
            return Ok(_notificationService.GetById(id));
        }

        [Route("getall/{id}")]
        [HttpGet]
        public IActionResult GetAllUserNotifications(string id)
        {
            return Ok(_notificationService.GetAllUserNotifications(id));
        }
    }
}