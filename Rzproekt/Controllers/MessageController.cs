using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rzproekt.Core.Data;
using Rzproekt.Models;

namespace Rzproekt.Controllers {
    /// <summary>
    /// Контроллер описывает работу сообщений.
    /// </summary>
    [ApiController, Route("api/message")]
    public class MessageController : ControllerBase {
        ApplicationDbContext _db;

        public MessageController(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Метод отправляет сообщение.
        /// </summary>
        [HttpPost, Route("send")]
        public async Task<IActionResult> Send([FromBody] MessageDto messageDto) {
            return Ok();
        }
    }
}
