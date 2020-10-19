using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rzproekt.Core;
using Rzproekt.Core.Data;
using Rzproekt.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rzproekt.Services {
    /// <summary>
    /// Сервис реализует методы работы с контактами.
    /// </summary>
    public class ContactService : ContactBase {
        ApplicationDbContext _db;

        public ContactService(ApplicationDbContext db) => _db = db;
       
        /// <summary>
        /// Метод получает контактную информацию.
        /// </summary>
        /// <returns></returns>
        public async override Task<IEnumerable> GetContactsInfo() {
            return await _db.Contacts.ToListAsync();
        }

        /// <summary>
        /// Метод добавляет контакты.
        /// </summary>
        /// <param name="filesCert"></param>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public override Task AddContact(IFormCollection filesCert, ContactDto contactDto) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод удаляет контакт.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Task RemoveContact(int id) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод изменяет контакты.
        /// </summary>
        /// <param name="filesCert"></param>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public override Task ChangeContact(IFormCollection filesCert, ContactDto contactDto) {
            throw new NotImplementedException();
        }
    }
}