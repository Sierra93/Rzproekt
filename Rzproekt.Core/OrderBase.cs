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
        public abstract Task<IEnumerable> GetOrders();
    }
}
