using Microsoft.AspNetCore.Http;
using Rzproekt.Core.Data;
using Rzproekt.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rzproekt.Core {
    /// <summary>
    /// Базовый абстрактный класс описывает методы работы с контактами.
    /// </summary>
    public abstract class ContactBase {
        /// <summary>
        /// Метод получает контактную информацию.
        /// </summary>
        /// <returns></returns>
        public abstract Task<IEnumerable> GetContactsInfo();

        /// <summary>
        /// Метод добавляет контакты.
        /// </summary>
        /// <param name="filesCert"></param>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public abstract Task AddContact(IFormCollection filesCert, ContactDto contactDto);

        /// <summary>
        /// Метод удаляет контакт.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract Task RemoveContact(int id);

        /// <summary>
        /// Метод изменяет контакты.
        /// </summary>
        /// <param name="filesCert"></param>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public abstract Task ChangeContact(IFormCollection filesCert, ContactDto contactDto);
    }
}