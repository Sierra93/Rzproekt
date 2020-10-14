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
    /// Контроллер описывает работу со статистикой.
    /// </summary>
    [ApiController, Route("api/statistic")]
    public class StatisticController : ControllerBase {
        ApplicationDbContext _db;

        public StatisticController(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Метод получает данные статистики.
        /// </summary>
        [HttpPost, Route("get-statistic")]
        public async Task<IActionResult> GetStatisticInfo() {
            StatisticBase statisticBase = new StatisticService(_db);
            
            return Ok(await statisticBase.GetStatisticInfo());
        }
    }
}
