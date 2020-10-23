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

        /// <summary>
        /// Метод ищет сертификат по тексту.
        /// </summary>
        [HttpPost, Route("search")]
        public async Task<IActionResult> SearchCert([FromBody] CertDto certDto) {
            AboutBase aboutBase = new AboutService(_db);

            return Ok(await aboutBase.SearchCert(certDto.CertName));
        }

        /// <summary>
        /// Метод ищет награду по тексту.
        /// </summary>
        [HttpPost, Route("search-award")]
        public async Task<IActionResult> SearchAward([FromBody] AwardDto awardDto) {
            AboutBase aboutBase = new AboutService(_db);

            return Ok(await aboutBase.SearchAward(awardDto.AwardName));
        }       
    }
}