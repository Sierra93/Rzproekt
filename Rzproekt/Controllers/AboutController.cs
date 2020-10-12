using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rzproekt.Core;
using Rzproekt.Core.Data;
using Rzproekt.Services;

namespace Rzproekt.Controllers {
    /// <summary>
    /// Контроллер описывает работу с данными о нас.
    /// </summary>
    [ApiController, Route("api/about")]
    public class AboutController : ControllerBase {
        ApplicationDbContext _db;

        public AboutController(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Метод описывает данные о нас.
        /// </summary>
        [HttpPost, Route("get-about")]
        public async Task<IActionResult> GetAboutInfo() {
            AboutBase aboutBase = new AboutService(_db);

            return Ok(await aboutBase.GetAboutInfo());
        }
    }
}