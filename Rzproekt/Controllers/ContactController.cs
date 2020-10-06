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
    /// Контроллер описывает методы работы с контактами.
    /// </summary>
    [ApiController, Route("api/contact")]
    public class ContactController : ControllerBase {
        ApplicationDbContext _db;

        public ContactController(ApplicationDbContext db) => db = _db;

        /// <summary>
        /// Метод получает контактную информацию.
        /// </summary>
        [HttpPost, Route("get-contacts")]
        public async Task<IActionResult> GetContactInfo() {
            ContactBase contactBase = new ContactService(_db);

            return Ok(await contactBase.GetContactsInfo());
        }
    }
}
