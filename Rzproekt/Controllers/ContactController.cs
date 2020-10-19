using System;
using System.Collections.Generic;
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
    /// Контроллер описывает методы работы с контактами.
    /// </summary>
    [ApiController, Route("api/contact")]
    public class ContactController : ControllerBase {
        ApplicationDbContext _db;

        public ContactController(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Метод получает контактную информацию компании.
        /// </summary>
        [HttpPost, Route("contacts-company")]
        public async Task<IActionResult> GetContactInfo() {
            ContactBase contactBase = new ContactService(_db);

            return Ok(await contactBase.GetContactsCompany());
        }

        /// <summary>
        /// Метод получает контактную информацию руководства.
        /// </summary>
        [HttpPost, Route("contacts-lead")]
        public async Task<IActionResult> GetContactLead() {
            ContactBase contactBase = new ContactService(_db);

            return Ok(await contactBase.GetContactsLeads());
        }

        /// <summary>
        /// Метод ищет руководителя по тексту.
        /// </summary>
        [HttpPost, Route("search")]
        public async Task<IActionResult> SearchLead([FromBody] ContactLeadDto contactLeadDto) {
            ContactBase contactBase = new ContactService(_db);
            var oLead = await contactBase.SearchLead(contactLeadDto.LeadName);

            return Ok(oLead);
        }
    }
}
