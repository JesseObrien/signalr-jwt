using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using sigtest.Hubs;

namespace sigtest.Controllers
{
    [Authorize]
    [Route("")]
    [Route("messages")]
    [ApiController]
    public class MessagesController: ControllerBase
    {
        private IHubContext<NotificationHub> _hubContext;
        public MessagesController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        // POST events
        [HttpPost("/messages/share")]
        public IActionResult Post(string message)
        {
            _hubContext.Clients.All.SendAsync("Notify", User.Identity.Name, message);

            return new ObjectResult(null);
        }
    }
}
