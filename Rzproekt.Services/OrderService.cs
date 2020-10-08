using Microsoft.EntityFrameworkCore;
using Rzproekt.Core;
using Rzproekt.Core.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rzproekt.Services {
    public class OrderService : OrderBase {
        ApplicationDbContext _db;

        public OrderService(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Метод получает данные хидера.
        /// </summary>
        /// <returns></returns>
        public async override Task<IEnumerable> GetOrders() {
            return await _db.Orders.Take(3).ToListAsync();
        }
    }
}
