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
    /// Сервис реализует методы работы с футером.
    /// </summary>
    public class FooterService : FooterBase {
        ApplicationDbContext _db;

        public FooterService(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Метод получает данные футера.
        /// </summary>
        public async override Task<IEnumerable> GetFooterInfo() {
            return await _db.Footers.ToListAsync();
        }
    }
}
