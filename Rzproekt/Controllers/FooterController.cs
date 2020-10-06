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
    /// Контроллер описывает работу с футером.
    /// </summary>
    [ApiController, Route("api/footer")]
    public class FooterController : ControllerBase {
        ApplicationDbContext _db;

        public FooterController(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Метод получает данные футера.
        /// </summary>
        [HttpPost, Route("get-footer")]
        public async Task<IActionResult> GetFooterInfo() {
            FooterBase footerBase = new FooterService(_db);

            return Ok(await footerBase.GetFooterInfo());
        }
    }
}
