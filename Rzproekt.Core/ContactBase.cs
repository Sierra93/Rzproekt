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
        public abstract Task<IEnumerable> GetContactsCompany();

        /// <summary>
        /// Метод получает контактную информацию руководства.
        /// </summary>
        /// <returns></returns>
        public abstract Task<IEnumerable> GetContactsLeads();

        /// <summary>
        /// Метод добавляет контакты.
        /// </summary>
        /// <param name="filesCert"></param>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public abstract Task AddContactCompany(ContactCompanyDto contactCompanyDto);

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
        public abstract Task ChangeContact(IFormCollection filesCert, ContactCompanyDto contactDto);

        /// <summary>
        /// Метод изменяет контакты руководства.
        /// </summary>
        /// <param name="filesClient"></param>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public abstract Task ChangeContactLead(IFormCollection filesClient, string jsonString);

        /// <summary>
        /// Метод находит руководства.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public abstract Task<IEnumerable> SearchLead(string name);
    }
}