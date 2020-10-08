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
        /// Метод загружает файл в папку.
        /// </summary>
        [HttpPost, Route("upload-image")]
        public async Task<IActionResult> UploadImage(IFormCollection form) {
            BackOfficeBase backOfficeBase = new BackOfficeService(_db);
            await backOfficeBase.UploadImage(form);

            return Ok("Файл успешно загружен");
        }       

        /// <summary>
        /// Метод изменяет хидер.
        /// </summary>
        [HttpPost, Route("change-header")]
        public async Task<IActionResult> ChangeHeader([FromBody] object header) {
            HeaderBase backOfficeBase = new HeaderService(_db);
            await backOfficeBase.ChangeHeader(header);

            return Ok("Header успешно изменен");
        }
    }
}