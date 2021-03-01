using Rzproekt.Core.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rzproekt.Core {
    /// <summary>
    /// Базовый абстрактный класс описывает методы работы со статистикой.
    /// </summary>
    public abstract class StatisticBase {
        /// <summary>
        /// Метод получает все данные статистики.
        /// </summary>
        /// <returns></returns>
        public abstract Task<IEnumerable> GetStatisticInfo();

        /// <summary>
        /// Метод изменяет статистику.
        /// </summary>
        /// <param name="stat"></param>
        /// <returns></returns>
        public abstract Task ChangeStatistic(object stat);
    }
}
