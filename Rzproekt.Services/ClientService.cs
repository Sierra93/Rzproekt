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
    /// Сервис реализует методы работы с клиентами.
    /// </summary>
    public class ClientService : ClientBase {
        ApplicationDbContext _db;

        public ClientService(ApplicationDbContext db) => db = _db;

        /// <summary>
        /// Метод получает список клиентов.
        /// </summary>
        /// <returns></returns>
        public async override Task<IEnumerable> GetClientsInfo() {
            return await _db.Clients.ToListAsync();
        }
    }
}
