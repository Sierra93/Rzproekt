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
    /// Контроллер описывает работу с хидером.
    /// </summary>
    [ApiController, Route("api/header")]
    public class HeaderController : ControllerBase {
        ApplicationDbContext _db;

        public HeaderController(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Метод получает информацию хидера.
        /// </summary>
        [HttpPost, Route("get-header")]
        public async Task<IActionResult> GetHeaderInfo() {
            HeaderBase headerBase = new HeaderService(_db);

            return Ok(await headerBase.GetHeaderInfo());
        }
    }
}
