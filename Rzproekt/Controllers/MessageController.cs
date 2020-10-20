using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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

        [HttpGet, Route("send")]
        public async Task<IActionResult> Create([FromQuery] string product) {
            await _hubContext.Clients.All.SendAsync("Send", product);
            //await _hubContext.Clients.All.SendAsync("Notify", $"Добавлено: {product} - {DateTime.Now.ToShortTimeString()}");
            //await _hubContext.Clients.Client(connectionId).SendAsync("Notify", $"Ваш товар добавлен!");

            return Ok();
        }
    }
}