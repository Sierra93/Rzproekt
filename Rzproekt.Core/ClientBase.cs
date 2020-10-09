using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rzproekt.Core {
    /// <summary>
    /// Базовый абстрактный класс описывает методы работы с клиентами.
    /// </summary>
    public abstract class ClientBase {
        /// <summary>
        /// Метод получает список клиентов.
        /// </summary>
        /// <returns></returns>
        public abstract Task<IEnumerable> GetClientsInfo();

        public abstract Task AddClient();
    }
}
