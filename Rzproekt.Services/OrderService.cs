using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rzproekt.Core;
using Rzproekt.Core.Consts;
using Rzproekt.Core.Data;
using Rzproekt.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rzproekt.Services {
    public class OrderService : OrderBase {
        ApplicationDbContext _db;

        public OrderService(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Метод изменяет услугу по ее Id.
        /// </summary>
        /// <param name="filesService"></param>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public async override Task ChangeOrder(IFormCollection filesService, string jsonString) {
            try {
                CommonMethodsService common = new CommonMethodsService(_db);
                OrderDto newOrder = JsonSerializer.Deserialize<OrderDto>(jsonString);

                var isOrder = await GetEditOrder(newOrder.OrderId);

                var path = await common.UploadSingleFile(filesService);
                path = path.Replace("wwwroot", "");
                isOrder.Url = path;
                isOrder.MainTitle = newOrder.MainTitle;
                isOrder.Title = newOrder.Title;
                isOrder.Text = newOrder.Text;

                _db.Orders.Update(isOrder);

                await _db.SaveChangesAsync();
                Debugger.Break();
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Метод получает первые 3 услуги.
        /// </summary>
        /// <returns></returns>
        public async override Task<IEnumerable> GetPartialOrderInfo() {
            return await _db.Orders.Take(3).ToListAsync();
        }

        /// <summary>
        /// Метод получает список услуг.
        /// </summary>
        /// <returns></returns>
        public async override Task<IEnumerable> GetOrders() {
            return await _db.Orders.ToListAsync();
        }

        /// <summary>
        /// Метод выбирает услугу, которую нужно изменить.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        async Task<OrderDto> GetEditOrder(int id) {
            return await _db.Orders.Where(o => o.OrderId == id).FirstOrDefaultAsync();
        }
    }
}
