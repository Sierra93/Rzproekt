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

            return Ok("Header успешно изменен");
        }
    }
}