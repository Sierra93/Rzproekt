using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rzproekt.Core;
using Rzproekt.Core.Data;
using Rzproekt.Models;
using Rzproekt.Services;

namespace Rzproekt.Controllers {
    /// <summary>
    /// Контроллер описывает работу с админкой.
    /// </summary>
    [ApiController, Route("api/back-office")]
    public class BackOfficeController : ControllerBase {
        ApplicationDbContext _db;

        public BackOfficeController(ApplicationDbContext db) => _db = db;
  
        /// <summary>
        /// Метод изменяет хидер.
        /// </summary>
        [HttpPost, Route("change-header")]
        //[RequestSizeLimit(100_000_000)]
        //[RequestFormLimits(MultipartBodyLengthLimit = 409715200)]
        //[RequestSizeLimit(409715200)]
        public async Task<IActionResult> ChangeHeader([FromForm] IFormCollection filesLogo, [FromForm] string jsonString) {
            HeaderBase backOfficeBase = new HeaderService(_db);
            await backOfficeBase.ChangeHeader(filesLogo, jsonString);

            return Ok();
        }

        /// <summary>
        /// Метод изменяет данные услуг.
        /// </summary>
        [HttpPost, Route("change-order")]
        public async Task<IActionResult> ChangeOrder([FromForm] IFormCollection filesService, [FromForm] string jsonString) {
            OrderBase orderBase = new OrderService(_db);
            await orderBase.ChangeOrder(filesService, jsonString);

            return Ok();
        }

        /// <summary>
        /// Метод изменяет информацию о нас.
        /// </summary>
        [HttpPost, Route("change-about")]
        public async Task<IActionResult> ChangeAbout() {
            return Ok();
        }

        /// <summary>
        /// Метод добавляет клиента.
        /// </summary>
        [HttpPost, Route("add-client")]
        public async Task<IActionResult> AddClient([FromForm] IFormCollection filesService, [FromForm] string jsonString) {
            return Ok();
        }

        /// <summary>
        /// Метод изменяет клиента.
        /// </summary>
        [HttpPost, Route("change-client")]
        public async Task<IActionResult> ChangeClientInfo([FromForm] IFormCollection filesClient, [FromForm] string jsonString) {
            ClientBase clientBase = new ClientService(_db);
            await clientBase.ChangeClientInfo(filesClient, jsonString);

            return Ok();
        }
    }
}