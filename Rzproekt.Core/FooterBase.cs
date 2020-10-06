using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rzproekt.Core {
    /// <summary>
    /// Базовый абстрактный класс описывает методы работы с футером.
    /// </summary>
    public abstract class FooterBase {
        /// <summary>
        /// Метод получает данные футера.
        /// </summary>
        public abstract Task<IEnumerable> GetFooterInfo();
    }
}
