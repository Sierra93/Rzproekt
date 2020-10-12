using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Метод добавляет клиента.
        /// </summary>
        /// <param name="filesClient"></param>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public abstract Task AddClient(IFormCollection filesClient);

        /// <summary>
        /// Метод изменяет клиента.
        /// </summary>
        /// <param name="filesClient"></param>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public abstract Task ChangeClientInfo(IFormCollection filesClient, string jsonString);

        /// <summary>
        /// Метод удаляет клиента.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract Task DeleteClient(int id);

        /// <summary>
        /// Метод получает кол-во клиентов.
        /// </summary>
        /// <returns></returns>
        public abstract Task<int> GetClientCount();
    }
}
