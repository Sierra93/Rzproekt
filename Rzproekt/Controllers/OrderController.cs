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
    /// Контроллер описывает работу с услугами.
    /// </summary>
    [ApiController, Route("api/order")]
    public class OrderController : ControllerBase {
        ApplicationDbContext _db;

        public OrderController(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Метод получает все услуги.
        /// </summary>
        [HttpPost, Route("get-orders")]
        public async Task<IActionResult> GetHeaderInfo() {
            OrderBase headerBase = new OrderService(_db);

            return Ok(await headerBase.GetOrderInfo());
        }
    }
}
