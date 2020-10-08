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
    /// Сервис реализует методы хидера.
    /// </summary>
    public class HeaderService : HeaderBase {
        ApplicationDbContext _db;

        public HeaderService(ApplicationDbContext db) => _db = db;
        
        /// <summary>
        /// Метод получает данные хидера.
        /// </summary>
        /// <returns></returns>
        public async override Task<IEnumerable> GetHeaderInfo() {
            return await _db.Headers.ToListAsync();
        }

        /// <summary>
        /// Метод изменяет хидер.
        /// </summary>
        /// <param name="headerDto"></param>
        /// <returns></returns>
        public async override Task<HeaderDto> ChangeHeader(object header) {
            try {
                return null;
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
