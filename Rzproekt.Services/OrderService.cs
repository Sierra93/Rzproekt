using Microsoft.AspNetCore.Http;
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

        public override Task ChangeOrder(IFormCollection filesLogo, string jsonString) {
            throw new NotImplementedException();
        }

        public async override Task<IEnumerable> GetOrderInfo() {
            return await _db.Orders.Take(3).ToListAsync();
        }
    }
}
