using Microsoft.EntityFrameworkCore;
using Rzproekt.Core;
using Rzproekt.Core.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rzproekt.Services {
    public class StatisticService : StatisticBase {
        ApplicationDbContext _db;

        public StatisticService(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Метод получает все данные статистики.
        /// </summary>
        /// <returns></returns>
        public async override Task<IEnumerable> GetStatisticInfo() {
            return await _db.Statistics.ToListAsync();
        }
    }
}
