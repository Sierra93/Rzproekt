using Microsoft.EntityFrameworkCore;
using Rzproekt.Core;
using Rzproekt.Core.Data;
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

        public ContactService(ApplicationDbContext db) => db = _db;

        /// <summary>
        /// Метод получает контактную информацию.
        /// </summary>
        /// <returns></returns>
        public async override Task<IEnumerable> GetContactsInfo() {
            return await _db.Contacts.ToListAsync();
        }
    }
}
