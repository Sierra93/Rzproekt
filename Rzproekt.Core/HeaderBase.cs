using Rzproekt.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rzproekt.Core {
    /// <summary>
    /// Базовый абстрактный класс описывает методы хидера.
    /// </summary>
    public abstract class HeaderBase {
        /// <summary>
        /// Метод получает данные хидера.
        /// </summary>
        /// <returns></returns>
        public abstract Task<IEnumerable> GetHeaderInfo();

        /// <summary>
        /// Метод изменяет хидер.
        /// </summary>
        /// <param name="headerDto"></param>
        /// <returns></returns>
        public abstract Task<HeaderDto> ChangeHeader(object header);
    }
}
