using Microsoft.AspNetCore.Http;
using Rzproekt.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rzproekt.Core {
    /// <summary>
    /// Базовый абстрактный класс описывает методы услуг.
    /// </summary>
    public abstract class OrderBase {
        /// <summary>
        /// Метод получает все услуги.
        /// </summary>
        /// <returns></returns>
        public abstract Task<IEnumerable> GetPartialOrderInfo();

        /// <summary>
        /// Метод изменяет данные услуг.
        /// </summary>
        /// <returns></returns>
        public abstract Task ChangeOrder(IFormCollection filesService, string jsonString);

        /// <summary>
        /// Метод получает список услуг.
        /// </summary>
        /// <returns></returns>
        //public abstract Task<OrderDto> GetEditOrder(int orderId);

        /// <summary>
        /// Метод получает все услуги.
        /// </summary>
        /// <returns></returns>
        public abstract Task<IEnumerable> GetOrders();
    }
}
