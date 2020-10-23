using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Rzproekt.Core;
using Rzproekt.Core.Data;
using Rzproekt.Models;
using Rzproekt.Services;

namespace Rzproekt.Controllers {
    /// <summary>
    /// Контроллер описывает работу сообщений.
    /// </summary>
    [ApiController, Route("api/message")]
    public class MessageController : Controller {
        ApplicationDbContext _db;
        IHubContext<ChatHub> _hubContext;

        public MessageController(ApplicationDbContext db, IHubContext<ChatHub> hubContext) {
            _db = db;
            _hubContext = hubContext;
        }

        [HttpPost, Route("send")]
        public async Task<IActionResult> Create([FromBody] MessageDto messageDto) {
            MessageBase messageBase = new MessageService(_db);
            var aResult = await messageBase.Send(messageDto);

            //await _hubContext.Clients.All.SendAsync("Send", "1");

            return Ok(aResult);
        }
    }
}