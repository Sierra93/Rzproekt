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
    /// Сервис реализует методы о нас.
    /// </summary>
    public class AboutService : AboutBase {
        ApplicationDbContext _db;

        public AboutService(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Метод получает все данные о нас.
        /// </summary>
        /// <returns></returns>
        public async override Task<IEnumerable> GetAboutInfo() {
            return await _db.Abouts.ToListAsync();
        }
    }
}
