using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Rzproekt.Core;
using Rzproekt.Core.Consts;
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

        /// <summary>
        /// Метод передает сообщение параллельно записывая его в БД.
        /// </summary>
        /// <param name="messageDto"></param>
        /// <returns></returns>
        [HttpPost, Route("send")]
        public async Task<IActionResult> Create([FromBody] MessageDto messageDto) {
            MessageBase messageBase = new MessageService(_db);
            var aResult = await messageBase.Send(messageDto);

            //await _hubContext.Clients.All.SendAsync("Send", "1");

            return Ok(aResult);
        }

        /// <summary>
        /// Метод получает список всех диалогов.
        /// </summary>
        [HttpPost, Route("dialog-list")]
        public async Task<IActionResult> GetDialogs() {
            MessageBase messageBase = new MessageService(_db);

            return Ok(await messageBase.GetDialogs());
        }

        /// <summary>
        /// Метод получает сообщений диалога по его Id.
        /// </summary>
        [HttpPost, Route("dialog-messages")]
        public async Task<IActionResult> GetDialogMessages([FromBody] DialogMessage dialogMessage) {
            MessageBase messageBase = new MessageService(_db);

            return Ok(await messageBase.GetDialogMessages(dialogMessage.DialogId));
        }

        /// <summary>
        /// Метод удаляет диалог по его Id.
        /// </summary>
        [HttpGet, Route("remove-dialog/{id}")]
        public async Task<IActionResult> RemoveDialog([FromRoute] int id) {
            MessageBase messageBase = new MessageService(_db);
            await messageBase.RemoveDialog(id);

            return Ok("Диалог успешно удален");
        }

        /// <summary>
        /// Метод получает диалог с сообщениями по UserId.
        /// </summary>
        [HttpPost, Route("user-messages")]
        public async Task<IActionResult> GetUserMessages([FromBody] DialogMember dialogMember) {           
            MessageBase messageBase = new MessageService(_db);
            var aMessages = await messageBase.GetUserMessages(dialogMember.UserId);

            return Ok(aMessages);
        }
    }
}